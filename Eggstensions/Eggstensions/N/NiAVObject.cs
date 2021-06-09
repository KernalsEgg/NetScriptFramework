namespace Eggstensions
{
	public class NiAVObject : NiObject
	{
		public NiAVObject(System.IntPtr address) : base(address)
		{
		}



		public NiNode GetParent()
		{
			return Memory.Read<System.IntPtr>(this, 0x30);
		}



		static public implicit operator NiAVObject(System.IntPtr address)
		{
			return new NiAVObject(address);
		}
	}
}
