using Eggstensions;



namespace ScrambledBugs
{
	namespace Delegates
	{
		namespace Instances
		{
			namespace Fixes
			{
				static internal class SpeedMultUpdates
				{
					static public Delegates.Types.Fixes.SpeedMultUpdates.RemoveMovementFlags RemoveMovementFlags { get; } = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.Fixes.SpeedMultUpdates.RemoveMovementFlags>(ScrambledBugs.Offsets.Fixes.SpeedMultUpdates.RemoveMovementFlags);

					static public Delegates.Types.Fixes.SpeedMultUpdates.UpdateMovementSpeed UpdateMovementSpeed { get; } = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.Fixes.SpeedMultUpdates.UpdateMovementSpeed>(ScrambledBugs.Offsets.Fixes.SpeedMultUpdates.UpdateMovementSpeed);
				}
			}
		}

		namespace Types
		{
			namespace Fixes
			{
				unsafe static internal class HarvestedFlags
				{
					[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
					public delegate void SetHarvestedFlag(TESObjectREFR* reference, System.Byte harvested);
				}

				unsafe static internal class DualCasting
				{
					[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
					public delegate void SetDualCasting(ActiveEffect* activeEffect, System.Single multiplier);
				}

				unsafe static internal class SpeedMultUpdates
				{
					[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
					public delegate void ActorValueSink(Actor* actor, System.Int32 actorValue, System.Single old, System.Single delta);

					[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
					public delegate void RemoveMovementFlags(Actor* actor);

					[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
					public delegate void UpdateMovementSpeed(Actor* actor);
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
