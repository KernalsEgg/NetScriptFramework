namespace Eggstensions
{
	public class SettingT<T> : Setting<T>
		where T : unmanaged
	{
		public SettingT(System.IntPtr address) : base(address)
		{
		}
	}
}
