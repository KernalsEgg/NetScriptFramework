using Eggstensions;



namespace ScrambledBugs.Fixes
{
	static internal class TerrainDecals
	{
		static public void Fix()
		{
			Memory.SafeWrite<System.Byte>(ScrambledBugs.Offsets.Fixes.TerrainDecals.UnloadHavokData, new System.Byte[5] { Assembly.Ret, Assembly.Nop, Assembly.Nop, Assembly.Nop, Assembly.Nop });
		}
	}
}
