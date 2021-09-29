using Eggstensions;



namespace ScrambledBugs.Patches
{
	static internal class LockpickingExperience
	{
		static public System.Boolean Patch()
		{
			if (!ScrambledBugs.Patterns.Patches.LockpickingExperience.HasNotBeenUnlocked)
			{
				return false;
			}

			Memory.SafeFill<System.Byte>(ScrambledBugs.Offsets.Patches.LockpickingExperience.HasNotBeenUnlocked, 2, Assembly.Nop);

			return true;
		}
	}
}
