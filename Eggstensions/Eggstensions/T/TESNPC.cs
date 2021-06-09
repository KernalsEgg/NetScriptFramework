namespace Eggstensions
{
	public class TESNPC : TESActorBase
	{
		public TESNPC(System.IntPtr address) : base(address)
		{
		}



		static public implicit operator TESNPC(System.IntPtr address)
		{
			return new TESNPC(address);
		}
	}
}
