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
				return Memory.Read<System.IntPtr>(Memory.Read<System.IntPtr>(this, 0x0), Memory<System.IntPtr>.Size * index);
			}
		}
	}
}
