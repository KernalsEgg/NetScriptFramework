namespace ScrambledBugs
{
	internal class TerrainDecals
	{
		internal TerrainDecals()
		{
			NetScriptFramework.Memory.WriteBytes(TerrainDecals._unloadHavokData, new System.Byte[] { 0xC3, 0x90, 0x90, 0x90, 0x90 }, true);
		}



		static TerrainDecals()
		{
			TerrainDecals._unloadHavokData = NetScriptFramework.Main.GameInfo.GetAddressOf(18711, 0xE7, 0, "E9 ?? ?? ?? ??"); // SkyrimSE.exe + 0x271BE0
		}



		readonly static private System.IntPtr _unloadHavokData;
	}
}
