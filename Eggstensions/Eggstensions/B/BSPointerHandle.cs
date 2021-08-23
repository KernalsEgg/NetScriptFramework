namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x4)]
	unsafe public struct BSPointerHandle
	{
		[System.Runtime.InteropServices.FieldOffset(0x0)] public System.UInt32 Handle;



		static public BSPointerHandle* GetHandle(BSPointerHandle* handle, NiPointer smartPointer)
		{
			return Eggstensions.Delegates.Instances.BSPointerHandle.GetHandle(handle, smartPointer);
		}

		static public System.Boolean GetSmartPointer(BSPointerHandle* handle, NiPointer* smartPointer)
		{
			return Eggstensions.Delegates.Instances.BSPointerHandle.GetSmartPointer(handle, smartPointer) != 0;
		}
	}
}
