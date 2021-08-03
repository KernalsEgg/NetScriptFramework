namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Size = 0x190)]
	public struct Context
	{
		public FloatingPointRegister Xmm0;	// 0x0
		public FloatingPointRegister Xmm1;	// 0x10
		public FloatingPointRegister Xmm2;	// 0x20
		public FloatingPointRegister Xmm3;	// 0x30
		public FloatingPointRegister Xmm4;	// 0x40
		public FloatingPointRegister Xmm5;	// 0x50
		public FloatingPointRegister Xmm6;	// 0x60
		public FloatingPointRegister Xmm7;	// 0x70
		public FloatingPointRegister Xmm8;	// 0x80
		public FloatingPointRegister Xmm9;	// 0x90
		public FloatingPointRegister Xmm10;	// 0xA0
		public FloatingPointRegister Xmm11;	// 0xB0
		public FloatingPointRegister Xmm12;	// 0xC0
		public FloatingPointRegister Xmm13;	// 0xD0
		public FloatingPointRegister Xmm14;	// 0xE0
		public FloatingPointRegister Xmm15;	// 0xF0
		public IntegerRegister Rax;			// 0x100
		public IntegerRegister Rbx;			// 0x108
		public IntegerRegister Rcx;			// 0x110
		public IntegerRegister Rdx;			// 0x118
		public IntegerRegister Rsi;			// 0x120
		public IntegerRegister Rdi;			// 0x128
		public IntegerRegister R8;			// 0x130
		public IntegerRegister R9;			// 0x138
		public IntegerRegister R12;			// 0x140
		public IntegerRegister R13;			// 0x148
		public IntegerRegister R14;			// 0x150
		public IntegerRegister R15;			// 0x158
		public IntegerRegister R10;			// 0x160
		public IntegerRegister Rbp;			// 0x168
		public FlagsRegister Flags;			// 0x170
		public IntegerRegister R11;			// 0x178
		public IntegerRegister Rsp;			// 0x180
		public IntegerRegister Rip;			// 0x188
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
	public struct IntegerRegister
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
