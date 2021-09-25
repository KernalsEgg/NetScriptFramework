namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x4)]
	unsafe public struct BSPointerHandle
	{
		[System.Runtime.InteropServices.FieldOffset(0x0)] public System.UInt32 Handle;



		// Static
		static public BSPointerHandle* GetHandle(BSPointerHandle* handle, NiPointer smartPointer)
		{
			var getHandle = (delegate* unmanaged[Cdecl]<BSPointerHandle*, NiPointer, BSPointerHandle*>)Eggstensions.Offsets.BSPointerHandle.GetHandle;

			return GetHandle(handle, smartPointer);



			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			BSPointerHandle* GetHandle(BSPointerHandle* handle, NiPointer smartPointer)
			{
				return getHandle(handle, smartPointer);
			}
		}

		static public System.Boolean GetSmartPointer(BSPointerHandle* handle, NiPointer* smartPointer)
		{
			var getSmartPointer = (delegate* unmanaged[Cdecl]<BSPointerHandle*, NiPointer*, System.Byte>)Eggstensions.Offsets.BSPointerHandle.GetSmartPointer;

			return GetSmartPointer(handle, smartPointer) != 0;



			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			System.Byte GetSmartPointer(BSPointerHandle* handle, NiPointer* smartPointer)
			{
				return getSmartPointer(handle, smartPointer);
			}
		}
	}
}
