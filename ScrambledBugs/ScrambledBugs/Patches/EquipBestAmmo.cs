using Eggstensions;



namespace ScrambledBugs.Patches
{
	internal class EquipBestAmmo
	{
		public EquipBestAmmo()
		{
			Memory.SafeWriteArray<System.Byte>(Offsets.Patches.EquipBestAmmo.CompareDamageContainer, new System.Byte[2] { 0x76, 0x06 });
			Memory.SafeWriteArray<System.Byte>(Offsets.Patches.EquipBestAmmo.CompareDamageInventoryChanges, new System.Byte[2] { 0x76, 0x10 });

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address			= Offsets.Patches.EquipBestAmmo.GetWorstAmmo + 0x5F,
				Pattern			= "F3 0F10 35 ?? ?? ?? ??",
				ReplaceLength	= 8,
				IncludeLength	= 0,
				Before			= registers => registers.XMM6f = System.Single.MinValue
			});
		}
	}
}
