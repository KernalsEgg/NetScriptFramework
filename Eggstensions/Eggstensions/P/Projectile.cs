namespace Eggstensions
{
	[System.Flags]
	public enum ProjectileFlags : System.UInt32
	{
		IsHitscan1				= 1U << 0, // SkyrimSE.exe + 0x747910 (VID 42867) + 0x81
		IsHitscanHasNoTracers	= 1U << 1, // SkyrimSE.exe + 0x747910 (VID 42867) + 0xBF
		IsHitscan2				= 1U << 3, // SkyrimSE.exe + 0x747910 (VID 42867) + 0x88
		HasTracers				= 1U << 4, // SkyrimSE.exe + 0x747910 (VID 42867) + 0x6D
		IsHitscanHasTracers		= 1U << 5, // SkyrimSE.exe + 0x747910 (VID 42867) + 0xA7
		HasGravity				= 1U << 6, // SkyrimSE.exe + 0x747910 (VID 42867) + 0xD8
		Is3DLoaded				= 1U << 8, // SkyrimSE.exe + 0x754820 (VID 43030) + 0xD3
		IsArrowQuiver3DHandled	= 1U << 26 // SkyrimSE.exe + 0x732390 (VID 42546) + 0x49
	}



	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x1D8)]
	public struct Projectile
	{
		[System.Runtime.InteropServices.FieldOffset(0x0)] public TESObjectREFR TESObjectREFR;
		[System.Runtime.InteropServices.FieldOffset(0x198)] public System.Single Damage;				// SkyrimSE.exe + 0x74A950 (VID 42920) + 0x332
		[System.Runtime.InteropServices.FieldOffset(0x1CC)] public ProjectileFlags Flags;
		[System.Runtime.InteropServices.FieldOffset(0x1D0)] public System.Byte StartedQueueingFiles;	// SkyrimSE.exe + 0x754DC0 (VID 43035) + 0x1CB
		[System.Runtime.InteropServices.FieldOffset(0x1D1)] public System.Byte FinishedQueueingFiles;	// SkyrimSE.exe + 0x754FF0 (VID 43036) + 0x5
	}
}
