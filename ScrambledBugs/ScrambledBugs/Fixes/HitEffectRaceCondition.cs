using Eggstensions;



namespace ScrambledBugs.Fixes
{
	internal class HitEffectRaceCondition
	{
		public HitEffectRaceCondition()
		{
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address			= Offsets.Fixes.HitEffectRaceCondition.ShouldUpdate + 0x3B,
				Pattern			= "48 8B 47 48" + "48 8B 48 10" + "8B 41 68" + "D1 E8",
				ReplaceLength	= 4 + 4 + 3 + 2, // 13
				IncludeLength	= 4 + 4 + 3 + 2, // 13
				Before			= registers =>
				{
					// activeEffect != System.IntPtr.Zero
					
					ActiveEffect activeEffect = registers.DI;

					var flags = activeEffect.Flags;

					if ((flags & ActiveEffectFlags.ApplyingVisualEffects) != 0 || (flags & ActiveEffectFlags.ApplyingSounds) != 0)
					{
						registers.AX = System.IntPtr.Zero; // Return true

						registers.Skip();
					}
				}
			});
		}
	}
}
