using Eggstensions;



namespace ScrambledBugs.Fixes
{
	internal class TrainingMenuText
	{
		static TrainingMenuText()
		{
			Memory.SafeWriteArray<System.Byte>(ScrambledBugs.Offsets.Fixes.TrainingMenuText.UpdateText, new System.Byte[3] { 0xFF, 0x50, 0x18 });
		}
	}
}
