using Eggstensions.SkyrimSE;



namespace MountedInteractions
{
    public class Plugin : NetScriptFramework.Plugin
    {
		override public System.Int32 RequiredLibraryVersion	{ get { return 10; } }

		override public System.Int32 Version				{ get { return 1; } }

		override public System.String Author				{ get { return "meh321 and KernalsEgg"; } }

		override public System.String Key					{ get { return "MountedInteractions"; } }

		override public System.String Name					{ get { return "Mounted Interactions"; } }



		override protected System.Boolean Initialize(System.Boolean loadedAny)
		{
			// loadedAny

			Plugin._settings = new Settings();
			Plugin._settings.Load();

			Plugin.WriteHooks();

			if (Plugin._settings.AccurateFollowerCommands)
			{
				Plugin.WriteHooksAccurateFollowerCommands();
			}

			if (Plugin._settings.DismountBySneaking)
			{
				Plugin.WriteHooksDismountBySneaking();
			}

			return true;
		}



		static Plugin()
		{
			Plugin._activateFurniture =			NetScriptFramework.Main.GameInfo.GetAddressOf(17034); // SkyrimSE.exe + 0x21A4B0
			Plugin._activateHandler =			NetScriptFramework.Main.GameInfo.GetAddressOf(41346); // SkyrimSE.exe + 0x708BF0
			Plugin._activateHandlerActivate =	NetScriptFramework.Main.GameInfo.GetAddressOf(39471); // SkyrimSE.exe + 0x6A9F90
			Plugin._handleLookInput =			NetScriptFramework.Main.GameInfo.GetAddressOf(49839); // SkyrimSE.exe + 0x849930
			Plugin._hudMenu =					NetScriptFramework.Main.GameInfo.GetAddressOf(50718); // SkyrimSE.exe + 0x87D580
			Plugin._mount =						NetScriptFramework.Main.GameInfo.GetAddressOf(49888); // SkyrimSE.exe + 0x84BE40
			Plugin._pick =						NetScriptFramework.Main.GameInfo.GetAddressOf(25591); // SkyrimSE.exe + 0x3AA4B0
			Plugin._pickCrosshairReference =	NetScriptFramework.Main.GameInfo.GetAddressOf(39534); // SkyrimSE.exe + 0x6B01E0
			Plugin._placeCommandWaitMarker =	NetScriptFramework.Main.GameInfo.GetAddressOf(39550); // SkyrimSE.exe + 0x6B11C0
			Plugin._rightHandWeaponDraw =		NetScriptFramework.Main.GameInfo.GetAddressOf(41743); // SkyrimSE.exe + 0x720FB0
			Plugin._setHUDData =				NetScriptFramework.Main.GameInfo.GetAddressOf(39535); // SkyrimSE.exe + 0x6B0570
			Plugin._sneakHandler =				NetScriptFramework.Main.GameInfo.GetAddressOf(41357); // SkyrimSE.exe + 0x7094C0
			Plugin._updateWeaponOut =			NetScriptFramework.Main.GameInfo.GetAddressOf(49908); // SkyrimSE.exe + 0x84D630
		}



		readonly static private System.IntPtr _activateFurniture;
		readonly static private System.IntPtr _activateHandler;
		readonly static private System.IntPtr _activateHandlerActivate;
		readonly static private System.IntPtr _handleLookInput;
		readonly static private System.IntPtr _hudMenu;
		readonly static private System.IntPtr _mount;
		readonly static private System.IntPtr _pick;
		readonly static private System.IntPtr _pickCrosshairReference;
		readonly static private System.IntPtr _placeCommandWaitMarker;
		readonly static private System.IntPtr _rightHandWeaponDraw;
		readonly static private System.IntPtr _setHUDData;
		readonly static private System.IntPtr _sneakHandler;
		readonly static private System.IntPtr _updateWeaponOut;

		static private Settings _settings;



