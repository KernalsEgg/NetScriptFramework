using Eggstensions;



namespace ScrambledBugs.Patches
{
	internal class LockpickingExperience
	{
		static LockpickingExperience()
		{
			Memory.SafeFill<System.Byte>(ScrambledBugs.Offsets.Patches.LockpickingExperience.HasNotBeenUnlocked, 2, Assembly.Nop);
		}
	}
}
