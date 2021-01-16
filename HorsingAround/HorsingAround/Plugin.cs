﻿using Eggstensions.SkyrimSE;



namespace HorsingAround
{
    public class Plugin : NetScriptFramework.Plugin
    {
		override public System.Int32 RequiredLibraryVersion	{ get { return 10; } }

		override public System.Int32 Version				{ get { return 1; } }

		override public System.String Author				{ get { return "meh321 and KernalsEgg"; } }

		override public System.String Key					{ get { return "HorsingAround"; } }

		override public System.String Name					{ get { return "Horsing Around"; } }



		override protected System.Boolean Initialize(System.Boolean loadedAny)
		{
			// loadedAny

			Plugin._settings = new Settings();
			Plugin._settings.Load();

			if (Plugin._settings.DismountBySneaking)
			{
				Plugin.DismountBySneaking();
			}

			Plugin.AccurateFollowerCommands();
			Plugin.BlockFurnitureActivation();
			Plugin.SetActivateDistance();
			Plugin.SetCameraOffsets();
			Plugin.SetCameraRotation();
			Plugin.SetRaycastPosition();
			Plugin.ShowHUD();
			Plugin.SkipCrosshairPick();

			return true;
		}



		static Plugin()
		{
			Plugin._activateHandlerActivate =					NetScriptFramework.Main.GameInfo.GetAddressOf(39471); // SkyrimSE.exe + 0x6A9F90
			Plugin._activateHandlerButtonEvent =				NetScriptFramework.Main.GameInfo.GetAddressOf(41346); // SkyrimSE.exe + 0x708BF0
			Plugin._crosshairPickDataPick =						NetScriptFramework.Main.GameInfo.GetAddressOf(25591); // SkyrimSE.exe + 0x3AA4B0
			Plugin._furnitureActivate =							NetScriptFramework.Main.GameInfo.GetAddressOf(17034); // SkyrimSE.exe + 0x21A4B0
			Plugin._horseCameraStateLookInput =					NetScriptFramework.Main.GameInfo.GetAddressOf(49839); // SkyrimSE.exe + 0x849930
			Plugin._hudData =									NetScriptFramework.Main.GameInfo.GetAddressOf(39535); // SkyrimSE.exe + 0x6B0570
			Plugin._hudMenu =									NetScriptFramework.Main.GameInfo.GetAddressOf(50718); // SkyrimSE.exe + 0x87D580
			Plugin._playerCameraMount =							NetScriptFramework.Main.GameInfo.GetAddressOf(49888); // SkyrimSE.exe + 0x84BE40
			Plugin._playerCameraUpdateWeaponDrawn =				NetScriptFramework.Main.GameInfo.GetAddressOf(49908); // SkyrimSE.exe + 0x84D630
			Plugin._playerCharacterPickCrosshairReference =		NetScriptFramework.Main.GameInfo.GetAddressOf(39534); // SkyrimSE.exe + 0x6B01E0
			Plugin._playerCharacterPlaceWaitCommandMarker =		NetScriptFramework.Main.GameInfo.GetAddressOf(39550); // SkyrimSE.exe + 0x6B11C0
			Plugin._rightHandWeaponDrawHandlerPlayerCharacter =	NetScriptFramework.Main.GameInfo.GetAddressOf(41743); // SkyrimSE.exe + 0x720FB0
			Plugin._sneakHandlerButtonEvent =					NetScriptFramework.Main.GameInfo.GetAddressOf(41357); // SkyrimSE.exe + 0x7094C0
		}



		readonly static private System.IntPtr _activateHandlerActivate;
		readonly static private System.IntPtr _activateHandlerButtonEvent;
		readonly static private System.IntPtr _crosshairPickDataPick;
		readonly static private System.IntPtr _furnitureActivate;
		readonly static private System.IntPtr _horseCameraStateLookInput;
		readonly static private System.IntPtr _hudData;
		readonly static private System.IntPtr _hudMenu;
		readonly static private System.IntPtr _playerCameraMount;
		readonly static private System.IntPtr _playerCameraUpdateWeaponDrawn;
		readonly static private System.IntPtr _playerCharacterPickCrosshairReference;
		readonly static private System.IntPtr _playerCharacterPlaceWaitCommandMarker;
		readonly static private System.IntPtr _rightHandWeaponDrawHandlerPlayerCharacter;
		readonly static private System.IntPtr _sneakHandlerButtonEvent;

