namespace ScrambledBugs.Patches
{
	internal class MultipleEnchantmentEffects
	{
		static protected class Offsets
		{
			static Offsets()
			{
				Offsets.ImproveEffect = NetScriptFramework.Main.GameInfo.GetAddressOf(50366);
				Offsets.IsNotCostliestEffect = NetScriptFramework.Main.GameInfo.GetAddressOf(50366, 0x23, 0, "0F85 C7010000"); // 6
			}



			/// <summary> SkyrimSE.exe + 0x868A00 </summary>
			static internal System.IntPtr ImproveEffect { get; }

			/// <summary> SkyrimSE.exe + 0x868A00 </summary>
			static internal System.IntPtr IsNotCostliestEffect { get; }
		}



		internal MultipleEnchantmentEffects()
		{
			NetScriptFramework.Memory.WriteNop(MultipleEnchantmentEffects.Offsets.IsNotCostliestEffect, 6);

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = MultipleEnchantmentEffects.Offsets.ImproveEffect + 0x126,
				Pattern = "48 85 C0" + "74 4E",
				ReplaceLength = 3 + 2,
				IncludeLength = 0,
				Before = cpuRegisters =>
				{
					var enchantmentEntry = cpuRegisters.AX;

					if (enchantmentEntry == System.IntPtr.Zero)
					{
						cpuRegisters.IP += 0x4E;

						return;
					}

					var effect = cpuRegisters.BX;
					var costliestEffect = NetScriptFramework.Memory.ReadPointer(cpuRegisters.DI + 0x28);

					if (effect != costliestEffect)
					{
						cpuRegisters.XMM1f = cpuRegisters.XMM2f; // power = maximumPower
						cpuRegisters.IP += 0x4E;

						return;
					}
				},
			});
		}
	}
}
