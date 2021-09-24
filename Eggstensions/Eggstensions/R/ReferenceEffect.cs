namespace Eggstensions
{
	public interface IReferenceEffect : INiObject
	{
	}

	public struct ReferenceEffect : IReferenceEffect
	{
	}



	namespace ExtensionMethods
	{
		unsafe static public class IReferenceEffect
		{
			// Field
			static public ReferenceEffectController* Controller<TReferenceEffect>(this ref TReferenceEffect referenceEffect)
				where TReferenceEffect : unmanaged, Eggstensions.IReferenceEffect
			{
				return *(ReferenceEffectController**)referenceEffect.AddByteOffset(0x30);
			}
		}
	}
}
