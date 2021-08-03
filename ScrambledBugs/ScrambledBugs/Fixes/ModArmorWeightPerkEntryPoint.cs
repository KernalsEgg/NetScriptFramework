using Eggstensions;



namespace ScrambledBugs.Fixes
{
	unsafe internal class ModArmorWeightPerkEntryPoint
	{
		static ModArmorWeightPerkEntryPoint()
		{
			ModArmorWeightPerkEntryPoint.ModArmorWeightContainer = (Context* context) =>
			{
				// inventoryEntryData	!= null
				// itemWeight			!= null
				// actor				!= null

				var inventoryEntryData = (InventoryEntryData*)context->Rbp.IntPtr.ToPointer();
				var item = inventoryEntryData->Item;

				if (item != null)
				{
					var itemWeight = Memory.Read<System.Single>(context->Rsp.IntPtr, 0xB0);

					if (itemWeight > 0.0F)
					{
						var actor = (Actor*)Memory.Read<System.IntPtr>(context->Rsp.IntPtr, 0xB8).ToPointer();

						if (actor != null)
						{
							if (item->TESForm.FormType == FormType.Armor)
							{
								var itemCount = context->Rdx.Int32 + context->Rax.Int32; // inventoryChangesItemCount + containerItemCount

								if (itemCount > 0)
								{
									if (InventoryEntryData.IsWorn(inventoryEntryData))
									{
										BGSEntryPointPerkEntry.HandleEntryPoints(EntryPoint.ModArmorWeight, actor, item, &itemWeight);

										context->Xmm7.Single += itemWeight;
										context->Rdx.Int32 -= 1; // inventoryChangesItemCount
									}
								}
							}
						}
					}
				}
			};

			SkyrimSE.Trampoline.CaptureContext
			(
				ScrambledBugs.Offsets.Fixes.ModArmorWeightPerkEntryPoint.ModArmorWeightContainer,
				ModArmorWeightPerkEntryPoint.ModArmorWeightContainer,
				Memory.ReadArray<System.Byte>
				(
					ScrambledBugs.Offsets.Fixes.ModArmorWeightPerkEntryPoint.ModArmorWeightContainer,
					Memory.Size<RelativeCall>.Unmanaged
				)
			);



			ModArmorWeightPerkEntryPoint.ModArmorWeightInventoryChanges = (Context* context) =>
			{
				// actor		!= null
				// armor		!= null
				// armorWeight	!= null

				var actor = (Actor*)context->Rdx.IntPtr.ToPointer();
				var armor = (TESObjectARMO*)context->R8.IntPtr.ToPointer();
				var armorWeight = Memory.Read<System.Single>(context->R9.IntPtr);

				context->Xmm1.Single = armorWeight; // armorWeight

				BGSEntryPointPerkEntry.HandleEntryPoints(EntryPoint.ModArmorWeight, actor, armor, &armorWeight);

				context->Xmm6.Single += armorWeight; // totalModifiedArmorWeight
			};

			SkyrimSE.Trampoline.CaptureContext
			(
				ScrambledBugs.Offsets.Fixes.ModArmorWeightPerkEntryPoint.ModArmorWeightInventoryChanges,
				ModArmorWeightPerkEntryPoint.ModArmorWeightInventoryChanges
			);
			Memory.SafeFill<System.Byte>
			(
				ScrambledBugs.Offsets.Fixes.ModArmorWeightPerkEntryPoint.ModArmorWeightInventoryChanges,
				Memory.Size<RelativeCall>.Unmanaged,
				5 + 9 + 4 - Memory.Size<RelativeCall>.Unmanaged,
				Assembly.Nop
			);



			var addPerkEntry = Memory.ReadVirtualFunction<Eggstensions.Delegates.Types.BGSPerkEntry.AddPerkEntry>(Eggstensions.Offsets.BGSEntryPointPerkEntry.VirtualFunctionTable, 0xA);

			ModArmorWeightPerkEntryPoint.AddPerkEntry = (BGSPerkEntry* perkEntry, Actor* perkOwner) =>
			{
				addPerkEntry(perkEntry, perkOwner);

				var inventoryChanges = TESObjectREFR.GetInventoryChanges(&perkOwner->TESObjectREFR);

				if (inventoryChanges != null)
				{
					InventoryChanges.ResetWeight(inventoryChanges);
				}
			};

			Memory.WriteVirtualFunction<Eggstensions.Delegates.Types.BGSPerkEntry.AddPerkEntry>(Eggstensions.Offsets.BGSEntryPointPerkEntry.VirtualFunctionTable, 0xA, ModArmorWeightPerkEntryPoint.AddPerkEntry);



			var removePerkEntry = Memory.ReadVirtualFunction<Eggstensions.Delegates.Types.BGSPerkEntry.RemovePerkEntry>(Eggstensions.Offsets.BGSEntryPointPerkEntry.VirtualFunctionTable, 0xB);

			ModArmorWeightPerkEntryPoint.RemovePerkEntry = (BGSPerkEntry* perkEntry, Actor* perkOwner) =>
			{
				removePerkEntry(perkEntry, perkOwner);

				var inventoryChanges = TESObjectREFR.GetInventoryChanges(&perkOwner->TESObjectREFR);

				if (inventoryChanges != null)
				{
					InventoryChanges.ResetWeight(inventoryChanges);
				}
			};

			Memory.WriteVirtualFunction<Eggstensions.Delegates.Types.BGSPerkEntry.RemovePerkEntry>(Eggstensions.Offsets.BGSEntryPointPerkEntry.VirtualFunctionTable, 0xB, ModArmorWeightPerkEntryPoint.RemovePerkEntry);
		}



		static public Eggstensions.Delegates.Types.BGSPerkEntry.AddPerkEntry AddPerkEntry { get; }
		static public Eggstensions.Delegates.Types.Context.CaptureContext ModArmorWeightContainer { get; }
		static public Eggstensions.Delegates.Types.Context.CaptureContext ModArmorWeightInventoryChanges { get; }
		static public Eggstensions.Delegates.Types.BGSPerkEntry.RemovePerkEntry RemovePerkEntry { get; }
	}
}
