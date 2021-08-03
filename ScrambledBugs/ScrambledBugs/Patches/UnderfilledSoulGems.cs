using Eggstensions;



namespace ScrambledBugs.Patches
{
	internal class UnderfilledSoulGems
	{
		static UnderfilledSoulGems()
		{
			Memory.SafeWriteArray<System.Byte>(ScrambledBugs.Offsets.Patches.UnderfilledSoulGems.FindBestSoulGem, new System.Byte[2] { 0x75, 0x2E });
		}
	}
}
