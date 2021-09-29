using Eggstensions;



namespace ScrambledBugs.Fixes
{
	static internal class TerrainDecals
	{
		static public System.Boolean Fix()
		{
			if (!ScrambledBugs.Patterns.Fixes.TerrainDecals.UnloadHavokData)
			{
				return false;
			}
			
			Memory.SafeWrite<System.Byte>(ScrambledBugs.Offsets.Fixes.TerrainDecals.UnloadHavokData, new System.Byte[5] { Assembly.Ret, Assembly.Nop, Assembly.Nop, Assembly.Nop, Assembly.Nop });

			return true;
		}
	}
}
