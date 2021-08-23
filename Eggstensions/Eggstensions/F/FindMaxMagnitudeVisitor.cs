namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x18)]
	unsafe public struct FindMaxMagnitudeVisitor
	{
		[System.Runtime.InteropServices.FieldOffset(0x8)] public ActiveEffect* FinishedActiveEffect;
		[System.Runtime.InteropServices.FieldOffset(0x10)] public System.Single MaximumMagnitude;
	}
}
