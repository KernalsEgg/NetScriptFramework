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
	
	
	
	public interface IProjectile : ITESObjectREFR
	{
	}

	public struct Projectile : IProjectile
	{
	}



	namespace ExtensionMethods
	{
		unsafe static public class IProjectile
		{
			/// <summary>SkyrimSE.exe + 0x74A950 (VID 42920) + 0x332</summary>
			static public System.Single Damage<TProjectile>(this ref TProjectile projectile)
				where TProjectile : unmanaged, Eggstensions.IProjectile
			{
				return *(System.Single*)projectile.AddByteOffset(0x198);
			}

			static public ProjectileFlags Flags<TProjectile>(this ref TProjectile projectile)
				where TProjectile : unmanaged, Eggstensions.IProjectile
			{
				return (ProjectileFlags)(*(System.UInt32*)projectile.AddByteOffset(0x1CC));
			}

			/// <summary>SkyrimSE.exe + 0x754DC0 (VID 43035) + 0x1CB</summary>
			static public System.Byte StartedQueueingFiles<TProjectile>(this ref TProjectile projectile)
				where TProjectile : unmanaged, Eggstensions.IProjectile
			{
				return *(System.Byte*)projectile.AddByteOffset(0x1D0);
			}

			/// <summary>SkyrimSE.exe + 0x754FF0 (VID 43036) + 0x5</summary>
			static public System.Byte FinishedQueueingFiles<TProjectile>(this ref TProjectile projectile)
				where TProjectile : unmanaged, Eggstensions.IProjectile
			{
				return *(System.Byte*)projectile.AddByteOffset(0x1D1);
			}
		}
	}
}
