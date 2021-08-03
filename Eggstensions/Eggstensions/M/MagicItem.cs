﻿namespace Eggstensions
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



	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x90)]
	unsafe public struct MagicItem // TESBoundObject, TESFullName
	{
		[System.Runtime.InteropServices.FieldOffset(0x0)] public TESBoundObject TESBoundObject;
		[System.Runtime.InteropServices.FieldOffset(0x30)] public TESFullName TESFullName;



		// Virtual
		static public SpellType GetSpellType(MagicItem* magicItem)
		{
			var getSpellType = Memory.ReadVirtualFunction<Eggstensions.Delegates.Types.MagicItem.GetSpellType>(*(System.IntPtr*)magicItem, 0x53);

			return (SpellType)getSpellType(magicItem);
		}
	}
}
