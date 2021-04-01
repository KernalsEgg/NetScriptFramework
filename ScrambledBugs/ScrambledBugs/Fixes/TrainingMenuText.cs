namespace ScrambledBugs.Fixes
{
	internal class TrainingMenuText
	{
		static protected class Offsets
		{
			static Offsets()
			{
				Offsets.UpdateText = NetScriptFramework.Main.GameInfo.GetAddressOf(51794, 0x289, 0, "FF 50 10");
			}



			/// <summary> SkyrimSE.exe + 0x8CEA30 </summary>
			static internal System.IntPtr UpdateText { get; }
		}



		internal TrainingMenuText()
		{
			NetScriptFramework.Memory.WriteBytes(TrainingMenuText.Offsets.UpdateText, new System.Byte[] { 0xFF, 0x50, 0x18 }, true);
		}
	}
}
