using Eggstensions.ExtensionMethods;



namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x18)]
	unsafe public struct InventoryEntryData
	{
		[System.Runtime.InteropServices.FieldOffset(0x0)] public TESBoundObject* Item;



		// Member
		public System.Boolean IsWorn()
		{
			var isWorn = (delegate* unmanaged[Cdecl]<InventoryEntryData*, System.Byte>)Eggstensions.Offsets.InventoryEntryData.IsWorn;

			return IsWorn(this.AsPointer()) != 0;



			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			System.Byte IsWorn(InventoryEntryData* inventoryEntryData)
			{
				return isWorn(inventoryEntryData);
			}
		}
	}
}
