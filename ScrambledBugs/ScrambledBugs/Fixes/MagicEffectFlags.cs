using Eggstensions;
using Eggstensions.ExtensionMethods;



namespace ScrambledBugs.Fixes
{
	unsafe static internal class MagicEffectFlags
	{
		static public System.Boolean Fix()
		{
			if
			(
				!ScrambledBugs.Patterns.Fixes.MagicEffectFlags.ResetEffectiveness
				||
				!ScrambledBugs.Patterns.Fixes.MagicEffectFlags.SetEffectiveness
			)
			{
				return false;
			}

			var setEffectiveness = (delegate* unmanaged[Cdecl]<ActiveEffect*, System.Single, void>)&SetEffectiveness;

			Trampoline.WriteRelativeCall(ScrambledBugs.Offsets.Fixes.MagicEffectFlags.ResetEffectiveness, setEffectiveness);
			Trampoline.WriteRelativeCall(ScrambledBugs.Offsets.Fixes.MagicEffectFlags.SetEffectiveness, setEffectiveness);

			[System.Runtime.InteropServices.UnmanagedCallersOnly(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
			static void SetEffectiveness(ActiveEffect* activeEffect, System.Single effectiveness)
			{
				// activeEffect != null

				if (effectiveness == 1.0F || effectiveness < 0.0F)
				{
					return;
				}

				var flags = activeEffect->Effect()->BaseEffect->Data()->Flags;

				if ((flags & EffectSettingDataFlags.NoDuration) != EffectSettingDataFlags.NoDuration && (flags & EffectSettingDataFlags.PowerAffectsDuration) == EffectSettingDataFlags.PowerAffectsDuration)
				{
					activeEffect->Duration(activeEffect->Duration() * effectiveness);
				}

				if ((flags & EffectSettingDataFlags.NoMagnitude) != EffectSettingDataFlags.NoMagnitude && (flags & EffectSettingDataFlags.PowerAffectsMagnitude) == EffectSettingDataFlags.PowerAffectsMagnitude)
				{
					var oldMagnitude = activeEffect->Magnitude();
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

					activeEffect->Magnitude(newMagnitude);
				}
			}

			return true;
		}
	}
}
