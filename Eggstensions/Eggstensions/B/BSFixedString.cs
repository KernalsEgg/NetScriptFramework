namespace Eggstensions
{
	public class BSFixedString : NativeObject
	{
		public BSFixedString(System.IntPtr address) : base(address)
		{
		}



		static public implicit operator BSFixedString(System.IntPtr address)
		{
			return new BSFixedString(address);
		}
	}
}
