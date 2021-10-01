using Eggstensions;
using Eggstensions.ExtensionMethods;



namespace ScrambledBugs.Patches.ApplySpellPerkEntryPoints
{
	unsafe static internal class CastSpells
	{
		static public System.Boolean Patch()
		{
			if
			(
				!ScrambledBugs.Patterns.Patches.ApplySpellPerkEntryPoints.CastSpells.ApplyBashingSpell
				||
				!ScrambledBugs.Patterns.Patches.ApplySpellPerkEntryPoints.CastSpells.ApplyCombatHitSpell
				||
				!ScrambledBugs.Patterns.Patches.ApplySpellPerkEntryPoints.CastSpells.ApplyCombatHitSpellArrowProjectile
				||
				!ScrambledBugs.Patterns.Patches.ApplySpellPerkEntryPoints.CastSpells.ApplyReanimateSpell
				||
				!ScrambledBugs.Patterns.Patches.ApplySpellPerkEntryPoints.CastSpells.ApplyWeaponSwingSpell
			)
			{
				return false;
			}

			CastSpells.ApplySpell();

			return true;
		}



		static public void ApplySpell()
		{
			var applySpell = (delegate* unmanaged[Cdecl]<Actor*, SpellItem*, Actor*, void>)&ApplySpell;

			Trampoline.WriteRelativeCall(ScrambledBugs.Offsets.Patches.ApplySpellPerkEntryPoints.CastSpells.ApplyBashingSpell, applySpell);
			Trampoline.WriteRelativeCall(ScrambledBugs.Offsets.Patches.ApplySpellPerkEntryPoints.CastSpells.ApplyCombatHitSpell, applySpell);
			Trampoline.WriteRelativeCall(ScrambledBugs.Offsets.Patches.ApplySpellPerkEntryPoints.CastSpells.ApplyCombatHitSpellArrowProjectile, applySpell);
			Trampoline.WriteRelativeCall(ScrambledBugs.Offsets.Patches.ApplySpellPerkEntryPoints.CastSpells.ApplyReanimateSpell, applySpell);
			Trampoline.WriteRelativeCall(ScrambledBugs.Offsets.Patches.ApplySpellPerkEntryPoints.CastSpells.ApplyWeaponSwingSpell, applySpell);

			[System.Runtime.InteropServices.UnmanagedCallersOnly(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
			static void ApplySpell(Actor* target, SpellItem* spell, Actor* caster)
			{
				// target	!= null
				// spell	!= null
				// caster	!= null

				spell->Apply(caster, target);
			}
		}
	}
}
