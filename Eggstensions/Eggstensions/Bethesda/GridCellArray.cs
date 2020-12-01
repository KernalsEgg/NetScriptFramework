namespace Eggstensions.Bethesda
{
	public class GridCellArray : System.Collections.Generic.IEnumerable<System.IntPtr>
	{
		public System.IntPtr Address { get; }



		public GridCellArray(System.IntPtr gridCellArray)
		{
			if (gridCellArray == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("gridCellArray"); }

			Address = gridCellArray;
		}



		public System.Collections.Generic.IEnumerator<System.IntPtr> GetEnumerator()
		{
			var gridCellArray = Address;
			var begin = GridCellArray.GetBegin(gridCellArray);
			var length = GridArray.GetLength(gridCellArray);

			for (var row = 0; row < length; row++)
			{
				for (var column = 0; column < length; column++)
				{
					var cell = NetScriptFramework.Memory.ReadPointer(begin + 0x8 * (length * row + column));
					if (cell == System.IntPtr.Zero) { throw new Eggceptions.NullException("cell"); }

					yield return cell;
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
			if (gridCellArray == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("gridCellArray"); }

			var begin = NetScriptFramework.Memory.ReadPointer(gridCellArray + 0x18);
			if (begin == System.IntPtr.Zero) { throw new Eggceptions.NullException("begin"); }

			return begin;
		}
	}
}
