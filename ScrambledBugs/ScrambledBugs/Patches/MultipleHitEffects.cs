using Eggstensions.Interoperability.Managed; // Memory



namespace ScrambledBugs.Patches
{
	namespace Offsets
	{
		static internal class MultipleHitEffects
		{
			/// <summary> SkyrimSE.exe + 0x5468E0 </summary>
			static public System.IntPtr IsNotCostliestEffect { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf(33471, 0x15, 0, "74 0A"); // 2
		}
	}
	
	
	
	internal class MultipleHitEffects
	{
		public MultipleHitEffects()
		{
			Memory.SafeWriteByteArray(Offsets.MultipleHitEffects.IsNotCostliestEffect, new System.Byte[] { 0xEB, 0x0A }); // 1 << 1 (NoHitShader), 1 << 2 (NoHitEffectArt), 1 << 3
		}
	}
}
