namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x4)]
	public struct Color
	{
		[System.Runtime.InteropServices.FieldOffset(0x0)] public System.Byte Red;
		[System.Runtime.InteropServices.FieldOffset(0x1)] public System.Byte Green;
		[System.Runtime.InteropServices.FieldOffset(0x2)] public System.Byte Blue;
		[System.Runtime.InteropServices.FieldOffset(0x3)] public System.Byte Alpha;
	}
}
