using Eggstensions;



namespace ScrambledBugs.Patches
{
	static internal class UnderfilledSoulGems
	{
		static public System.Boolean Patch()
		{
			if (!ScrambledBugs.Patterns.Patches.UnderfilledSoulGems.CompareSoulLevelValue)
			{
				return false;
			}

			Memory.SafeWrite<System.Byte>(ScrambledBugs.Offsets.Patches.UnderfilledSoulGems.CompareSoulLevelValue, new System.Byte?[2] { 0x75, null });

			return true;
		}
	}
}
