namespace Eggstensions.Bethesda.BSTArray
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
	}
}
