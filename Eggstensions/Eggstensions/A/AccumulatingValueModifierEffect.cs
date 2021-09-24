namespace Eggstensions
{
	public interface IAccumulatingValueModifierEffect : IValueModifierEffect
	{
	}

	public struct AccumulatingValueModifierEffect : IAccumulatingValueModifierEffect
	{
	}



	namespace ExtensionMethods
	{
		unsafe static public class IAccumulatingValueModifierEffect
		{
			// Field
			static public System.Single CurrentMagnitude<TAccumulatingValueModifierEffect>(this ref TAccumulatingValueModifierEffect accumulatingValueModifierEffect)
				where TAccumulatingValueModifierEffect : unmanaged, Eggstensions.IAccumulatingValueModifierEffect
			{
				return *(System.Single*)accumulatingValueModifierEffect.AddByteOffset(0x98);
			}

			static public System.Single MaximumMagnitude<TAccumulatingValueModifierEffect>(this ref TAccumulatingValueModifierEffect accumulatingValueModifierEffect)
				where TAccumulatingValueModifierEffect : unmanaged, Eggstensions.IAccumulatingValueModifierEffect
			{
				return *(System.Single*)accumulatingValueModifierEffect.AddByteOffset(0x9C);
			}

			static public System.Single HoldDuration<TAccumulatingValueModifierEffect>(this ref TAccumulatingValueModifierEffect accumulatingValueModifierEffect)
				where TAccumulatingValueModifierEffect : unmanaged, Eggstensions.IAccumulatingValueModifierEffect
			{
				return *(System.Single*)accumulatingValueModifierEffect.AddByteOffset(0xA0);
			}
		}
	}
}
