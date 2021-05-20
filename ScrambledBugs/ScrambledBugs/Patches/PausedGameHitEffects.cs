using Eggstensions.Interoperability.Managed; // Memory



namespace ScrambledBugs.Patches
{
	namespace Offsets
	{
		static internal class PausedGameHitEffects
		{
			/// <summary> SkyrimSE.exe + 0x5402D0 </summary>
			static public System.IntPtr IsNotApplyingHitEffects { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf(33319, 0x37, 0, "74 3F"); // 2
		}
	}
	


	internal class PausedGameHitEffects
	{
		public PausedGameHitEffects()
		{
			Memory.SafeWriteNopArray(Offsets.PausedGameHitEffects.IsNotApplyingHitEffects, 2);
		}
	}
}
