﻿namespace Eggstensions.SkyrimSE
{
	static public class NiNode
	{
		/// <param name = "niNode">NiNode</param>
		/// <returns>NiTObjectArray&lt;NiAVObject&gt;</returns>
		static public System.IntPtr GetChildren(System.IntPtr niNode)
		{
			if (niNode == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(niNode)); }

			return niNode + 0x110;
		}
	}
}