using Eggstensions;



namespace ScrambledBugs.Patches
{
	static internal class PausedGameHitEffects
	{
		static public void Patch()
		{
			Memory.SafeFill<System.Byte>(ScrambledBugs.Offsets.Patches.PausedGameHitEffects.IsNotApplyingHitEffects, 2, Assembly.Nop);
		}
	}
}
