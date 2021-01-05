using Eggstensions.Bethesda;



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
			Plugin.WriteHooksUI();

			return true;
		}



		static Plugin()
		{
			Plugin._activateFurniture =			NetScriptFramework.Main.GameInfo.GetAddressOf(17034); // <SkyrimSE.exe> + 0x21A4B0
			Plugin._crosshairPickData =			NetScriptFramework.Main.GameInfo.GetAddressOf(25591); // <SkyrimSE.exe> + 0x3AA4B0
			Plugin._hudData =					NetScriptFramework.Main.GameInfo.GetAddressOf(39535); // <SkyrimSE.exe> + 0x6B0570
			Plugin._hudMenu =					NetScriptFramework.Main.GameInfo.GetAddressOf(50718); // <SkyrimSE.exe> + 0x87D580
			Plugin._mount =						NetScriptFramework.Main.GameInfo.GetAddressOf(49888); // <SkyrimSE.exe> + 0x84BE40
			Plugin._pickCrosshairReference =	NetScriptFramework.Main.GameInfo.GetAddressOf(39534); // <SkyrimSE.exe> + 0x6B01E0
			Plugin._rightHandWeaponDraw =		NetScriptFramework.Main.GameInfo.GetAddressOf(41743); // <SkyrimSE.exe> + 0x720FB0
			Plugin._updateWeaponOut =			NetScriptFramework.Main.GameInfo.GetAddressOf(49908); // <SkyrimSE.exe> + 0x84D630
		}



		readonly static private System.IntPtr _activateFurniture;
		readonly static private System.IntPtr _crosshairPickData;
		readonly static private System.IntPtr _hudData;
		readonly static private System.IntPtr _hudMenu;
		readonly static private System.IntPtr _mount;
		readonly static private System.IntPtr _pickCrosshairReference;
		readonly static private System.IntPtr _rightHandWeaponDraw;
		readonly static private System.IntPtr _updateWeaponOut;

		static private Settings _settings;



		static private void WriteHooks()
		{
			// Set camera offsets
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = Plugin._updateWeaponOut + 0x2F,
				Pattern = "40 0FB6 D7" + "FF 50 ??",
				ReplaceLength = 4 + 3,
				IncludeLength = 4,
				After = cpuRegisters =>
				{
					var weaponOut = cpuRegisters.DX != System.IntPtr.Zero;
					var horseCameraState = cpuRegisters.CX;

					if (weaponOut)
					{
						ThirdPersonState.SetTargetOffsets(horseCameraState, (Plugin._settings.WeaponDrawnOffsetX, Plugin._settings.WeaponDrawnOffsetY, Plugin._settings.WeaponDrawnOffsetZ));
					}
					else
					{
						ThirdPersonState.SetTargetOffsets(horseCameraState, (Plugin._settings.WeaponSheathedOffsetX, Plugin._settings.WeaponSheathedOffsetY, Plugin._settings.WeaponSheathedOffsetZ));
					}
				}
			});

			// Correct activation position
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = Plugin._pickCrosshairReference + 0x214,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 5,
				Before = cpuRegisters =>
				{
					// RCX = crosshairPickData
					// RDX = bhkWorld
					// R8 = position
					// R9 = rotation

					var playerCamera = PlayerCamera.Instance;
					var currentState = TESCamera.GetCurrentState(playerCamera);

					if (TESCameraState.IsHorse(currentState))
					{
						var position = cpuRegisters.R8;
						var origin = PlayerCamera.GetOrigin(playerCamera, currentState);
						var currentOffset = ThirdPersonState.GetCurrentOffset(currentState, false);

						NetScriptFramework.Memory.WriteFloat(position, origin.x + currentOffset.x);
						NetScriptFramework.Memory.WriteFloat(position + 0x4, origin.y + currentOffset.y);
						NetScriptFramework.Memory.WriteFloat(position + 0x8, origin.z + currentOffset.z);
					}
				}
			});

			// Set activation distance
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = Plugin._crosshairPickData + 0x180,
				Pattern = "F3 44 0F10 35 ?? ?? ?? ??",
				ReplaceLength = 9,
				IncludeLength = 0,
				Before = cpuRegisters =>
				{
					cpuRegisters.XMM14f = PlayerCamera.IsHorse(PlayerCamera.Instance) ? Plugin._settings.ActivateDistance : PlayerCharacter.ActivateDistance;
				}
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = Plugin._crosshairPickData + 0xC41,
				Pattern = "F3 0F10 05 ?? ?? ?? ??",
				ReplaceLength = 8,
				IncludeLength = 0,
				Before = cpuRegisters =>
				{
					cpuRegisters.XMM0f = PlayerCamera.IsHorse(PlayerCamera.Instance) ? Plugin._settings.ActivateDistance : PlayerCharacter.ActivateDistance;
				}
			});
			
			// Skip picking player and horse
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = Plugin._crosshairPickData + 0x408,
				Pattern = "48 3B 05 ?? ?? ?? ??",
				ReplaceLength = 7,
				IncludeLength = 0,
				Before = cpuRegisters =>
				{
					var playerCharacter = PlayerCharacter.Instance;
					var target = cpuRegisters.AX;

					if (playerCharacter == target)
					{
						cpuRegisters.FLAGS = new System.IntPtr(cpuRegisters.FLAGS.ToInt64() | 0x40);
					}
					else
					{
						var currentState = TESCamera.GetCurrentState(PlayerCamera.Instance);

						if (TESCameraState.IsHorse(currentState))
						{
							using (var horse = new TESObjectREFR.ReferenceFromHandle(HorseCameraState.GetHorse(currentState)))
							{
								cpuRegisters.FLAGS = (horse.Reference == target) ? new System.IntPtr(cpuRegisters.FLAGS.ToInt64() | 0x40) : new System.IntPtr(cpuRegisters.FLAGS.ToInt64() & ~0x40);
							}
						}
						else
						{
							cpuRegisters.FLAGS = new System.IntPtr(cpuRegisters.FLAGS.ToInt64() & ~0x40);
						}
					}
				}
			});

			// Block activating furniture
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = Plugin._activateFurniture + 0x25,
				Pattern = "48 8B E9" + "4D 85 C0",
				ReplaceLength = 6,
				IncludeLength = 6,
				After = cpuRegisters =>
				{
					var playerCharacter = PlayerCharacter.Instance;

					if (Actor.IsOnMount(playerCharacter) && !Actor.IsOnFlyingMount(playerCharacter))
					{
						cpuRegisters.FLAGS = new System.IntPtr(cpuRegisters.FLAGS.ToInt64() | 0x40);
					}
				}
			});
		}

		static private void WriteHooksUI()
		{
			// Set HUD data
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = Plugin._hudData + 0xAA,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 0,
				Before = Plugin.IsOnFlyingMount
			});

			// HorseMode (weapon sheathed)
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = Plugin._mount + 0xED,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 5,
				Before = cpuRegisters =>
				{
					if (PlayerCamera.IsHorse(PlayerCamera.Instance))
					{
						cpuRegisters.Skip();
					}
				}
			});

			// WarHorseMode (weapon drawn)
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = Plugin._rightHandWeaponDraw + 0x12E,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 0,
				Before = Plugin.IsOnFlyingMount
			});

			// HorseMode and WarHorseMode
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = Plugin._hudMenu + 0x1209,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 0,
				Before = Plugin.IsOnFlyingMount
			});
		}

		static private void IsOnFlyingMount(NetScriptFramework.CPURegisters cpuRegisters)
		{
			cpuRegisters.AX = new System.IntPtr(Actor.IsOnFlyingMount(PlayerCharacter.Instance) ? 1 : 0);
		}
	}
}
