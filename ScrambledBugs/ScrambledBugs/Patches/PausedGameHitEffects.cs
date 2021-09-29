using Eggstensions;



namespace ScrambledBugs.Patches
{
	static internal class PausedGameHitEffects
	{
		static public System.Boolean Patch()
		{
			if (!ScrambledBugs.Patterns.Patches.PausedGameHitEffects.IsNotApplyingHitEffects)
			{
				return false;
			}

			Memory.SafeFill<System.Byte>(ScrambledBugs.Offsets.Patches.PausedGameHitEffects.IsNotApplyingHitEffects, 2, Assembly.Nop);

			return true;
		}
	}
}
