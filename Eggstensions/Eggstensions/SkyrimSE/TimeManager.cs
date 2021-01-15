namespace Eggstensions.SkyrimSE
{
	class TimeManager
	{
		static public System.IntPtr Instance
		{
			get
			{
				return VIDS.TimeManager.Instance;
			}
		}



		/// <param name="timeManager">TimeManager</param>
		static public System.Single GetFrameTime1(System.IntPtr timeManager)
		{
			if (timeManager == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(timeManager)); }
			
			return NetScriptFramework.Memory.ReadFloat(timeManager + 0x18);
		}

		/// <param name="timeManager">TimeManager</param>
		static public System.Single GetFrameTime2(System.IntPtr timeManager)
		{
			if (timeManager == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(timeManager)); }

			return NetScriptFramework.Memory.ReadFloat(timeManager + 0x1C);
		}
	}
}
