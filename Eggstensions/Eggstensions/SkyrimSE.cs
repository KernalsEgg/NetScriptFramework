namespace Eggstensions
{
	static public class SkyrimSE
	{
		static SkyrimSE()
		{
			SkyrimSE.ProcessModule = Memory.GetProcessModule("SkyrimSE.exe");

			Memory.GetSystemInfo(out var systemInfo);
			SkyrimSE.Trampoline = new Trampoline(SkyrimSE.ProcessModule, (System.Int32)systemInfo.AllocationGranularity);

			if (SkyrimSE.Trampoline.Address == System.IntPtr.Zero)
			{
				throw new System.InsufficientMemoryException(nameof(SkyrimSE.Trampoline));
			}

			Memory.MemSet(SkyrimSE.Trampoline.Address, Assembly.Int3, new System.IntPtr(SkyrimSE.Trampoline.Size));
		}



		static public System.Diagnostics.ProcessModule ProcessModule { get; }
		static public Trampoline Trampoline { get; }
	}
}
