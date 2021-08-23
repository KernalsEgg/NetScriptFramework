namespace Eggstensions
{
	[System.Flags]
	public enum ActiveEffectFlags : System.UInt32
	{
		NoHitShader				= 1U << 1,
		NoHitEffectArt			= 1U << 2,
		NoInitialFlare			= 1U << 4,
		ApplyingVisualEffects	= 1U << 5,
		ApplyingSounds			= 1U << 6,
		HasConditions			= 1U << 7,
		Recover					= 1U << 9,
		DualCasting				= 1U << 12,
		Inactive				= 1U << 15,
		AppliedEffects			= 1U << 16,
		RemovedEffects			= 1U << 17,
		Dispelled				= 1U << 18,
		WornOff					= 1U << 31
	}



	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x90)]
	unsafe public struct ActiveEffect
	{
		[System.Runtime.InteropServices.FieldOffset(0x34)] public BSPointerHandle Caster; // Actor
		[System.Runtime.InteropServices.FieldOffset(0x40)] public MagicItem* Spell;
		[System.Runtime.InteropServices.FieldOffset(0x48)] public Effect* Effect;
		[System.Runtime.InteropServices.FieldOffset(0x50)] public MagicTarget* MagicTarget;
		[System.Runtime.InteropServices.FieldOffset(0x70)] public System.Single ElapsedTime;
		[System.Runtime.InteropServices.FieldOffset(0x74)] public System.Single Duration;
		[System.Runtime.InteropServices.FieldOffset(0x78)] public System.Single Magnitude;
		[System.Runtime.InteropServices.FieldOffset(0x7C)] public ActiveEffectFlags Flags;
		[System.Runtime.InteropServices.FieldOffset(0x88)] public CastingSource CastingSource;



		// Member
		static public void Dispel(ActiveEffect* activeEffect, System.Boolean force)
		{
			Eggstensions.Delegates.Instances.ActiveEffect.Dispel(activeEffect, (System.Byte)(force ? 1 : 0));
		}

		static public System.Single GetCurrentMagnitude(ActiveEffect* activeEffect)
		{
			return Eggstensions.Delegates.Instances.ActiveEffect.GetCurrentMagnitude(activeEffect);
		}
	}
}
