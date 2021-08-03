namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x18)]
	unsafe public struct InventoryEntryData
	{
		[System.Runtime.InteropServices.FieldOffset(0x0)] public TESBoundObject* Item;



		// Member
		static public System.Boolean IsWorn(InventoryEntryData* inventoryEntryData)
		{
			return Eggstensions.Delegates.Instances.InventoryEntryData.IsWorn(inventoryEntryData) != 0;
		}
	}
}
