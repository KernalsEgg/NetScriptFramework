namespace Eggstensions
{
	public class UI : NativeObject
	{
		public UI(System.IntPtr address) : base(address)
		{
		}



		static public void Notification(System.String text, System.String sound, System.Boolean queueOnce)
		{
			Delegates.Instances.UI.Notification(text, sound, (System.Byte)(queueOnce ? 1 : 0));
		}
	}
}
