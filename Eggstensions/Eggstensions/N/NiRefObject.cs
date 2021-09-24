namespace Eggstensions
{
	public interface INiRefObject : IVirtualObject
	{
	}

	public struct NiRefObject : INiRefObject
	{
	}



	namespace ExtensionMethods
	{
		unsafe static public class INiRefObject
		{
			// Field
			static public System.UInt32* ReferenceCount<TNiRefObject>(this ref TNiRefObject referenceObject)
				where TNiRefObject : unmanaged, Eggstensions.INiRefObject
			{
				return (System.UInt32*)referenceObject.AddByteOffset(0x8);
			}



			// Virtual
			static public void Delete<TNiRefObject>(this ref TNiRefObject referenceObject)
				where TNiRefObject : unmanaged, Eggstensions.INiRefObject
			{
				var delete = (delegate* unmanaged[Cdecl]<TNiRefObject*, void>)referenceObject.VirtualFunction(0x1);

				Delete(referenceObject.AsPointer());



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				void Delete(TNiRefObject* referenceObject)
				{
					delete(referenceObject);
				}
			}
		}
	}
}
