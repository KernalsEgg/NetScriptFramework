namespace Eggstensions
{
	[System.Flags]
	public enum TESHitEventFlags : System.Byte
	{
		None		= 0,
		PowerAttack	= 1 << 0,
		SneakAttack	= 1 << 1,
		BashAttack	= 1 << 2,
		HitBlocked	= 1 << 3
	}



	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x20)]
	unsafe public struct TESHitEvent
	{
		[System.Runtime.InteropServices.FieldOffset(0x0)] public TESObjectREFR* Target;
		[System.Runtime.InteropServices.FieldOffset(0x8)] public TESObjectREFR* Cause;
		[System.Runtime.InteropServices.FieldOffset(0x10)] public System.UInt32 Source; // FormId
		[System.Runtime.InteropServices.FieldOffset(0x14)] public System.UInt32 Projectile; // FormId
		[System.Runtime.InteropServices.FieldOffset(0x18)] public TESHitEventFlags Flags;
	}
}
