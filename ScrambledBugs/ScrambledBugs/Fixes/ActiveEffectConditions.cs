namespace ScrambledBugs.Fixes
{
	internal class ActiveEffectConditions
	{
		internal ActiveEffectConditions()
		{
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = ActiveEffectConditions._updateActiveEffectConditions + 0xDD,
				Pattern = "F3 0F 10 4F 70",
				ReplaceLength = 5,
				IncludeLength = 0,
				Before = cpuRegisters => cpuRegisters.XMM1f = ActiveEffectConditions.GetElapsedSecondsModulus(cpuRegisters.DI, cpuRegisters.XMM6f),
			});
		}

		static ActiveEffectConditions()
		{
			ActiveEffectConditions._activeEffectConditionUpdateFrequency = NetScriptFramework.Main.GameInfo.GetAddressOf(516661);	// SkyrimSE.exe + 0x2F25CE8
			ActiveEffectConditions._updateActiveEffectConditions = NetScriptFramework.Main.GameInfo.GetAddressOf(33287);			// SkyrimSE.exe + 0x53E3E0
		}



		readonly static private System.IntPtr _activeEffectConditionUpdateFrequency;

		readonly static private System.IntPtr _updateActiveEffectConditions;



		static private System.Single GetElapsedSecondsModulus(System.IntPtr activeEffect, System.Single delta)
		{
			var elapsedSeconds = NetScriptFramework.Memory.ReadFloat(activeEffect + 0x70);
			System.Single modulus;

			if (elapsedSeconds == 0.0F)
			{
				modulus = 0.0F;
				NetScriptFramework.Memory.WriteFloat(activeEffect + 0x8C, delta);
			}
			else
			{
				modulus = NetScriptFramework.Memory.ReadFloat(activeEffect + 0x8C);

				if (modulus <= 0.0F || System.Single.IsNaN(modulus) || System.Single.IsInfinity(modulus))
				{
					modulus = 0.0F;
					NetScriptFramework.Memory.WriteFloat(activeEffect + 0x8C, delta);
				}
				else
				{
					modulus %= 1.0F / NetScriptFramework.Memory.ReadFloat(ActiveEffectConditions._activeEffectConditionUpdateFrequency);
					NetScriptFramework.Memory.WriteFloat(activeEffect + 0x8C, modulus + delta);
				}
			}

			return modulus;
		}
	}
}
