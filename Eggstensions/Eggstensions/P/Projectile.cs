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
	
	
	
	public class Projectile : TESObjectREFR
	{
		public Projectile(System.IntPtr address) : base(address)
		{
		}



		public System.Single Damage
		{
			get
			{
				return Memory.Read<System.Single>(this, 0x198); // SkyrimSE.exe + 0x74A950 (VID 42920) + 0x332
			}
		}

		public ProjectileFlags Flags
		{
			get
			{
				return (ProjectileFlags)Memory.Read<System.UInt32>(this, 0x1CC);
			}
		}

		public System.Boolean StartedQueueingFiles
		{
			get
			{
				return Memory.Read<System.Byte>(this, 0x1D0) != 0; // SkyrimSE.exe + 0x754DC0 (VID 43035) + 0x1CB
			}
		}

		public System.Boolean FinishedQueueingFiles
		{
			get
			{
				return Memory.Read<System.Byte>(this, 0x1D1) != 0; // SkyrimSE.exe + 0x754FF0 (VID 43036) + 0x5
			}
		}



		static public implicit operator Projectile(System.IntPtr address)
		{
			return new Projectile(address);
		}
	}
}
