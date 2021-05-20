namespace Eggstensions
{
	namespace Delegates
	{
		namespace Instances
		{
			static public class Actor
			{
				static public Delegates.Types.Actor.AddSpell AddSpell { get; } = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.Actor.AddSpell>(Offsets.Actor.AddSpell);
			}

			static public class BGSPerkEntry
			{
				static public Delegates.Types.BGSPerkEntry.HandleEntryPoint1 HandleEntryPoint1 { get; } = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.BGSPerkEntry.HandleEntryPoint1>(Offsets.BGSPerkEntry.HandlePerkEntry);

				static public Delegates.Types.BGSPerkEntry.HandleEntryPoint2 HandleEntryPoint2 { get; } = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.BGSPerkEntry.HandleEntryPoint2>(Offsets.BGSPerkEntry.HandlePerkEntry);

				static public Delegates.Types.BGSPerkEntry.HandleEntryPoint3 HandleEntryPoint3 { get; } = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.BGSPerkEntry.HandleEntryPoint3>(Offsets.BGSPerkEntry.HandlePerkEntry);
			}

			static public class BSTEventSource
			{
				static public Delegates.Types.BSTEventSource.AddEventSink AddEventSink { get; } = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.BSTEventSource.AddEventSink>(Offsets.BSTEventSource.AddEventSink);
			}

			static public class InventoryEntryData
			{
				static public Delegates.Types.InventoryEntryData.IsWorn IsWorn { get; } = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.InventoryEntryData.IsWorn>(Offsets.InventoryEntryData.IsWorn);
			}

			static public class ScriptEventSourceHolder
			{
				static public Delegates.Types.ScriptEventSourceHolder.GetInstance GetInstance { get; } = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.ScriptEventSourceHolder.GetInstance>(Offsets.ScriptEventSourceHolder.GetInstance);
			}

			static public class TESDataHandler
			{
				static public Delegates.Types.TESDataHandler.GetForm GetForm { get; } = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.TESDataHandler.GetForm>(Offsets.TESDataHandler.GetForm);
			}
		}

		namespace Types
		{
			static public class Actor
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate System.Boolean AddSpell(System.IntPtr actor, System.IntPtr spell);

				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)] // Virtual
				public delegate System.IntPtr GetMagicCaster(System.IntPtr actor, System.Int32 castingSource);
			}
			
			static public class BGSPerkEntry
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate void HandleEntryPoint1(System.Int32 perkEntryPoint, System.IntPtr perkOwner, System.IntPtr argument1);

				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate void HandleEntryPoint2(System.Int32 perkEntryPoint, System.IntPtr perkOwner, System.IntPtr argument1, System.IntPtr argument2);

				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate void HandleEntryPoint3(System.Int32 perkEntryPoint, System.IntPtr perkOwner, System.IntPtr argument1, System.IntPtr argument2, System.IntPtr argument3);
			}

			static public class BSTEventSource
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate void AddEventSink(System.IntPtr eventSource, System.IntPtr eventSink);
			}

			static public class InventoryEntryData
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate System.Boolean IsWorn(System.IntPtr inventoryEntryData);
			}

			static public class MagicCaster
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)] // Virtual
				public delegate void Cast(System.IntPtr magicCaster, System.IntPtr spell, System.Boolean noHitEffectArt, System.IntPtr target, System.Single dualCastingMultiplier, System.Boolean hostileDualCastingMultiplierOnly, System.Single magnitudeOverride, System.IntPtr unknownPointer);
			}

			static public class MagicItem
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)] // Virtual
				public delegate System.Int32 GetSpellType(System.IntPtr magicItem);
			}

			static public class NiObject
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)] // Virtual
				public delegate System.IntPtr AsNode(System.IntPtr niObject);
			}

			static public class ReferenceEffectController
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)] // Virtual
				public delegate System.IntPtr GetAttachRoot(System.IntPtr referenceEffectController);
			}

			static public class ScriptEventSourceHolder
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate System.IntPtr GetInstance();
			}

			static public class TESDataHandler
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate System.IntPtr GetForm(System.UInt32 formID);
			}

			static public class TESForm
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)] // Virtual
				public delegate void RemoveChanges(System.IntPtr form, System.UInt32 changeFlags);
			}

			static public class TESObjectREFR
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)] // Virtual
				public delegate System.IntPtr GetCurrent3D(System.IntPtr reference);
			}
		}
	}
}
