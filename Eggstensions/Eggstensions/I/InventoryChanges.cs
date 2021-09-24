using Eggstensions.ExtensionMethods;



namespace Eggstensions
{
	unsafe public struct InventoryChanges
	{
		public void ResetWeight()
		{
			var resetWeight = (delegate* unmanaged[Cdecl]<InventoryChanges*, void>)Eggstensions.Offsets.InventoryChanges.ResetWeight;

			ResetWeight(this.AsPointer());



			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			void ResetWeight(InventoryChanges* inventoryChanges)
			{
				resetWeight(inventoryChanges);
			}
		}
	}
}
