namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x20)]
	unsafe public struct InventoryChanges
	{
		// Member
		static public void ResetWeight(InventoryChanges* inventoryChanges)
		{
			Eggstensions.Delegates.Instances.InventoryChanges.ResetWeight(inventoryChanges);
		}
	}
}
