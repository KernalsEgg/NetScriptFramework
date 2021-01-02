using static NetScriptFramework._IntPtrExtensions;

using Eggstensions.Bethesda;



namespace MountedInteractions
{
    public class Plugin : NetScriptFramework.Plugin
    {
		override public System.Int32 RequiredLibraryVersion { get { return 10; } }

		override public System.Int32 Version { get { return 1; } }

		override public System.String Author { get { return "meh321 and KernalsEgg"; } }

		override public System.String Key { get { return "MountedInteractions"; } }

		override public System.String Name { get { return "Mounted Interactions"; } }



		override protected System.Boolean Initialize(System.Boolean loadedAny)
		{
			// loadedAny

			Plugin._settings = new Settings();
			Plugin._settings.Load();

			Plugin.WriteNOPs();
			Plugin.WriteHooks();

			return true;
		}



		static Plugin()
		{
			_crosshairPickData =		NetScriptFramework.Main.GameInfo.GetAddressOf(25591); // SkyrimSE.exe + 0x3AA4B0
			_hudData =					NetScriptFramework.Main.GameInfo.GetAddressOf(39535); // SkyrimSE.exe + 0x6B0570
			_hudMenu =					NetScriptFramework.Main.GameInfo.GetAddressOf(50718); // SkyrimSE.exe + 0x87D580
			_pickCrosshairReference =	NetScriptFramework.Main.GameInfo.GetAddressOf(39534); // SkyrimSE.exe + 0x6B01E0
			_rightHandWeaponDraw =		NetScriptFramework.Main.GameInfo.GetAddressOf(41743); // SkyrimSE.exe + 0x720FB0
			_rightHandWeaponSheathe =	NetScriptFramework.Main.GameInfo.GetAddressOf(36190); // SkyrimSE.exe + 0x5CCE70
			_stopMountHorse =			NetScriptFramework.Main.GameInfo.GetAddressOf(49889); // SkyrimSE.exe + 0x84BF50
			_stopMountWarHorse =		NetScriptFramework.Main.GameInfo.GetAddressOf(39639); // SkyrimSE.exe + 0x6B62B0
			_startMount =				NetScriptFramework.Main.GameInfo.GetAddressOf(49888); // SkyrimSE.exe + 0x84BE40
			_updateWeaponOut =			NetScriptFramework.Main.GameInfo.GetAddressOf(49908); // SkyrimSE.exe + 0x84D630
		}



		readonly static private System.IntPtr _crosshairPickData;
		readonly static private System.IntPtr _hudData;
		readonly static private System.IntPtr _hudMenu;
		readonly static private System.IntPtr _pickCrosshairReference;
		readonly static private System.IntPtr _rightHandWeaponDraw;
		readonly static private System.IntPtr _rightHandWeaponSheathe;
		readonly static private System.IntPtr _stopMountHorse;
		readonly static private System.IntPtr _stopMountWarHorse;
		readonly static private System.IntPtr _startMount;
		readonly static private System.IntPtr _updateWeaponOut;

		static private Settings _settings;



		// HorseMode: Weapon sheathed
		// WarHorseMode: Weapon drawn
		static void WriteNOPs()
		{
			// HorseMode
			NetScriptFramework.Memory.VerifyBytes(_hudMenu + 0x121B, "E8");
			NetScriptFramework.Memory.WriteNop(_hudMenu + 0x121B, 5);

			NetScriptFramework.Memory.VerifyBytes(_stopMountHorse + 0x259, "E8");
			NetScriptFramework.Memory.WriteNop(_stopMountHorse + 0x259, 5);

			NetScriptFramework.Memory.VerifyBytes(_startMount + 0xED, "E8");
			NetScriptFramework.Memory.WriteNop(_startMount + 0xED, 5);

			// WarHorseMode
			NetScriptFramework.Memory.VerifyBytes(_hudMenu + 0x1243, "E8");
			NetScriptFramework.Memory.WriteNop(_hudMenu + 0x1243, 5);

			NetScriptFramework.Memory.VerifyBytes(_rightHandWeaponDraw + 0x13E, "E8");
			NetScriptFramework.Memory.WriteNop(_rightHandWeaponDraw + 0x13E, 5);

			NetScriptFramework.Memory.VerifyBytes(_rightHandWeaponSheathe + 0x13D, "E8");
			NetScriptFramework.Memory.WriteNop(_rightHandWeaponSheathe + 0x13D, 5);

			NetScriptFramework.Memory.VerifyBytes(_stopMountWarHorse + 0x28, "E8");
			NetScriptFramework.Memory.WriteNop(_stopMountWarHorse + 0x28, 5);
		}

		static void WriteHooks()
		{
			// Set camera offsets
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = _updateWeaponOut + 0x2C,
				Pattern = "48 8B 01" + "40 0FB6 D7" + "FF 50 ??",
				ReplaceLength = 3 + 4 + 3,
				IncludeLength = 3 + 4,
				After = cpuRegisters =>
				{
					var horseCameraState = cpuRegisters.CX;
					var weaponOut = cpuRegisters.DX.ToBool();

					if (weaponOut)
					{
						ThirdPersonState.SetTargetOffsets(horseCameraState, (_settings.WeaponDrawnOffsetX, _settings.WeaponDrawnOffsetY, _settings.WeaponDrawnOffsetZ));
					}
					else
					{
						ThirdPersonState.SetTargetOffsets(horseCameraState, (_settings.WeaponSheathedOffsetX, _settings.WeaponSheathedOffsetY, _settings.WeaponSheathedOffsetZ));
					}
				}
			});
			
			// Set HUD data
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = _hudData + 0xAA,
				Pattern = "E8",
				ReplaceLength = 5,
				IncludeLength = 0,
				Before = cpuRegisters =>
				{
					// RCX = playerCharacter
					
					var playerCharacter = cpuRegisters.CX;

					// RAX is flipped
					cpuRegisters.AX = new System.IntPtr(Actor.IsOnFlyingMount(playerCharacter) ? 1 : 0);
				}
			});
			
			// Set activation distance 1
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = _crosshairPickData + 0x180,
				Pattern = "F3 44 0F10 35 ?? ?? ?? ??",
				ReplaceLength = 9,
				IncludeLength = 0,
				Before = cpuRegisters =>
				{
					var playerCharacter = cpuRegisters.AX;

					cpuRegisters.XMM14f = (Actor.IsOnMount(playerCharacter) && !Actor.IsOnFlyingMount(playerCharacter)) ? _settings.ActivateDistance : PlayerCharacter.ActivateDistance;
				}
			});

			// Set activation distance 2
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = _crosshairPickData + 0xC41,
				Pattern = "F3 0F10 05 ?? ?? ?? ??",
				ReplaceLength = 8,
				IncludeLength = 0,
				Before = cpuRegisters =>
				{
					var playerCharacter = PlayerCharacter.Instance;

					cpuRegisters.XMM0f = (Actor.IsOnMount(playerCharacter) && !Actor.IsOnFlyingMount(playerCharacter)) ? _settings.ActivateDistance : PlayerCharacter.ActivateDistance;
				}
			});
			
			// Set activation origin
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = _pickCrosshairReference + 0x214,
				Pattern = "E8",
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

					if (TESCameraState.GetState(currentState) == TESCameraStates.HorseCameraState)
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
		}
	}
}
