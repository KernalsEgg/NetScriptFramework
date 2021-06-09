using Eggstensions;



namespace ScrambledBugs.Patches
{
	internal class PausedGameHitEffects
	{
		public PausedGameHitEffects()
		{
			Memory.SafeWriteArray<System.Byte>(Offsets.Patches.PausedGameHitEffects.IsNotApplyingHitEffects, new System.Byte[2] { Memory.Nop, Memory.Nop });
		}
	}
}
