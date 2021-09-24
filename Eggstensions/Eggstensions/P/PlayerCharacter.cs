namespace Eggstensions
{
	public interface IPlayerCharacter : IActor
	{
	}

	unsafe public struct PlayerCharacter : IPlayerCharacter
	{
		static public PlayerCharacter* Instance
		{
			get
			{
				return *(PlayerCharacter**)Eggstensions.Offsets.PlayerCharacter.Instance;
			}
		}
	}
}
