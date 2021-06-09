namespace Eggstensions
{
	public enum BSEventNotifyControl : System.Int32
	{
		Continue	= 0,
		Stop		= 1
	}
	
	
	
	public class BSTEventSink : NativeObject, System.IDisposable
	{
		public BSTEventSink(Delegates.Types.BSTEventSink.ProcessEvent processEvent) : base(System.Runtime.InteropServices.Marshal.AllocHGlobal(0x1 * Memory<System.IntPtr>.Size))
		{
			VirtualFunctionTable = System.Runtime.InteropServices.Marshal.AllocHGlobal(0x2 * Memory<System.IntPtr>.Size);

			Destructor		= eventSink => this.Dispose();
			ProcessEvent	= processEvent;

			Memory.Write<System.IntPtr>(Address, 0x0 * Memory<System.IntPtr>.Size, VirtualFunctionTable);
			Memory.Write<System.IntPtr>(VirtualFunctionTable, 0x0 * Memory<System.IntPtr>.Size, System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(Destructor));
			Memory.Write<System.IntPtr>(VirtualFunctionTable, 0x1 * Memory<System.IntPtr>.Size, System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(ProcessEvent));
		}

		~BSTEventSink()
		{
			this.Dispose(false);
		}



		public Delegates.Types.BSTEventSink.Destructor Destructor { get; }
		public Delegates.Types.BSTEventSink.ProcessEvent ProcessEvent { get; }
		public System.IntPtr VirtualFunctionTable { get; }



		virtual public void Dispose(System.Boolean disposing)
		{
			System.Runtime.InteropServices.Marshal.FreeHGlobal(Address);
			System.Runtime.InteropServices.Marshal.FreeHGlobal(VirtualFunctionTable);
		}



		public void AddHarvestEventSink()
		{
			Delegates.Instances.BSTEventSink.AddHarvestEventSink(this);
		}

		public void Dispose()
		{
			this.Dispose(true);
			System.GC.SuppressFinalize(this);
		}

		public void RemoveHarvestEventSink()
		{
			Delegates.Instances.BSTEventSink.RemoveHarvestEventSink(this);
		}
	}
}
