namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x10)]
	unsafe public struct NiObject
	{
		// Virtual
		static public NiNode* AsNode(NiObject* niObject)
		{
			var asNode = Memory.ReadVirtualFunction<Eggstensions.Delegates.Types.NiObject.AsNode>(*(System.IntPtr*)niObject, 0x3);

			return asNode(niObject);
		}
	}
}
