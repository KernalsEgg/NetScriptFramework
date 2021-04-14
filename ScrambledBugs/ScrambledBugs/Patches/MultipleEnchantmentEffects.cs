namespace ScrambledBugs.Patches
{
	internal class MultipleEnchantmentEffects
	{
		static protected class Offsets
		{
			static Offsets()
			{
				Offsets.IsNotCostliestEffect = NetScriptFramework.Main.GameInfo.GetAddressOf(50366, 0x23, 0, "0F85 C7010000"); // 6
			}



			/// <summary> SkyrimSE.exe + 0x868A00 </summary>
			static internal System.IntPtr IsNotCostliestEffect { get; }
		}



		internal MultipleEnchantmentEffects()
		{
			NetScriptFramework.Memory.WriteNop(MultipleEnchantmentEffects.Offsets.IsNotCostliestEffect, 6);
		}
	}
}
