namespace Eggstensions
{
	public interface INiObject : IVirtualObject
	{
	}

	public struct NiObject : INiObject
	{
	}



	namespace ExtensionMethods
	{
		unsafe static public class INiObject
		{
			// Virtual
			static public NiNode* AsNode<TNiObject>(this ref TNiObject niObject)
				where TNiObject : unmanaged, Eggstensions.INiObject
			{
				var asNode = (delegate* unmanaged[Cdecl]<TNiObject*, NiNode*>)niObject.VirtualFunction(0x3);

				return AsNode(niObject.AsPointer());



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				NiNode* AsNode(TNiObject* niObject)
				{
					return asNode(niObject);
				}
			}
		}
	}
}
