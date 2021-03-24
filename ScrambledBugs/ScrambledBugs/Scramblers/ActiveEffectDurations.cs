namespace ScrambledBugs
{
	internal class ActiveEffectDurations
	{
		internal ActiveEffectDurations()
		{
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = ActiveEffectDurations._updateActiveEffectConditions + 0xDD,
				Pattern = "F3 0F 10 4F 70",
				ReplaceLength = 5,
				IncludeLength = 0,
				Before = cpuRegisters => cpuRegisters.XMM1f = ActiveEffectDurations.GetElapsedSecondsModulus(cpuRegisters.DI, cpuRegisters.XMM6f),
			});
		}

		static ActiveEffectDurations()
		{
			ActiveEffectDurations._activeEffectConditionUpdateFrequency = NetScriptFramework.Main.GameInfo.GetAddressOf(516661);	// SkyrimSE.exe + 0x2F25CE8
			ActiveEffectDurations._updateActiveEffectConditions = NetScriptFramework.Main.GameInfo.GetAddressOf(33287);				// SkyrimSE.exe + 0x53E3E0
		}



		readonly static private System.IntPtr _activeEffectConditionUpdateFrequency;

		readonly static private System.IntPtr _updateActiveEffectConditions;



		static private System.Single GetElapsedSecondsModulus(System.IntPtr activeEffect, System.Single elapsedSecondsDelta)
		{
			NetScriptFramework.Main.Log.AppendLine("activeEffect = " + activeEffect.ToString("X8"));
			
			var elapsedSeconds = NetScriptFramework.Memory.ReadFloat(activeEffect + 0x70);
			System.Single elapsedSecondsModulus;

			if (elapsedSeconds == 0.0F)
			{
				elapsedSecondsModulus = 0.0F;
				NetScriptFramework.Memory.WriteFloat(activeEffect + 0x8C, elapsedSecondsDelta);
			}
			else
			{
				elapsedSecondsModulus = NetScriptFramework.Memory.ReadFloat(activeEffect + 0x8C) % (1.0F / NetScriptFramework.Memory.ReadFloat(ActiveEffectDurations._activeEffectConditionUpdateFrequency));
				NetScriptFramework.Memory.WriteFloat(activeEffect + 0x8C, elapsedSecondsModulus + elapsedSecondsDelta);
			}

			return elapsedSecondsModulus;
		}
	}
}
