using Eggstensions;



namespace ScrambledBugs.Patches
{
	internal class LockpickingExperience
	{
		public LockpickingExperience()
		{
			Memory.SafeWriteArray<System.Byte>(Offsets.Patches.LockpickingExperience.HasNotBeenUnlocked, new System.Byte[2] { Memory.Nop, Memory.Nop });
		}
	}
}
