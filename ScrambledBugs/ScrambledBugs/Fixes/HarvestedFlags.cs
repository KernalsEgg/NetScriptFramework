using Eggstensions;



namespace ScrambledBugs.Fixes
{
	unsafe internal class HarvestedFlags
	{
		static HarvestedFlags()
		{
			var removeHarvestedFlag = Memory.ReadRelativeCall<ScrambledBugs.Delegates.Types.Fixes.HarvestedFlags.SetHarvestedFlag>(ScrambledBugs.Offsets.Fixes.HarvestedFlags.RemoveHarvestedFlag);

			HarvestedFlags.RemoveChangeFlag = (TESObjectREFR* reference, System.Byte harvested) =>
			{
				// reference != null

				var formType = reference->BaseObject->TESForm.FormType;

				if (formType == FormType.Flora || formType == FormType.Tree)
				{
					TESForm.RemoveChanges(&reference->TESForm, (System.UInt32)TESObjectREFR.ChangeFlags.Empty);
				}

				removeHarvestedFlag(reference, harvested);
			};

			ScrambledBugs.Plugin.Trampoline.WriteRelativeCall<ScrambledBugs.Delegates.Types.Fixes.HarvestedFlags.SetHarvestedFlag>
			(
				ScrambledBugs.Offsets.Fixes.HarvestedFlags.RemoveHarvestedFlag,
				HarvestedFlags.RemoveChangeFlag
			);
		}



		static public ScrambledBugs.Delegates.Types.Fixes.HarvestedFlags.SetHarvestedFlag RemoveChangeFlag { get; }
	}
}
