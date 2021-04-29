namespace ScrambledBugs.Patches
{
	internal class EquipBestAmmo
	{
		static protected class Offsets
		{
			static Offsets()
			{
				Offsets.CompareDamageContainer			= NetScriptFramework.Main.GameInfo.GetAddressOf(15846, 0x11A, 0, "73 06"); // 2
				Offsets.CompareDamageInventoryChanges	= NetScriptFramework.Main.GameInfo.GetAddressOf(15846, 0x1E1, 0, "73 10"); // 2
				Offsets.GetWorstAmmo					= NetScriptFramework.Main.GameInfo.GetAddressOf(15846);
			}



			/// <summary> SkyrimSE.exe + 0x1E3090 </summary>
			static internal System.IntPtr CompareDamageContainer { get; }

			/// <summary> SkyrimSE.exe + 0x1E3090 </summary>
			static internal System.IntPtr CompareDamageInventoryChanges { get; }

			/// <summary> SkyrimSE.exe + 0x1E3090 </summary>
			static internal System.IntPtr GetWorstAmmo { get; }
		}



		internal EquipBestAmmo()
		{
			NetScriptFramework.Memory.WriteBytes(EquipBestAmmo.Offsets.CompareDamageContainer, new System.Byte[] { 0x76, 0x06 }, true);
			NetScriptFramework.Memory.WriteBytes(EquipBestAmmo.Offsets.CompareDamageInventoryChanges, new System.Byte[] { 0x76, 0x10 }, true);

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = EquipBestAmmo.Offsets.GetWorstAmmo + 0x5F,
				Pattern = "F3 0F10 35 ?? ?? ?? ??",
				ReplaceLength = 8,
				IncludeLength = 0,
				Before = cpuRegisters => cpuRegisters.XMM6f = System.Single.MinValue,
			});
		}
	}
}
