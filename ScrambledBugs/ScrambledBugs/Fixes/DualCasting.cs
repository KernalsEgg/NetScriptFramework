using Eggstensions;



namespace ScrambledBugs.Fixes
{
	unsafe internal class DualCasting
	{
		static DualCasting()
		{
			DualCasting.SetDualCasting = (ActiveEffect* activeEffect, System.Single multiplier) =>
			{
				// activeEffect != null

				if (multiplier == 1.0F || multiplier < 0.0F)
				{
					return;
				}

				var flags = activeEffect->Effect->BaseEffect->Data.Flags;

				if ((flags & EffectSettingFlags.NoDuration) != EffectSettingFlags.NoDuration && (flags & EffectSettingFlags.PowerAffectsDuration) == EffectSettingFlags.PowerAffectsDuration)
				{
					activeEffect->Duration *= multiplier;
				}

				if ((flags & EffectSettingFlags.NoMagnitude) != EffectSettingFlags.NoMagnitude && (flags & EffectSettingFlags.PowerAffectsMagnitude) == EffectSettingFlags.PowerAffectsMagnitude)
				{
					var oldMagnitude = activeEffect->Magnitude;
					var newMagnitude = oldMagnitude * multiplier;

					if (oldMagnitude > 0.0F)
					{
						if (newMagnitude < 1.0F)
						{
							newMagnitude = 1.0F;
						}
					}
					else
					{
						if (newMagnitude > -1.0F)
						{
							newMagnitude = -1.0F;
						}
					}

					activeEffect->Magnitude = newMagnitude;
				}
			};

			SkyrimSE.Trampoline.WriteRelativeCall<ScrambledBugs.Delegates.Types.Fixes.DualCasting.SetDualCasting>
			(
				ScrambledBugs.Offsets.Fixes.DualCasting.ResetDualCasting,
				DualCasting.SetDualCasting
			);

			SkyrimSE.Trampoline.WriteRelativeCall<ScrambledBugs.Delegates.Types.Fixes.DualCasting.SetDualCasting>
			(
				ScrambledBugs.Offsets.Fixes.DualCasting.SetDualCasting,
				DualCasting.SetDualCasting
			);
		}



		static public ScrambledBugs.Delegates.Types.Fixes.DualCasting.SetDualCasting SetDualCasting { get; }
	}
}
