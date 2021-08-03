namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x1C8)]
	public struct UI
	{
		// Static
		static public void Notification(System.String text, System.String sound, System.Boolean queueOnce)
		{
			Eggstensions.Delegates.Instances.UI.Notification(text, sound, (System.Byte)(queueOnce ? 1 : 0));
		}
	}
}
