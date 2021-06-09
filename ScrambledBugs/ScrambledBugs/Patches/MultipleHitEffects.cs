using Eggstensions;



namespace ScrambledBugs.Patches
{
	internal class MultipleHitEffects
	{
		public MultipleHitEffects()
		{
			Memory.SafeWriteArray<System.Byte>(Offsets.Patches.MultipleHitEffects.IsNotCostliestEffect, new System.Byte[2] { 0xEB, 0x0A }); // 1 << 1 (NoHitShader), 1 << 2 (NoHitEffectArt), 1 << 3
		}
	}
}
