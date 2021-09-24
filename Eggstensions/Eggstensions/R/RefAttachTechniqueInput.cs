namespace Eggstensions
{
	public interface IRefAttachTechniqueInput : BSAttachTechniques.IAttachTechniqueInput
	{
	}

	public struct RefAttachTechniqueInput
	{
	}



	namespace ExtensionMethods
	{
		unsafe static public class IRefAttachTechniqueInput
		{
			// Field
			static public TESRace* Race<TRefAttachTechniqueInput>(this ref TRefAttachTechniqueInput referenceAttachTechniqueInput)
				where TRefAttachTechniqueInput : unmanaged, Eggstensions.IRefAttachTechniqueInput
			{
				return *(TESRace**)referenceAttachTechniqueInput.AddByteOffset(0x28);
			}

			static public bhkWorld* HavokWorld<TRefAttachTechniqueInput>(this ref TRefAttachTechniqueInput referenceAttachTechniqueInput)
				where TRefAttachTechniqueInput : unmanaged, Eggstensions.IRefAttachTechniqueInput
			{
				return *(bhkWorld**)referenceAttachTechniqueInput.AddByteOffset(0x30);
			}

			static public BSFixedString* NodeName<TRefAttachTechniqueInput>(this ref TRefAttachTechniqueInput referenceAttachTechniqueInput)
				where TRefAttachTechniqueInput : unmanaged, Eggstensions.IRefAttachTechniqueInput
			{
				return (BSFixedString*)referenceAttachTechniqueInput.AddByteOffset(0x40);
			}
		}
	}
}
