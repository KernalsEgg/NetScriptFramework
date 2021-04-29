using static NetScriptFramework._IntPtrExtensions;



namespace ScrambledBugs.Fixes
{
	internal class ModArmorWeightPerkEntryPoint
	{
		static protected class Offsets
		{
			static Offsets()
			{
				Offsets.ApplyPerkEntryPoints	= NetScriptFramework.Main.GameInfo.GetAddressOf(23073);
				Offsets.GetTotalItemWeight		= NetScriptFramework.Main.GameInfo.GetAddressOf(15883);
				Offsets.IsWorn					= NetScriptFramework.Main.GameInfo.GetAddressOf(15763);
			}



			/// <summary> SkyrimSE.exe + 0x32ECE0 </summary>
			static internal System.IntPtr ApplyPerkEntryPoints { get; }

			/// <summary> SkyrimSE.exe + 0x1E9130 </summary>
			static internal System.IntPtr GetTotalItemWeight { get; }

			/// <summary> SkyrimSE.exe + 0x1D6A40 </summary>
			static internal System.IntPtr IsWorn { get; }
		}



		static protected class BGSEntryPoint
		{
			internal enum EntryPoints : System.UInt32
			{
				ModArmorWeight = 32
			}
		}

		static protected class InventoryEntryData
		{
			static internal System.IntPtr GetItem(System.IntPtr inventoryEntryData)
			{
				return NetScriptFramework.Memory.ReadPointer(inventoryEntryData + 0x0);
			}
			
			static internal System.Boolean IsWorn(System.IntPtr inventoryEntryData)
			{
				return NetScriptFramework.Memory.InvokeCdecl(ModArmorWeightPerkEntryPoint.Offsets.IsWorn, inventoryEntryData).ToBool();
			}
		}

		static protected class TESForm
		{
			internal enum FormTypes : System.Byte
			{
				TESObjectARMO = 0x1A
			}



			static internal TESForm.FormTypes GetFormType(System.IntPtr form)
			{
				return (TESForm.FormTypes)NetScriptFramework.Memory.ReadUInt8(form + 0x1A);
			}
		}



		internal ModArmorWeightPerkEntryPoint()
		{
			// Modify the weight of worn armor in TESContainer
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = ModArmorWeightPerkEntryPoint.Offsets.GetTotalItemWeight + 0x159,
				Pattern = "8B 55 10" + "8B 00",
				ReplaceLength = 3 + 2, // 5
				IncludeLength = 3 + 2, // 5
				After = cpuRegisters =>
				{
					// inventoryEntryData != System.IntPtr.Zero

					var inventoryEntryData = cpuRegisters.BP;
					var item = ModArmorWeightPerkEntryPoint.InventoryEntryData.GetItem(inventoryEntryData);

					if (item != System.IntPtr.Zero)
					{
						var itemWeight = cpuRegisters.SP + 0xB0;

						if (NetScriptFramework.Memory.ReadFloat(itemWeight) > 0.0F)
						{
							var actor = NetScriptFramework.Memory.ReadPointer(cpuRegisters.SP + 0xB8);

							if (actor != System.IntPtr.Zero)
							{
								var formType = ModArmorWeightPerkEntryPoint.TESForm.GetFormType(item);

								if (formType == ModArmorWeightPerkEntryPoint.TESForm.FormTypes.TESObjectARMO)
								{
									var itemCount = cpuRegisters.DX.ToInt32Safe() + cpuRegisters.AX.ToInt32Safe(); // inventoryChangesItemCount + containerItemCount

									if (itemCount > 0)
									{
										if (ModArmorWeightPerkEntryPoint.InventoryEntryData.IsWorn(inventoryEntryData))
										{
											NetScriptFramework.Memory.InvokeCdecl(ModArmorWeightPerkEntryPoint.Offsets.ApplyPerkEntryPoints, (System.UInt32)ModArmorWeightPerkEntryPoint.BGSEntryPoint.EntryPoints.ModArmorWeight, actor, item, itemWeight);

											cpuRegisters.XMM7f += NetScriptFramework.Memory.ReadFloat(itemWeight); // totalItemWeight
											cpuRegisters.DX -= 1; // inventoryChangesItemCount
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
				Address = ModArmorWeightPerkEntryPoint.Offsets.GetTotalItemWeight + 0x29F,
				Pattern = "E8 ?? ?? ?? ??" + "F3 0F10 8C 24 B0000000" + "F3 0F58 F1",
				ReplaceLength = 5 + 9 + 4, // 18
				IncludeLength = 0,
				Before = cpuRegisters =>
				{
					// actor != System.IntPtr.Zero
					// item != System.IntPtr.Zero
					// itemWeight != System.IntPtr.Zero

					var entryPoint = cpuRegisters.CX;
					var actor = cpuRegisters.DX;
					var item = cpuRegisters.R8;
					var itemWeight = cpuRegisters.R9;
					
					cpuRegisters.XMM1f = NetScriptFramework.Memory.ReadFloat(itemWeight); // itemWeight
					NetScriptFramework.Memory.InvokeCdecl(ModArmorWeightPerkEntryPoint.Offsets.ApplyPerkEntryPoints, entryPoint, actor, item, itemWeight);
					cpuRegisters.XMM6f += NetScriptFramework.Memory.ReadFloat(itemWeight); // totalModifiedItemWeight
				}
			});
		}
	}
}
