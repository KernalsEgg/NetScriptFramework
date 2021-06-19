namespace Eggstensions
{
	namespace Events
	{
		static public class Initialize
		{
			static Initialize()
			{
				Initialize.OldInitialize = Memory.WriteVirtualFunction<Delegates.Types.InitTESThread.Initialize>(Offsets.InitTESThread.VirtualFunctionTable, 0x1, Initialize.NewInitialize);
			}
			
			
			
			static public event System.EventHandler<System.EventArgs> After;

			static public event System.EventHandler<System.EventArgs> Before;



			static public Delegates.Types.InitTESThread.Initialize NewInitialize { get; } = Initialize.OnInitialize;

			static public Delegates.Types.InitTESThread.Initialize OldInitialize { get; }



			/// <param name="initTESThread">InitTESThread</param>
			static private void OnInitialize(System.IntPtr initTESThread)
			{
				Initialize.Before?.Invoke(null, System.EventArgs.Empty);
				Initialize.OldInitialize(initTESThread);
				Initialize.After?.Invoke(null, System.EventArgs.Empty);
			}
		}
	}
}
