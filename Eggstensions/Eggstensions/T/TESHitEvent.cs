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



	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Size = 0x20)]
	unsafe public struct TESHitEvent
	{
		public TESObjectREFR* Target;		// 0x0
		public TESObjectREFR* Cause;		// 0x8
		public System.UInt32 Source;		// 0x10 (FormID)
		public System.UInt32 Projectile;	// 0x14 (FormID)
		public TESHitEventFlags Flags;		// 0x18
	}
}
