namespace Eggstensions
{
	namespace BSAttachTechniques
	{
		public interface IAttachTechniqueInput : IVirtualObject
		{
		}

		public struct AttachTechniqueInput : IAttachTechniqueInput
		{
		}
	}



	namespace ExtensionMethods
	{
		namespace BSAttachTechniques
		{
			unsafe static public class IAttachTechniqueInput
			{
				// Field
				static public NiNode* AttachRoot<TAttachTechniqueInput>(this ref TAttachTechniqueInput attachTechniqueInput)
					where TAttachTechniqueInput : unmanaged, Eggstensions.BSAttachTechniques.IAttachTechniqueInput
				{
					return *(NiNode**)attachTechniqueInput.AddByteOffset(0x8);
				}

				static public NiNode* EffectRoot<TAttachTechniqueInput>(this ref TAttachTechniqueInput attachTechniqueInput)
					where TAttachTechniqueInput : unmanaged, Eggstensions.BSAttachTechniques.IAttachTechniqueInput
				{
					return *(NiNode**)attachTechniqueInput.AddByteOffset(0x10);
				}
			}
		}
	}
}
