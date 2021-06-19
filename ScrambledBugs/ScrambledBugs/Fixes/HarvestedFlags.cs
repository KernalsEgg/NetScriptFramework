using Eggstensions;



namespace ScrambledBugs.Fixes
{
	internal class HarvestedFlags
	{
		public HarvestedFlags()
		{
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address			= Offsets.Fixes.HarvestedFlags.Respawn + 0x31C,
				Pattern			= "E8 ?? ?? ?? ??",
				ReplaceLength	= 5,
				IncludeLength	= 5,
				Before			= registers =>
				{
					// reference != System.IntPtr.Zero
					
					TESObjectREFR reference = registers.CX;

					TESBoundObject baseObject	= reference.BaseObject;
					var formType				= baseObject.FormType;

					if (formType == FormType.Flora || formType == FormType.Tree)
					{
						reference.RemoveChanges((System.UInt32)TESObjectREFR.ChangeFlags.Empty);
					}
				}
			});
		}
	}
}
