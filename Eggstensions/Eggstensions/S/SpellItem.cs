namespace Eggstensions
{
	public interface ISpellItem : IMagicItem
	{
	}

	public struct SpellItem : ISpellItem
	{
	}



	namespace ExtensionMethods
	{
		unsafe static public class ISpellItem
		{
			// Member
			/// <summary>SkyrimSE.exe + 0x632180 (VID 37817)</summary>
			static public void Apply<TSpellItem, TActor1, TActor2>(this ref TSpellItem spell, TActor1* source, TActor2* target)
				where TSpellItem : unmanaged, Eggstensions.ISpellItem
				where TActor1 : unmanaged, Eggstensions.IActor
				where TActor2 : unmanaged, Eggstensions.IActor
			{
				if (spell.ShouldAddSpell())
				{
					target->AddSpell(spell.AsPointer());
				}
				else
				{
					var magicCaster = source->GetMagicCaster(CastingSource.Instant);

					magicCaster->Cast(spell.AsPointer(), false, target, 1.0F, false, 0.0F, (Actor*)null);
				}
			}

			static public System.Boolean ShouldAddSpell<TSpellItem>(this ref TSpellItem spell)
				where TSpellItem : unmanaged, Eggstensions.ISpellItem
			{
				var shouldAddSpell = (delegate* unmanaged[Cdecl]<TSpellItem*, System.Byte>)Eggstensions.Offsets.SpellItem.ShouldAddSpell;

				return ShouldAddSpell(spell.AsPointer()) != 0;



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				System.Byte ShouldAddSpell(TSpellItem* spell)
				{
					return shouldAddSpell(spell);
				}
			}
		}
	}
}
