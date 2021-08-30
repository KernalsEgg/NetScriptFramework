using Eggstensions;



namespace ScrambledBugs.Fixes
{
	static internal class TrainingMenuText
	{
		static public void Fix()
		{
			Memory.SafeWriteNullableArray<System.Byte>(ScrambledBugs.Offsets.Fixes.TrainingMenuText.GetPermanentActorValue, new System.Byte?[3] { null, null, 0x18 });
		}
	}
}
