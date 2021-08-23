namespace Eggstensions
{
	public enum EffectArchetype : System.Int32
	{
		AccumulateMagnitude = 32
	}
	
	[System.Flags]
	public enum EffectSettingFlags : System.UInt32
	{
		NoDuration				= 1U << 9,
		NoMagnitude				= 1U << 10,
		NoArea					= 1U << 11,
		PowerAffectsMagnitude	= 1U << 21,
		PowerAffectsDuration	= 1U << 22
	}
	


	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0xF0)]
	public struct EffectSettingData
	{
		[System.Runtime.InteropServices.FieldOffset(0x0)] public EffectSettingFlags Flags;
		[System.Runtime.InteropServices.FieldOffset(0x10)] public ActorValue MagicSkill;
		[System.Runtime.InteropServices.FieldOffset(0x28)] public System.Single TaperWeight;
		[System.Runtime.InteropServices.FieldOffset(0x4C)] public System.Single TaperCurve;
		[System.Runtime.InteropServices.FieldOffset(0x50)] public System.Single TaperDuration;
		[System.Runtime.InteropServices.FieldOffset(0x58)] public EffectArchetype EffectArchetype;
	}
	
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x198)]
	public struct EffectSetting
	{
		[System.Runtime.InteropServices.FieldOffset(0x0)] public TESForm TESForm;
		[System.Runtime.InteropServices.FieldOffset(0x68)] public EffectSettingData Data;
	}
}
