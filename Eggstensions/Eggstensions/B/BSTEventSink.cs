namespace Eggstensions
{
	public enum BSEventNotifyControl : System.Int32
	{
		Continue	= 0,
		Stop		= 1
	}



	unsafe public class BSTEventSink : System.IDisposable
	{
		/// <param name="processEvent">BSEventNotifyControl ProcessEvent(System.IntPtr eventSink, void* eventArguments, void* eventSource)</param>
		public BSTEventSink(delegate* unmanaged[Cdecl]<System.IntPtr, void*, BSTEventSource*, System.Int32> processEvent)
		{
			VirtualFunctionTable	= System.Runtime.InteropServices.Marshal.AllocHGlobal(0x2 * System.Runtime.CompilerServices.Unsafe.SizeOf<System.IntPtr>());
			Address					= System.Runtime.InteropServices.Marshal.AllocHGlobal(0x1 * System.Runtime.CompilerServices.Unsafe.SizeOf<System.IntPtr>());

			((System.IntPtr*)VirtualFunctionTable)[0]	= new System.IntPtr((delegate* unmanaged[Cdecl]<System.IntPtr, void>)&Destructor);
			((System.IntPtr*)VirtualFunctionTable)[1]	= new System.IntPtr(processEvent);
			*(System.IntPtr*)Address					= VirtualFunctionTable;



			[System.Runtime.InteropServices.UnmanagedCallersOnly(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
			static void Destructor(System.IntPtr eventSink)
			{
				System.Runtime.InteropServices.Marshal.FreeHGlobal(eventSink);					// Address
				System.Runtime.InteropServices.Marshal.FreeHGlobal(*(System.IntPtr*)eventSink);	// VirtualFunctionTable
			}
		}



		public System.IntPtr Address { get; }
		public System.IntPtr VirtualFunctionTable { get; }



		public void Dispose()
		{
			System.Runtime.InteropServices.Marshal.FreeHGlobal(Address);
			System.Runtime.InteropServices.Marshal.FreeHGlobal(VirtualFunctionTable);
		}
	}
}
