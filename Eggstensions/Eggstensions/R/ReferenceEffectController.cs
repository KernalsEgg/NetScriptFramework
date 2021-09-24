namespace Eggstensions
{
	public interface IReferenceEffectController : IVirtualObject
	{
	}

	public struct ReferenceEffectController : IReferenceEffectController
	{
	}



	namespace ExtensionMethods
	{
		unsafe static public class IReferenceEffectController
		{
			// Virtual
			static public NiAVObject* GetAttachRoot<TReferenceEffectController>(this ref TReferenceEffectController referenceEffectController)
				where TReferenceEffectController : unmanaged, Eggstensions.IReferenceEffectController
			{
				var getAttachRoot = (delegate* unmanaged[Cdecl]<TReferenceEffectController*, NiAVObject*>)referenceEffectController.VirtualFunction(0xF);

				return GetAttachRoot(referenceEffectController.AsPointer());



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				NiAVObject* GetAttachRoot(TReferenceEffectController* referenceEffectController)
				{
					return getAttachRoot(referenceEffectController);
				}
			}
		}
	}
}
