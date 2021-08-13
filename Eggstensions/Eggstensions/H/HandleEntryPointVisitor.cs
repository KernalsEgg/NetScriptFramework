namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x30)]
	unsafe public struct HandleEntryPointVisitor
	{
		[System.Runtime.InteropServices.FieldOffset(0x8)] public EntryPointFunctionResult Result;
		[System.Runtime.InteropServices.FieldOffset(0x10)] public System.IntPtr Arguments; // Count = ArgumentCount
		[System.Runtime.InteropServices.FieldOffset(0x18)] public System.IntPtr Results; // Count = ResultCount
		[System.Runtime.InteropServices.FieldOffset(0x20)] public Actor* PerkOwner;
		[System.Runtime.InteropServices.FieldOffset(0x28)] public System.Byte ArgumentCount;
		[System.Runtime.InteropServices.FieldOffset(0x29)] public System.Byte ResultCount;
	}
}
