namespace Eggstensions.SkyrimSE
{
	public class GridCellArray : System.Collections.Generic.IEnumerable<System.IntPtr>
	{
		public GridCellArray(System.IntPtr gridCellArray)
		{
			if (gridCellArray == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(gridCellArray)); }

			Address = gridCellArray;
		}



		public System.IntPtr Address { get; }



		public System.Collections.Generic.IEnumerator<System.IntPtr> GetEnumerator()
		{
			var gridCellArray = Address;
			var length = GridArray.GetLength(gridCellArray);
			var begin = GridCellArray.GetBegin(gridCellArray);
			if (begin == System.IntPtr.Zero) { yield break; }

			for (var row = 0; row < length; row++)
			{
				for (var column = 0; column < length; column++)
				{
					var loadedCell = NetScriptFramework.Memory.ReadPointer(begin + 0x8 * (length * row + column));
					if (loadedCell == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(loadedCell)); }

					yield return loadedCell;
				}
			}
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}



		/// <param name = "gridCellArray">GridCellArray</param>
		static public System.IntPtr GetBegin(System.IntPtr gridCellArray)
		{
			if (gridCellArray == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(gridCellArray)); }

			return NetScriptFramework.Memory.ReadPointer(gridCellArray + 0x18);
		}
	}
}
