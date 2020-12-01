namespace Eggstensions.Bethesda
{
	static public class BSGeometry
	{
		/// <param name="bsGeometry">BSGeometry</param>
		/// <returns>NiProperty, System.IntPtr.Zero</returns>
		static public System.IntPtr GetProperties(System.IntPtr bsGeometry)
		{
			if (bsGeometry == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bsGeometry"); }

			return NiPointer.GetValue(bsGeometry + 0x128);
		}
		
		/// <param name = "bsGeometry">BSGeometry</param>
		/// <returns>NiSkinInstance, System.IntPtr.Zero</returns>
		static public System.IntPtr GetSkin(System.IntPtr bsGeometry)
		{
			if (bsGeometry == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bsGeometry"); }

			return NiPointer.GetValue(bsGeometry + 0x130);
		}
	}
}
