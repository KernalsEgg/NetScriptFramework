using Eggstensions;



namespace ScrambledBugs.Fixes
{
	static internal class TrainingMenuText
	{
		static public void Fix()
		{
			Memory.SafeWriteArray<System.Byte>(ScrambledBugs.Offsets.Fixes.TrainingMenuText.GetPermanentActorValue, new System.Byte[3] { 0xFF, 0x50, 0x18 });
		}
	}
}
