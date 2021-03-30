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
				Before = cpuRegisters => cpuRegisters.XMM1f = ActiveEffectConditions.GetUpdateTime(cpuRegisters.DI, cpuRegisters.XMM6f),
			});
		}

		

		static private System.Single GetUpdateTime(System.IntPtr activeEffect, System.Single frameTime)
		{
			// activeEffect != System.IntPtr.Zero
			
			System.Single updateTime;
			var elapsedTime = NetScriptFramework.Memory.ReadFloat(activeEffect + 0x70);

			if (elapsedTime <= 0.0F)
			{
				updateTime = 0.0F;
				NetScriptFramework.Memory.WriteFloat(activeEffect + 0x8C, frameTime);
			}
			else
			{
				updateTime = NetScriptFramework.Memory.ReadFloat(activeEffect + 0x8C);
				var updateInterval = 1.0F / NetScriptFramework.Memory.ReadFloat(ActiveEffectConditions.Offsets.ActiveEffectConditionUpdateFrequency);

				if (updateTime <= 0.0F || System.Single.IsNaN(updateTime) || System.Single.IsInfinity(updateTime)) // Account for garbage memory in existing saves
				{
					updateTime = elapsedTime % updateInterval;
				}
				else
				{
					updateTime %= updateInterval;
				}

				NetScriptFramework.Memory.WriteFloat(activeEffect + 0x8C, updateTime + frameTime);
			}

			return updateTime;
		}
	}
}
