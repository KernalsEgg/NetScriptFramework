using Eggstensions;



namespace ScrambledBugs.Fixes
{
	internal class TrainingMenuText
	{
		public TrainingMenuText()
		{
			Memory.SafeWriteArray<System.Byte>(Offsets.Fixes.TrainingMenuText.UpdateText, new System.Byte[3] { 0xFF, 0x50, 0x18 });
		}
	}
}
