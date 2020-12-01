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
			return new Enumerator(GridCellArray.GetBegin(Address), GridArray.GetLength(Address));
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}



		/// <summary>&lt;SkyrimSE.exe&gt; + 0x1D4E60 (VID15713)</summary>
		private class Enumerator : System.Collections.Generic.IEnumerator<System.IntPtr>
		{
			readonly private System.Int32 _length;

			readonly private System.IntPtr _begin;



			private System.Int32 _column;

			private System.Int32 _row;



			public Enumerator(System.IntPtr begin, System.Int32 length)
			{
				if (begin == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("begin"); }
				if (length < 0) { throw new Eggceptions.ArgumentOutOfRangeException("length"); }

				_begin = begin;
				_length = length;

				Reset();
			}



			/// <returns>TESObjectCELL</returns>
			public System.IntPtr Current
			{
				get
				{
					var current = NetScriptFramework.Memory.ReadPointer(_begin + 0x8 * (_length * _row + _column));
					if (current == System.IntPtr.Zero) { throw new Eggceptions.NullException("current"); }

					return current;
				}
			}

			object System.Collections.IEnumerator.Current
			{
				get
				{
					return Current;
				}
			}



			public void Dispose()
			{
			}

			public System.Boolean MoveNext()
			{
				if (++_column < _length)
				{
					return true;
				}

				if (++_row < _length)
				{
					_column = 0;
					return true;
				}

				return false;
			}

			public void Reset()
			{
				_column = -1;
				_row = 0;
			}
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
