namespace Eggstensions
{
	namespace Marshal
	{
		[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x18)]
		abstract public class BSTArray : System.IDisposable
		{
			public class IntPtr : BSTArray<System.IntPtr>
			{
				public System.Int32 Push(ref System.IntPtr element)
				{
					return Delegates.Instances.BSTArray.IntPtr.Push(this, ref element);
				}
			}



			~BSTArray()
			{
				this.Dispose(false);
			}



			[System.Runtime.InteropServices.FieldOffset(0x0)]
			public System.IntPtr Elements	= System.IntPtr.Zero;

			[System.Runtime.InteropServices.FieldOffset(0x8)]
			public System.Int32 Capacity	= 0;

			[System.Runtime.InteropServices.FieldOffset(0x10)]
			public System.Int32 Length		= 0;



			virtual protected void Dispose(System.Boolean disposing)
			{
				this.Deallocate();
			}



			public void Deallocate()
			{
				Delegates.Instances.BSTArray.Deallocate(this);
			}

			public void Dispose()
			{
				this.Dispose(true);
				System.GC.SuppressFinalize(this);
			}
		}

		abstract public class BSTArray<T> : BSTArray, System.Collections.Generic.IEnumerable<T>
			where T : unmanaged
		{
			public System.Collections.Generic.IEnumerator<T> GetEnumerator()
			{
				for (System.Int32 index = 0; index < Length; index++)
				{
					yield return Memory.Read<T>(Elements, Memory<T>.Size * index);
				}
			}

			System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
			{
				return this.GetEnumerator();
			}
		}
	}



	abstract public class BSTArray : NativeObject
	{
		public class IntPtr : BSTArray<System.IntPtr>
		{
			public IntPtr(System.IntPtr address) : base(address)
			{
			}

			public IntPtr(System.IntPtr address, System.Int32 offset) : base(address + offset)
			{
			}



			public System.Int32 Push(ref System.IntPtr element)
			{
				return Delegates.Instances.BSTArray.IntPtr.Push(this, ref element);
			}



			static public implicit operator IntPtr(System.IntPtr address)
			{
				return new IntPtr(address);
			}
		}
		
		
		
		public BSTArray(System.IntPtr address) : base(address)
		{
		}



		public System.IntPtr Elements
		{
			get
			{
				return Memory.Read<System.IntPtr>(this, 0x0);
			}
		}

		public System.Int32 Capacity
		{
			get
			{
				return Memory.Read<System.Int32>(this, 0x8);
			}
		}

		public System.Int32 Length
		{
			get
			{
				return Memory.Read<System.Int32>(this, 0x10);
			}
		}



		public void Deallocate()
		{
			Delegates.Instances.BSTArray.Deallocate(this);
		}
	}

	abstract public class BSTArray<T> : BSTArray, System.Collections.Generic.IEnumerable<T>
		where T : unmanaged
	{
		public BSTArray(System.IntPtr address) : base(address)
		{
		}



		public System.Collections.Generic.IEnumerator<T> GetEnumerator()
		{
			var elements = Elements;
			var length = Length;

			for (System.Int32 index = 0; index < length; index++)
			{
				yield return Memory.Read<T>(elements, Memory<T>.Size * index);
			}
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}
}
