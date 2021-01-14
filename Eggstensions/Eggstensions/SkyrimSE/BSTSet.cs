namespace Eggstensions.SkyrimSE
{
	public class BSTSet : System.Collections.Generic.IEnumerable<(System.IntPtr value, System.IntPtr next)>
	{
		public BSTSet(System.IntPtr bstSet)
		{
			if (bstSet == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(bstSet)); }

			Address = bstSet;
		}



		public System.IntPtr Address { get; }



		public System.Collections.Generic.IEnumerator<(System.IntPtr value, System.IntPtr next)> GetEnumerator()
		{
			var bstSet = Address;
			var capacity = BSTSet.GetCapacity(bstSet);
			var begin = BSTSet.GetBegin(bstSet);
			if (begin == System.IntPtr.Zero) { yield break; }

			for (var i = 0; i < capacity; i++)
			{
				var bstSetEntry = begin + 0x10 * i;
				
				var next = BSTSetEntry.GetNext(bstSetEntry);
				if (next == System.IntPtr.Zero) { continue; }

				var value = BSTSetEntry.GetValue(bstSetEntry);
				if (value == System.IntPtr.Zero) { continue; }

				yield return (value, next);
			}
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}



		/// <param name="bstSet">BSTSet</param>
		/// <returns>BSTSetEntry</returns>
		static public System.IntPtr GetBegin(System.IntPtr bstSet)
		{
			if (bstSet == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(bstSet)); }

			return NetScriptFramework.Memory.ReadPointer(bstSet + 0x20 + 0x8);
		}

		/// <param name="bstSet">BSTSet</param>
		static public System.Int32 GetCapacity(System.IntPtr bstSet)
		{
			if (bstSet == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(bstSet)); }

			return NetScriptFramework.Memory.ReadInt32(bstSet + 0xC);
		}

		/// <param name="bstSet">BSTSet</param>
		static public System.Int32 GetCount(System.IntPtr bstSet)
		{
			if (bstSet == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(bstSet)); }

			return BSTSet.GetCapacity(bstSet) - BSTSet.GetFreeCount(bstSet);
		}

		/// <param name="bstSet">BSTSet</param>
		static public System.Int32 GetFreeCount(System.IntPtr bstSet)
		{
			if (bstSet == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(bstSet)); }

			return NetScriptFramework.Memory.ReadInt32(bstSet + 0x10);
		}
	}
}
