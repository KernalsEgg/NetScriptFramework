namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x58)]
	unsafe public struct BSTEventSource
	{
		// Member
		static public void AddEventSink(BSTEventSource* eventSource, System.IntPtr eventSink)
		{
			Eggstensions.Delegates.Instances.BSTEventSource.AddEventSink(eventSource, eventSink);
		}

		static public void RemoveEventSink(BSTEventSource* eventSource, System.IntPtr eventSink)
		{
			Eggstensions.Delegates.Instances.BSTEventSource.RemoveEventSink(eventSource, eventSink);
		}
	}
}
