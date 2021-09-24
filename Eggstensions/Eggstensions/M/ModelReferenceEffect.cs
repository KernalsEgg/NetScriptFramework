namespace Eggstensions
{
	public interface IModelReferenceEffect : IReferenceEffect
	{
	}

	public struct ModelReferenceEffect : IModelReferenceEffect
	{
	}



	namespace ExtensionMethods
	{
		unsafe static public class IModelReferenceEffect
		{
			// Field
			static public RefAttachTechniqueInput* HitEffectArtData<TModelReferenceEffect>(this ref TModelReferenceEffect modelReferenceEffect)
				where TModelReferenceEffect : unmanaged, Eggstensions.IModelReferenceEffect
			{
				return (RefAttachTechniqueInput*)modelReferenceEffect.AddByteOffset(0x68);
			}
		}
	}
}
