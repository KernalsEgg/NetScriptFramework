namespace Eggstensions
{
	public interface IBGSEntryPointFunctionDataSpellItem : IBGSEntryPointFunctionData
	{
	}

	public struct BGSEntryPointFunctionDataSpellItem : IBGSEntryPointFunctionDataSpellItem
	{
	}



	namespace ExtensionMethods
	{
		unsafe static public class IBGSEntryPointFunctionDataSpellItem
		{
			// Field
			static public SpellItem* Spell<TBGSEntryPointFunctionDataSpellItem>(this ref TBGSEntryPointFunctionDataSpellItem entryPointFunctionDataSpellItem)
				where TBGSEntryPointFunctionDataSpellItem : unmanaged, Eggstensions.IBGSEntryPointFunctionDataSpellItem
			{
				return *(SpellItem**)entryPointFunctionDataSpellItem.AddByteOffset(0x8);
			}
		}
	}
}
