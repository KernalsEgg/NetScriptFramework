using Eggstensions;
using Eggstensions.Interoperability.Managed; // Memory



namespace ScrambledBugs.Fixes
{
	namespace Offsets
	{
		static internal class ActiveEffectConditions
		{
			/// <summary> SkyrimSE.exe + 0x53E3E0 </summary>
			static public System.IntPtr UpdateActiveEffectConditions { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf(33287);
		}
	}


	
	internal class ActiveEffectConditions
	{
		public ActiveEffectConditions()
		{
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = Offsets.ActiveEffectConditions.UpdateActiveEffectConditions + 0xDD,
				Pattern = "F3 0F10 4F 70",
				ReplaceLength = 5,
				IncludeLength = 0,
				Before = registers => registers.XMM1f = ActiveEffectConditions.GetUpdateTime(registers.DI, registers.XMM6f)
			});
		}

		

		static public System.Single GetUpdateTime(ActiveEffect activeEffect, System.Single frameTime)
		{
			// activeEffect != System.IntPtr.Zero
			
			System.Single updateTime;
			var elapsedTime = activeEffect.ElapsedTime;

			if (elapsedTime <= 0.0F)
			{
				updateTime = 0.0F;
				Memory.WriteSingle(activeEffect, 0x8C, frameTime);
			}
			else
			{
				updateTime = Memory.ReadSingle(activeEffect, 0x8C);
				var updateInterval = 1.0F / ActiveEffect.ConditionUpdateFrequency;

				if (updateTime <= 0.0F || System.Single.IsNaN(updateTime) || System.Single.IsInfinity(updateTime)) // Account for garbage memory in existing saves
				{
					updateTime = elapsedTime % updateInterval;
				}
				else
				{
					updateTime %= updateInterval;
				}

				Memory.WriteSingle(activeEffect, 0x8C, updateTime + frameTime);
			}

			return updateTime;
		}
	}
}
