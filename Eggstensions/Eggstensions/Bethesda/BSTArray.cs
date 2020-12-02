namespace Eggstensions.Bethesda
{
	static public class BSTArray
	{
		/// <param name = "bstArray">BSTArray&lt;T, BSTArrayHeapAllocator&gt;</param>
		static public System.Int32 GetCapacity(System.IntPtr bstArray)
		{
			if (bstArray == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bstArray"); }

			return NetScriptFramework.Memory.ReadInt32(bstArray + 0x8);
		}

		/// <param name = "bstArray">BSTArray&lt;T, BSTArrayHeapAllocator&gt;</param>
		static public System.Int32 GetCount(System.IntPtr bstArray)
		{
			if (bstArray == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bstArray"); }

			return NetScriptFramework.Memory.ReadInt32(bstArray + 0x10);
		}

		/// <param name = "bstArray">BSTArray&lt;T, BSTArrayHeapAllocator&gt;</param>
		static public System.IntPtr GetBegin(System.IntPtr bstArray)
		{
			if (bstArray == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bstArray"); }

			var begin = NetScriptFramework.Memory.ReadPointer(bstArray);
			if (begin == System.IntPtr.Zero) { throw new Eggceptions.NullException("begin"); }

			return begin;
		}

		static public System.Collections.Generic.IEnumerable<System.IntPtr> IntPtr(System.IntPtr bstArray)
		{
			if (bstArray == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bstArray"); }

			var count = BSTArray.GetCount(bstArray);
			var begin = BSTArray.GetBegin(bstArray);

			for (var i = 0; i < count; i++)
			{
				yield return NetScriptFramework.Memory.ReadPointer(begin + 0x8 * i);
			}
		}

		static public System.Collections.Generic.IEnumerable<System.UInt32> UInt32(System.IntPtr bstArray)
		{
			if (bstArray == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bstArray"); }

			var count = BSTArray.GetCount(bstArray);
			var begin = BSTArray.GetBegin(bstArray);

			for (var i = 0; i < count; i++)
			{
				yield return NetScriptFramework.Memory.ReadUInt32(begin + 0x4 * i);
			}
		}
	}
}
