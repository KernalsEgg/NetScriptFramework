using Eggstensions;



namespace ScrambledBugs.Patches.ApplySpellPerkEntryPoints
{
	unsafe static internal class MultipleSpells
	{
		static public ScrambledBugs.Delegates.Types.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplyBashingSpell ApplyBashingSpell { get; set; }
		static public ScrambledBugs.Delegates.Types.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplyCombatHitSpell ApplyCombatHitSpell { get; set; }
		static public ScrambledBugs.Delegates.Types.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplyReanimateSpell ApplyReanimateSpell { get; set; }
		static public ScrambledBugs.Delegates.Types.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplySneakingSpell ApplySneakingSpell { get; set; }
		static public ScrambledBugs.Delegates.Types.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplyWeaponSwingSpell ApplyWeaponSwingSpell { get; set; }
		static public ScrambledBugs.Delegates.Types.Patches.ApplySpellPerkEntryPoints.MultipleSpells.EntryPointFunction SelectSpell { get; set; }



		static public void Patch(System.Boolean castSpells)
		{
			MultipleSpells.ApplyBashingSpell = (System.Int32 entryPoint, Actor* perkOwner, Actor* target, SpellItem** result) =>
			{
				// perkOwner	!= null
				// target		!= null
				// result		!= null

				var bashingSpells = new BSTArray();

				try
				{
					BGSEntryPointPerkEntry.HandleEntryPoints((EntryPoint)entryPoint, perkOwner, target, &bashingSpells);

					for (var index = 0; index < bashingSpells.Length; index++)
					{
						var bashingSpell = (SpellItem*)Memory.Read<System.IntPtr>(bashingSpells.Elements, Memory.Size<System.IntPtr>.Unmanaged * index);

						if (bashingSpell != null)
						{
							SpellItem.Apply(bashingSpell, castSpells ? perkOwner : target, target);
						}
					}
				}
				finally
				{
					BSTArray.Deallocate(&bashingSpells);
				}
			};

			ScrambledBugs.Plugin.Trampoline.WriteRelativeCall<ScrambledBugs.Delegates.Types.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplyBashingSpell>
			(
				ScrambledBugs.Offsets.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplyBashingSpell,
				MultipleSpells.ApplyBashingSpell
			);


			
			MultipleSpells.ApplyCombatHitSpell = (System.Int32 entryPoint, Actor* perkOwner, TESObjectWEAP* weapon, Actor* target, SpellItem** result) =>
			{
				// perkOwner	!= null
				// weapon		!= null
				// target		!= null
				// result		!= null

				var combatHitSpells = new BSTArray();

				try
				{
					BGSEntryPointPerkEntry.HandleEntryPoints((EntryPoint)entryPoint, perkOwner, weapon, target, &combatHitSpells);

					for (var index = 0; index < combatHitSpells.Length; index++)
					{
						var combatHitSpell = (SpellItem*)Memory.Read<System.IntPtr>(combatHitSpells.Elements, Memory.Size<System.IntPtr>.Unmanaged * index);

						if (combatHitSpell != null)
						{
							SpellItem.Apply(combatHitSpell, castSpells ? perkOwner : target, target);
						}
					}
				}
				finally
				{
					BSTArray.Deallocate(&combatHitSpells);
				}
			};

			ScrambledBugs.Plugin.Trampoline.WriteRelativeCall<ScrambledBugs.Delegates.Types.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplyCombatHitSpell>
			(
				ScrambledBugs.Offsets.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplyCombatHitSpell,
				MultipleSpells.ApplyCombatHitSpell
			);

			ScrambledBugs.Plugin.Trampoline.WriteRelativeCall<ScrambledBugs.Delegates.Types.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplyCombatHitSpell>
			(
				ScrambledBugs.Offsets.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplyCombatHitSpellArrowProjectile,
				MultipleSpells.ApplyCombatHitSpell
			);



			MultipleSpells.ApplyReanimateSpell = (System.Int32 entryPoint, Actor* perkOwner, SpellItem* spell, Actor* target, SpellItem** result) =>
			{
				// perkOwner	!= null
				// spell		!= null
				// target		!= null
				// result		!= null

				var reanimateSpells = new BSTArray();

				try
				{
					BGSEntryPointPerkEntry.HandleEntryPoints((EntryPoint)entryPoint, perkOwner, spell, target, &reanimateSpells);

					for (var index = 0; index < reanimateSpells.Length; index++)
					{
						var reanimateSpell = (SpellItem*)Memory.Read<System.IntPtr>(reanimateSpells.Elements, Memory.Size<System.IntPtr>.Unmanaged * index);

						if (reanimateSpell != null)
						{
							SpellItem.Apply(reanimateSpell, castSpells ? perkOwner : target, target);
						}
					}
				}
				finally
				{
					BSTArray.Deallocate(&reanimateSpells);
				}
			};

			ScrambledBugs.Plugin.Trampoline.WriteRelativeCall<ScrambledBugs.Delegates.Types.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplyReanimateSpell>
			(
				ScrambledBugs.Offsets.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplyReanimateSpell,
				MultipleSpells.ApplyReanimateSpell
			);



			MultipleSpells.ApplySneakingSpell = (System.Int32 entryPoint, Actor* perkOwner, SpellItem** result) =>
			{
				// perkOwner	!= null
				// result		!= null

				var sneakingSpells = new BSTArray();

				try
				{
					BGSEntryPointPerkEntry.HandleEntryPoints((EntryPoint)entryPoint, perkOwner, &sneakingSpells);

					for (var index = 0; index < sneakingSpells.Length; index++)
					{
						var sneakingSpell = (SpellItem*)Memory.Read<System.IntPtr>(sneakingSpells.Elements, Memory.Size<System.IntPtr>.Unmanaged * index);

						if (sneakingSpell != null)
						{
							SpellItem.Apply(sneakingSpell, perkOwner, perkOwner);
						}
					}
				}
				finally
				{
					BSTArray.Deallocate(&sneakingSpells);
				}
			};

			ScrambledBugs.Plugin.Trampoline.WriteRelativeCall<ScrambledBugs.Delegates.Types.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplySneakingSpell>
			(
				ScrambledBugs.Offsets.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplySneakingSpell,
				MultipleSpells.ApplySneakingSpell
			);



			MultipleSpells.ApplyWeaponSwingSpell = (System.Int32 entryPoint, Actor* perkOwner, Actor* attacker, TESObjectWEAP* attackerWeapon, SpellItem** result) =>
			{
				// perkOwner		!= null
				// attacker			!= null
				// attackerWeapon	!= null
				// result			!= null

				var weaponSwingSpells = new BSTArray();

				try
				{
					BGSEntryPointPerkEntry.HandleEntryPoints((EntryPoint)entryPoint, perkOwner, attacker, attackerWeapon, &weaponSwingSpells);

					for (var index = 0; index < weaponSwingSpells.Length; index++)
					{
						var weaponSwingSpell = (SpellItem*)Memory.Read<System.IntPtr>(weaponSwingSpells.Elements, Memory.Size<System.IntPtr>.Unmanaged * index);

						if (weaponSwingSpell != null)
						{
							SpellItem.Apply(weaponSwingSpell, castSpells ? attacker : perkOwner, perkOwner);
						}
					}
				}
				finally
				{
					BSTArray.Deallocate(&weaponSwingSpells);
				}
			};

			ScrambledBugs.Plugin.Trampoline.WriteRelativeCall<ScrambledBugs.Delegates.Types.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplyWeaponSwingSpell>
			(
				ScrambledBugs.Offsets.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplyWeaponSwingSpell,
				MultipleSpells.ApplyWeaponSwingSpell
			);



			MultipleSpells.SelectSpell = (Actor* perkOwner, System.Int32 result, System.Byte resultCount, System.IntPtr results, BGSEntryPointFunctionData* entryPointFunctionData) =>
			{
				// perkOwner				!= null
				// results					!= System.IntPtr.Zero
				// entryPointFunctionData	!= null

				if ((EntryPointFunctionResult)result != EntryPointFunctionResult.SpellItem)
				{
					return;
				}

				if (resultCount != Memory.Read<System.UInt32>(ScrambledBugs.Offsets.Patches.ApplySpellPerkEntryPoints.MultipleSpells.SelectSpellResultCount))
				{
					return;
				}

				if (BGSEntryPointFunctionData.GetType(entryPointFunctionData) != EntryPointFunctionDataType.SpellItem)
				{
					return;
				}

				var spells	= (BSTArray*)Memory.Read<System.IntPtr>(results);
				var spell	= ((BGSEntryPointFunctionDataSpellItem*)entryPointFunctionData)->Spell;

				BSTArray.Push(spells, new System.IntPtr(&spell));
			};

			Memory.Write<System.IntPtr>
			(
				ScrambledBugs.Offsets.Patches.ApplySpellPerkEntryPoints.MultipleSpells.SelectSpell,
				System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<ScrambledBugs.Delegates.Types.Patches.ApplySpellPerkEntryPoints.MultipleSpells.EntryPointFunction>(MultipleSpells.SelectSpell)
			);
		}
	}
}
