namespace Eggstensions
{
	namespace Marshal
	{
		namespace Delegates
		{
			namespace Instances
			{
				static public class BGSEntryPointPerkEntry
				{
					static public Delegates.Types.BGSEntryPointPerkEntry.HandleEntryPoints1BSTArray HandleEntryPoints1BSTArray { get; } = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.BGSEntryPointPerkEntry.HandleEntryPoints1BSTArray>(Offsets.BGSEntryPointPerkEntry.HandleEntryPoints);
					static public Delegates.Types.BGSEntryPointPerkEntry.HandleEntryPoints2BSTArray HandleEntryPoints2BSTArray { get; } = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.BGSEntryPointPerkEntry.HandleEntryPoints2BSTArray>(Offsets.BGSEntryPointPerkEntry.HandleEntryPoints);
					static public Delegates.Types.BGSEntryPointPerkEntry.HandleEntryPoints3BSTArray HandleEntryPoints3BSTArray { get; } = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.BGSEntryPointPerkEntry.HandleEntryPoints3BSTArray>(Offsets.BGSEntryPointPerkEntry.HandleEntryPoints);
				}

				static public class BSTArray
				{
					static public class IntPtr
					{
						static public Delegates.Types.BSTArray.IntPtr.Push Push { get; } = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.BSTArray.IntPtr.Push>(Offsets.BSTArray.IntPtr.Push);
					}



					static public Delegates.Types.BSTArray.Deallocate Deallocate { get; } = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.BSTArray.Deallocate>(Offsets.BSTArray.Deallocate);
				}
			}

			namespace Types
			{
				static public class BGSEntryPointPerkEntry
				{
					[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
					public delegate void HandleEntryPoints1BSTArray(System.Int32 entryPoint, System.IntPtr perkOwner, Marshal.BSTArray result1);

					[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
					public delegate void HandleEntryPoints2BSTArray(System.Int32 entryPoint, System.IntPtr perkOwner, System.IntPtr argument2, Marshal.BSTArray result1);

					[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
					public delegate void HandleEntryPoints3BSTArray(System.Int32 entryPoint, System.IntPtr perkOwner, System.IntPtr argument2, System.IntPtr argument3, Marshal.BSTArray result1);
				}

				static public class BSTArray
				{
					static public class IntPtr
					{
						[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
						public delegate System.Int32 Push(Marshal.BSTArray array, ref System.IntPtr element);
					}



					[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
					public delegate void Deallocate(Marshal.BSTArray array);
				}
			}
		}
	}
	
	namespace Delegates
	{
		namespace Instances
		{
			static public class ActiveEffect
			{
				static public Delegates.Types.ActiveEffect.Dispel Dispel { get; } = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.ActiveEffect.Dispel>(Offsets.ActiveEffect.Dispel);
			}
			
			static public class Actor
			{
				static public Delegates.Types.Actor.AddSpell AddSpell { get; } = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.Actor.AddSpell>(Offsets.Actor.AddSpell);
			}

			static public class BGSEntryPointPerkEntry
			{
				static public Delegates.Types.BGSEntryPointPerkEntry.HandleEntryPoints1IntPtr HandleEntryPoints1IntPtr { get; } = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.BGSEntryPointPerkEntry.HandleEntryPoints1IntPtr>(Offsets.BGSEntryPointPerkEntry.HandleEntryPoints);

				static public Delegates.Types.BGSEntryPointPerkEntry.HandleEntryPoints2IntPtr HandleEntryPoints2IntPtr { get; } = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.BGSEntryPointPerkEntry.HandleEntryPoints2IntPtr>(Offsets.BGSEntryPointPerkEntry.HandleEntryPoints);

				static public Delegates.Types.BGSEntryPointPerkEntry.HandleEntryPoints2Single HandleEntryPoints2Single { get; } = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.BGSEntryPointPerkEntry.HandleEntryPoints2Single>(Offsets.BGSEntryPointPerkEntry.HandleEntryPoints);

				static public Delegates.Types.BGSEntryPointPerkEntry.HandleEntryPoints3IntPtr HandleEntryPoints3IntPtr { get; } = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.BGSEntryPointPerkEntry.HandleEntryPoints3IntPtr>(Offsets.BGSEntryPointPerkEntry.HandleEntryPoints);
			}

			static public class BSTArray
			{
				static public class IntPtr
				{
					static public Delegates.Types.BSTArray.IntPtr.Push Push { get; } = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.BSTArray.IntPtr.Push>(Offsets.BSTArray.IntPtr.Push);
				}
				
				
				
				static public Delegates.Types.BSTArray.Deallocate Deallocate { get; } = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.BSTArray.Deallocate>(Offsets.BSTArray.Deallocate);
			}

			static public class BSTEventSink
			{
				static public Delegates.Types.BSTEventSink.AddHarvestEventSink AddHarvestEventSink { get; }			= System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.BSTEventSink.AddHarvestEventSink>(Offsets.BSTEventSink.AddHarvestEventSink);
				static public Delegates.Types.BSTEventSink.RemoveHarvestEventSink RemoveHarvestEventSink { get; }	= System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.BSTEventSink.RemoveHarvestEventSink>(Offsets.BSTEventSink.RemoveHarvestEventSink);
			}

			static public class BSTEventSource
			{
				static public Delegates.Types.BSTEventSource.AddEventSink AddEventSink { get; }			= System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.BSTEventSource.AddEventSink>(Offsets.BSTEventSource.AddEventSink);
				static public Delegates.Types.BSTEventSource.RemoveEventSink RemoveEventSink { get; }	= System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.BSTEventSource.RemoveEventSink>(Offsets.BSTEventSource.RemoveEventSink);
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

			static public class UI
			{
				static public Delegates.Types.UI.Notification Notification { get; } = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.UI.Notification>(Offsets.UI.Notification);
			}
		}

		namespace Types
		{
			static public class ActiveEffect
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate void Dispel(System.IntPtr activeEffect, System.Byte force);
			}
			
			static public class Actor
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate System.Byte AddSpell(System.IntPtr actor, System.IntPtr spell);

				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)] // Virtual
				public delegate System.IntPtr GetMagicCaster(System.IntPtr actor, System.Int32 castingSource);
			}

