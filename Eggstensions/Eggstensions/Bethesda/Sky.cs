namespace Eggstensions.Bethesda
{
	static public class Sky
	{
		/// <returns>Sky</returns>
		static public System.IntPtr Instance
		{
			get
			{
				var instance = NetScriptFramework.Memory.InvokeCdecl(VIDS.Sky.Instance);
				if (instance == System.IntPtr.Zero) { throw new Eggceptions.NullException("instance"); }

				return instance;
			}
		}



		/// <param name="sky">Sky</param>
		static public System.Single GetCurrentGameHour(System.IntPtr sky)
		{
			if (sky == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("sky"); }

			return NetScriptFramework.Memory.ReadFloat(sky + 0x1B0);
		}

		/// <param name="sky">Sky</param>
		/// <returns>TESWeather, System.IntPtr.Zero</returns>
		static public System.IntPtr GetCurrentWeather(System.IntPtr sky)
		{
			if (sky == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("sky"); }

			return NetScriptFramework.Memory.ReadPointer(sky + 0x48);
		}

		/// <param name="sky">Sky</param>
		static public System.Single GetLastWeatherUpdate(System.IntPtr sky)
		{
			if (sky == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("sky"); }

			return NetScriptFramework.Memory.ReadFloat(sky + 0x1B4);
		}
		
		/// <param name="sky">Sky</param>
		/// <returns>Precipitation</returns>
		static public System.IntPtr GetPrecipitation(System.IntPtr sky)
		{
			if (sky == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("sky"); }

			var precipitation = NetScriptFramework.Memory.ReadPointer(sky + 0xA0);
			if (precipitation == System.IntPtr.Zero) { throw new Eggceptions.NullException("precipitation"); }

			return precipitation;
		}
	}
}
