using Eggstensions.Interoperability.Managed; // Memory



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
				return Memory.ReadSingle(Offsets.ActiveEffect.ConditionUpdateFrequency);
			}
		}



		public System.Single ElapsedTime
		{
			get
			{
				return Memory.ReadSingle(this, 0x70);
			}
		}



		static public implicit operator ActiveEffect(System.IntPtr address)
		{
			return new ActiveEffect(address);
		}
	}
}
