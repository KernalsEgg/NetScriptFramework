using Eggstensions;



namespace ScrambledBugs.Patches
{
	unsafe static internal class EquipBestAmmo
	{
		static public Eggstensions.Delegates.Types.Context.CaptureContext CompareDamageContainer { get; set; }
		static public Eggstensions.Delegates.Types.Context.CaptureContext CompareDamageInventoryChanges { get; set; }
		static public Eggstensions.Delegates.Types.Context.CaptureContext InitializeDamage { get; set; }



		static public void Patch()
		{
			EquipBestAmmo.InitializeDamage = (Context* context) =>
			{
				context->Xmm6.Single = System.Single.MinValue;
			};

			Memory.SafeFill<System.Byte>
			(
				ScrambledBugs.Offsets.Patches.EquipBestAmmo.InitializeDamage,
				8,
				Assembly.Nop
			);

			ScrambledBugs.Plugin.Trampoline.CaptureContext
			(
				ScrambledBugs.Offsets.Patches.EquipBestAmmo.InitializeDamage,
				EquipBestAmmo.InitializeDamage
			);



			EquipBestAmmo.CompareDamageContainer = (Context* context) =>
			{
				var damage			= context->Xmm0.Single;
				var highestDamage	= context->Xmm6.Single;

				if (damage > highestDamage)
				{
					var ammo = (TESAmmo*)context->R8.IntPtr;

					if (TESAmmo.IsPlayable(ammo))
					{
						return;
					}
				}

				context->Rip.IntPtr += 0x6;
			};

			ScrambledBugs.Plugin.Trampoline.CaptureContext
			(
				ScrambledBugs.Offsets.Patches.EquipBestAmmo.CompareDamageContainer,
				EquipBestAmmo.CompareDamageContainer
			);



			EquipBestAmmo.CompareDamageInventoryChanges = (Context* context) =>
			{
				var damage			= context->Xmm0.Single;
				var highestDamage	= context->Xmm6.Single;

				if (damage > highestDamage)
				{
					var ammo = (TESAmmo*)context->Rbp.IntPtr;

					if (TESAmmo.IsPlayable(ammo))
					{
						return;
					}
				}

				context->Rip.IntPtr += 0x10;
			};

			ScrambledBugs.Plugin.Trampoline.CaptureContext
			(
				ScrambledBugs.Offsets.Patches.EquipBestAmmo.CompareDamageInventoryChanges,
				EquipBestAmmo.CompareDamageInventoryChanges
			);
		}
	}
}
