namespace Eggstensions
{
	namespace Delegates
	{
		namespace Instances
		{
			static public class ActiveEffect
			{
				static public Delegates.Types.ActiveEffect.Dispel Dispel { get; } = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.ActiveEffect.Dispel>(Eggstensions.Offsets.ActiveEffect.Dispel);
			}
			
			static public class Actor
			{
				static public Delegates.Types.Actor.AddSpell AddSpell { get; }										= System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.Actor.AddSpell>(Eggstensions.Offsets.Actor.AddSpell);
				static public Delegates.Types.Actor.GetActorValueModifier GetActorValueModifier { get; }			= System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.Actor.GetActorValueModifier>(Eggstensions.Offsets.Actor.GetActorValueModifier);
				static public Delegates.Types.Actor.RemoveActorValueModifiers RemoveActorValueModifiers { get; }	= System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.Actor.RemoveActorValueModifiers>(Eggstensions.Offsets.Actor.RemoveActorValueModifiers);
				static public Delegates.Types.Actor.RevertSelectedSpell RevertSelectedSpell { get; }				= System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.Actor.RevertSelectedSpell>(Eggstensions.Offsets.Actor.RevertSelectedSpell);
				static public Delegates.Types.Actor.UpdateMovementSpeed UpdateMovementSpeed { get; }				= System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.Actor.UpdateMovementSpeed>(Eggstensions.Offsets.Actor.UpdateMovementSpeed);
			}

			static public class BGSEntryPointPerkEntry
			{
				static public Delegates.Types.BGSEntryPointPerkEntry.HandleEntryPoints1 HandleEntryPoints1 { get; } = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.BGSEntryPointPerkEntry.HandleEntryPoints1>(Eggstensions.Offsets.BGSEntryPointPerkEntry.HandleEntryPoints);

				static public Delegates.Types.BGSEntryPointPerkEntry.HandleEntryPoints2 HandleEntryPoints2 { get; } = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.BGSEntryPointPerkEntry.HandleEntryPoints2>(Eggstensions.Offsets.BGSEntryPointPerkEntry.HandleEntryPoints);

				static public Delegates.Types.BGSEntryPointPerkEntry.HandleEntryPoints3 HandleEntryPoints3 { get; } = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.BGSEntryPointPerkEntry.HandleEntryPoints3>(Eggstensions.Offsets.BGSEntryPointPerkEntry.HandleEntryPoints);
			}

			static public class BSTArray
			{
				static public class IntPtr
				{
					static public Delegates.Types.BSTArray.IntPtr.Push Push { get; } = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.BSTArray.IntPtr.Push>(Eggstensions.Offsets.BSTArray.IntPtr.Push);
				}



				static public Delegates.Types.BSTArray.Deallocate Deallocate { get; } = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.BSTArray.Deallocate>(Eggstensions.Offsets.BSTArray.Deallocate);
			}

			static public class BSTEventSource
			{
				static public Delegates.Types.BSTEventSource.AddEventSink AddEventSink { get; }			= System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.BSTEventSource.AddEventSink>(Eggstensions.Offsets.BSTEventSource.AddEventSink);
				static public Delegates.Types.BSTEventSource.RemoveEventSink RemoveEventSink { get; }	= System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.BSTEventSource.RemoveEventSink>(Eggstensions.Offsets.BSTEventSource.RemoveEventSink);
			}

			static public class ExtraDataList
			{
				static public Delegates.Types.ExtraDataList.GetCharge GetCharge { get; }		= System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.ExtraDataList.GetCharge>(Eggstensions.Offsets.ExtraDataList.GetCharge);
				static public Delegates.Types.ExtraDataList.HasExtraData HasExtraData { get; }	= System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.ExtraDataList.HasExtraData>(Eggstensions.Offsets.ExtraDataList.HasExtraData);
			}

			static public class InventoryChanges
			{
				static public Delegates.Types.InventoryChanges.ResetWeight ResetWeight { get; } = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.InventoryChanges.ResetWeight>(Eggstensions.Offsets.InventoryChanges.ResetWeight);
			}

			static public class InventoryEntryData
			{
				static public Delegates.Types.InventoryEntryData.IsWorn IsWorn { get; } = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.InventoryEntryData.IsWorn>(Eggstensions.Offsets.InventoryEntryData.IsWorn);
			}

			static public class MagicItem
			{
				static public Delegates.Types.MagicItem.GetCost GetCost { get; }						= System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.MagicItem.GetCost>(Eggstensions.Offsets.MagicItem.GetCost);
				static public Delegates.Types.MagicItem.GetCostActorValue GetCostActorValue { get; }	= System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.MagicItem.GetCostActorValue>(Eggstensions.Offsets.MagicItem.GetCostActorValue);
			}

