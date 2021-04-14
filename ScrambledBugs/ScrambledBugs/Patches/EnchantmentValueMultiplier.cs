namespace ScrambledBugs.Patches
{
	internal class EnchantmentValueMultiplier
	{
		static protected class Offsets
		{
			static Offsets()
			{
				Offsets.EnchantmentGoldMult =	NetScriptFramework.Main.GameInfo.GetAddressOf(506059);
				Offsets.GetValue =				NetScriptFramework.Main.GameInfo.GetAddressOf(15757);
			}



			/// <summary> SkyrimSE.exe + 0x1DE45F8 </summary>
			static internal System.IntPtr EnchantmentGoldMult { get; }

			/// <summary> SkyrimSE.exe + 0x1D66E0 </summary>
			static internal System.IntPtr GetValue { get; }
		}

		static protected class Setting
		{
			static internal System.Single GetFloat(System.IntPtr setting)
			{
				return NetScriptFramework.Memory.ReadFloat(setting + 0x8);
			}
		}



		internal EnchantmentValueMultiplier()
		{
			// Armor
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = EnchantmentValueMultiplier.Offsets.GetValue + 0xEE,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 5,
				After = cpuRegisters => cpuRegisters.XMM0f *= System.Math.Max(EnchantmentValueMultiplier.Setting.GetFloat(EnchantmentValueMultiplier.Offsets.EnchantmentGoldMult), 0.0F),
			});

			// Weapon
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = EnchantmentValueMultiplier.Offsets.GetValue + 0x14A,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 5,
				Before = cpuRegisters =>
				{
					var enchantmentGoldMult = System.Math.Max(EnchantmentValueMultiplier.Setting.GetFloat(EnchantmentValueMultiplier.Offsets.EnchantmentGoldMult), 0.0F);
					
					cpuRegisters.XMM1f *= enchantmentGoldMult;
					cpuRegisters.XMM2f *= enchantmentGoldMult;
				},
			});
		}
	}
}
