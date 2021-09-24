using Eggstensions.ExtensionMethods;



namespace Eggstensions
{
	public enum ExtraDataType : System.Int32
	{
		Charge		= 0x28,
		Enchantment	= 0x9B
	}



	unsafe public struct ExtraDataList
	{
		public System.Single GetCharge()
		{
			var getCharge = (delegate* unmanaged[Cdecl]<ExtraDataList*, System.Single>)Eggstensions.Offsets.ExtraDataList.GetCharge;

			return GetCharge(this.AsPointer());



			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			System.Single GetCharge(ExtraDataList* extraDataList)
			{
				return getCharge(extraDataList);
			}
		}

		public System.Boolean HasExtraData(ExtraDataType extraDataType)
		{
			var hasExtraData = (delegate* unmanaged[Cdecl]<ExtraDataList*, System.Int32, System.Byte>)Eggstensions.Offsets.ExtraDataList.HasExtraData;

			return HasExtraData(this.AsPointer(), (System.Int32)extraDataType) != 0;



			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			System.Byte HasExtraData(ExtraDataList* extraDataList, System.Int32 extraDataType)
			{
				return hasExtraData(extraDataList, extraDataType);
			}
		}
	}
}
