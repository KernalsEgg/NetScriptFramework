namespace Eggstensions.Bethesda
{
	static public class BSGeometry
	{
		/// <param name = "bsGeometry">BSGeometry</param>
		/// <returns>NiPointer&lt;NiSkinInstance&gt;, System.IntPtr.Zero</returns>
		static public System.IntPtr GetSkin(System.IntPtr bsGeometry)
		{
			if (bsGeometry == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bsGeometry"); }

			return NetScriptFramework.Memory.ReadPointer(bsGeometry + 0x130);
		}
	}
}
