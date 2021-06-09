namespace Eggstensions
{
	public class Setting<T> : VirtualObject
		where T : unmanaged
	{
		public Setting(System.IntPtr address) : base(address)
		{
		}



		public T Value
		{
			get
			{
				return Memory.Read<T>(this, 0x8);
			}
		}

		public System.String Name
		{
			get
			{
				return Memory.ReadString(Memory.Read<System.IntPtr>(this, 0x10));
			}
		}
	}
}
