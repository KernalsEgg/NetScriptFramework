namespace Eggstensions
{
	namespace Events
	{
		unsafe static public class InitializeThread
		{
			static InitializeThread()
			{
				InitializeThread.initializeThread = (delegate* unmanaged[Cdecl]<InitTESThread*, void>)((System.IntPtr*)Eggstensions.Offsets.InitTESThread.VirtualFunctionTable)[0x1];
				
				Memory.WriteVirtualFunction(Eggstensions.Offsets.InitTESThread.VirtualFunctionTable, 0x1, (delegate* unmanaged[Cdecl]<InitTESThread*, void>)&InitializeThread.OnInitializeThread);
			}



			static public event System.EventHandler After;
			static public event System.EventHandler Before;



			static private delegate* unmanaged[Cdecl]<InitTESThread*, void> initializeThread;



			[System.Runtime.InteropServices.UnmanagedCallersOnly(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
			static private void OnInitializeThread(InitTESThread* initializeThread)
			{
				InitializeThread.Before?.Invoke(null, System.EventArgs.Empty);
				InitializeThread.initializeThread(initializeThread);
				InitializeThread.After?.Invoke(null, System.EventArgs.Empty);
			}
		}
	}
}
