using Eggstensions.SkyrimSE;



namespace HorsingAround
{
    public class Plugin : NetScriptFramework.Plugin
    {
		override public System.Int32 RequiredLibraryVersion	{ get; } = 10;

		override public System.Int32 Version				{ get; } = 1;

		override public System.String Author				{ get; } = "meh321 and KernalsEgg";

		override public System.String Key					{ get; } = "HorsingAround";

		override public System.String Name					{ get; } = "Horsing Around";



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



		static private Settings _settings;



		static private void AccurateFollowerCommands()
		{
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Allow the Player to command followers standing behind them while in third-person, and more easily command followers standing among hostiles
			{
				Address = VIDS.ActivateHandler.ProcessButton + 0x7F,
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
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Block the Player from activating furniture while mounted
			{
				Address = VIDS.TESFurniture.Activate + 0x25,
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
				Address = VIDS.PlayerCharacter.ProcessActivate + 0x92,
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
				Address = VIDS.SneakHandler.ProcessButton + 0xF,
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

		static private void SetActivateDistance()
		{
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Set the maximum activation distance while on horseback
			{
				Address = VIDS.CrosshairPickData.Pick + 0x180,
				Pattern = "F3 44 0F10 35 ?? ?? ?? ??",
				ReplaceLength = 9,
				IncludeLength = 0,
				Before = cpuRegisters =>
				{
					var playerCharacter = PlayerCharacter.Instance;

					cpuRegisters.XMM14f = (Actor.IsOnMount(playerCharacter) && !Actor.IsOnFlyingMount(playerCharacter)) ? Plugin._settings.ActivateDistance : SettingT.INISettingCollection.Interface.ActivatePickLength;
				}
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Set the maximum activation distance while on horseback (compatible with Better Telekinesis)
			{
				Address = VIDS.CrosshairPickData.Pick + 0xC49,
				Pattern = "44 0F2F D0" + "76 78",
				ReplaceLength = 6,
				IncludeLength = 0,
				Before = cpuRegisters =>
				{
					var isCommanding = cpuRegisters.AX != System.IntPtr.Zero;

					if (!isCommanding)
					{
						var playerCharacter = PlayerCharacter.Instance;

						if (Actor.IsOnMount(playerCharacter) && !Actor.IsOnFlyingMount(playerCharacter))
						{
							cpuRegisters.XMM0f = Plugin._settings.ActivateDistance;
						}
					}

					var targetDistance = cpuRegisters.XMM10f;
					var activateDistance = cpuRegisters.XMM0f;

					if (targetDistance <= activateDistance)
					{
						cpuRegisters.IP += 0x78;
					}
				}
			});
		}

		static private void SetCameraOffsets()
		{
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Set the camera offsets while on horseback
			{
				Address = VIDS.PlayerCamera.UpdateWeaponDrawn + 0x2F,
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
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Set the minimum and maximum rotation of the Player's horse about the x-axis while the Player has drawn their weapon
			{
				Address = VIDS.Actor.SetRotationX + 0x79,
				Pattern = "F3 0F10 35 ?? ?? ?? ??" + "F3 0F59 35 ?? ?? ?? ??",
				ReplaceLength = 8 + 8,
				IncludeLength = 0,
				Before = cpuRegisters =>
				{
					var rider = cpuRegisters.AX;
					var degreesToRadians = (System.Single)(System.Math.PI / 180.0d);

					if (rider == PlayerCharacter.Instance)
					{
						cpuRegisters.XMM6f = Plugin._settings.WeaponDrawnRotationForwards * degreesToRadians;
						cpuRegisters.XMM7f = -Plugin._settings.WeaponDrawnRotationBackwards * degreesToRadians;

						cpuRegisters.IP += 8 + 8;
					}
					else
					{
						cpuRegisters.XMM6f = SettingT.GameSettingCollection.MountedMaxLookingDown * degreesToRadians;
					}
				}
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Set the minimum and maximum rotation of the Player's horse about the x-axis while the Player has sheathed their weapon
			{
				Address = VIDS.Actor.SetRotationX + 0x89,
				Pattern = "F3 0F10 3D ?? ?? ?? ??" + "F3 0F59 3D ?? ?? ?? ??",
				ReplaceLength = 8 + 8,
				IncludeLength = 0,
				Before = cpuRegisters =>
				{
					var rider = cpuRegisters.AX;
					var degreesToRadians = (System.Single)(System.Math.PI / 180.0d);

					if (rider == PlayerCharacter.Instance)
					{
						cpuRegisters.XMM6f = Plugin._settings.WeaponSheathedRotationForwards * degreesToRadians;
						cpuRegisters.XMM7f = -Plugin._settings.WeaponSheathedRotationBackwards * degreesToRadians;
					}
					else
					{
						cpuRegisters.XMM7f = -SettingT.GameSettingCollection.HorseMaxUpwardPitch * degreesToRadians;
					}
				}
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Handle look input while on horseback
			{
				Address = VIDS.HorseCameraState.HandleLookInput + 0x2C,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 5,
				After = cpuRegisters =>
				{
					var isCameraTarget = cpuRegisters.AX != System.IntPtr.Zero;
					
					if (isCameraTarget)
					{
						var horseCameraState = cpuRegisters.BX;
						var lookInput = cpuRegisters.DI;
						var cameraTarget = NetScriptFramework.Memory.ReadPointer(cpuRegisters.SP + 0x40);

						var freeRotationX = ThirdPersonState.GetFreeRotationX(horseCameraState);
						var frameTimeRealTime = TimeManager.GetFrameTimeRealTime(TimeManager.Instance);
						var freeRotationSpeed = SettingT.INISettingCollection.Camera.FreeRotationSpeed;

						freeRotationX += frameTimeRealTime * freeRotationSpeed * NetScriptFramework.Memory.ReadFloat(lookInput);
						ThirdPersonState.SetFreeRotationX(horseCameraState, freeRotationX);

						var freeRotationY = -TESObjectREFR.GetRotationX(cameraTarget);
						var degreesToRadians = (System.Single)(System.Math.PI / 180.0d);

						if (freeRotationY > 90.0f * degreesToRadians)
						{
							freeRotationY = 90.0f * degreesToRadians;
						}
						else if (freeRotationY < -90.0f * degreesToRadians)
						{
							freeRotationY = -90.0f * degreesToRadians;
						}

						ThirdPersonState.SetFreeRotationY(horseCameraState, freeRotationY);

						if (freeRotationY < 0.0f)
						{
							var pitchZoomOutMaxDist = SettingT.INISettingCollection.Camera.PitchZoomOutMaxDist;

							ThirdPersonState.SetPitchZoomOffset(horseCameraState, (freeRotationY / (-90.0f * degreesToRadians)) * pitchZoomOutMaxDist);
						}

						cpuRegisters.AX = System.IntPtr.Zero;
					}
				}
			});
		}

		static private void SetRaycastPosition()
		{
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Correct the position of the follower wait command while on horseback (origin)
			{
				Address = VIDS.PlayerCharacter.PlaceWaitCommandMarker + 0x19D,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 5,
				Before = Plugin.SetOrigin
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Correct the position of the follower wait command while on horseback (current offset)
			{
				Address = VIDS.PlayerCharacter.PlaceWaitCommandMarker + 0x1BF,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 5,
				Before = Plugin.SetCurrentOffset
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Correct the activation position while on horseback (origin)
			{
				Address = VIDS.PlayerCharacter.PickCrosshairReference + 0xFF,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 5,
				Before = Plugin.SetOrigin
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Correct the activation position while on horseback (current offset)
			{
				Address = VIDS.PlayerCharacter.PickCrosshairReference + 0x131,
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
				Address = VIDS.PlayerCharacter.SetHUDData + 0xAA,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 0,
				Before = Plugin.IsOnFlyingMount
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Do not set the HorseMode HUD mode when mounting a horse
			{
				Address = VIDS.PlayerCamera.Mount + 0xED,
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
				Address = VIDS.RightHandWeaponDrawHandler.ExecuteHandler + 0x12E,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 0,
				Before = Plugin.IsOnFlyingMount
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Do not set the HorseMode or WarHorseMode HUD modes
			{
				Address = VIDS.HUDMenu.ProcessMessage + 0x1209,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 0,
				Before = Plugin.IsOnFlyingMount
			});
		}

		static private void SkipCrosshairPick()
		{
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters() // Skip picking both the Player and the mount they may be riding
			{
				Address = VIDS.CrosshairPickData.Pick + 0x408,
				Pattern = "48 3B 05 ?? ?? ?? ??",
				ReplaceLength = 7,
				IncludeLength = 0,
				Before = cpuRegisters =>
				{
					cpuRegisters.FLAGS = SkipCrosshairPick() ? new System.IntPtr(cpuRegisters.FLAGS.ToInt64() | 0x40) : new System.IntPtr(cpuRegisters.FLAGS.ToInt64() & ~0x40);



					System.Boolean SkipCrosshairPick()
					{
						var target = cpuRegisters.AX;

						if (target != System.IntPtr.Zero)
						{
							if (TESObjectREFR.IsCharacter(target))
							{
								var playerCharacter = PlayerCharacter.Instance;

								if (playerCharacter == target)
								{
									return true;
								}
								else if (Actor.IsBeingRiddenBy(target, playerCharacter))
								{
									return true;
								}
							}
						}

						return false;
					}
				}
			});
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
