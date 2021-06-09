namespace Eggstensions
{
	public class BSTEventSource : NativeObject
	{
		public BSTEventSource(System.IntPtr address) : base(address)
		{
		}
		
		
		
		public void AddEventSink(BSTEventSink eventSink)
		{
			Delegates.Instances.BSTEventSource.AddEventSink(this, eventSink);
		}

		public void RemoveEventSink(BSTEventSink eventSink)
		{
			Delegates.Instances.BSTEventSource.RemoveEventSink(this, eventSink);
		}



		static public implicit operator BSTEventSource(System.IntPtr address)
		{
			return new BSTEventSource(address);
		}
	}
}
