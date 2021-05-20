using Eggstensions.Interoperability.Managed; // Memory



namespace Eggstensions
{
	public class NiAVObject : NiObject
	{
		public NiAVObject(System.IntPtr address) : base(address)
		{
		}



		public NiNode GetParent()
		{
			return Memory.ReadIntPtr(this, 0x30);
		}



		static public implicit operator NiAVObject(System.IntPtr address)
		{
			return new NiAVObject(address);
		}
	}
}
