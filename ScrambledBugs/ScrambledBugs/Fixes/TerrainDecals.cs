using Eggstensions.Interoperability.Managed; // Memory



namespace ScrambledBugs.Fixes
{
	namespace Offsets
	{
		static internal class TerrainDecals
		{
			/// <summary> SkyrimSE.exe + 0x271BE0 </summary>
			static public System.IntPtr UnloadHavokData { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf(18711, 0xE7, 0, "E9 ?? ?? ?? ??"); // 5
		}
	}
	


	internal class TerrainDecals
	{
		public TerrainDecals()
		{
			Memory.SafeWriteByteArray(Offsets.TerrainDecals.UnloadHavokData, new System.Byte[] { Memory.Ret, Memory.Nop, Memory.Nop, Memory.Nop, Memory.Nop });
		}
	}
}
