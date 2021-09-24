using Eggstensions.ExtensionMethods;



namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x18)]
	unsafe public struct BSTArray : System.IDisposable
	{
		[System.Runtime.InteropServices.FieldOffset(0x0)] public System.IntPtr Elements;
		[System.Runtime.InteropServices.FieldOffset(0x8)] public System.Int32 Capacity;
		[System.Runtime.InteropServices.FieldOffset(0x10)] public System.Int32 Length;



		// Member
		public void Deallocate()
		{
			var deallocate = (delegate* unmanaged[Cdecl]<BSTArray*, void>)Eggstensions.Offsets.BSTArray.Deallocate;

			Deallocate(this.AsPointer());



			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			void Deallocate(BSTArray* array)
			{
				deallocate(array);
			}
		}

		public void Dispose()
		{
			Deallocate();
		}

		public System.Int32 Push(void* element)
		{
			var push = (delegate* unmanaged[Cdecl]<BSTArray*, void*, System.Int32>)Eggstensions.Offsets.BSTArray.IntPtr.Push;

			return Push(this.AsPointer(), element);



			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			System.Int32 Push(BSTArray* array, void* element)
			{
				return push(array, element);
			}
		}
	}
}
