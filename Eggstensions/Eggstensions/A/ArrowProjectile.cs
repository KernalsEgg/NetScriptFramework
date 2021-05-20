namespace Eggstensions
{
	public class ArrowProjectile : MissileProjectile
	{
		public ArrowProjectile(System.IntPtr address) : base(address)
		{
		}



		static public implicit operator ArrowProjectile(System.IntPtr address)
		{
			return new ArrowProjectile(address);
		}
	}
}
