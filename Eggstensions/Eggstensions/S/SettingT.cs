namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x18)]
	unsafe public struct SettingT
	{
		public struct GameSettingCollection
		{
			static public SettingT* ArrowBowMinTime
			{
				get
				{
					return (SettingT*)Eggstensions.Offsets.SettingT.GameSettingCollection.ArrowBowMinTime;
				}
			}

			static public SettingT* ArrowMinPower
			{
				get
				{
					return (SettingT*)Eggstensions.Offsets.SettingT.GameSettingCollection.ArrowMinPower;
				}
			}

			static public SettingT* BowDrawTime
			{
				get
				{
					return (SettingT*)Eggstensions.Offsets.SettingT.GameSettingCollection.BowDrawTime;
				}
			}
		}



		[System.Runtime.InteropServices.FieldOffset(0x0)] public Setting Setting;
	}
}
