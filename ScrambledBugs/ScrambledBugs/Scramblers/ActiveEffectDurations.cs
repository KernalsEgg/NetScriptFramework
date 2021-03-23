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
				ReplaceLength = 0x79,
				IncludeLength = 0x0,
				Before = cpuRegisters => cpuRegisters.IP = ActiveEffectDurations.UpdateActiveEffectConditions(cpuRegisters.DI) ? ActiveEffectDurations._update : ActiveEffectDurations._skipUpdate,
			});
		}

		static ActiveEffectDurations()
		{
			ActiveEffectDurations._activeEffectConditionUpdateFrequency = NetScriptFramework.Main.GameInfo.GetAddressOf(516661);	// SkyrimSE.exe + 0x2F25CE8
			ActiveEffectDurations._updateActiveEffectConditions = NetScriptFramework.Main.GameInfo.GetAddressOf(33287);				// SkyrimSE.exe + 0x53E3E0

			ActiveEffectDurations._skipUpdate = NetScriptFramework.Main.GameInfo.GetAddressOf(33287, 0x1DD, 0, "48 8B 5C 24 58");
			ActiveEffectDurations._update = NetScriptFramework.Main.GameInfo.GetAddressOf(33287, 0x156, 0, "8B 47 34");

			ActiveEffectDurations._activeEffects = new System.Collections.Generic.Dictionary<System.IntPtr, (System.Int32 previousTick, System.Int64 elapsedTicks)>();
			ActiveEffectDurations._lock = new System.Object();
		}



		readonly static private System.IntPtr _activeEffectConditionUpdateFrequency;

		readonly static private System.IntPtr _skipUpdate;

		readonly static private System.IntPtr _update;

		readonly static private System.IntPtr _updateActiveEffectConditions;



		static private System.Collections.Generic.Dictionary<System.IntPtr, (System.Int32 tickCount, System.Int64 elapsedTicks)> _activeEffects;

		static private System.Object _lock;



		static private System.Single ActiveEffectConditionUpdateFrequency
		{
			get
			{
				return NetScriptFramework.Memory.ReadFloat(ActiveEffectDurations._activeEffectConditionUpdateFrequency);
			}
		}



		static private System.Boolean UpdateActiveEffectConditions(System.IntPtr activeEffect)
		{
			if (activeEffect == System.IntPtr.Zero) { return false; }
			
			lock (ActiveEffectDurations._lock)
			{
				if (ActiveEffectDurations._activeEffects.TryGetValue(activeEffect, out var value))
				{
					var tickCount = System.Environment.TickCount;
					var elapsedTicks = unchecked(tickCount - value.tickCount);

					if (elapsedTicks > 0)
					{
						ActiveEffectDurations._activeEffects[activeEffect] = (tickCount, value.elapsedTicks + elapsedTicks);

						var updateFrequency = (System.Double)ActiveEffectDurations.ActiveEffectConditionUpdateFrequency / 1000.0D;
						var previousUpdate = System.Math.Ceiling(value.elapsedTicks * updateFrequency);
						var currentUpdate = System.Math.Ceiling((value.elapsedTicks + elapsedTicks) * updateFrequency);

						if (currentUpdate > previousUpdate)
						{
							return true;
						}
					}

					return false;
				}
				else
				{
					ActiveEffectDurations._activeEffects[activeEffect] = (System.Environment.TickCount, 0);

					return true;
				}
			}
		}
	}
}
