using Eggstensions;
using Eggstensions.ExtensionMethods;



namespace ScrambledBugs.Fixes
{
	unsafe static internal class ModArmorWeightPerkEntryPoint
	{
		static public System.Boolean Fix()
		{
			if
			(
				!ScrambledBugs.Patterns.Fixes.ModArmorWeightPerkEntryPoint.ModArmorWeightContainer
				||
				!ScrambledBugs.Patterns.Fixes.ModArmorWeightPerkEntryPoint.ModArmorWeightInventoryChanges
			)
			{
				return false;
			}

			ModArmorWeightPerkEntryPoint.ModArmorWeight();

			ModArmorWeightPerkEntryPoint.AddPerkEntry();
			ModArmorWeightPerkEntryPoint.RemovePerkEntry();

			return true;
		}



		static private delegate* unmanaged[Cdecl]<BGSPerkEntry*, Actor*, void> addPerkEntry;
		static private delegate* unmanaged[Cdecl]<BGSPerkEntry*, Actor*, void> removePerkEntry;



		static public void ModArmorWeight()
		{
			var modArmorWeightContainer = (delegate* unmanaged[Cdecl]<Context*, void>)&ModArmorWeightContainer;

			Trampoline.CaptureContext
			(
				ScrambledBugs.Offsets.Fixes.ModArmorWeightPerkEntryPoint.ModArmorWeightContainer,
				modArmorWeightContainer,
				Memory.ReadArray<System.Byte>
				(
					ScrambledBugs.Offsets.Fixes.ModArmorWeightPerkEntryPoint.ModArmorWeightContainer,
					System.Runtime.CompilerServices.Unsafe.SizeOf<RelativeCall>()
				)
			);

			[System.Runtime.InteropServices.UnmanagedCallersOnly(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
			static void ModArmorWeightContainer(Context* context)
			{
				// inventoryEntryData	!= null
				// itemWeight			!= null
				// actor				!= null

				var inventoryEntryData	= (InventoryEntryData*)context->Rbp.IntPtr;
				var item				= inventoryEntryData->Item;

				if (item != null)
				{
					var itemWeight = *(System.Single*)(context->Rsp.IntPtr + 0xB0);

					if (itemWeight > 0.0F)
					{
						var actor = *(Actor**)(context->Rsp.IntPtr + 0xB8);

						if (actor != null)
						{
							if (item->FormType() == FormType.Armor)
							{
								var itemCount = context->Rdx.Int32 + context->Rax.Int32; // inventoryChangesItemCount + containerItemCount

								if (itemCount > 0)
								{
									if (inventoryEntryData->IsWorn())
									{
										BGSEntryPointPerkEntry.HandleEntryPoints(EntryPoint.ModArmorWeight, actor, item, &itemWeight);

										context->Xmm7.Single	+= itemWeight;
										context->Rdx.Int32		-= 1; // inventoryChangesItemCount
									}
								}
							}
						}
					}
				}
			}



			var modArmorWeightInventoryChanges = (delegate* unmanaged[Cdecl]<Context*, void>)&ModArmorWeightInventoryChanges;

			Memory.SafeFill<System.Byte>(ScrambledBugs.Offsets.Fixes.ModArmorWeightPerkEntryPoint.ModArmorWeightInventoryChanges, 5 + 9 + 4, Assembly.Nop);
			Trampoline.CaptureContext(ScrambledBugs.Offsets.Fixes.ModArmorWeightPerkEntryPoint.ModArmorWeightInventoryChanges, modArmorWeightInventoryChanges);

			[System.Runtime.InteropServices.UnmanagedCallersOnly(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
			static void ModArmorWeightInventoryChanges(Context* context)
			{
				// actor		!= null
				// armor		!= null
				// armorWeight	!= null

				var actor		= (Actor*)context->Rdx.IntPtr;
				var armor		= (TESObjectARMO*)context->R8.IntPtr;
				var armorWeight	= *(System.Single*)context->R9.IntPtr;

				context->Xmm1.Single = armorWeight; // armorWeight

				BGSEntryPointPerkEntry.HandleEntryPoints(EntryPoint.ModArmorWeight, actor, armor, &armorWeight);

				context->Xmm6.Single += armorWeight; // totalModifiedArmorWeight
			}
		}

		static public void AddPerkEntry()
		{
			ModArmorWeightPerkEntryPoint.addPerkEntry = (delegate* unmanaged[Cdecl]<BGSPerkEntry*, Actor*, void>)Memory.ReadVirtualFunction(Eggstensions.Offsets.BGSEntryPointPerkEntry.VirtualFunctionTable, 0xA);

			var addPerkEntry = (delegate* unmanaged[Cdecl]<BGSPerkEntry*, Actor*, void>)&AddPerkEntry;

			Memory.WriteVirtualFunction(Eggstensions.Offsets.BGSEntryPointPerkEntry.VirtualFunctionTable, 0xA, addPerkEntry);

			[System.Runtime.InteropServices.UnmanagedCallersOnly(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
			static void AddPerkEntry(BGSPerkEntry* perkEntry, Actor* perkOwner)
			{
				AddPerkEntry(perkEntry, perkOwner);

				var inventoryChanges = perkOwner->GetInventoryChanges();

				if (inventoryChanges != null)
				{
					inventoryChanges->ResetWeight();
				}



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				void AddPerkEntry(BGSPerkEntry* perkEntry, Actor* perkOwner)
				{
					ModArmorWeightPerkEntryPoint.addPerkEntry(perkEntry, perkOwner);
				}
			}
		}

		static public void RemovePerkEntry()
		{
			ModArmorWeightPerkEntryPoint.removePerkEntry = (delegate* unmanaged[Cdecl]<BGSPerkEntry*, Actor*, void>)Memory.ReadVirtualFunction(Eggstensions.Offsets.BGSEntryPointPerkEntry.VirtualFunctionTable, 0xB);

			var removePerkEntry = (delegate* unmanaged[Cdecl]<BGSPerkEntry*, Actor*, void>)&RemovePerkEntry;

			Memory.WriteVirtualFunction(Eggstensions.Offsets.BGSEntryPointPerkEntry.VirtualFunctionTable, 0xB, removePerkEntry);

			[System.Runtime.InteropServices.UnmanagedCallersOnly(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
			static void RemovePerkEntry(BGSPerkEntry* perkEntry, Actor* perkOwner)
			{
				RemovePerkEntry(perkEntry, perkOwner);

				var inventoryChanges = perkOwner->GetInventoryChanges();

				if (inventoryChanges != null)
				{
					inventoryChanges->ResetWeight();
				}



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				void RemovePerkEntry(BGSPerkEntry* perkEntry, Actor* perkOwner)
				{
					ModArmorWeightPerkEntryPoint.removePerkEntry(perkEntry, perkOwner);
				}
			}
		}
	}
}
