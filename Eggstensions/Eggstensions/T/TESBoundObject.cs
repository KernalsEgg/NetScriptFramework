namespace Eggstensions
{
	public class TESBoundObject : TESForm
	{
		public TESBoundObject(System.IntPtr address) : base(address)
		{
		}



		static public implicit operator TESBoundObject(System.IntPtr address)
		{
			return new TESBoundObject(address);
		}
	}
}
