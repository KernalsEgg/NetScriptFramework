using Eggstensions;



namespace ScrambledBugs.Fixes
{
	unsafe static internal class HarvestedFlags
	{
		static public ScrambledBugs.Delegates.Types.Fixes.HarvestedFlags.SetHarvestedFlag RemoveChangeFlag { get; set; }



		static public void Fix()
		{
			var setHarvestedFlag = Memory.ReadRelativeCall<ScrambledBugs.Delegates.Types.Fixes.HarvestedFlags.SetHarvestedFlag>(ScrambledBugs.Offsets.Fixes.HarvestedFlags.RemoveHarvestedFlag);

			HarvestedFlags.RemoveChangeFlag = (TESObjectREFR* reference, System.Byte harvested) =>
			{
				// reference != null

				var formType = reference->BaseObject->TESForm.FormType;

				if (formType == FormType.Flora || formType == FormType.Tree)
				{
					TESForm.RemoveChanges(&reference->TESForm, (System.UInt32)TESObjectREFR.ChangeFlags.Empty);
				}

				setHarvestedFlag(reference, harvested);
			};

			ScrambledBugs.Plugin.Trampoline.WriteRelativeCall<ScrambledBugs.Delegates.Types.Fixes.HarvestedFlags.SetHarvestedFlag>
			(
				ScrambledBugs.Offsets.Fixes.HarvestedFlags.RemoveHarvestedFlag,
				HarvestedFlags.RemoveChangeFlag
			);
		}
	}
}
