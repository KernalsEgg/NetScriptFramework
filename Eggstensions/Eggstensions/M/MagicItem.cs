namespace Eggstensions
{
	public enum CastingSource : System.Int32
	{
		LeftHand	= 0,
		RightHand	= 1,
		Other		= 2,
		Instant		= 3
	}

	public enum SpellType : System.Int32
	{
		Spell				= 0,
		Disease				= 1,
		Power				= 2,
		LesserPower			= 3,
		Ability				= 4,
		Poison				= 5,
		Enchantment			= 6,
		Potion				= 7,
		Ingredient			= 8,
		LeveledSpell		= 9,
		Addiction			= 10,
		VoicePower			= 11,
		StaffEnchantment	= 12,
		Scroll				= 13,

		AddSpell = (1 << Disease) | (1 << Ability) | (1 << Addiction)
	}



	public class MagicItem : TESBoundObject
	{
		public MagicItem(System.IntPtr address) : base(address)
		{
		}



		virtual public SpellType GetSpellType()
		{
			var getSpellType = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.MagicItem.GetSpellType>(this[0x53]);

			return (SpellType)getSpellType(this);
		}



		static public explicit operator TESFullName(MagicItem magicItem)
		{
			return new TESFullName(magicItem, 0x30);
		}
	}
}
