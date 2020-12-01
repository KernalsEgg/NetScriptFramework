namespace Eggstensions.Bethesda
{
	static public class Precipitation
	{
		/// <param name="precipitation">Precipitation</param>
		/// <returns>NiPointer&lt;BSGeometry&gt;</returns>
		static public System.IntPtr GetCurrentPrecipitation(System.IntPtr precipitation)
		{
			if (precipitation == System.IntPtr.Zero) { throw new Eggceptions.ArgumentFormatException("precipitation"); }

			return NiPointer.GetValue(precipitation + 0x70);
		}
	}
}
