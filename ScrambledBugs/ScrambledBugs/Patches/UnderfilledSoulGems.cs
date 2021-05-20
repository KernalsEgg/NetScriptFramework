using Eggstensions.Interoperability.Managed; // Memory



namespace ScrambledBugs.Patches
{
	namespace Offsets
	{
		static internal class UnderfilledSoulGems
		{
			/// <summary> SkyrimSE.exe + 0x1E5050 </summary>
			static public System.IntPtr FindBestSoulGem { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf(15854, 0xE6, 0, "72 2E"); // 2
		}
	}


	
	internal class UnderfilledSoulGems
	{
		public UnderfilledSoulGems()
		{
			Memory.SafeWriteByteArray(Offsets.UnderfilledSoulGems.FindBestSoulGem, new System.Byte[] { 0x75, 0x2E });
		}
	}
}
