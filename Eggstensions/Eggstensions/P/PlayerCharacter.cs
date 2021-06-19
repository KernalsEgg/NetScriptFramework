namespace Eggstensions
{
	public class PlayerCharacter : Actor
	{
		public PlayerCharacter(System.IntPtr address) : base(address)
		{
		}



		static public PlayerCharacter Instance
		{
			get
			{
				return Memory.Read<System.IntPtr>(Offsets.PlayerCharacter.Instance);
			}
		}



		static public implicit operator PlayerCharacter(System.IntPtr address)
		{
			return new PlayerCharacter(address);
		}
	}
}
