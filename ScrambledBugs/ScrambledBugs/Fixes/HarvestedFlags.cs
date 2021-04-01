namespace ScrambledBugs.Fixes
{
	internal class HarvestedFlags
	{
		static protected class Offsets
		{
			static Offsets()
			{
				Offsets.Respawn = NetScriptFramework.Main.GameInfo.GetAddressOf(18843);
			}



			/// <summary> SkyrimSE.exe + 0x278920 </summary>
			static internal System.IntPtr Respawn { get; }
		}

		static protected class TESForm
		{
			internal enum FormTypes : System.Byte
			{
				TESObjectTREE =	0x26,
				TESFlora =		0x27
			}



			static internal TESForm.FormTypes GetFormType(System.IntPtr form)
			{
				return (TESForm.FormTypes)NetScriptFramework.Memory.ReadUInt8(form + 0x1A);
			}

			static internal System.Boolean IsHarvestable(System.IntPtr form)
			{
				var formType = TESForm.GetFormType(form);

				return formType == TESForm.FormTypes.TESObjectTREE || formType == TESForm.FormTypes.TESFlora;
			}

			static internal void RemoveChange(System.IntPtr form, System.UInt32 change)
			{
				var virtualFunctionTable = NetScriptFramework.Memory.ReadPointer(form);
				var removeChange = NetScriptFramework.Memory.ReadPointer(virtualFunctionTable + 0x58);

				NetScriptFramework.Memory.InvokeThisCall(form, removeChange, change);
			}
		}

		static protected class TESObjectREFR
		{
			internal enum Changes : System.UInt32
			{
				Empty = 1 << 21
			}



			static internal System.IntPtr GetBaseObject(System.IntPtr reference)
			{
				return NetScriptFramework.Memory.ReadPointer(reference + 0x40);
			}

			static internal void RemoveHarvestedFlag(System.IntPtr reference)
			{
				// reference != System.IntPtr.Zero
				
				var baseObject = HarvestedFlags.TESObjectREFR.GetBaseObject(reference);

				if (HarvestedFlags.TESForm.IsHarvestable(baseObject))
				{
					HarvestedFlags.TESForm.RemoveChange(reference, (System.UInt32)HarvestedFlags.TESObjectREFR.Changes.Empty);
				}
			}
		}



		internal HarvestedFlags()
		{
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = HarvestedFlags.Offsets.Respawn + 0x31C,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 5,
				Before = cpuRegisters => HarvestedFlags.TESObjectREFR.RemoveHarvestedFlag(cpuRegisters.CX),
			});
		}
	}
}
