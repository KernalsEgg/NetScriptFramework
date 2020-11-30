namespace Eggstensions.Bethesda.BSTArray
{
	public class UInt32 : System.Collections.Generic.IEnumerable<System.UInt32>
	{
		public System.IntPtr Address { get; }



		public UInt32(System.IntPtr bstArray)
		{
			if (bstArray == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bstArray"); }

			Address = bstArray;
		}



		public System.Collections.Generic.IEnumerator<System.UInt32> GetEnumerator()
		{
			return new Enumerator(BSTArray.GetBegin(Address), BSTArray.GetCount(Address));
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}



		private class Enumerator : System.Collections.Generic.IEnumerator<System.UInt32>
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



			public System.UInt32 Current
			{
				get
				{
					return NetScriptFramework.Memory.ReadUInt32(_begin + 0x4 * _index);
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
