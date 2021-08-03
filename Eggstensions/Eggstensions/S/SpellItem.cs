namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0xE8)]
	unsafe public struct SpellItem // MagicItem
	{
		[System.Runtime.InteropServices.FieldOffset(0x0)] public MagicItem MagicItem;



		// Member
		/// <summary>SkyrimSE.exe + 0x632180 (VID 37817)</summary>
		static public void Apply(SpellItem* spell, Actor* source, Actor* target)
		{
			var spellType = MagicItem.GetSpellType(&spell->MagicItem);
				
			if (((1 << (System.Int32)spellType) & (System.Int32)SpellType.AddSpell) != 0)
			{
				Actor.AddSpell(target, spell);
			}
			else
			{
				var magicCaster = Actor.GetMagicCaster(source, CastingSource.Instant);

				MagicCaster.Cast(magicCaster, spell, false, target, 1.0F, false, 0.0F, null);
			}
		}
	}
}
