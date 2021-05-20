using Eggstensions.Interoperability.Managed; // Memory



namespace ScrambledBugs.Fixes
{
	namespace Offsets
	{
		static internal class TrainingMenuText
		{
			/// <summary> SkyrimSE.exe + 0x8CEA30 </summary>
			static public System.IntPtr UpdateText { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf(51794, 0x289, 0, "FF 50 10"); // 3
		}
	}
	


	internal class TrainingMenuText
	{
		public TrainingMenuText()
		{
			Memory.SafeWriteByteArray(Offsets.TrainingMenuText.UpdateText, new System.Byte[] { 0xFF, 0x50, 0x18 });
		}
	}
}
