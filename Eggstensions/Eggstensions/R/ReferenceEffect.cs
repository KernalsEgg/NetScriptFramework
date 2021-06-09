namespace Eggstensions
{
	public class ReferenceEffect : VirtualObject
	{
		public ReferenceEffect(System.IntPtr address) : base(address)
		{
		}



		public ReferenceEffectController Controller
		{
			get
			{
				return Memory.Read<System.IntPtr>(this, 0x30);
			}
		}
	}
}
