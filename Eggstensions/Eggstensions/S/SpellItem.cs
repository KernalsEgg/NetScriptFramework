namespace Eggstensions
{
	public class SpellItem : MagicItem
	{
		public SpellItem(System.IntPtr address) : base(address)
		{
		}



		/// <summary>SkyrimSE.exe + 0x632180 (VID 37817)</summary>
		public void Apply(Actor source, Actor target)
		{
			var spellType = this.GetSpellType();

			if (((1 << (System.Int32)spellType) & (System.Int32)SpellType.AddSpell) != 0)
			{
				target.AddSpell(this);
			}
			else
			{
				var magicCaster = source.GetMagicCaster(CastingSource.Instant);

				magicCaster.Cast(this, false, target, 1.0F, false, 0.0F, System.IntPtr.Zero);
			}
		}



		static public implicit operator SpellItem(System.IntPtr address)
		{
			return new SpellItem(address);
		}
	}
}
