namespace Eggstensions
{
	public class InventoryChanges : NativeObject
	{
		public InventoryChanges(System.IntPtr address) : base(address)
		{
		}



		public void ResetWeight()
		{
			Delegates.Instances.InventoryChanges.ResetWeight(this);
		}



		static public implicit operator InventoryChanges(System.IntPtr address)
		{
			return new InventoryChanges(address);
		}
	}
}
