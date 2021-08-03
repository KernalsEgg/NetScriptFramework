namespace Eggstensions
{
	public enum EntryPoint : System.Byte
	{
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



	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x10)]
	unsafe public struct BGSPerkEntry
	{
		[System.Runtime.InteropServices.FieldOffset(0x8)] public System.Byte Rank;
		[System.Runtime.InteropServices.FieldOffset(0x9)] public System.Byte Priority;



		// Virtual
		static public System.Boolean EvaluateConditions(BGSPerkEntry* perkEntry, System.Int32 argumentCount, System.IntPtr arguments)
		{
			var evaluateConditions = Memory.ReadVirtualFunction<Eggstensions.Delegates.Types.BGSPerkEntry.EvaluateConditions>(*(System.IntPtr*)perkEntry, 0x0);

			return evaluateConditions(perkEntry, argumentCount, arguments) != 0;
		}

		static public EntryPointFunction GetFunction(BGSPerkEntry* perkEntry)
		{
			var getFunction = Memory.ReadVirtualFunction<Eggstensions.Delegates.Types.BGSPerkEntry.GetFunction>(*(System.IntPtr*)perkEntry, 0x1);

			return (EntryPointFunction)getFunction(perkEntry);
		}

		static public BGSEntryPointFunctionData* GetFunctionData(BGSPerkEntry* perkEntry)
		{
			var getFunctionData = Memory.ReadVirtualFunction<Eggstensions.Delegates.Types.BGSPerkEntry.GetFunctionData>(*(System.IntPtr*)perkEntry, 0x2);

			return getFunctionData(perkEntry);
		}

		static public void AddPerkEntry(BGSPerkEntry* perkEntry, Actor* perkOwner)
		{
			var addPerkEntry = Memory.ReadVirtualFunction<Eggstensions.Delegates.Types.BGSPerkEntry.AddPerkEntry>(*(System.IntPtr*)perkEntry, 0xA);

			addPerkEntry(perkEntry, perkOwner);
		}

		static public void RemovePerkEntry(BGSPerkEntry* perkEntry, Actor* perkOwner)
		{
			var removePerkEntry = Memory.ReadVirtualFunction<Eggstensions.Delegates.Types.BGSPerkEntry.RemovePerkEntry>(*(System.IntPtr*)perkEntry, 0xB);

			removePerkEntry(perkEntry, perkOwner);
		}
	}
}
