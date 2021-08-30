using Eggstensions;



namespace ScrambledBugs.Patches
{
	static internal class UnderfilledSoulGems
	{
		static public void Patch()
		{
			Memory.SafeWriteNullableArray<System.Byte>(ScrambledBugs.Offsets.Patches.UnderfilledSoulGems.CompareSoulLevelValue, new System.Byte?[2] { 0x75, null });
		}
	}
}
