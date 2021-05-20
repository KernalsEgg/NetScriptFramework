namespace Eggstensions
{
	public class ScriptEventSourceHolder : NativeObject
	{
		public ScriptEventSourceHolder(System.IntPtr address) : base(address)
		{
		}



		static public ScriptEventSourceHolder Instance
		{
			get
			{
				return Delegates.Instances.ScriptEventSourceHolder.GetInstance();
			}
		}



		static public BSTEventSource TESHitEvent
		{
			get
			{
				return ScriptEventSourceHolder.Instance + 0x5D8;
			}
		}



		static public implicit operator ScriptEventSourceHolder(System.IntPtr address)
		{
			return new ScriptEventSourceHolder(address);
		}
	}
}
