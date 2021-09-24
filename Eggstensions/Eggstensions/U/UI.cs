namespace Eggstensions
{
	public interface IUI : IUnmanagedObject
	{
	}

	unsafe public struct UI : IUI
	{
		// Static
		static public void Notification(System.String text, System.String sound, System.Boolean queueOnce)
		{
			var notification = (delegate* unmanaged[Cdecl]<UnmanagedType.LPStr, UnmanagedType.LPStr, System.Byte, void>)Eggstensions.Offsets.UI.Notification;

			Notification(new UnmanagedType.LPStr { Value = text }, new UnmanagedType.LPStr { Value = sound }, (System.Byte)(queueOnce ? 1 : 0));



			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			void Notification(UnmanagedType.LPStr text, UnmanagedType.LPStr sound, System.Byte queueOnce)
			{
				notification(text, sound, queueOnce);
			}
		}
	}
}
