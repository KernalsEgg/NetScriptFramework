using Eggstensions.Interoperability.Managed; // Memory



namespace Eggstensions
{
	public class VirtualObject : NativeObject
	{
		public VirtualObject(System.IntPtr address) : base(address)
		{
		}



		public System.IntPtr this[System.Int32 index]
		{
			get
			{
				return Memory.ReadIntPtr(Memory.ReadIntPtr(this, 0x0), 0x8 * index);
			}
		}
	}
}
