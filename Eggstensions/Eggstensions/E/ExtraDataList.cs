namespace Eggstensions
{
	public enum ExtraDataType : System.Int32
	{
		Charge		= 0x28,
		Enchantment	= 0x9B
	}



	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x18)]
	unsafe public struct ExtraDataList
	{
		// Member
		static public System.Single GetCharge(ExtraDataList* extraDataList)
		{
			return Eggstensions.Delegates.Instances.ExtraDataList.GetCharge(extraDataList);
		}

		static public System.Boolean HasExtraData(ExtraDataList* extraDataList, ExtraDataType extraDataType)
		{
			return Eggstensions.Delegates.Instances.ExtraDataList.HasExtraData(extraDataList, (System.Int32)extraDataType) != 0;
		}
	}
}
