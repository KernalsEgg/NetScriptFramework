using Eggstensions;



namespace ScrambledBugs.Patches
{
	static internal class MultipleHitEffects
	{
		static public System.Boolean Patch()
		{
			if (!ScrambledBugs.Patterns.Patches.MultipleHitEffects.IsNotCostliestEffect)
			{
				return false;
			}

			Memory.SafeWrite<System.Byte>(ScrambledBugs.Offsets.Patches.MultipleHitEffects.IsNotCostliestEffect, new System.Byte?[2] { 0xEB, null }); // 1 << 1 (NoHitShader), 1 << 2 (NoHitEffectArt), 1 << 3

			return true;
		}
	}
}
