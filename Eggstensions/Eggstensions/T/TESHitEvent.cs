namespace Eggstensions
{
	[System.Flags]
	public enum HitEventFlags : System.Byte
	{
		None		= 0,
		PowerAttack	= 1 << 0,
		SneakAttack	= 1 << 1,
		BashAttack	= 1 << 2,
		HitBlocked	= 1 << 3
	}
	


	public class TESHitEvent : NativeObject
	{
		public TESHitEvent(System.IntPtr address) : base(address)
		{
		}



		public TESObjectREFR Target
		{
			get
			{
				return Memory.Read<System.IntPtr>(this, 0x0);
			}
		}

		public TESObjectREFR Cause
		{
			get
			{
				return Memory.Read<System.IntPtr>(this, 0x8);
			}
		}

		/// <summary>FormID</summary>
		public System.UInt32 Source
		{
			get
			{
				return Memory.Read<System.UInt32>(this, 0x10);
			}
		}

		/// <summary>FormID</summary>
		public System.UInt32 Projectile
		{
			get
			{
				return Memory.Read<System.UInt32>(this, 0x14);
			}
		}

		public HitEventFlags Flags
		{
			get
			{
				return (HitEventFlags)Memory.Read<System.Byte>(this, 0x18);
			}
		}



		static public implicit operator TESHitEvent(System.IntPtr address)
		{
			return new TESHitEvent(address);
		}
	}
}
