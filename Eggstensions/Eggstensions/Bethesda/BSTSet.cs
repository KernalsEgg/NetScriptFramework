namespace Eggstensions.Bethesda
{
	public class BSTSet : System.Collections.Generic.IEnumerable<(System.IntPtr value, System.IntPtr next)>
	{
		public System.IntPtr Address { get; }


		
		public BSTSet(System.IntPtr bstSet)
		{
			if (bstSet == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bstSet"); }

			Address = bstSet;
		}



		public System.Collections.Generic.IEnumerator<(System.IntPtr value, System.IntPtr next)> GetEnumerator()
		{
			return new Enumerator(BSTSet.GetBegin(Address), BSTSet.GetCapacity(Address));
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}



		private class Enumerator : System.Collections.Generic.IEnumerator<(System.IntPtr value, System.IntPtr next)>
		{
			readonly private System.Int32 _capacity;

			readonly private System.IntPtr _begin;



			private System.Int32 _index;

			private System.IntPtr _next;

			private System.IntPtr _value;



			public Enumerator(System.IntPtr begin, System.Int32 capacity)
			{
				if (begin == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("begin"); }
				if (capacity < 0) { throw new Eggceptions.ArgumentOutOfRangeException("capacity"); }

				_begin = begin;
				_capacity = capacity;

				Reset();
			}



			public (System.IntPtr value, System.IntPtr next) Current
			{
				get
				{
					return (_value, _next);
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
				while (++_index < _capacity)
				{
					var address = _begin + 0x10 * _index;

					var next = BSTSetEntry.GetNext(address);
					if (next == System.IntPtr.Zero) { continue; }

					var value = BSTSetEntry.GetValue(address);
					if (value == System.IntPtr.Zero) { continue; }

					_next = next;
					_value = value;

					return true;
				}

				return false;
			}

			public void Reset()
			{
				_index = -1;

//				_next = System.IntPtr.Zero;
//				_value = System.IntPtr.Zero;
			}
		}



		/// <param name="bstSet">BSTSet</param>
		/// <returns>BSTSetEntry</returns>
		static public System.IntPtr GetBegin(System.IntPtr bstSet)
		{
			if (bstSet == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bstSet"); }

			var begin = NetScriptFramework.Memory.ReadPointer(bstSet + 0x20 + 0x8);
			if (begin == System.IntPtr.Zero) { throw new Eggceptions.NullException("begin"); }

			return begin;
		}

		/// <param name="bstSet">BSTSet</param>
		static public System.Int32 GetCapacity(System.IntPtr bstSet)
		{
			if (bstSet == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bstSet"); }

			return NetScriptFramework.Memory.ReadInt32(bstSet + 0xC);
		}

		/// <param name="bstSet">BSTSet</param>
		static public System.Int32 GetCount(System.IntPtr bstSet)
		{
			if (bstSet == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bstSet"); }

			return BSTSet.GetCapacity(bstSet) - BSTSet.GetFreeCount(bstSet);
		}

		/// <param name="bstSet">BSTSet</param>
		static public System.Int32 GetFreeCount(System.IntPtr bstSet)
		{
			if (bstSet == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bstSet"); }

			return NetScriptFramework.Memory.ReadInt32(bstSet + 0x10);
		}
	}
}
