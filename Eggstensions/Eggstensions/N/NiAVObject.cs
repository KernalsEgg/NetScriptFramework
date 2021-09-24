namespace Eggstensions
{
	public interface INiAVObject : INiObject
	{
	}

	public struct NiAVObject : INiAVObject
	{
	}



	namespace ExtensionMethods
	{
		unsafe static public class INiAVObject
		{
			// Field
			static public NiNode* Parent<TNiAVObject>(this ref TNiAVObject avObject)
				where TNiAVObject : unmanaged, Eggstensions.INiAVObject
			{
				return *(NiNode**)avObject.AddByteOffset(0x30);
			}
		}
	}
}
