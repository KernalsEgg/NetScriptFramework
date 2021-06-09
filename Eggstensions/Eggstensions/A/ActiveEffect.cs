namespace Eggstensions
{
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
