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

			static public System.Single FavorRequestPickDistance
			{
				get
				{
					return Setting.GetSingle(VIDS.SettingT.GameSettingCollection.FavorRequestPickDistance);
				}
			}

			static public System.Single HorseMaxUpwardPitch
			{
				get
				{
					return Setting.GetSingle(VIDS.SettingT.GameSettingCollection.HorseMaxUpwardPitch);
				}
			}

			static public System.Single MountedMaxLookingDown
			{
				get
				{
					return Setting.GetSingle(VIDS.SettingT.GameSettingCollection.MountedMaxLookingDown);
				}
			}

			static public System.Single OverShoulderRangedMountedAddY // Weapon drawn
			{
				get
				{
					return Setting.GetSingle(VIDS.SettingT.GameSettingCollection.OverShoulderRangedMountedAddY);
				}
			}

			static public System.Single OverShoulderRangedMountedPosX
			{
				get
				{
					return Setting.GetSingle(VIDS.SettingT.GameSettingCollection.OverShoulderRangedMountedPosX);
				}
			}

			static public System.Single OverShoulderRangedMountedPosZ
			{
				get
				{
					return Setting.GetSingle(VIDS.SettingT.GameSettingCollection.OverShoulderRangedMountedPosZ);
				}
			}
		}

		static public class INISettingCollection
		{
			static public class Camera
			{
				static public System.Single OverShoulderHorseAddY // Weapon sheathed
				{
					get
					{
						return Setting.GetSingle(VIDS.SettingT.INISettingCollection.Camera.OverShoulderHorseAddY);
					}
				}

				static public System.Single OverShoulderHorsePosX
				{
					get
					{
						return Setting.GetSingle(VIDS.SettingT.INISettingCollection.Camera.OverShoulderHorsePosX);
					}
				}

				static public System.Single OverShoulderHorsePosZ
				{
					get
					{
						return Setting.GetSingle(VIDS.SettingT.INISettingCollection.Camera.OverShoulderHorsePosZ);
					}
				}
			}

			static public class General
			{
				static public System.UInt32 GridsToLoad
				{
					get
					{
						return Setting.GetUInt32(VIDS.SettingT.INISettingCollection.General.GridsToLoad);
					}
				}
			}

			static public class Interface
			{
				static public System.Single ActivatePickLength
				{
					get
					{
						return Setting.GetSingle(VIDS.SettingT.INISettingCollection.Interface.ActivatePickLength);
					}
				}
			}
		}
	}
}
