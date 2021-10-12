using Eggstensions;



namespace ScrambledBugs.Patches
{
	static internal class LeveledCharacters
	{
		static public System.Boolean Patch()
		{
			if (!ScrambledBugs.Patterns.Patches.LeveledCharacters.IsVeryHard)
			{
				return false;
			}

			Memory.SafeFill<System.Byte>(ScrambledBugs.Offsets.Patches.LeveledCharacters.IsVeryHard, 2, Assembly.Nop);

			return true;
		}
	}
}
