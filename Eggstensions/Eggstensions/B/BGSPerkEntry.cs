namespace Eggstensions
{
	public enum EntryPoint : System.Byte
	{
		ModSpellMagnitude		= 29,
		ModArmorWeight			= 32,
		ApplyCombatHitSpell		= 51,
		ApplyBashingSpell		= 52,
		ApplyReanimateSpell		= 53,
		ApplyWeaponSwingSpell	= 67,
		ApplySneakingSpell		= 69
	}

	public enum EntryPointFunction : System.Byte
	{
		SelectSpell = 10
	}

	public enum EntryPointFunctionResult : System.Byte
	{
		Value					= 0,
		LeveledList				= 1,
		ActivateChoice			= 2,
		// 3
		SpellItem				= 4,
		BooleanGraphVariable	= 5,
		Text					= 6
	}

	public enum PerkEntryType : System.Byte
	{
		Quest		= 0,
		Ability		= 1,
		EntryPoint	= 2
	}



	public interface IBGSPerkEntry : IVirtualObject
	{
	}

	public struct BGSPerkEntry : IBGSPerkEntry
	{
	}



	namespace ExtensionMethods
	{
		unsafe static public class IBGSPerkEntry
		{
			// Field
			static public System.Byte Rank<TBGSPerkEntry>(this ref TBGSPerkEntry perkEntry)
				where TBGSPerkEntry : unmanaged, Eggstensions.IBGSPerkEntry
			{
				return *(System.Byte*)perkEntry.AddByteOffset(0x8);
			}

			static public System.Byte Priority<TBGSPerkEntry>(this ref TBGSPerkEntry perkEntry)
				where TBGSPerkEntry : unmanaged, Eggstensions.IBGSPerkEntry
			{
				return *(System.Byte*)perkEntry.AddByteOffset(0x9);
			}



			// Virtual
			static public System.Boolean EvaluateConditions<TBGSPerkEntry>(this ref TBGSPerkEntry perkEntry, System.Int32 argumentCount, System.IntPtr arguments)
				where TBGSPerkEntry : unmanaged, Eggstensions.IBGSPerkEntry
			{
				var evaluateConditions = (delegate* unmanaged[Cdecl]<TBGSPerkEntry*, System.Int32, System.IntPtr, System.Byte>)perkEntry.VirtualFunction(0x0);

				return EvaluateConditions(perkEntry.AsPointer(), argumentCount, arguments) != 0;



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				System.Byte EvaluateConditions(TBGSPerkEntry* perkEntry, System.Int32 argumentCount, System.IntPtr arguments)
				{
					return evaluateConditions(perkEntry, argumentCount, arguments);
				}
			}

			static public EntryPointFunction GetFunction<TBGSPerkEntry>(this ref TBGSPerkEntry perkEntry)
				where TBGSPerkEntry : unmanaged, Eggstensions.IBGSPerkEntry
			{
				var getFunction = (delegate* unmanaged[Cdecl]<TBGSPerkEntry*, System.Byte>)perkEntry.VirtualFunction(0x1);

				return (EntryPointFunction)GetFunction(perkEntry.AsPointer());



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				System.Byte GetFunction(TBGSPerkEntry* perkEntry)
				{
					return getFunction(perkEntry);
				}
			}

			static public BGSEntryPointFunctionData* GetFunctionData<TBGSPerkEntry>(this ref TBGSPerkEntry perkEntry)
				where TBGSPerkEntry : unmanaged, Eggstensions.IBGSPerkEntry
			{
				var getFunctionData = (delegate* unmanaged[Cdecl]<TBGSPerkEntry*, BGSEntryPointFunctionData*>)perkEntry.VirtualFunction(0x2);

				return GetFunctionData(perkEntry.AsPointer());



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				BGSEntryPointFunctionData* GetFunctionData(TBGSPerkEntry* perkEntry)
				{
					return getFunctionData(perkEntry);
				}
			}

			static public void AddPerkEntry<TBGSPerkEntry, TActor>(this ref TBGSPerkEntry perkEntry, TActor* perkOwner)
				where TBGSPerkEntry : unmanaged, Eggstensions.IBGSPerkEntry
				where TActor : unmanaged, Eggstensions.IActor
			{
				var addPerkEntry = (delegate* unmanaged[Cdecl]<TBGSPerkEntry*, TActor*, void>)perkEntry.VirtualFunction(0xA);

				AddPerkEntry(perkEntry.AsPointer(), perkOwner);



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				void AddPerkEntry(TBGSPerkEntry* perkEntry, TActor* perkOwner)
				{
					addPerkEntry(perkEntry, perkOwner);
				}
			}

			static public void RemovePerkEntry<TBGSPerkEntry, TActor>(this ref TBGSPerkEntry perkEntry, TActor* perkOwner)
				where TBGSPerkEntry : unmanaged, Eggstensions.IBGSPerkEntry
				where TActor : unmanaged, Eggstensions.IActor
			{
				var removePerkEntry = (delegate* unmanaged[Cdecl]<TBGSPerkEntry*, TActor*, void>)perkEntry.VirtualFunction(0xB);

				RemovePerkEntry(perkEntry.AsPointer(), perkOwner);



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				void RemovePerkEntry(TBGSPerkEntry* perkEntry, TActor* perkOwner)
				{
					removePerkEntry(perkEntry, perkOwner);
				}
			}
		}
	}
}
