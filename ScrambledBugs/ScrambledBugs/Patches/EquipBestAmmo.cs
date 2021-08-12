﻿using Eggstensions;



namespace ScrambledBugs.Patches
{
	unsafe internal class EquipBestAmmo
	{
		static EquipBestAmmo()
		{
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



			EquipBestAmmo.CompareDamageContainer = (Context* context) =>
			{
				var damage = context->Xmm0.Single;
				var highestDamage = context->Xmm6.Single;

				if (damage > highestDamage)
				{
					var ammo = (TESAmmo*)context->R8.IntPtr.ToPointer();

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
				var damage = context->Xmm0.Single;
				var highestDamage = context->Xmm6.Single;

				if (damage > highestDamage)
				{
					var ammo = (TESAmmo*)context->Rbp.IntPtr.ToPointer();

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



		static public Eggstensions.Delegates.Types.Context.CaptureContext CompareDamageContainer { get; }
		static public Eggstensions.Delegates.Types.Context.CaptureContext CompareDamageInventoryChanges { get; }
		static public Eggstensions.Delegates.Types.Context.CaptureContext InitializeDamage { get; }
	}
}
