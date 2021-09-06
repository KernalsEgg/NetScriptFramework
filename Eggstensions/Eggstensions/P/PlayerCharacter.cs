namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0xBE0)]
	unsafe public struct PlayerCharacter
	{
		[System.Runtime.InteropServices.FieldOffset(0x0)] public Actor Actor;



		static public PlayerCharacter* Instance
		{
			get
			{
				return (PlayerCharacter*)Memory.Read<System.IntPtr>(Eggstensions.Offsets.PlayerCharacter.Instance);
			}
		}
	}
}
