using Eggstensions;



namespace ScrambledBugs.Patches
{
	internal class MultipleHitEffects
	{
		static MultipleHitEffects()
		{
			Memory.SafeWriteArray<System.Byte>(ScrambledBugs.Offsets.Patches.MultipleHitEffects.IsNotCostliestEffect, new System.Byte[2] { 0xEB, 0x0A }); // 1 << 1 (NoHitShader), 1 << 2 (NoHitEffectArt), 1 << 3
		}
	}
}
