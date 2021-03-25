namespace ScrambledBugs.Fixes
{
	internal class ActiveEffectConditions
	{
		static internal class Offsets
		{
			static Offsets()
			{
				Offsets.ActiveEffectConditionUpdateFrequency = NetScriptFramework.Main.GameInfo.GetAddressOf(516661);	// SkyrimSE.exe + 0x2F25CE8
				Offsets.UpdateActiveEffectConditions = NetScriptFramework.Main.GameInfo.GetAddressOf(33287);			// SkyrimSE.exe + 0x53E3E0
			}



			static internal System.IntPtr ActiveEffectConditionUpdateFrequency { get; }
			static internal System.IntPtr UpdateActiveEffectConditions { get; }
		}
		
		
		
		internal ActiveEffectConditions()
		{
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = ActiveEffectConditions.Offsets.UpdateActiveEffectConditions + 0xDD,
				Pattern = "F3 0F 10 4F 70",
				ReplaceLength = 5,
				IncludeLength = 0,
				Before = cpuRegisters => cpuRegisters.XMM1f = ActiveEffectConditions.GetElapsedSecondsModulus(cpuRegisters.DI, cpuRegisters.XMM6f),
			});
		}

		

		static private System.Single GetElapsedSecondsModulus(System.IntPtr activeEffect, System.Single delta)
		{
			System.Single modulus;
			var elapsedSeconds = NetScriptFramework.Memory.ReadFloat(activeEffect + 0x70);

			if (elapsedSeconds <= 0.0F)
			{
				modulus = 0.0F;
				NetScriptFramework.Memory.WriteFloat(activeEffect + 0x8C, delta);
			}
			else
			{
				modulus = NetScriptFramework.Memory.ReadFloat(activeEffect + 0x8C);
				var updateInterval = 1.0F / NetScriptFramework.Memory.ReadFloat(ActiveEffectConditions.Offsets.ActiveEffectConditionUpdateFrequency);

				if (modulus <= 0.0F || System.Single.IsNaN(modulus) || System.Single.IsInfinity(modulus))
				{
					modulus = elapsedSeconds % updateInterval;
				}
				else
				{
					modulus %= updateInterval;
				}

				NetScriptFramework.Memory.WriteFloat(activeEffect + 0x8C, modulus + delta);
			}

			return modulus;
		}
	}
}
