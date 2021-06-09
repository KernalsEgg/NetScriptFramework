using Eggstensions;



namespace ScrambledBugs.Fixes
{
	internal class TerrainDecals
	{
		public TerrainDecals()
		{
			Memory.SafeWriteArray<System.Byte>(Offsets.Fixes.TerrainDecals.UnloadHavokData, new System.Byte[5] { Memory.Ret, Memory.Nop, Memory.Nop, Memory.Nop, Memory.Nop });
		}
	}
}