			static public class BGSEntryPointFunctionData
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)] // Virtual
				new public delegate System.Int32 GetType(System.IntPtr entryPointFunctionData);
			}

			static public class BGSEntryPointPerkEntry
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate void HandleEntryPoints1IntPtr(System.Int32 entryPoint, System.IntPtr perkOwner, ref System.IntPtr result1);

				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate void HandleEntryPoints2IntPtr(System.Int32 entryPoint, System.IntPtr perkOwner, System.IntPtr argument2, ref System.IntPtr result1);

				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate void HandleEntryPoints2Single(System.Int32 entryPoint, System.IntPtr perkOwner, System.IntPtr argument2, ref System.Single result1);

				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate void HandleEntryPoints3IntPtr(System.Int32 entryPoint, System.IntPtr perkOwner, System.IntPtr argument2, System.IntPtr argument3, ref System.IntPtr result1);
			}

			static public class BGSPerkEntry
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)] // Virtual
				public delegate System.Byte EvaluateConditions(System.IntPtr perkEntry, System.Int32 argumentCount, System.IntPtr arguments);

				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)] // Virtual
				public delegate System.Byte GetFunction(System.IntPtr perkEntry);

				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)] // Virtual
				public delegate System.IntPtr GetFunctionData(System.IntPtr perkEntry);
			}

			static public class BSTArray
			{
				static public class IntPtr
				{
					[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
					public delegate System.Int32 Push(System.IntPtr array, ref System.IntPtr element);
				}



				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate void Deallocate(System.IntPtr array);
			}

			static public class BSTEventSink
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate void AddHarvestEventSink(System.IntPtr eventSink);

				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)] // Virtual
				public delegate void Destructor(System.IntPtr eventSink);

				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)] // Virtual
				public delegate System.Int32 ProcessEvent(System.IntPtr eventSink, System.IntPtr eventArguments, System.IntPtr eventSource);

				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate void RemoveHarvestEventSink(System.IntPtr eventSink);
			}

			static public class BSTEventSource
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate void AddEventSink(System.IntPtr eventSource, System.IntPtr eventSink);

				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate void RemoveEventSink(System.IntPtr eventSource, System.IntPtr eventSink);
			}

			static public class InventoryEntryData
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate System.Byte IsWorn(System.IntPtr inventoryEntryData);
			}

			static public class MagicCaster
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)] // Virtual
				public delegate void Cast(System.IntPtr magicCaster, System.IntPtr spell, System.Byte noHitEffectArt, System.IntPtr target, System.Single dualCastingMultiplier, System.Byte hostileDualCastingMultiplierOnly, System.Single magnitudeOverride, System.IntPtr unknownPointer);
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

			static public class TESFullName
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)] // Virtual
				public delegate System.IntPtr GetFullName(System.IntPtr fullName);
			}

			static public class TESObjectREFR
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)] // Virtual
				public delegate System.IntPtr GetCurrent3D(System.IntPtr reference);
			}

			static public class UI
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
				public delegate void Notification([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPStr)] System.String text, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPStr)] System.String sound, System.Byte queueOnce);
			}
		}
	}
}
