namespace Eggstensions
{
	[System.Flags]
	public enum EffectSettingFlags : System.UInt32
	{
		NoDuration				= 1U << 9,
		NoMagnitude				= 1U << 10,
		PowerAffectsMagnitude	= 1U << 21,
		PowerAffectsDuration	= 1U << 22
	}
	


	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0xF0)]
	public struct EffectSettingData
	{
		[System.Runtime.InteropServices.FieldOffset(0x0)] public EffectSettingFlags Flags;
	}
	
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x198)]
	public struct EffectSetting // TESForm
	{
		[System.Runtime.InteropServices.FieldOffset(0x0)] public TESForm TESForm;
		[System.Runtime.InteropServices.FieldOffset(0x68)] public EffectSettingData Data;
	}
}
