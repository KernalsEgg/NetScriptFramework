namespace Eggstensions
{
	class BGSEntryPointFunctionDataSpellItem : BGSEntryPointFunctionData
	{
		public BGSEntryPointFunctionDataSpellItem(System.IntPtr address) : base(address)
		{
		}



		public SpellItem Spell
		{
			get
			{
				return Memory.Read<System.IntPtr>(this, 0x8);
			}
		}



		static public implicit operator BGSEntryPointFunctionDataSpellItem(System.IntPtr address)
		{
			return new BGSEntryPointFunctionDataSpellItem(address);
		}
	}
}
