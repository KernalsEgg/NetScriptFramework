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



	public class BGSPerkEntry : VirtualObject
	{
		public BGSPerkEntry(System.IntPtr address) : base(address)
		{
		}



		public System.Byte Rank
		{
			get
			{
				return Memory.Read<System.Byte>(this, 0x8);
			}
		}

		public System.Byte Priority
		{
			get
			{
				return Memory.Read<System.Byte>(this, 0x9);
			}
		}



		virtual public System.Boolean EvaluateConditions(System.Int32 argumentCount, System.IntPtr arguments)
		{
			var evaluateConditions = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.BGSPerkEntry.EvaluateConditions>(this[0x0]);

			return evaluateConditions(this, argumentCount, arguments) != 0;
		}

		virtual public EntryPointFunction GetFunction()
		{
			var getFunction = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.BGSPerkEntry.GetFunction>(this[0x1]);

			return (EntryPointFunction)getFunction(this);
		}

		/// <returns>BGSEntryPointFunctionData*</returns>
		virtual public System.IntPtr GetFunctionData()
		{
			var getFunctionData = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.BGSPerkEntry.GetFunctionData>(this[0x2]);

			return getFunctionData(this);
		}
	}
}
