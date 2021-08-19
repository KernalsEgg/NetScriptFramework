using Eggstensions;



namespace ScrambledBugs.Patches
{
	static internal class LockpickingExperience
	{
		static public void Patch()
		{
			Memory.SafeFill<System.Byte>(ScrambledBugs.Offsets.Patches.LockpickingExperience.HasNotBeenUnlocked, 2, Assembly.Nop);
		}
	}
}
