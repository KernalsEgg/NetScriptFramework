namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x48)]
	unsafe public struct ReferenceEffect
	{
		[System.Runtime.InteropServices.FieldOffset(0x30)] public ReferenceEffectController* Controller;
	}
}
