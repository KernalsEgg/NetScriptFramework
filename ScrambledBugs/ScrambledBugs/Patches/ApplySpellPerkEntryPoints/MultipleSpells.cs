using Eggstensions;
using Eggstensions.ExtensionMethods;



namespace ScrambledBugs.Patches.ApplySpellPerkEntryPoints
{
	unsafe static internal class MultipleSpells
	{
		static public System.Boolean Patch(System.Boolean castSpells)
		{
			if
			(
				!ScrambledBugs.Patterns.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplyBashingSpell
				||
				!ScrambledBugs.Patterns.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplyCombatHitSpell
				||
				!ScrambledBugs.Patterns.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplyCombatHitSpellArrowProjectile
				||
				!ScrambledBugs.Patterns.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplyReanimateSpell
				||
				!ScrambledBugs.Patterns.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplySneakingSpell
				||
				!ScrambledBugs.Patterns.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplyWeaponSwingSpell
			)
			{
				return false;
			}



			MultipleSpells.castSpells = castSpells;
			
			
			
			var applyBashingSpell = (delegate* unmanaged[Cdecl]<System.Int32, Actor*, Actor*, SpellItem**, void>)&ApplyBashingSpell;

			Trampoline.WriteRelativeCall(ScrambledBugs.Offsets.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplyBashingSpell, applyBashingSpell);

			[System.Runtime.InteropServices.UnmanagedCallersOnly(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
			static void ApplyBashingSpell(System.Int32 entryPoint, Actor* perkOwner, Actor* target, SpellItem** result)
			{
				// perkOwner	!= null
				// target		!= null
				// result		!= null

				using var bashingSpells = new BSTArray();
				BGSEntryPointPerkEntry.HandleEntryPoints((EntryPoint)entryPoint, perkOwner, target, &bashingSpells);

				for (var index = 0; index < bashingSpells.Length; index++)
				{
					var bashingSpell = ((SpellItem**)bashingSpells.Elements)[index];

					if (bashingSpell != null)
					{
						bashingSpell->Apply(MultipleSpells.castSpells ? perkOwner : target, target);
					}
				}
			}



			var applyCombatHitSpell = (delegate* unmanaged[Cdecl]<System.Int32, Actor*, TESObjectWEAP*, Actor*, SpellItem**, void>)&ApplyCombatHitSpell;

			Trampoline.WriteRelativeCall(ScrambledBugs.Offsets.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplyCombatHitSpell, applyCombatHitSpell);
			Trampoline.WriteRelativeCall(ScrambledBugs.Offsets.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplyCombatHitSpellArrowProjectile, applyCombatHitSpell);

			[System.Runtime.InteropServices.UnmanagedCallersOnly(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
			static void ApplyCombatHitSpell(System.Int32 entryPoint, Actor* perkOwner, TESObjectWEAP* weapon, Actor* target, SpellItem** result)
			{
				// perkOwner	!= null
				// weapon		!= null
				// target		!= null
				// result		!= null

				using var combatHitSpells = new BSTArray();
				BGSEntryPointPerkEntry.HandleEntryPoints((EntryPoint)entryPoint, perkOwner, weapon, target, &combatHitSpells);

				for (var index = 0; index < combatHitSpells.Length; index++)
				{
					var combatHitSpell = ((SpellItem**)combatHitSpells.Elements)[index];

					if (combatHitSpell != null)
					{
						combatHitSpell->Apply(MultipleSpells.castSpells ? perkOwner : target, target);
					}
				}
			}



			var applyReanimateSpell = (delegate* unmanaged[Cdecl]<System.Int32, Actor*, SpellItem*, Actor*, SpellItem**, void>)&ApplyReanimateSpell;

			Trampoline.WriteRelativeCall(ScrambledBugs.Offsets.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplyReanimateSpell, applyReanimateSpell);

			[System.Runtime.InteropServices.UnmanagedCallersOnly(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
			static void ApplyReanimateSpell(System.Int32 entryPoint, Actor* perkOwner, SpellItem* spell, Actor* target, SpellItem** result)
			{
				// perkOwner	!= null
				// spell		!= null
				// target		!= null
				// result		!= null

				using var reanimateSpells = new BSTArray();
				BGSEntryPointPerkEntry.HandleEntryPoints((EntryPoint)entryPoint, perkOwner, spell, target, &reanimateSpells);

				for (var index = 0; index < reanimateSpells.Length; index++)
				{
					var reanimateSpell = ((SpellItem**)reanimateSpells.Elements)[index];

					if (reanimateSpell != null)
					{
						reanimateSpell->Apply(MultipleSpells.castSpells ? perkOwner : target, target);
					}
				}
			}



			var applySneakingSpell = (delegate* unmanaged[Cdecl]<System.Int32, Actor*, SpellItem**, void>)&ApplySneakingSpell;

			Trampoline.WriteRelativeCall(ScrambledBugs.Offsets.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplySneakingSpell, applySneakingSpell);

			[System.Runtime.InteropServices.UnmanagedCallersOnly(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
			static void ApplySneakingSpell(System.Int32 entryPoint, Actor* perkOwner, SpellItem** result)
			{
				// perkOwner	!= null
				// result		!= null

				using var sneakingSpells = new BSTArray();
				BGSEntryPointPerkEntry.HandleEntryPoints((EntryPoint)entryPoint, perkOwner, &sneakingSpells);

				for (var index = 0; index < sneakingSpells.Length; index++)
				{
					var sneakingSpell = ((SpellItem**)sneakingSpells.Elements)[index];

					if (sneakingSpell != null)
					{
						sneakingSpell->Apply(perkOwner, perkOwner);
					}
				}
			}



			var applyWeaponSwingSpell = (delegate* unmanaged[Cdecl]<System.Int32, Actor*, Actor*, TESObjectWEAP*, SpellItem**, void>)&ApplyWeaponSwingSpell;

			Trampoline.WriteRelativeCall(ScrambledBugs.Offsets.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplyWeaponSwingSpell, applyWeaponSwingSpell);

			[System.Runtime.InteropServices.UnmanagedCallersOnly(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
			static void ApplyWeaponSwingSpell(System.Int32 entryPoint, Actor* perkOwner, Actor* attacker, TESObjectWEAP* attackerWeapon, SpellItem** result)
			{
				// perkOwner		!= null
				// attacker			!= null
				// attackerWeapon	!= null
				// result			!= null

				using var weaponSwingSpells = new BSTArray();
				BGSEntryPointPerkEntry.HandleEntryPoints((EntryPoint)entryPoint, perkOwner, attacker, attackerWeapon, &weaponSwingSpells);

				for (var index = 0; index < weaponSwingSpells.Length; index++)
				{
					var weaponSwingSpell = ((SpellItem**)weaponSwingSpells.Elements)[index];

					if (weaponSwingSpell != null)
					{
						weaponSwingSpell->Apply(MultipleSpells.castSpells ? attacker : perkOwner, perkOwner);
					}
				}
			}



			var selectSpell = (delegate* unmanaged[Cdecl]<Actor*, System.Int32, System.Byte, System.IntPtr, BGSEntryPointFunctionData*, void>)&SelectSpell;

			*(delegate* unmanaged[Cdecl]<Actor*, System.Int32, System.Byte, System.IntPtr, BGSEntryPointFunctionData*, void>*)ScrambledBugs.Offsets.Patches.ApplySpellPerkEntryPoints.MultipleSpells.SelectSpell = selectSpell;

			[System.Runtime.InteropServices.UnmanagedCallersOnly(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
			static void SelectSpell(Actor* perkOwner, System.Int32 result, System.Byte resultCount, System.IntPtr results, BGSEntryPointFunctionData* entryPointFunctionData)
			{
				// perkOwner				!= null
				// results					!= System.IntPtr.Zero
				// entryPointFunctionData	!= null

				if ((EntryPointFunctionResult)result != EntryPointFunctionResult.SpellItem)
				{
					return;
				}

				if (resultCount != *(System.UInt32*)ScrambledBugs.Offsets.Patches.ApplySpellPerkEntryPoints.MultipleSpells.SelectSpellResultCount)
				{
					return;
				}

				if (entryPointFunctionData->GetDataType() != EntryPointFunctionDataType.SpellItem)
				{
					return;
				}

				var spells	= *(BSTArray**)results;
				var spell	= ((BGSEntryPointFunctionDataSpellItem*)entryPointFunctionData)->Spell();

				spells->Push(&spell);
			}



			return true;
		}



		static private System.Boolean castSpells;
	}
}
