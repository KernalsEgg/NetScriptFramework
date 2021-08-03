using Eggstensions;



namespace ScrambledBugs.Fixes
{
	internal class TerrainDecals
	{
		static TerrainDecals()
		{
			Memory.SafeWriteArray<System.Byte>(ScrambledBugs.Offsets.Fixes.TerrainDecals.UnloadHavokData, new System.Byte[5] { Assembly.Ret, Assembly.Nop, Assembly.Nop, Assembly.Nop, Assembly.Nop });
		}
	}
}
