namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x28)]
	unsafe public struct Effect
	{
		[System.Runtime.InteropServices.FieldOffset(0x10)] public EffectSetting* BaseEffect;
	}
}
