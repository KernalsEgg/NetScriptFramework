using Eggstensions.Interoperability.Managed; // Memory



namespace ScrambledBugs.Patches
{
	namespace Offsets
	{
		static internal class EquipBestAmmo
		{
			/// <summary> SkyrimSE.exe + 0x1E3090 </summary>
			static public System.IntPtr CompareDamageContainer { get; }			= NetScriptFramework.Main.GameInfo.GetAddressOf(15846, 0x11A, 0, "73 06"); // 2

			/// <summary> SkyrimSE.exe + 0x1E3090 </summary>
			static public System.IntPtr CompareDamageInventoryChanges { get; }	= NetScriptFramework.Main.GameInfo.GetAddressOf(15846, 0x1E1, 0, "73 10"); // 2

			/// <summary> SkyrimSE.exe + 0x1E3090 </summary>
			static public System.IntPtr GetWorstAmmo { get; }					= NetScriptFramework.Main.GameInfo.GetAddressOf(15846);
		}
	}
	


	internal class EquipBestAmmo
	{
		public EquipBestAmmo()
		{
			Memory.SafeWriteByteArray(Offsets.EquipBestAmmo.CompareDamageContainer, new System.Byte[] { 0x76, 0x06 });
			Memory.SafeWriteByteArray(Offsets.EquipBestAmmo.CompareDamageInventoryChanges, new System.Byte[] { 0x76, 0x10 });

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = Offsets.EquipBestAmmo.GetWorstAmmo + 0x5F,
				Pattern = "F3 0F10 35 ?? ?? ?? ??",
				ReplaceLength = 8,
				IncludeLength = 0,
				Before = registers => registers.XMM6f = System.Single.MinValue
			});
		}
	}
}
