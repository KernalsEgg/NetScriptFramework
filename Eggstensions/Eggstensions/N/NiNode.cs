namespace Eggstensions
{
	public class NiNode : NiAVObject
	{
		public NiNode(System.IntPtr address) : base(address)
		{
		}



		static public implicit operator NiNode(System.IntPtr address)
		{
			return new NiNode(address);
		}
	}
}
