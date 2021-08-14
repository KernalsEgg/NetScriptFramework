namespace Eggstensions
{
	namespace Events
	{
		unsafe static public class Initialize
		{
			static Initialize()
			{
				var initialize = Memory.ReadVirtualFunction<Eggstensions.Delegates.Types.InitTESThread.Initialize>(Eggstensions.Offsets.InitTESThread.VirtualFunctionTable, 0x1);

				Initialize.initialize = (InitTESThread* initTESThread) =>
				{
					Initialize.Before?.Invoke(null, System.EventArgs.Empty);
					initialize(initTESThread);
					Initialize.After?.Invoke(null, System.EventArgs.Empty);
				};
				
				Memory.WriteVirtualFunction<Eggstensions.Delegates.Types.InitTESThread.Initialize>(Eggstensions.Offsets.InitTESThread.VirtualFunctionTable, 0x1, Initialize.initialize);
			}



			static public event System.EventHandler After;
			static public event System.EventHandler Before;



			static private Eggstensions.Delegates.Types.InitTESThread.Initialize initialize;
		}
	}
}