		static private Settings _settings;



		static private void AccurateFollowerCommands()
		{
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Allow the player to command followers standing behind them while in third-person, and more easily command followers standing among hostiles
			{
				Address = Plugin._activateHandlerButtonEvent + 0x7F,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 0,
				After = cpuRegisters =>
				{
					var playerCharacter = cpuRegisters.CX;
					var targetTeammate = PlayerCharacter.GetTargetTeammate(playerCharacter);

					if (targetTeammate != System.IntPtr.Zero)
					{
						NiRefObject.IncrementReferenceCount(TESObjectREFR.GetHandleRefObject(targetTeammate));
					}

					NetScriptFramework.Memory.WritePointer(cpuRegisters.DX, targetTeammate);
				}
			});
		}

		static private void BlockFurnitureActivation()
		{
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Block the player from activating furniture while mounted
			{
				Address = Plugin._furnitureActivate + 0x25,
				Pattern = "48 8B E9" + "4D 85 C0",
				ReplaceLength = 6,
				IncludeLength = 6,
				After = cpuRegisters =>
				{
					if (Actor.IsOnMount(PlayerCharacter.Instance))
					{
						cpuRegisters.FLAGS = new System.IntPtr(cpuRegisters.FLAGS.ToInt64() | 0x40);
					}
				}
			});
		}

		static private void DismountBySneaking()
		{
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Do not dismount from horseback when the activate button is released
			{
				Address = Plugin._activateHandlerActivate + 0x92,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 5,
				Before = cpuRegisters =>
				{
					var playerCharacter = PlayerCharacter.Instance;

					if (Actor.IsOnMount(playerCharacter) && !Actor.IsOnFlyingMount(playerCharacter))
					{
						cpuRegisters.AX = BSPointerHandle.Null;
						cpuRegisters.Skip();
					}
				}
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Dismount from horseback when the sneak button is released
			{
				Address = Plugin._sneakHandlerButtonEvent + 0xF,
				Pattern = "0F57 C0" + "0F2E 42 28",
				ReplaceLength = 7,
				IncludeLength = 7,
				Before = cpuRegisters =>
				{
					var buttonEvent = cpuRegisters.DX;

					if (ButtonEvent.IsReleased(buttonEvent))
					{
						var activateHandler = PlayerControls.GetActivateHandler(PlayerControls.Instance);

						if (ActivateHandler.IsActivateControlsEnabled(activateHandler))
						{
							var playerCharacter = PlayerCharacter.Instance;

							if (Actor.IsOnMount(playerCharacter) && !Actor.IsOnFlyingMount(playerCharacter))
							{
								using (var mount = Actor.GetMount(playerCharacter))
								{
									var mountReference = mount.Reference;

									if (mountReference != System.IntPtr.Zero)
									{
										TESObjectREFR.Activate(mountReference, playerCharacter);
									}
								}
							}
						}
					}
				}
			});
		}

		static private void SetActivateDistance()
		{
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Set the maximum activation distance while on horseback
			{
				Address = Plugin._crosshairPickDataPick + 0x180,
				Pattern = "F3 44 0F10 35 ?? ?? ?? ??",
				ReplaceLength = 9,
				IncludeLength = 0,
				Before = cpuRegisters =>
				{
					cpuRegisters.XMM14f = Plugin.GetActivateDistance();
				}
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Set the maximum activation distance while on horseback
			{
				Address = Plugin._crosshairPickDataPick + 0xC41,
				Pattern = "F3 0F10 05 ?? ?? ?? ??",
				ReplaceLength = 8,
				IncludeLength = 0,
				Before = cpuRegisters =>
				{
					cpuRegisters.XMM0f = Plugin.GetActivateDistance();
				}
			});
		}

		static private void SetCameraOffsets()
		{
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Set the camera offsets while on horseback
			{
				Address = Plugin._playerCameraUpdateWeaponDrawn + 0x2F,
				Pattern = "40 0FB6 D7" + "FF 50 ??",
				ReplaceLength = 4 + 3,
				IncludeLength = 4,
				After = cpuRegisters =>
				{
					var weaponDrawn = cpuRegisters.DX != System.IntPtr.Zero;
					var horseCameraState = cpuRegisters.CX;

					if (weaponDrawn)
					{
						ThirdPersonState.SetTargetOffsets(horseCameraState, (Plugin._settings.WeaponDrawnOffsetX, Plugin._settings.WeaponDrawnOffsetY, Plugin._settings.WeaponDrawnOffsetZ));
					}
					else
					{
						ThirdPersonState.SetTargetOffsets(horseCameraState, (Plugin._settings.WeaponSheathedOffsetX, Plugin._settings.WeaponSheathedOffsetY, Plugin._settings.WeaponSheathedOffsetZ));
					}
				}
			});
		}

		static private void SetCameraRotation()
		{
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Set the minimum and maximum camera rotation while on horseback
			{
				Address = Plugin._horseCameraStateLookInput + 0x8A,
				Pattern = "F3 0F11 A3 D8000000",
				ReplaceLength = 8,
				IncludeLength = 8,
				After = cpuReigsters =>
				{
					var horseCameraState = cpuReigsters.BX;
					var playerCamera = TESCameraState.GetCamera(horseCameraState);
					var weaponSheathed = PlayerCamera.GetWeaponSheathed(playerCamera);

					var degreesToRadians = (System.Single)(System.Math.PI / 180.0d);
					var freeRotationY = ThirdPersonState.GetFreeRotationY(horseCameraState);

					if (weaponSheathed)
					{
						var weaponSheathedRotationBackwards = Plugin._settings.WeaponSheathedRotationBackwards * degreesToRadians;

						if (freeRotationY > weaponSheathedRotationBackwards)
						{
							ThirdPersonState.SetFreeRotationY(horseCameraState, weaponSheathedRotationBackwards);
						}
						else
						{
							var weaponSheathedRotationForwards = -Plugin._settings.WeaponSheathedRotationForwards * degreesToRadians;

							if (freeRotationY < weaponSheathedRotationForwards)
							{
								ThirdPersonState.SetFreeRotationY(horseCameraState, weaponSheathedRotationForwards);
							}
						}
					}
					else
					{
						var weaponDrawnRotationBackwards = Plugin._settings.WeaponDrawnRotationBackwards * degreesToRadians;

						if (freeRotationY > weaponDrawnRotationBackwards)
						{
							ThirdPersonState.SetFreeRotationY(horseCameraState, weaponDrawnRotationBackwards);
						}
						else
						{
							var weaponDrawnRotationForwards = -Plugin._settings.WeaponDrawnRotationForwards * degreesToRadians;

							if (freeRotationY < weaponDrawnRotationForwards)
							{
								ThirdPersonState.SetFreeRotationY(horseCameraState, weaponDrawnRotationForwards);
							}
						}
					}

					cpuReigsters.IP += 0xDD - (0x8A + 0x8);
				}
			});
		}

		static private void SetRaycastPosition()
		{
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Correct the position of the follower wait command while on horseback (origin)
			{
				Address = Plugin._playerCharacterPlaceWaitCommandMarker + 0x19D,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 5,
				Before = Plugin.SetOrigin
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Correct the position of the follower wait command while on horseback (current offset)
			{
				Address = Plugin._playerCharacterPlaceWaitCommandMarker + 0x1BF,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 5,
				Before = Plugin.SetCurrentOffset
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Correct the activation position while on horseback (origin)
			{
				Address = Plugin._playerCharacterPickCrosshairReference + 0xFF,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 5,
				Before = Plugin.SetOrigin
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Correct the activation position while on horseback (current offset)
			{
				Address = Plugin._playerCharacterPickCrosshairReference + 0x131,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 5,
				Before = Plugin.SetCurrentOffset
			});
		}

		static private void ShowHUD()
		{
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Set HUD data while on horseback
			{
				Address = Plugin._hudData + 0xAA,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 0,
				Before = Plugin.IsOnFlyingMount
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Do not set the HorseMode HUD mode when mounting a horse
			{
				Address = Plugin._playerCameraMount + 0xED,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 5,
				Before = cpuRegisters =>
				{
					if (TESCamera.IsHorse(PlayerCamera.Instance))
					{
						cpuRegisters.Skip();
					}
				}
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Do not set the WarHorseMode HUD mode when drawing a weapon on horseback
			{
				Address = Plugin._rightHandWeaponDrawHandlerPlayerCharacter + 0x12E,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 0,
				Before = Plugin.IsOnFlyingMount
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Do not set the HorseMode or WarHorseMode HUD modes
			{
				Address = Plugin._hudMenu + 0x1209,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 0,
				Before = Plugin.IsOnFlyingMount
			});
		}

		static private void SkipCrosshairPick()
		{
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Skip picking both the player and the mount they may be riding
			{
				Address = Plugin._crosshairPickDataPick + 0x408,
				Pattern = "48 3B 05 ?? ?? ?? ??",
				ReplaceLength = 7,
				IncludeLength = 0,
				Before = cpuRegisters =>
				{
					var target = cpuRegisters.AX;
					var flags = new System.IntPtr(cpuRegisters.FLAGS.ToInt64() & ~0x40);

					if ((target != System.IntPtr.Zero) && TESObjectREFR.IsActor(target))
					{
						var playerCharacter = PlayerCharacter.Instance;

						if ((playerCharacter == target) || Actor.IsBeingRiddenBy(target, playerCharacter))
						{
							flags = new System.IntPtr(cpuRegisters.FLAGS.ToInt64() | 0x40);
						}
					}

					cpuRegisters.FLAGS = flags;
				}
			});
		}



		static public System.Single GetActivateDistance()
		{
			var playerCharacter = PlayerCharacter.Instance;

			return (Actor.IsOnMount(playerCharacter) && !Actor.IsOnFlyingMount(playerCharacter)) ? Plugin._settings.ActivateDistance : PlayerCharacter.ActivateDistance;
		}

		static private void SetOrigin(NetScriptFramework.CPURegisters cpuRegisters)
		{
			// cpuRegisters

			var playerCamera = cpuRegisters.CX;
			var currentState = TESCamera.GetCurrentState(playerCamera);

			if (TESCameraState.IsHorse(currentState))
			{
				var origin = PlayerCamera.GetOrigin(playerCamera, currentState);
				var originAddress = cpuRegisters.DX;

				NetScriptFramework.Memory.WriteFloat(originAddress, origin.x);
				NetScriptFramework.Memory.WriteFloat(originAddress + 0x4, origin.y);
				NetScriptFramework.Memory.WriteFloat(originAddress + 0x8, origin.z);

				cpuRegisters.Skip();
			}
		}

		static private void SetCurrentOffset(NetScriptFramework.CPURegisters cpuRegisters)
		{
			// cpuRegisters

			var playerCamera = cpuRegisters.CX;
			var currentState = TESCamera.GetCurrentState(playerCamera);

			if (TESCameraState.IsHorse(currentState))
			{
				var currentOffset = ThirdPersonState.GetCurrentOffset(currentState, false);
				var currentOffsetAddress = cpuRegisters.DX;

				NetScriptFramework.Memory.WriteFloat(currentOffsetAddress, currentOffset.x);
				NetScriptFramework.Memory.WriteFloat(currentOffsetAddress + 0x4, currentOffset.y);
				NetScriptFramework.Memory.WriteFloat(currentOffsetAddress + 0x8, currentOffset.z);

				cpuRegisters.Skip();
			}
		}

		static private void IsOnFlyingMount(NetScriptFramework.CPURegisters cpuRegisters)
		{
			// cpuRegisters

			var playerCharacter = cpuRegisters.CX;

			cpuRegisters.AX = new System.IntPtr(Actor.IsOnFlyingMount(playerCharacter) ? 1 : 0);
		}
	}
}