namespace Eggstensions
{
	public enum BSEventNotifyControl : System.Int32
	{
		Continue	= 0,
		Stop		= 1
	}



	unsafe public class BSTEventSink
	{
		/// <param name="processEvent">BSEventNotifyControl ProcessEvent(System.IntPtr eventSink, void* eventArguments, void* eventSource)</param>
		public BSTEventSink(delegate* unmanaged[Cdecl]<System.IntPtr, void*, void*, System.Int32> processEvent)
		{
			VirtualFunctionTable	= System.Runtime.InteropServices.Marshal.AllocHGlobal(0x2 * System.Runtime.CompilerServices.Unsafe.SizeOf<System.IntPtr>());
			Address					= System.Runtime.InteropServices.Marshal.AllocHGlobal(0x1 * System.Runtime.CompilerServices.Unsafe.SizeOf<System.IntPtr>());

			System.Runtime.CompilerServices.Unsafe.Write<System.IntPtr>
			(
				(VirtualFunctionTable + 0x0 * System.Runtime.CompilerServices.Unsafe.SizeOf<System.IntPtr>()).ToPointer(),
				new System.IntPtr((delegate* unmanaged[Cdecl]<System.IntPtr, void>)&Destructor)
			);

			System.Runtime.CompilerServices.Unsafe.Write<System.IntPtr>
			(
				(VirtualFunctionTable + 0x1 * System.Runtime.CompilerServices.Unsafe.SizeOf<System.IntPtr>()).ToPointer(),
				new System.IntPtr(processEvent)
			);

			System.Runtime.CompilerServices.Unsafe.Write<System.IntPtr>
			(
				(Address + 0x0 * System.Runtime.CompilerServices.Unsafe.SizeOf<System.IntPtr>()).ToPointer(),
				VirtualFunctionTable
			);
		}



		public System.IntPtr Address { get; }
		public System.IntPtr VirtualFunctionTable { get; }



		[System.Runtime.InteropServices.UnmanagedCallersOnly(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
		static public void Destructor(System.IntPtr eventSink)
		{
			System.Runtime.InteropServices.Marshal.FreeHGlobal(eventSink);					// Address
			System.Runtime.InteropServices.Marshal.FreeHGlobal(*(System.IntPtr*)eventSink);	// VirtualFunctionTable
		}
	}
}
