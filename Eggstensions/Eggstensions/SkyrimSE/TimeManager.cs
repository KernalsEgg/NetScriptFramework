namespace Eggstensions.SkyrimSE
{
	static public class TimeManager
	{
		static public System.IntPtr Instance
		{
			get
			{
				return VIDS.TimeManager.Instance;
			}
		}



		/// <param name="timeManager">TimeManager</param>
		static public System.Single GetFrameTimeGameTime(System.IntPtr timeManager)
		{
			if (timeManager == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(timeManager)); }
			
			return NetScriptFramework.Memory.ReadFloat(timeManager + 0x18);
		}

		/// <param name="timeManager">TimeManager</param>
		static public System.Single GetFrameTimeRealTime(System.IntPtr timeManager)
		{
			if (timeManager == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(timeManager)); }

			return NetScriptFramework.Memory.ReadFloat(timeManager + 0x1C);
		}

		/// <param name="timeManager">TimeManager</param>
		static public System.Single GetRunTime(System.IntPtr timeManager)
		{
			if (timeManager == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(timeManager)); }

			return NetScriptFramework.Memory.ReadFloat(timeManager + 0x20);
		}
	}
}
