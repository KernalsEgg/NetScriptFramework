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

			var assembly = new UnmanagedArray<System.Byte>();

			assembly.Add(new System.Byte[7] { 0x44, 0x8B, 0x97, 0xCC, 0x01, 0x00, 0x00 });																			// mov r10d, [rdi+1CC]
			assembly.Add(new System.Byte[4] { 0x41, 0xC1, 0xEA, 0x08 });																							// shr r10d, 08 (ProjectileFlags.Is3DLoaded)
			assembly.Add(new System.Byte[4] { 0x41, 0xF6, 0xC2, 0x01 });																							// test r10b, 01
			assembly.Add(new System.Byte[2] { 0x74, (System.Byte)Memory.Size<AbsoluteJump>.Unmanaged });															// je 0E
			assembly.Add(Assembly.AbsoluteJump<ScrambledBugs.Delegates.Types.Patches.ApplySpellPerkEntryPoints.CastSpells.ApplySpell>(CastSpells.ApplySpell));
			assembly.Add(new System.Byte[1] { 0xC3 });                                                                                                              // ret

			ScrambledBugs.Plugin.Trampoline.WriteRelativeCallBranch
			(
				ScrambledBugs.Offsets.Patches.ApplySpellPerkEntryPoints.CastSpells.ApplyCombatHitSpellArrowProjectile,
				assembly
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
