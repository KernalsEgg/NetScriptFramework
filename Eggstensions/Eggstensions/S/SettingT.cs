namespace Eggstensions
{
	static public class SettingT
	{
		static public SettingT<System.IntPtr> MagicGuideNoMarker
		{
			get
			{
				return new SettingT<System.IntPtr>(Offsets.SettingT.MagicGuideNoMarker);
			}
		}

		static public SettingT<System.IntPtr> MagicGuideNoPath
		{
			get
			{
				return new SettingT<System.IntPtr>(Offsets.SettingT.MagicGuideNoPath);
			}
		}

		static public SettingT<System.IntPtr> PlayerSetMarkerName
		{
			get
			{
				return new SettingT<System.IntPtr>(Offsets.SettingT.PlayerSetMarkerName);
			}
		}
	}
	
	public class SettingT<T> : Setting<T>
		where T : unmanaged
	{
		public SettingT(System.IntPtr address) : base(address)
		{
		}
	}
}