			static public class ScriptEventSourceHolder
			{
				static public Delegates.Types.ScriptEventSourceHolder.GetInstance GetInstance { get; } = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.ScriptEventSourceHolder.GetInstance>(Eggstensions.Offsets.ScriptEventSourceHolder.GetInstance);
			}

			static public class SpellItem
			{
				static public Delegates.Types.SpellItem.ShouldAddSpell ShouldAddSpell { get; } = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.SpellItem.ShouldAddSpell>(Eggstensions.Offsets.SpellItem.ShouldAddSpell);
			}

			static public class TESDataHandler
			{
				static public Delegates.Types.TESDataHandler.GetForm GetForm { get; } = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.TESDataHandler.GetForm>(Eggstensions.Offsets.TESDataHandler.GetForm);
			}

			static public class TESForm
			{
				static public Delegates.Types.TESForm.GetEnchantment GetEnchantment { get; }		= System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.TESForm.GetEnchantment>(Eggstensions.Offsets.TESForm.GetEnchantment);
				static public Delegates.Types.TESForm.GetFullName GetFullName { get; }				= System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.TESForm.GetFullName>(Eggstensions.Offsets.TESForm.GetFullName);
				static public Delegates.Types.TESForm.GetMaximumCharge GetMaximumCharge { get; }	= System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.TESForm.GetMaximumCharge>(Eggstensions.Offsets.TESForm.GetMaximumCharge);
			}

			static public class TESObjectREFR
			{
				static public Delegates.Types.TESObjectREFR.GetInventoryChanges GetInventoryChanges { get; } = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.TESObjectREFR.GetInventoryChanges>(Eggstensions.Offsets.TESObjectREFR.GetInventoryChanges);
			}

			static public class UI
			{
				static public Delegates.Types.UI.Notification Notification { get; } = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.UI.Notification>(Eggstensions.Offsets.UI.Notification);
			}
		}

		namespace Types
		{
			unsafe static public class ActiveEffect
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate void Dispel(Eggstensions.ActiveEffect* activeEffect, System.Byte force);
			}

