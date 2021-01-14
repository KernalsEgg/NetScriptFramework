namespace Eggstensions.SkyrimSE
{
	static public class GridArray
	{
		/// <param name = "gridArray">GridArray</param>
		static public System.Int32 GetLength(System.IntPtr gridArray)
		{
			if (gridArray == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(gridArray)); }

			return NetScriptFramework.Memory.ReadInt32(gridArray + 0x10);
		}
	}
}