		static private void WriteHooks()
		{
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Set HUD data on horse
			{
				Address = Plugin._setHUDData + 0xAA,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 0,
				Before = Plugin.IsOnFlyingMount
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Skip HUD mode (HorseMode)
			{
				Address = Plugin._mount + 0xED,
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

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Skip HUD mode (WarHorseMode)
			{
				Address = Plugin._rightHandWeaponDraw + 0x12E,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 0,
				Before = Plugin.IsOnFlyingMount
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Skip HUD modes (HorseMode and WarHorseMode)
			{
				Address = Plugin._hudMenu + 0x1209,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 0,
				Before = Plugin.IsOnFlyingMount
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Set horse camera offsets
			{
				Address = Plugin._updateWeaponOut + 0x2F,
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

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Set horse camera minimum and maximum pitch
			{
				Address = Plugin._handleLookInput + 0x8A,
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
						var weaponSheathedRotationUpward = Plugin._settings.WeaponSheathedRotationUpward * degreesToRadians;

						if (freeRotationY > weaponSheathedRotationUpward)
						{
							ThirdPersonState.SetFreeRotationY(horseCameraState, weaponSheathedRotationUpward);
						}
						else
						{
							var weaponSheathedRotationDownward = -Plugin._settings.WeaponSheathedRotationDownward * degreesToRadians;

							if (freeRotationY < weaponSheathedRotationDownward)
							{
								ThirdPersonState.SetFreeRotationY(horseCameraState, weaponSheathedRotationDownward);
							}
						}
					}
					else
					{
						var weaponDrawnRotationUpward = Plugin._settings.WeaponDrawnRotationUpward * degreesToRadians;

						if (freeRotationY > weaponDrawnRotationUpward)
						{
							ThirdPersonState.SetFreeRotationY(horseCameraState, weaponDrawnRotationUpward);
						}
						else
						{
							var weaponDrawnRotationDownward = -Plugin._settings.WeaponDrawnRotationDownward * degreesToRadians;

							if (freeRotationY < weaponDrawnRotationDownward)
							{
								ThirdPersonState.SetFreeRotationY(horseCameraState, weaponDrawnRotationDownward);
							}
						}
					}

					cpuReigsters.IP += 0x4B;
				}
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Correct player wait command position on horse (origin)
			{
				Address = Plugin._placeCommandWaitMarker + 0x19D,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 5,
				Before = Plugin.SetOrigin
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Correct player wait command position on horse (current offset)
			{
				Address = Plugin._placeCommandWaitMarker + 0x1BF,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 5,
				Before = Plugin.SetCurrentOffset
			});
			
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Correct player activation position on horse (origin)
			{
				Address = Plugin._pickCrosshairReference + 0xFF,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 5,
				Before = Plugin.SetOrigin
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Correct player activation position on horse (current offset)
			{
				Address = Plugin._pickCrosshairReference + 0x131,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 5,
				Before = Plugin.SetCurrentOffset
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Set player activation distance on horse
			{
				Address = Plugin._pick + 0x180,
				Pattern = "F3 44 0F10 35 ?? ?? ?? ??",
				ReplaceLength = 9,
				IncludeLength = 0,
				Before = cpuRegisters =>
				{
					cpuRegisters.XMM14f = Plugin.GetActivateDistance(cpuRegisters);
				}
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Set player activation distance on horse
			{
				Address = Plugin._pick + 0xC41,
				Pattern = "F3 0F10 05 ?? ?? ?? ??",
				ReplaceLength = 8,
				IncludeLength = 0,
				Before = cpuRegisters =>
				{
					cpuRegisters.XMM0f = Plugin.GetActivateDistance(cpuRegisters);
				}
			});
			
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Skip picking player and mount
			{
				Address = Plugin._pick + 0x408,
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
			
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Block player activating furniture on mount
			{
				Address = Plugin._activateFurniture + 0x25,
				Pattern = "48 8B E9" + "4D 85 C0",
				ReplaceLength = 6,
				IncludeLength = 6,
				After = cpuRegisters =>
				{
					var playerCharacter = PlayerCharacter.Instance;

					if (Actor.IsOnMount(playerCharacter))
					{
						cpuRegisters.FLAGS = new System.IntPtr(cpuRegisters.FLAGS.ToInt64() | 0x40);
					}
				}
			});
		}

		static private void WriteHooksAccurateFollowerCommands()
		{
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Correct actor being commanded by player
			{
				Address = Plugin._activateHandler + 0x7F,
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

		static private void WriteHooksDismountBySneaking()
		{
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Do not dismount on release activate button
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

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Dismount on release sneak button
			{
				Address = Plugin._sneakHandler + 0xF,
				Pattern = "0F57 C0" + "0F2E 42 28",
				ReplaceLength = 7,
				IncludeLength = 7,
				Before = cpuRegisters =>
				{
					var buttonEvent = cpuRegisters.DX;

					if (ButtonEvent.IsReleased(buttonEvent))
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
			});
		}

		static private void IsOnFlyingMount(NetScriptFramework.CPURegisters cpuRegisters)
		{
			// cpuRegisters

			var playerCharacter = cpuRegisters.CX;

			cpuRegisters.AX = new System.IntPtr(Actor.IsOnFlyingMount(playerCharacter) ? 1 : 0);
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

		static public System.Single GetActivateDistance(NetScriptFramework.CPURegisters cpuRegisters)
		{
			// cpuRegisters

			var playerCharacter = PlayerCharacter.Instance;

			return (Actor.IsOnMount(playerCharacter) && !Actor.IsOnFlyingMount(playerCharacter)) ? Plugin._settings.ActivateDistance : PlayerCharacter.ActivateDistance;
		}
	}
}
