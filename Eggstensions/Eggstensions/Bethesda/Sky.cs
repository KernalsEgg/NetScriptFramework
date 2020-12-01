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
