﻿namespace Eggstensions.SkyrimSE
{
	static public class NiBoneNames
	{
		/// <returns>NiBoneNames</returns>
		static public System.IntPtr Instance
		{
			get
			{
				var instance = NetScriptFramework.Memory.InvokeCdecl(VIDS.NiBoneNames.Instance);
				if (instance == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(instance)); }

				return instance;
			}
		}



		/// <param name="niBoneNames">NiBoneNames</param>
		/// <returns>BSFaceGenNiNodeSkinned</returns>
		static public System.IntPtr GetBSFaceGenNiNodeSkinned(System.IntPtr niBoneNames)
		{
			if (niBoneNames == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(niBoneNames)); }

			return niBoneNames + 0x190;
		}
	}
}