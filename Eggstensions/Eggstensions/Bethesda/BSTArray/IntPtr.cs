namespace Eggstensions.Bethesda.BSTArray
{
	public class IntPtr : System.Collections.Generic.IEnumerable<System.IntPtr>
	{
		public System.IntPtr Address { get; }



		public IntPtr(System.IntPtr bstArray)
		{
			if (bstArray == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bstArray"); }

			Address = bstArray;
		}



		public System.Collections.Generic.IEnumerator<System.IntPtr> GetEnumerator()
		{
			return new Enumerator(BSTArray.GetBegin(Address), BSTArray.GetCount(Address));
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}



		private class Enumerator : System.Collections.Generic.IEnumerator<System.IntPtr>
		{
			readonly private System.Int32 _count;

			readonly private System.IntPtr _begin;



			private System.Int32 _index;



			public Enumerator(System.IntPtr begin, System.Int32 count)
			{
				if (begin == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("begin"); }
				if (count < 0) { throw new Eggceptions.ArgumentOutOfRangeException("count"); }

				_begin = begin;
				_count = count;

				Reset();
			}



			public System.IntPtr Current
			{
				get
				{
					return NetScriptFramework.Memory.ReadPointer(_begin + 0x8 * _index);
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
				while (++_index < _count)
				{
					return true;
				}

				return false;
			}

			public void Reset()
			{
				_index = -1;
			}
		}
	}
}
