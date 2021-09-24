namespace Eggstensions
{
	public interface IBGSEntryPointPerkEntry : IBGSPerkEntry
	{
	}

	unsafe public struct BGSEntryPointPerkEntry
	{
		// Static
		static public void HandleEntryPoints<TActor>(EntryPoint entryPoint, TActor* perkOwner, void* result1)
			where TActor : unmanaged, IActor
		{
			var handleEntryPoints = (delegate* unmanaged[Cdecl]<System.Int32, TActor*, void*, void>)Eggstensions.Offsets.BGSEntryPointPerkEntry.HandleEntryPoints;

			HandleEntryPoints((System.Int32)entryPoint, perkOwner, result1);



			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			void HandleEntryPoints(System.Int32 entryPoint, TActor* perkOwner, void* result1)
			{
				handleEntryPoints(entryPoint, perkOwner, result1);
			}
		}

		static public void HandleEntryPoints<TActor>(EntryPoint entryPoint, TActor* perkOwner, void* argument2, void* result1)
			where TActor : unmanaged, IActor
		{
			var handleEntryPoints = (delegate* unmanaged[Cdecl]<System.Int32, TActor*, void*, void*, void>)Eggstensions.Offsets.BGSEntryPointPerkEntry.HandleEntryPoints;

			HandleEntryPoints((System.Int32)entryPoint, perkOwner, argument2, result1);



			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			void HandleEntryPoints(System.Int32 entryPoint, TActor* perkOwner, void* argument2, void* result1)
			{
				handleEntryPoints(entryPoint, perkOwner, argument2, result1);
			}
		}

		static public void HandleEntryPoints<TActor>(EntryPoint entryPoint, TActor* perkOwner, void* argument2, void* argument3, void* result1)
			where TActor : unmanaged, IActor
		{
			var handleEntryPoints = (delegate* unmanaged[Cdecl]<System.Int32, TActor*, void*, void*, void*, void>)Eggstensions.Offsets.BGSEntryPointPerkEntry.HandleEntryPoints;

			HandleEntryPoints((System.Int32)entryPoint, perkOwner, argument2, argument3, result1);



			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			void HandleEntryPoints(System.Int32 entryPoint, TActor* perkOwner, void* argument2, void* argument3, void* result1)
			{
				handleEntryPoints(entryPoint, perkOwner, argument2, argument3, result1);
			}
		}
	}



	namespace ExtensionMethods
	{
		unsafe static public class IBGSEntryPointPerkEntry
		{
			// Field
			static public EntryPoint EntryPoint<TBGSEntryPointPerkEntry>(this ref TBGSEntryPointPerkEntry entryPointPerkEntry)
				where TBGSEntryPointPerkEntry : unmanaged, Eggstensions.IBGSEntryPointPerkEntry
			{
				return (EntryPoint)(*(System.Byte*)entryPointPerkEntry.AddByteOffset(0x10));
			}

			static public EntryPointFunction Function<TBGSEntryPointPerkEntry>(this ref TBGSEntryPointPerkEntry entryPointPerkEntry)
				where TBGSEntryPointPerkEntry : unmanaged, Eggstensions.IBGSEntryPointPerkEntry
			{
				return (EntryPointFunction)(*(System.Byte*)entryPointPerkEntry.AddByteOffset(0x11));
			}

			static public System.Byte ArgumentCount<TBGSEntryPointPerkEntry>(this ref TBGSEntryPointPerkEntry entryPointPerkEntry)
				where TBGSEntryPointPerkEntry : unmanaged, Eggstensions.IBGSEntryPointPerkEntry
			{
				return *(System.Byte*)entryPointPerkEntry.AddByteOffset(0x12);
			}
		}
	}
}
