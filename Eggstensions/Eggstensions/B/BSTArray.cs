namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x18)]
	unsafe public struct BSTArray
	{
		[System.Runtime.InteropServices.FieldOffset(0x0)] public System.IntPtr Elements;
		[System.Runtime.InteropServices.FieldOffset(0x8)] public System.Int32 Capacity;
		[System.Runtime.InteropServices.FieldOffset(0x10)] public System.Int32 Length;
		
		
		
		// Member
		static public System.Int32 Push(BSTArray* array, System.IntPtr element)
		{
			return Eggstensions.Delegates.Instances.BSTArray.IntPtr.Push(array, element);
		}

		static public void Deallocate(BSTArray* array)
		{
			Eggstensions.Delegates.Instances.BSTArray.Deallocate(array);
		}
	}
}
