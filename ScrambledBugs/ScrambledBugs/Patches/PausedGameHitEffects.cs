using Eggstensions;



namespace ScrambledBugs.Patches
{
	internal class PausedGameHitEffects
	{
		static PausedGameHitEffects()
		{
			Memory.SafeFill<System.Byte>(ScrambledBugs.Offsets.Patches.PausedGameHitEffects.IsNotApplyingHitEffects, 2, Assembly.Nop);
		}
	}
}
