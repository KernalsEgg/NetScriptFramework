namespace Eggstensions.SkyrimSE
{
	static public class Precipitation
	{
		/// <param name="precipitation">Precipitation</param>
		/// <returns>BSGeometry, System.IntPtr.Zero</returns>
		static public System.IntPtr GetCurrentPrecipitationObject(System.IntPtr precipitation)
		{
			if (precipitation == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(precipitation)); }

			return NiPointer.GetValue(precipitation + 0x70);
		}
	}
}
