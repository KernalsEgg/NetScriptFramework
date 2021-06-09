using Eggstensions;



namespace ScrambledBugs.Fixes
{
	internal class ActiveEffectConditions
	{
		public ActiveEffectConditions()
		{
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address			= Offsets.Fixes.ActiveEffectConditions.UpdateConditions + 0xDD,
				Pattern			= "F3 0F10 4F 70",
				ReplaceLength	= 5,
				IncludeLength	= 0,
				Before			= registers => registers.XMM1f = ActiveEffectConditions.GetUpdateTime(registers.DI, registers.XMM6f)
			});
		}



		static public System.Single GetUpdateTime(ActiveEffect activeEffect, System.Single frameTime)
		{
			// activeEffect != System.IntPtr.Zero

			System.Single updateTime;

			var elapsedTime	= activeEffect.ElapsedTime;
			var padding8C	= activeEffect.GetPadding8C<System.Single>();

			if (elapsedTime <= 0.0F)
			{
				updateTime		= 0.0F;
				padding8C.Value	= frameTime;
			}
			else
			{
				updateTime			= padding8C.Value;
				var updateInterval	= 1.0F / ActiveEffect.ConditionUpdateFrequency;

				if (updateTime <= 0.0F || System.Single.IsNaN(updateTime) || System.Single.IsInfinity(updateTime)) // Account for garbage memory in existing saves
				{
					updateTime = elapsedTime % updateInterval;
				}
				else
				{
					updateTime %= updateInterval;
				}

				padding8C.Value = updateTime + frameTime;
			}

			return updateTime;
		}
	}
}
