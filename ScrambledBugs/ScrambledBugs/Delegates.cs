using Eggstensions;



namespace ScrambledBugs
{
	namespace Delegates
	{
		namespace Instances
		{
			namespace Fixes
			{
				static internal class MovementSpeed
				{
					static public Delegates.Types.Fixes.MovementSpeed.RemoveMovementFlags RemoveMovementFlags { get; } = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.Fixes.MovementSpeed.RemoveMovementFlags>(ScrambledBugs.Offsets.Fixes.MovementSpeed.RemoveMovementFlags);
				}

				static internal class WeaponCharge
				{
					static public Delegates.Types.Fixes.WeaponCharge.RemoveEquippedItemFlags RemoveEquippedItemFlags { get; } = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.Fixes.WeaponCharge.RemoveEquippedItemFlags>(ScrambledBugs.Offsets.Fixes.WeaponCharge.RemoveEquippedItemFlags);
				}
			}
		}

		namespace Types
		{
			namespace Fixes
			{
				unsafe static internal class ActorValuePercentage
				{
					[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
					public delegate System.Single GetActorValuePercentage(Eggstensions.Actor* actor, System.Int32 actorValue);

					[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
					public delegate System.Single GetHealthPercentage(Eggstensions.Actor* actor);

					[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
					public delegate System.Single GetStaminaPercentage(Eggstensions.Actor* actor);
				}

				unsafe static internal class HarvestedFlags
				{
					[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
					public delegate void SetHarvestedFlag(TESObjectREFR* reference, System.Byte harvested);
				}

				unsafe static internal class MagicEffectFlags
				{
					[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
					public delegate void SetEffectiveness(ActiveEffect* activeEffect, System.Single effectiveness);
				}

				unsafe static internal class MovementSpeed
				{
					[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
					public delegate void ActorValueSink(Actor* actor, System.Int32 actorValue, System.Single old, System.Single delta);

					[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
					public delegate void RemoveMovementFlags(Actor* actor);
				}

				static internal class QuickShot
				{
					[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
					public delegate System.Single GetArrowPower(System.Single drawTime, System.Single bowSpeed);
				}

				unsafe static internal class WeaponCharge
				{
					[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
					public delegate void HandleEquippedItem(Actor* actor, TESBoundObject* item, ExtraDataList* extraDataList, System.Byte leftHand);

					[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
					public delegate void RemoveEquippedItemFlags(PlayerCharacter* player, System.Byte flags);
				}
			}

			namespace Patches
			{
				namespace ApplySpellPerkEntryPoints
				{
					unsafe static internal class CastSpells
					{
						[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
						public delegate void ApplySpell(Actor* target, SpellItem* spell, Actor* source);
					}

					unsafe static internal class MultipleSpells
					{
						[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
						public delegate void ApplyBashingSpell(System.Int32 entryPoint, Actor* perkOwner, Actor* target, SpellItem** result);

						[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
						public delegate void ApplyCombatHitSpell(System.Int32 entryPoint, Actor* perkOwner, TESObjectWEAP* weapon, Actor* target, SpellItem** result);

						[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
						public delegate void ApplyReanimateSpell(System.Int32 entryPoint, Actor* perkOwner, SpellItem* spell, Actor* target, SpellItem** result);

						[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
						public delegate void ApplySneakingSpell(System.Int32 entryPoint, Actor* perkOwner, SpellItem** result);

						[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
						public delegate void ApplyWeaponSwingSpell(System.Int32 entryPoint, Actor* perkOwner, Actor* attacker, TESObjectWEAP* attackerWeapon, SpellItem** result);

						[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
						public delegate void EntryPointFunction(Actor* perkOwner, System.Int32 result, System.Byte resultCount, System.IntPtr results, BGSEntryPointFunctionData* entryPointFunctionData);
					}
				}
			}
		}
	}
}
