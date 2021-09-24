namespace Eggstensions
{
	// LayoutKind.Explicit does not support generic types
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Size = 0x4)]
	unsafe public struct BSPointerHandle<T>
		where T : unmanaged, ITESObjectREFR
	{
		public System.UInt32 Handle;



		// Static
		static public BSPointerHandle<TTESObjectREFR>* GetHandle<TTESObjectREFR>(BSPointerHandle<TTESObjectREFR>* handle, NiPointer<TTESObjectREFR> smartPointer)
			where TTESObjectREFR : unmanaged, ITESObjectREFR
		{
			var getHandle = (delegate* unmanaged[Cdecl]<BSPointerHandle<TTESObjectREFR>*, NiPointer<TTESObjectREFR>, BSPointerHandle<TTESObjectREFR>*>)Eggstensions.Offsets.BSPointerHandle.GetHandle;

			return GetHandle(handle, smartPointer);



			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			BSPointerHandle<TTESObjectREFR>* GetHandle(BSPointerHandle<TTESObjectREFR>* handle, NiPointer<TTESObjectREFR> smartPointer)
			{
				return getHandle(handle, smartPointer);
			}
		}

		static public System.Boolean GetSmartPointer<TTESObjectREFR>(BSPointerHandle<TTESObjectREFR>* handle, NiPointer<TTESObjectREFR>* smartPointer)
			where TTESObjectREFR : unmanaged, ITESObjectREFR
		{
			var getSmartPointer = (delegate* unmanaged[Cdecl]<BSPointerHandle<TTESObjectREFR>*, NiPointer<TTESObjectREFR>*, System.Byte>)Eggstensions.Offsets.BSPointerHandle.GetSmartPointer;

			return GetSmartPointer(handle, smartPointer) != 0;



			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			System.Byte GetSmartPointer(BSPointerHandle<TTESObjectREFR>* handle, NiPointer<TTESObjectREFR>* smartPointer)
			{
				return getSmartPointer(handle, smartPointer);
			}
		}
	}
}
