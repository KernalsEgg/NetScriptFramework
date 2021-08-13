namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x18)]
	public struct Setting
	{
		[System.Runtime.InteropServices.FieldOffset(0x8)] public SettingValue Value;
		[System.Runtime.InteropServices.FieldOffset(0x10)] public System.IntPtr Name; // char*
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x8)]
	public struct SettingValue
	{
		[System.Runtime.InteropServices.FieldOffset(0x0)] public System.Byte Byte; // Boolean
		[System.Runtime.InteropServices.FieldOffset(0x0)] public Color Color;
		[System.Runtime.InteropServices.FieldOffset(0x0)] public System.Int32 Int32;
		[System.Runtime.InteropServices.FieldOffset(0x0)] public System.IntPtr String; // char*
		[System.Runtime.InteropServices.FieldOffset(0x0)] public System.Single Single;
		[System.Runtime.InteropServices.FieldOffset(0x0)] public System.UInt32 UInt32;
	}
}
