﻿namespace Eggstensions.Bethesda
{
	static public class TESFileCollection
	{
		/// <param name="fileCollection">TESFileCollection</param>
		/// <returns>BSTArray&lt;TESFile*&gt;</returns>
		static public System.IntPtr GetFiles(System.IntPtr fileCollection)
		{
			if (fileCollection == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("fileCollection"); }

			return fileCollection;
		}

		/// <param name="fileCollection">TESFileCollection</param>
		/// <returns>BSTArray&lt;TESFile*&gt;</returns>
		static public System.IntPtr GetLightFiles(System.IntPtr fileCollection)
		{
			if (fileCollection == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("fileCollection"); }

			return fileCollection + 0x18;
		}
	}
}
