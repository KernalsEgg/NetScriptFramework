namespace Eggstensions
{
	public enum CastingSource : System.Int32
	{
		LeftHand	= 0,
		RightHand	= 1,
		Other		= 2,
		Instant		= 3
	}

	public enum CastingType : System.Int32
	{
		ConstantEffect	= 0,
		FireAndForget	= 1,
		Concentration	= 2,
		Scroll			= 3
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



	public interface IMagicItem : ITESBoundObject
	{
	}

	public struct MagicItem : IMagicItem
	{
	}



	namespace ExtensionMethods
	{
		unsafe static public class IMagicItem
		{
			// Inheritance
			static public TESFullName* TESFullName<TMagicItem>(this ref TMagicItem magicItem)
				where TMagicItem : unmanaged, Eggstensions.IMagicItem
			{
				return (TESFullName*)magicItem.AddByteOffset(0x30);
			}



			// Virtual
			static public SpellType GetSpellType<TMagicItem>(this ref TMagicItem magicItem)
				where TMagicItem : unmanaged, Eggstensions.IMagicItem
			{
				var getSpellType = (delegate* unmanaged[Cdecl]<TMagicItem*, System.Int32>)magicItem.VirtualFunction(0x53);

				return (SpellType)GetSpellType(magicItem.AsPointer());



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				System.Int32 GetSpellType(TMagicItem* magicItem)
				{
					return getSpellType(magicItem);
				}
			}

			static public CastingType GetCastingType<TMagicItem>(this ref TMagicItem magicItem)
				where TMagicItem : unmanaged, Eggstensions.IMagicItem
			{
				var getCastingType = (delegate* unmanaged[Cdecl]<TMagicItem*, System.Int32>)magicItem.VirtualFunction(0x55);

				return (CastingType)GetCastingType(magicItem.AsPointer());



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				System.Int32 GetCastingType(TMagicItem* magicItem)
				{
					return getCastingType(magicItem);
				}
			}



			// Member
			static public System.Single GetCost<TMagicItem, TActor>(this ref TMagicItem magicItem, TActor* caster)
				where TMagicItem : unmanaged, Eggstensions.IMagicItem
				where TActor : unmanaged, Eggstensions.IActor
			{
				var getCost = (delegate* unmanaged[Cdecl]<TMagicItem*, TActor*, System.Single>)Eggstensions.Offsets.MagicItem.GetCost;

				return GetCost(magicItem.AsPointer(), caster);



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				System.Single GetCost(TMagicItem* magicItem, TActor* caster)
				{
					return getCost(magicItem, caster);
				}
			}

			static public ActorValue GetCostActorValue<TMagicItem>(this ref TMagicItem magicItem, System.Boolean rightHand)
				where TMagicItem : unmanaged, Eggstensions.IMagicItem
			{
				var getCostActorValue = (delegate* unmanaged[Cdecl]<TMagicItem*, System.Int32, System.Int32>)Eggstensions.Offsets.MagicItem.GetCostActorValue;

				return (ActorValue)GetCostActorValue(magicItem.AsPointer(), rightHand ? 1 : 0);



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				System.Int32 GetCostActorValue(TMagicItem* magicItem, System.Int32 rightHand)
				{
					return getCostActorValue(magicItem, rightHand);
				}
			}
		}
	}
}
