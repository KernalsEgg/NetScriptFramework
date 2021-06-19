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
		DualCasted				= 1U << 12,
		Inactive				= 1U << 15,
		AppliedEffects			= 1U << 16,
		RemovedEffects			= 1U << 17,
		Dispelled				= 1U << 18,
		WornOff					= 1U << 31
	}



	public class ActiveEffect : VirtualObject
	{
		public ActiveEffect(System.IntPtr address) : base(address)
		{
		}



		static public System.Single ConditionUpdateFrequency
		{
			get
			{
				return Memory.Read<System.Single>(Offsets.ActiveEffect.ConditionUpdateFrequency);
			}
		}



		public System.Single ElapsedTime
		{
			get
			{
				return Memory.Read<System.Single>(this, 0x70);
			}
		}

		public ActiveEffectFlags Flags
		{
			get
			{
				return (ActiveEffectFlags)Memory.Read<System.UInt32>(this, 0x7C);
			}
		}



		public void Dispel(System.Boolean force)
		{
			Delegates.Instances.ActiveEffect.Dispel(this, (System.Byte)(force ? 1 : 0));
		}
		
		/// <summary>0x4</summary>
		public Mutable.Union<T> GetPadding8C<T>()
			where T : unmanaged
		{
			return new Mutable.Union<T>(this, 0x8C);
		}



		static public implicit operator ActiveEffect(System.IntPtr address)
		{
			return new ActiveEffect(address);
		}
	}
}
