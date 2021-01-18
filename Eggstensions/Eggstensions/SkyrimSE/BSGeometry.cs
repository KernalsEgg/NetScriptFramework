namespace Eggstensions.SkyrimSE
{
	static public class BSGeometry
	{
		public enum States
		{
			Property =	0,
			Effect =	1
		}



		/// <param name="geometry">BSGeometry</param>
		/// <returns>NiProperty, System.IntPtr.Zero</returns>
		static public System.IntPtr GetProperties(System.IntPtr geometry, BSGeometry.States state)
		{
			if (geometry == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(geometry)); }

			return NiPointer.GetValue(geometry + 0x120 + (0x8 * (System.Int32)state));
		}

		/// <param name = "geometry">BSGeometry</param>
		/// <returns>BSDismemberSkinInstance, NiSkinInstance, System.IntPtr.Zero</returns>
		static public System.IntPtr GetSkin(System.IntPtr geometry)
		{
			if (geometry == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(geometry)); }

			return NiPointer.GetValue(geometry + 0x130);
		}
	}
}
