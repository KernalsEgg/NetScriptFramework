using Eggstensions;
using Eggstensions.ExtensionMethods;



namespace ScrambledBugs.Patches
{
	unsafe static internal class EquipBestAmmo
	{
		static public void Patch()
		{
			var initializeDamage = (delegate* unmanaged[Cdecl]<Context*, void>)&InitializeDamage;

			Memory.SafeFill<System.Byte>(ScrambledBugs.Offsets.Patches.EquipBestAmmo.InitializeDamage, 8, Assembly.Nop);
			Trampoline.CaptureContext(ScrambledBugs.Offsets.Patches.EquipBestAmmo.InitializeDamage, initializeDamage);

			[System.Runtime.InteropServices.UnmanagedCallersOnly(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
			static void InitializeDamage(Context* context)
			{
				context->Xmm6.Single = System.Single.MinValue;
			}



			var compareDamageContainer = (delegate* unmanaged[Cdecl]<Context*, void>)&CompareDamageContainer;

			Trampoline.CaptureContext(ScrambledBugs.Offsets.Patches.EquipBestAmmo.CompareDamageContainer, compareDamageContainer);

			[System.Runtime.InteropServices.UnmanagedCallersOnly(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
			static void CompareDamageContainer(Context* context)
			{
				var damage = context->Xmm0.Single;
				var highestDamage = context->Xmm6.Single;

				if (damage > highestDamage)
				{
					var ammo = (TESAmmo*)context->R8.IntPtr;

					if (ammo->IsPlayable())
					{
						return;
					}
				}

				context->Rip.IntPtr += 0x6;
			}



			var compareDamageInventoryChanges = (delegate* unmanaged[Cdecl]<Context*, void>)&CompareDamageInventoryChanges;

			Trampoline.CaptureContext(ScrambledBugs.Offsets.Patches.EquipBestAmmo.CompareDamageInventoryChanges, compareDamageInventoryChanges);

			[System.Runtime.InteropServices.UnmanagedCallersOnly(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
			static void CompareDamageInventoryChanges(Context* context)
			{
				var damage = context->Xmm0.Single;
				var highestDamage = context->Xmm6.Single;

				if (damage > highestDamage)
				{
					var ammo = (TESAmmo*)context->Rbp.IntPtr;

					if (ammo->IsPlayable())
					{
						return;
					}
				}

				context->Rip.IntPtr += 0x10;
			}
		}
	}
}
