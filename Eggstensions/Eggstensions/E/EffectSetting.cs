namespace Eggstensions
{
	public enum EffectArchetype : System.Int32
	{
		AccumulateMagnitude = 32
	}
	
	[System.Flags]
	public enum EffectSettingDataFlags : System.UInt32
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
		[System.Runtime.InteropServices.FieldOffset(0x0)] public EffectSettingDataFlags Flags;
		[System.Runtime.InteropServices.FieldOffset(0x10)] public ActorValue MagicSkill;
		[System.Runtime.InteropServices.FieldOffset(0x28)] public System.Single TaperWeight;
		[System.Runtime.InteropServices.FieldOffset(0x4C)] public System.Single TaperCurve;
		[System.Runtime.InteropServices.FieldOffset(0x50)] public System.Single TaperDuration;
		[System.Runtime.InteropServices.FieldOffset(0x58)] public EffectArchetype EffectArchetype;
	}



	public interface IEffectSetting : ITESForm
	{
	}

	public struct EffectSetting : IEffectSetting
	{
	}



	namespace ExtensionMethods
	{
		unsafe static public class IEffectSetting
		{
			// Field
			static public EffectSettingData* Data<TEffectSetting>(this ref TEffectSetting effectSetting)
				where TEffectSetting : unmanaged, Eggstensions.IEffectSetting
			{
				return (EffectSettingData*)effectSetting.AddByteOffset(0x68);
			}
		}
	}
}
