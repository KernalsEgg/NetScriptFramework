namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0xA8)]
	public struct AccumulatingValueModifierEffect
	{
		[System.Runtime.InteropServices.FieldOffset(0x0)] public ValueModifierEffect ValueModifierEffect;
		[System.Runtime.InteropServices.FieldOffset(0x98)] public System.Single CurrentMagnitude;
		[System.Runtime.InteropServices.FieldOffset(0x9C)] public System.Single MaximumMagnitude;
		[System.Runtime.InteropServices.FieldOffset(0xA0)] public System.Single HoldDuration;
	}
}
