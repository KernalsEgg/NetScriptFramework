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
					static public Delegates.Types.Fixes.SpeedMultUpdates.RemoveMovementFlags RemoveMovementFlags { get; } = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.Fixes.SpeedMultUpdates.RemoveMovementFlags>(Offsets.Fixes.SpeedMultUpdates.RemoveMovementFlags);

					static public Delegates.Types.Fixes.SpeedMultUpdates.UpdateMovementSpeed UpdateMovementSpeed { get; } = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.Fixes.SpeedMultUpdates.UpdateMovementSpeed>(Offsets.Fixes.SpeedMultUpdates.UpdateMovementSpeed);
				}
			}
		}

		namespace Types
		{
			namespace Fixes
			{
				static internal class SpeedMultUpdates
				{
					[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
					public delegate void ActorValueSink(System.IntPtr actor, System.Int32 actorValue, System.Single old, System.Single delta);

					[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
					public delegate void RemoveMovementFlags(System.IntPtr actor);

					[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
					public delegate void UpdateMovementSpeed(System.IntPtr actor);
				}
			}

			namespace Patches
			{
				namespace ApplySpellPerkEntryPoints
				{
					static internal class MultipleSpells
					{
						[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
						public delegate void EntryPointFunction(System.IntPtr perkOwner, System.Int32 result, System.Byte resultCount, System.IntPtr results, System.IntPtr entryPointFunctionDataSpellItem);
					}
				}
			}
		}
	}
}
