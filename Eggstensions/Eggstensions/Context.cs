namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x190)]
	public struct Context
	{
		[System.Runtime.InteropServices.FieldOffset(0x0)] public FloatingPointRegister Xmm0;
		[System.Runtime.InteropServices.FieldOffset(0x10)] public FloatingPointRegister Xmm1;
		[System.Runtime.InteropServices.FieldOffset(0x20)] public FloatingPointRegister Xmm2;
		[System.Runtime.InteropServices.FieldOffset(0x30)] public FloatingPointRegister Xmm3;
		[System.Runtime.InteropServices.FieldOffset(0x40)] public FloatingPointRegister Xmm4;
		[System.Runtime.InteropServices.FieldOffset(0x50)] public FloatingPointRegister Xmm5;
		[System.Runtime.InteropServices.FieldOffset(0x60)] public FloatingPointRegister Xmm6;
		[System.Runtime.InteropServices.FieldOffset(0x70)] public FloatingPointRegister Xmm7;
		[System.Runtime.InteropServices.FieldOffset(0x80)] public FloatingPointRegister Xmm8;
		[System.Runtime.InteropServices.FieldOffset(0x90)] public FloatingPointRegister Xmm9;
		[System.Runtime.InteropServices.FieldOffset(0xA0)] public FloatingPointRegister Xmm10;
		[System.Runtime.InteropServices.FieldOffset(0xB0)] public FloatingPointRegister Xmm11;
		[System.Runtime.InteropServices.FieldOffset(0xC0)] public FloatingPointRegister Xmm12;
		[System.Runtime.InteropServices.FieldOffset(0xD0)] public FloatingPointRegister Xmm13;
		[System.Runtime.InteropServices.FieldOffset(0xE0)] public FloatingPointRegister Xmm14;
		[System.Runtime.InteropServices.FieldOffset(0xF0)] public FloatingPointRegister Xmm15;
		[System.Runtime.InteropServices.FieldOffset(0x100)] public IntegerRegister Rax;
		[System.Runtime.InteropServices.FieldOffset(0x108)] public IntegerRegister Rbx;
		[System.Runtime.InteropServices.FieldOffset(0x110)] public IntegerRegister Rcx;
		[System.Runtime.InteropServices.FieldOffset(0x118)] public IntegerRegister Rdx;
		[System.Runtime.InteropServices.FieldOffset(0x120)] public IntegerRegister Rsi;
		[System.Runtime.InteropServices.FieldOffset(0x128)] public IntegerRegister Rdi;
		[System.Runtime.InteropServices.FieldOffset(0x130)] public IntegerRegister R8;
		[System.Runtime.InteropServices.FieldOffset(0x138)] public IntegerRegister R9;
		[System.Runtime.InteropServices.FieldOffset(0x140)] public IntegerRegister R12;
		[System.Runtime.InteropServices.FieldOffset(0x148)] public IntegerRegister R13;
		[System.Runtime.InteropServices.FieldOffset(0x150)] public IntegerRegister R14;
		[System.Runtime.InteropServices.FieldOffset(0x158)] public IntegerRegister R15;
		[System.Runtime.InteropServices.FieldOffset(0x160)] public IntegerRegister R10;
		[System.Runtime.InteropServices.FieldOffset(0x168)] public IntegerRegister Rbp;
		[System.Runtime.InteropServices.FieldOffset(0x170)] public FlagsRegister Flags;
		[System.Runtime.InteropServices.FieldOffset(0x178)] public IntegerRegister R11;
		[System.Runtime.InteropServices.FieldOffset(0x180)] public IntegerRegister Rsp;
		[System.Runtime.InteropServices.FieldOffset(0x188)] public IntegerRegister Rip;
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x8)]
	public struct FlagsRegister
	{
		[System.Runtime.InteropServices.FieldOffset(0x0)] public System.UInt32 UInt32;
		[System.Runtime.InteropServices.FieldOffset(0x0)] public System.UInt64 UInt64;
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x10)]
	public struct FloatingPointRegister
	{
		[System.Runtime.InteropServices.FieldOffset(0x0)] public System.Single Single;
		[System.Runtime.InteropServices.FieldOffset(0x0)] public System.Double Double;
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x8)]
	unsafe public struct IntegerRegister
	{
		[System.Runtime.InteropServices.FieldOffset(0x0)] public System.Byte Byte;
		[System.Runtime.InteropServices.FieldOffset(0x0)] public System.Double Double;
		[System.Runtime.InteropServices.FieldOffset(0x0)] public System.Int16 Int16;
		[System.Runtime.InteropServices.FieldOffset(0x0)] public System.Int32 Int32;
		[System.Runtime.InteropServices.FieldOffset(0x0)] public System.Int64 Int64;
		[System.Runtime.InteropServices.FieldOffset(0x0)] public System.IntPtr IntPtr;
		[System.Runtime.InteropServices.FieldOffset(0x0)] public System.SByte SByte;
		[System.Runtime.InteropServices.FieldOffset(0x0)] public System.Single Single;
		[System.Runtime.InteropServices.FieldOffset(0x0)] public System.UInt16 UInt16;
		[System.Runtime.InteropServices.FieldOffset(0x0)] public System.UInt32 UInt32;
		[System.Runtime.InteropServices.FieldOffset(0x0)] public System.UInt64 UInt64;
	}
}