			unsafe static public class Actor
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate System.Byte AddSpell(Eggstensions.Actor* actor, Eggstensions.SpellItem* spell);

				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate System.Single GetActorValueModifier(Eggstensions.Actor* actor, System.Int32 actorValueModifier, System.Int32 actorValue);

				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)] // Virtual
				public delegate Eggstensions.MagicCaster* GetMagicCaster(Eggstensions.Actor* actor, System.Int32 castingSource);

				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate void RemoveActorValueModifiers(Eggstensions.Actor* actor, System.Int32 actorValue);

				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate void RevertSelectedSpell(Eggstensions.Actor* actor, System.Int32 equipType, Eggstensions.MagicItem* magicItem);

				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate void UpdateMovementSpeed(Eggstensions.Actor* actor);
			}

			unsafe static public class ActorValueOwner
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)] // Virtual
				public delegate System.Single GetActorValue(Eggstensions.ActorValueOwner* actorValueOwner, System.Int32 actorValue);

				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)] // Virtual
				public delegate System.Single GetPermanentActorValue(Eggstensions.ActorValueOwner* actorValueOwner, System.Int32 actorValue);

				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)] // Virtual
				public delegate void RestoreActorValue(Eggstensions.ActorValueOwner* actorValueOwner, System.Int32 actorValueModifier, System.Int32 actorValue, System.Single value);

				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)] // Virtual
				public delegate void SetActorValue(Eggstensions.ActorValueOwner* actorValueOwner, System.Int32 actorValue, System.Single value);
			}

			unsafe static public class BGSEntryPointFunctionData
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)] // Virtual
				new public delegate System.Int32 GetType(Eggstensions.BGSEntryPointFunctionData* entryPointFunctionData);
			}

			unsafe static public class BGSEntryPointPerkEntry
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate void HandleEntryPoints1(System.Int32 entryPoint, Eggstensions.Actor* perkOwner, void* result1);

				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate void HandleEntryPoints2(System.Int32 entryPoint, Eggstensions.Actor* perkOwner, void* argument2, void* result1);

				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate void HandleEntryPoints3(System.Int32 entryPoint, Eggstensions.Actor* perkOwner, void* argument2, void* argument3, void* result1);
			}

			unsafe static public class BGSPerkEntry
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)] // Virtual
				public delegate void AddPerkEntry(Eggstensions.BGSPerkEntry* perkEntry, Eggstensions.Actor* perkOwner);

				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)] // Virtual
				public delegate System.Byte EvaluateConditions(Eggstensions.BGSPerkEntry* perkEntry, System.Int32 argumentCount, System.IntPtr arguments);

				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)] // Virtual
				public delegate System.Byte GetFunction(Eggstensions.BGSPerkEntry* perkEntry);

				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)] // Virtual
				public delegate Eggstensions.BGSEntryPointFunctionData* GetFunctionData(Eggstensions.BGSPerkEntry* perkEntry);

				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)] // Virtual
				public delegate void RemovePerkEntry(Eggstensions.BGSPerkEntry* perkEntry, Eggstensions.Actor* perkOwner);
			}

			unsafe static public class BSTArray
			{
				static public class IntPtr
				{
					[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
					public delegate System.Int32 Push(Eggstensions.BSTArray* array, System.IntPtr element);
				}



				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate void Deallocate(Eggstensions.BSTArray* array);
			}

			unsafe static public class BSTEventSink
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)] // Virtual
				public delegate void Destructor(System.IntPtr eventSink);

				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)] // Virtual
				public delegate System.Int32 ProcessEvent(System.IntPtr eventSink, void* eventArguments, void* eventSource);
			}

			unsafe static public class BSTEventSource
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate void AddEventSink(Eggstensions.BSTEventSource* eventSource, System.IntPtr eventSink);

				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate void RemoveEventSink(Eggstensions.BSTEventSource* eventSource, System.IntPtr eventSink);
			}

			unsafe static public class Context
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate void CaptureContext(Eggstensions.Context* context);
			}

			unsafe static public class ExtraDataList
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate System.Single GetCharge(Eggstensions.ExtraDataList* extraDataList);

				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate System.Byte HasExtraData(Eggstensions.ExtraDataList* extraDataList, System.Int32 extraDataType);
			}

			unsafe static public class InitTESThread
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)] // Virtual
				public delegate void Initialize(Eggstensions.InitTESThread* initTESThread);
			}

			unsafe static public class InventoryChanges
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate System.Byte ResetWeight(Eggstensions.InventoryChanges* inventoryChanges);
			}

			unsafe static public class InventoryEntryData
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate System.Byte IsWorn(Eggstensions.InventoryEntryData* inventoryEntryData);
			}

			unsafe static public class MagicCaster
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)] // Virtual
				public delegate void Cast(Eggstensions.MagicCaster* magicCaster, Eggstensions.SpellItem* spell, System.Byte noHitEffectArt, Eggstensions.Actor* target, System.Single effectiveness, System.Byte hostileEffectivenessOnly, System.Single magnitudeOverride, Eggstensions.Actor* cause);
			}

			unsafe static public class MagicItem
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)] // Virtual
				public delegate System.Int32 GetCastingType(Eggstensions.MagicItem* magicItem);

				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate System.Single GetCost(Eggstensions.MagicItem* magicItem, Eggstensions.Actor* caster);

				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate System.Int32 GetCostActorValue(Eggstensions.MagicItem* magicItem, System.Int32 rightHand);

				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)] // Virtual
				public delegate System.Int32 GetSpellType(Eggstensions.MagicItem* magicItem);
			}

			unsafe static public class NiObject
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)] // Virtual
				public delegate Eggstensions.NiNode* AsNode(Eggstensions.NiObject* niObject);
			}

			unsafe static public class ReferenceEffectController
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)] // Virtual
				public delegate Eggstensions.NiAVObject* GetAttachRoot(Eggstensions.ReferenceEffectController* referenceEffectController);
			}

			unsafe static public class ScriptEventSourceHolder
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate Eggstensions.ScriptEventSourceHolder* GetInstance();
			}

			unsafe static public class SpellItem
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate System.Byte ShouldAddSpell(Eggstensions.SpellItem* spell);
			}

			unsafe static public class TESAmmo
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)] // Virtual
				public delegate System.Byte IsPlayable(Eggstensions.TESAmmo* ammo);
			}

			unsafe static public class TESDataHandler
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate Eggstensions.TESForm* GetForm(System.UInt32 formID);
			}

			unsafe static public class TESForm
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate Eggstensions.EnchantmentItem* GetEnchantment(Eggstensions.TESForm* form, Eggstensions.ExtraDataList* extraDataList);

				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate System.IntPtr GetFullName(Eggstensions.TESForm* form);

				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate System.UInt16 GetMaximumCharge(Eggstensions.TESForm* form, Eggstensions.ExtraDataList* extraDataList);

				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)] // Virtual
				public delegate void RemoveChanges(Eggstensions.TESForm* form, System.UInt32 changeFlags);
			}

			unsafe static public class TESFullName
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)] // Virtual
				public delegate System.IntPtr GetFullName(Eggstensions.TESFullName* fullName);
			}

			unsafe static public class TESObjectREFR
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)] // Virtual
				public delegate Eggstensions.NiAVObject* GetCurrent3D(Eggstensions.TESObjectREFR* reference);

				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate Eggstensions.InventoryChanges* GetInventoryChanges(Eggstensions.TESObjectREFR* reference);
			}

			static public class UI
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
				public delegate void Notification([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPStr)] System.String text, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPStr)] System.String sound, System.Byte queueOnce);
			}
		}
	}
}
