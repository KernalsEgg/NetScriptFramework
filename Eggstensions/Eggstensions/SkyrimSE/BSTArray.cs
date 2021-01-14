﻿namespace Eggstensions.SkyrimSE
{
	public class BSTArray : System.Collections.Generic.IEnumerable<System.IntPtr>
	{
		public class Handle : System.Collections.Generic.IEnumerable<System.UInt32>
		{
			/// <param name = "bstArray">BSTArray&lt;T, BSTArrayHeapAllocator&gt;</param>
			public Handle(System.IntPtr bstArray)
			{
				if (bstArray == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(bstArray)); }

				Address = bstArray;
			}



			public System.IntPtr Address { get; }



			public System.Collections.Generic.IEnumerator<System.UInt32> GetEnumerator()
			{
				var bstArray = Address;
				var count = BSTArray.GetCount(bstArray);
				var begin = BSTArray.GetBegin(bstArray);
				if (begin == System.IntPtr.Zero) { yield break; }

				for (var i = 0; i < count; i++)
				{
					yield return NetScriptFramework.Memory.ReadUInt32(begin + 0x4 * i);
				}
			}

			System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}

		public class HandleAddress : System.Collections.Generic.IEnumerable<System.IntPtr>
		{
			/// <param name = "bstArray">BSTArray&lt;T, BSTArrayHeapAllocator&gt;</param>
			public HandleAddress(System.IntPtr bstArray)
			{
				if (bstArray == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(bstArray)); }

				Address = bstArray;
			}



			public System.IntPtr Address { get; }



			public System.Collections.Generic.IEnumerator<System.IntPtr> GetEnumerator()
			{
				var bstArray = Address;
				var count = BSTArray.GetCount(bstArray);
				var begin = BSTArray.GetBegin(bstArray);
				if (begin == System.IntPtr.Zero) { yield break; }

				for (var i = 0; i < count; i++)
				{
					yield return begin + 0x4 * i;
				}
			}

			System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}

		public class ReferenceFromHandle : System.Collections.Generic.IEnumerable<BSPointerHandle.ReferenceFromHandle>
		{
			/// <param name = "bstArray">BSTArray&lt;T, BSTArrayHeapAllocator&gt;</param>
			public ReferenceFromHandle(System.IntPtr bstArray)
			{
				if (bstArray == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(bstArray)); }

				Address = bstArray;
			}



			public System.IntPtr Address { get; }



			public System.Collections.Generic.IEnumerator<BSPointerHandle.ReferenceFromHandle> GetEnumerator()
			{
				var bstArray = Address;
				var count = BSTArray.GetCount(bstArray);
				var begin = BSTArray.GetBegin(bstArray);
				if (begin == System.IntPtr.Zero) { yield break; }

				for (var i = 0; i < count; i++)
				{
					yield return new BSPointerHandle.ReferenceFromHandle(begin + 0x4 * i);
				}
			}

			System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}



		/// <param name = "bstArray">BSTArray&lt;T, BSTArrayHeapAllocator&gt;</param>
		public BSTArray(System.IntPtr bstArray)
		{
			if (bstArray == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(bstArray)); }

			Address = bstArray;
		}



		public System.IntPtr Address { get; }



		public System.Collections.Generic.IEnumerator<System.IntPtr> GetEnumerator()
		{
			var bstArray = Address;
			var count = BSTArray.GetCount(bstArray);
			var begin = BSTArray.GetBegin(bstArray);
			if (begin == System.IntPtr.Zero) { yield break; }

			for (var i = 0; i < count; i++)
			{
				yield return NetScriptFramework.Memory.ReadPointer(begin + 0x8 * i);
			}
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}



		/// <param name = "bstArray">BSTArray&lt;T, BSTArrayHeapAllocator&gt;</param>
		static public System.Int32 GetCapacity(System.IntPtr bstArray)
		{
			if (bstArray == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(bstArray)); }

			return NetScriptFramework.Memory.ReadInt32(bstArray + 0x8);
		}

		/// <param name = "bstArray">BSTArray&lt;T, BSTArrayHeapAllocator&gt;</param>
		static public System.Int32 GetCount(System.IntPtr bstArray)
		{
			if (bstArray == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(bstArray)); }

			return NetScriptFramework.Memory.ReadInt32(bstArray + 0x10);
		}

		/// <param name = "bstArray">BSTArray&lt;T, BSTArrayHeapAllocator&gt;</param>
		static public System.IntPtr GetBegin(System.IntPtr bstArray)
		{
			if (bstArray == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(bstArray)); }

			return NetScriptFramework.Memory.ReadPointer(bstArray);
		}
	}
}