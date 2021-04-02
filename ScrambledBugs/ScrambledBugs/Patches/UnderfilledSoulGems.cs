namespace ScrambledBugs.Patches
{
	internal class UnderfilledSoulGems
	{
		static protected class Offsets
		{
			static Offsets()
			{
				Offsets.FindBestSoulGem = NetScriptFramework.Main.GameInfo.GetAddressOf(15854, 0xE6, 0, "72 2E"); // 2
			}



			/// <summary> SkyrimSE.exe + 0x1E5050 </summary>
			static internal System.IntPtr FindBestSoulGem { get; }
		}



		internal UnderfilledSoulGems()
		{
			NetScriptFramework.Memory.WriteBytes(UnderfilledSoulGems.Offsets.FindBestSoulGem, new System.Byte[] { 0x75, 0x2E }, true);
		}
	}
}
