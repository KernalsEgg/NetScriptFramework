using Eggstensions;



namespace ScrambledBugs.Patches.ApplySpellPerkEntryPoints
{
	unsafe internal class CastSpells
	{
		static CastSpells()
		{
			CastSpells.ApplySpell = (Actor* target, SpellItem* spell, Actor* source) =>
			{
				// target	!= null
				// spell	!= null
				// source	!= null

				SpellItem.Apply(spell, source, target);
			};

			ScrambledBugs.Plugin.Trampoline.WriteRelativeCall<ScrambledBugs.Delegates.Types.Patches.ApplySpellPerkEntryPoints.CastSpells.ApplySpell>
			(
				ScrambledBugs.Offsets.Patches.ApplySpellPerkEntryPoints.CastSpells.ApplyBashingSpell,
				CastSpells.ApplySpell
			);

			ScrambledBugs.Plugin.Trampoline.WriteRelativeCall<ScrambledBugs.Delegates.Types.Patches.ApplySpellPerkEntryPoints.CastSpells.ApplySpell>
			(
				ScrambledBugs.Offsets.Patches.ApplySpellPerkEntryPoints.CastSpells.ApplyCombatHitSpell,
				CastSpells.ApplySpell
			);

			ScrambledBugs.Plugin.Trampoline.WriteRelativeCall<ScrambledBugs.Delegates.Types.Patches.ApplySpellPerkEntryPoints.CastSpells.ApplySpell>
			(
				ScrambledBugs.Offsets.Patches.ApplySpellPerkEntryPoints.CastSpells.ApplyCombatHitSpellArrow,
				CastSpells.ApplySpell
			);

			ScrambledBugs.Plugin.Trampoline.WriteRelativeCall<ScrambledBugs.Delegates.Types.Patches.ApplySpellPerkEntryPoints.CastSpells.ApplySpell>
			(
				ScrambledBugs.Offsets.Patches.ApplySpellPerkEntryPoints.CastSpells.ApplyReanimateSpell,
				CastSpells.ApplySpell
			);

			ScrambledBugs.Plugin.Trampoline.WriteRelativeCall<ScrambledBugs.Delegates.Types.Patches.ApplySpellPerkEntryPoints.CastSpells.ApplySpell>
			(
				ScrambledBugs.Offsets.Patches.ApplySpellPerkEntryPoints.CastSpells.ApplyWeaponSwingSpell,
				CastSpells.ApplySpell
			);
		}



		static public ScrambledBugs.Delegates.Types.Patches.ApplySpellPerkEntryPoints.CastSpells.ApplySpell ApplySpell { get; }
	}
}
