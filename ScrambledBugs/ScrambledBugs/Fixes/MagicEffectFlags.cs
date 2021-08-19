using Eggstensions;



namespace ScrambledBugs.Fixes
{
	unsafe static internal class MagicEffectFlags
	{
		static public ScrambledBugs.Delegates.Types.Fixes.MagicEffectFlags.SetEffectiveness SetEffectiveness { get; set; }



		static public void Fix()
		{
			MagicEffectFlags.SetEffectiveness = (ActiveEffect* activeEffect, System.Single effectiveness) =>
			{
				// activeEffect != null

				if (effectiveness == 1.0F || effectiveness < 0.0F)
				{
					return;
				}

				var flags = activeEffect->Effect->BaseEffect->Data.Flags;

				if ((flags & EffectSettingFlags.NoDuration) != EffectSettingFlags.NoDuration && (flags & EffectSettingFlags.PowerAffectsDuration) == EffectSettingFlags.PowerAffectsDuration)
				{
					activeEffect->Duration *= effectiveness;
				}

				if ((flags & EffectSettingFlags.NoMagnitude) != EffectSettingFlags.NoMagnitude && (flags & EffectSettingFlags.PowerAffectsMagnitude) == EffectSettingFlags.PowerAffectsMagnitude)
				{
					var oldMagnitude = activeEffect->Magnitude;
					var newMagnitude = oldMagnitude * effectiveness;

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

			ScrambledBugs.Plugin.Trampoline.WriteRelativeCall<ScrambledBugs.Delegates.Types.Fixes.MagicEffectFlags.SetEffectiveness>
			(
				ScrambledBugs.Offsets.Fixes.MagicEffectFlags.ResetEffectiveness,
				MagicEffectFlags.SetEffectiveness
			);

			ScrambledBugs.Plugin.Trampoline.WriteRelativeCall<ScrambledBugs.Delegates.Types.Fixes.MagicEffectFlags.SetEffectiveness>
			(
				ScrambledBugs.Offsets.Fixes.MagicEffectFlags.SetEffectiveness,
				MagicEffectFlags.SetEffectiveness
			);
		}
	}
}
