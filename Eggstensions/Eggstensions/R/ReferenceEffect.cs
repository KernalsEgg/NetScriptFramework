using Eggstensions.Interoperability.Managed; // Memory



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
				return Memory.ReadIntPtr(this, 0x30);
			}
		}
	}
}
