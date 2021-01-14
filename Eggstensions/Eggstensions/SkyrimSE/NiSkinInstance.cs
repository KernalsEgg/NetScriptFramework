namespace Eggstensions.SkyrimSE
{
	static public class NiSkinInstance
	{
		/// <param name = "niSkinInstance">NiSkinInstance</param>
		/// <returns>NiAVObject</returns>
		static public System.IntPtr GetRootParent(System.IntPtr niSkinInstance)
		{
			if (niSkinInstance == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(niSkinInstance)); }

			var rootParent = NetScriptFramework.Memory.ReadPointer(niSkinInstance + 0x20);
			if (rootParent == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(rootParent)); }

			return rootParent;
		}
	}
}
