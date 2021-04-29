namespace ScrambledBugs.Patches
{
	internal class MultipleHitEffects
	{
		static protected class Offsets
		{
			static Offsets()
			{
				Offsets.IsNotCostliestEffect = NetScriptFramework.Main.GameInfo.GetAddressOf(33471, 0x15, 0, "74 0A"); // 2
			}



			/// <summary> SkyrimSE.exe + 0x5468E0 </summary>
			static internal System.IntPtr IsNotCostliestEffect { get; } // 1 << 1 (NoHitShader), 1 << 2 (NoHitEffectArt), 1 << 3
		}



		internal MultipleHitEffects()
		{
			NetScriptFramework.Memory.WriteBytes(MultipleHitEffects.Offsets.IsNotCostliestEffect, new System.Byte[] { 0xEB, 0x0A }, true);
		}
	}
}
