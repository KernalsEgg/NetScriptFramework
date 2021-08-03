namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x110)]
	unsafe public struct NiAVObject // NiObject
	{
		[System.Runtime.InteropServices.FieldOffset(0x0)] public NiObject NiObject;
		[System.Runtime.InteropServices.FieldOffset(0x30)] public NiNode* Parent;
	}
}
