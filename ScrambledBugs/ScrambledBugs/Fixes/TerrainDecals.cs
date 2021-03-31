namespace ScrambledBugs.Fixes
{
	internal class TerrainDecals
	{
		static protected class Offsets
		{
			static Offsets()
			{
				Offsets.UnloadHavokData = NetScriptFramework.Main.GameInfo.GetAddressOf(18711, 0xE7, 0, "E9 ?? ?? ?? ??");
			}



			/// <summary> SkyrimSE.exe + 0x271BE0 </summary>
			static internal System.IntPtr UnloadHavokData { get; }
		}
		
		
		
		internal TerrainDecals()
		{
			NetScriptFramework.Memory.WriteBytes(TerrainDecals.Offsets.UnloadHavokData, new System.Byte[] { 0xC3, 0x90, 0x90, 0x90, 0x90 }, true);
		}
	}
}
