namespace Eggstensions
{
	public enum BSEventNotifyControl : System.Int32
	{
		Continue	= 0,
		Stop		= 1
	}



	public class BSTEventSink : System.IDisposable
	{
		public BSTEventSink(Eggstensions.Delegates.Types.BSTEventSink.ProcessEvent processEvent)
		{
			Destructor		= eventSink => this.Dispose();
			ProcessEvent	= processEvent;

			Address					= System.Runtime.InteropServices.Marshal.AllocHGlobal(0x1 * Memory.Size<System.IntPtr>.Unmanaged);
			VirtualFunctionTable	= System.Runtime.InteropServices.Marshal.AllocHGlobal(0x2 * Memory.Size<System.IntPtr>.Unmanaged);

			Memory.Write<System.IntPtr>
			(
				Address,
				0x0 * Memory.Size<System.IntPtr>.Unmanaged,
				VirtualFunctionTable
			);
			Memory.Write<System.IntPtr>
			(
				VirtualFunctionTable,
				0x0 * Memory.Size<System.IntPtr>.Unmanaged,
				System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<Eggstensions.Delegates.Types.BSTEventSink.Destructor>(Destructor)
			);
			Memory.Write<System.IntPtr>
			(
				VirtualFunctionTable,
				0x1 * Memory.Size<System.IntPtr>.Unmanaged,
				System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<Eggstensions.Delegates.Types.BSTEventSink.ProcessEvent>(ProcessEvent)
			);
		}

		~BSTEventSink()
		{
			this.Dispose(false);
		}



		public Eggstensions.Delegates.Types.BSTEventSink.Destructor Destructor { get; }
		public Eggstensions.Delegates.Types.BSTEventSink.ProcessEvent ProcessEvent { get; }
		public System.IntPtr Address { get; }
		public System.IntPtr VirtualFunctionTable { get; }



		virtual public void Dispose(System.Boolean disposing)
		{
			System.Runtime.InteropServices.Marshal.FreeHGlobal(Address);
			System.Runtime.InteropServices.Marshal.FreeHGlobal(VirtualFunctionTable);
		}



		public void Dispose()
		{
			this.Dispose(true);
			System.GC.SuppressFinalize(this);
		}
	}
}
