using Eggstensions;



namespace ScrambledBugs.Patches
{
	unsafe internal class EquipBestAmmo
	{
		static EquipBestAmmo()
		{
			Memory.SafeWriteArray<System.Byte>(ScrambledBugs.Offsets.Patches.EquipBestAmmo.CompareDamageContainer, new System.Byte[2] { 0x76, 0x06 });
			Memory.SafeWriteArray<System.Byte>(ScrambledBugs.Offsets.Patches.EquipBestAmmo.CompareDamageInventoryChanges, new System.Byte[2] { 0x76, 0x10 });

			EquipBestAmmo.InitializeDamage = (Context* context) =>
			{
				context->Xmm6.Single = System.Single.MinValue;
			};

			ScrambledBugs.Plugin.Trampoline.CaptureContext
			(
				ScrambledBugs.Offsets.Patches.EquipBestAmmo.InitializeDamage,
				EquipBestAmmo.InitializeDamage
			);
			Memory.SafeFill<System.Byte>
			(
				ScrambledBugs.Offsets.Patches.EquipBestAmmo.InitializeDamage,
				Memory.Size<RelativeCall>.Unmanaged,
				8 - Memory.Size<RelativeCall>.Unmanaged,
				Assembly.Nop
			);
		}



		static public Eggstensions.Delegates.Types.Context.CaptureContext InitializeDamage { get; }
	}
}
