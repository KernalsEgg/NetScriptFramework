using Eggstensions;



namespace ScrambledBugs.Patches.ApplySpellPerkEntryPoints
{
	internal class CastSpells
	{
		public CastSpells()
		{
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address			= Offsets.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplyBashingSpell + 0x429,
				Pattern			= "E8 ?? ?? ?? ??",
				ReplaceLength	= 5,
				IncludeLength	= 0,
				Before			= registers =>
				{
					// spell		!= System.IntPtr.Zero
					// perkOwner	!= System.IntPtr.Zero
					// target		!= System.IntPtr.Zero

					SpellItem spell	= registers.DX;
					Actor perkOwner	= registers.R8;
					Actor target	= registers.CX;

					spell.Apply(perkOwner, target);
				}
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address			= Offsets.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplyCombatHitSpell + 0x79,
				Pattern			= "E8 ?? ?? ?? ??",
				ReplaceLength	= 5,
				IncludeLength	= 0,
				Before			= registers =>
				{
					// spell		!= System.IntPtr.Zero
					// perkOwner	!= System.IntPtr.Zero
					// target		!= System.IntPtr.Zero

					SpellItem spell	= registers.DX;
					Actor perkOwner	= registers.R8;
					Actor target	= registers.CX;

					spell.Apply(perkOwner, target);
				}
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address			= Offsets.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplyCombatHitSpellArrowProjectile + 0x2A7,
				Pattern			= "E8 ?? ?? ?? ??",
				ReplaceLength	= 5,
				IncludeLength	= 0,
				Before			= registers =>
				{
					// arrow		!= System.IntPtr.Zero
					// spell		!= System.IntPtr.Zero
					// perkOwner	!= System.IntPtr.Zero
					// target		!= System.IntPtr.Zero

					ArrowProjectile arrow = registers.DI;

					if ((arrow.Flags & ProjectileFlags.Is3DLoaded) != 0)
					{
						SpellItem spell	= registers.DX;
						Actor perkOwner	= registers.R8;
						Actor target	= registers.CX;

						spell.Apply(perkOwner, target);
					}
				}
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address			= Offsets.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplyReanimateSpell + 0xD2,
				Pattern			= "E8 ?? ?? ?? ??",
				ReplaceLength	= 5,
				IncludeLength	= 0,
				Before			= registers =>
				{
					// spell		!= System.IntPtr.Zero
					// perkOwner	!= System.IntPtr.Zero
					// target		!= System.IntPtr.Zero

					SpellItem spell	= registers.DX;
					Actor perkOwner	= registers.R8;
					Actor target	= registers.CX;

					spell.Apply(perkOwner, target);
				}
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address			= Offsets.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplyWeaponSwingSpell + 0xC3,
				Pattern			= "E8 ?? ?? ?? ??",
				ReplaceLength	= 5,
				IncludeLength	= 0,
				Before			= registers =>
				{
					// spell		!= System.IntPtr.Zero
					// attacker		!= System.IntPtr.Zero
					// perkOwner	!= System.IntPtr.Zero

					SpellItem spell	= registers.DX;
					Actor attacker	= registers.R8;
					Actor perkOwner	= registers.CX;

					spell.Apply(attacker, perkOwner);
				}
			});
		}
	}
}
