namespace Eggstensions
{
	public class bhkWorld : VirtualObject
	{
		public bhkWorld(System.IntPtr address) : base(address)
		{
		}



		static public implicit operator bhkWorld(System.IntPtr address)
		{
			return new bhkWorld(address);
		}
	}
}
