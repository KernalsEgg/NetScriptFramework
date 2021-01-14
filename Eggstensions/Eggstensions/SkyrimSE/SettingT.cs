namespace Eggstensions.SkyrimSE
{
	static public class SettingT
	{
		static public class GameSettingCollection
		{
			static public System.Boolean AutoAimBasedOnDistance
			{
				get
				{
					return Setting.GetBoolean(VIDS.SettingT.GameSettingCollection.AutoAimBasedOnDistance);
				}
			}

			static public System.Single AutoAimMaxDistance
			{
				get
				{
					return Setting.GetSingle(VIDS.SettingT.GameSettingCollection.AutoAimMaxDistance);
				}
			}

			static public System.Single AutoAimScreenPercentage
			{
				get
				{
					return Setting.GetSingle(VIDS.SettingT.GameSettingCollection.AutoAimScreenPercentage);
				}
			}
		}

		static public class INISettingCollection
		{
			static public System.UInt32 GridsToLoad
			{
				get
				{
					return Setting.GetUInt32(VIDS.SettingT.INISettingCollection.GridsToLoad);
				}
			}
		}
	}
}
