using Eggstensions;



namespace ScrambledBugs.Patches
{
	internal class UnderfilledSoulGems
	{
		public UnderfilledSoulGems()
		{
			Memory.SafeWriteArray<System.Byte>(Offsets.Patches.UnderfilledSoulGems.FindBestSoulGem, new System.Byte[2] { 0x75, 0x2E });
		}
	}
}
