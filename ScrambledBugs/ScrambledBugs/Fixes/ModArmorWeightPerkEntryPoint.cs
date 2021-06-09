using Eggstensions;

using static Eggstensions.ExtensionMethods.IntPtr;



namespace ScrambledBugs.Fixes
{
	internal class ModArmorWeightPerkEntryPoint
	{
		public ModArmorWeightPerkEntryPoint()
		{
			// Modify the weight of worn armor in TESContainer
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address			= Offsets.Fixes.ModArmorWeightPerkEntryPoint.GetTotalItemWeight + 0x159,
				Pattern			= "8B 55 10" + "8B 00",
				ReplaceLength	= 3 + 2, // 5
				IncludeLength	= 3 + 2, // 5
				After			= registers =>
				{
					// inventoryEntryData != System.IntPtr.Zero

					InventoryEntryData inventoryEntryData = registers.BP;
					var item = inventoryEntryData.Item;

					if (item)
					{
						var itemWeight = Memory.Read<System.Single>(registers.SP, 0xB0);

						if (itemWeight > 0.0F)
						{
							Actor actor = Memory.Read<System.IntPtr>(registers.SP, 0xB8);

							if (actor)
							{
								if (item.FormType == FormType.Armor)
								{
									var itemCount = registers.DX.ToInt32Safe() + registers.AX.ToInt32Safe(); // inventoryChangesItemCount + containerItemCount

									if (itemCount > 0)
									{
										if (inventoryEntryData.IsWorn())
										{
											BGSEntryPointPerkEntry.HandleEntryPoints(EntryPoint.ModArmorWeight, actor, item, ref itemWeight);

											registers.XMM7f	+= itemWeight;
											registers.DX	-= 1; // inventoryChangesItemCount
										}
									}
								}
							}
						}
					}
				}
			});

			// Modify the weight of worn armor in InventoryChanges
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address			= Offsets.Fixes.ModArmorWeightPerkEntryPoint.GetTotalItemWeight + 0x29F,
				Pattern			= "E8 ?? ?? ?? ??" + "F3 0F10 8C 24 B0000000" + "F3 0F58 F1",
				ReplaceLength	= 5 + 9 + 4, // 18
				IncludeLength	= 0,
				Before			= registers =>
				{
					// actor		!= System.IntPtr.Zero
					// item			!= System.IntPtr.Zero
					// itemWeight	!= System.IntPtr.Zero

					// entryPoint	= registers.CX
					var actor		= registers.DX;
					var item		= registers.R8;
					var itemWeight	= Memory.Read<System.Single>(registers.R9);

					registers.XMM1f = itemWeight; // itemWeight

					BGSEntryPointPerkEntry.HandleEntryPoints(EntryPoint.ModArmorWeight, actor, item, ref itemWeight);

					registers.XMM6f += itemWeight; // totalModifiedItemWeight
				}
			});
		}
	}
}
