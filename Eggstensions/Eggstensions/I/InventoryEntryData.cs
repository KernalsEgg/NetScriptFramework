namespace Eggstensions
{
	public class InventoryEntryData : NativeObject
	{
		public InventoryEntryData(System.IntPtr address) : base(address)
		{
		}



		public TESBoundObject Item
		{
			get
			{
				return Memory.Read<System.IntPtr>(this, 0x0);
			}
		}



		public System.Boolean IsWorn()
		{
			return Delegates.Instances.InventoryEntryData.IsWorn(this) != 0;
		}



		static public implicit operator InventoryEntryData(System.IntPtr address)
		{
			return new InventoryEntryData(address);
		}
	}
}
