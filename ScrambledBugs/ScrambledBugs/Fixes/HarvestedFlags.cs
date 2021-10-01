using Eggstensions;
using Eggstensions.ExtensionMethods;



namespace ScrambledBugs.Fixes
{
	unsafe static internal class HarvestedFlags
	{
		static public System.Boolean Fix()
		{
			if (!ScrambledBugs.Patterns.Fixes.HarvestedFlags.RemoveHarvestedFlag)
			{
				return false;
			}

			HarvestedFlags.RemoveChangeFlag();

			return true;
		}



		static private delegate* unmanaged[Cdecl]<TESObjectREFR*, System.Byte, void> setHarvestedFlag;



		static public void RemoveChangeFlag()
		{
			HarvestedFlags.setHarvestedFlag = (delegate* unmanaged[Cdecl]<TESObjectREFR*, System.Byte, void>)Memory.ReadRelativeCall(ScrambledBugs.Offsets.Fixes.HarvestedFlags.RemoveHarvestedFlag);

			var removeChangeFlag = (delegate* unmanaged[Cdecl]<TESObjectREFR*, System.Byte, void>)&RemoveChangeFlag;

			Trampoline.WriteRelativeCall(ScrambledBugs.Offsets.Fixes.HarvestedFlags.RemoveHarvestedFlag, removeChangeFlag);

			[System.Runtime.InteropServices.UnmanagedCallersOnly(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
			static void RemoveChangeFlag(TESObjectREFR* reference, System.Byte harvested)
			{
				// reference != null

				var formType = reference->BaseObject()->FormType();

				if (formType == FormType.Flora || formType == FormType.Tree)
				{
					reference->RemoveChanges((System.UInt32)TESObjectREFR.ChangeFlags.Empty);
				}

				SetHarvestedFlag(reference, harvested);



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				static void SetHarvestedFlag(TESObjectREFR* reference, System.Byte harvested)
				{
					HarvestedFlags.setHarvestedFlag(reference, harvested);
				}
			}
		}
	}
}
