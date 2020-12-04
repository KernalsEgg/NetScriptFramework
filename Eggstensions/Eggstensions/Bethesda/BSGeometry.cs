namespace Eggstensions.Bethesda
{
	static public class BSGeometry
	{
		public enum States
		{
			Property,
			Effect
		}



		/// <param name="bsGeometry">BSGeometry</param>
		/// <returns>NiProperty, System.IntPtr.Zero</returns>
		static public System.IntPtr GetProperties(System.IntPtr bsGeometry, BSGeometry.States state)
		{
			if (bsGeometry == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bsGeometry"); }

			return NiPointer.GetValue(bsGeometry + 0x120 + (0x8 * (System.Int32)state));
		}

		/// <param name = "bsGeometry">BSGeometry</param>
		/// <returns>BSDismemberSkinInstance, NiSkinInstance, System.IntPtr.Zero</returns>
		static public System.IntPtr GetSkin(System.IntPtr bsGeometry)
		{
			if (bsGeometry == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bsGeometry"); }

			return NiPointer.GetValue(bsGeometry + 0x130);
		}
	}
}
