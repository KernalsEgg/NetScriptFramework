namespace Eggstensions
{
	public class BSTEventSource : NativeObject
	{
		public BSTEventSource(System.IntPtr address) : base(address)
		{
		}
		
		
		
		static public void AddEventSink(BSTEventSource eventSource, System.IntPtr eventSink)
		{
			Delegates.Instances.BSTEventSource.AddEventSink(eventSource, eventSink);
		}



		static public implicit operator BSTEventSource(System.IntPtr address)
		{
			return new BSTEventSource(address);
		}
	}
}
