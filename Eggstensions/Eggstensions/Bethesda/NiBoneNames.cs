namespace Eggstensions.Bethesda
{
	static public class NiBoneNames
	{
		/// <summary>&lt;SkyrimSE.exe&gt; + 0x104AD0 (VID11308)</summary>
		/// <returns>NiBoneNames</returns>
		static public System.IntPtr Instance
		{
			get
			{
				var instancePointer = NetScriptFramework.Main.GameInfo.GetAddressOf(11308);
				if (instancePointer == System.IntPtr.Zero) { throw new Eggceptions.NullException("instancePointer"); }

				var instance = NetScriptFramework.Memory.InvokeCdecl(instancePointer);
				if (instance == System.IntPtr.Zero) { throw new Eggceptions.NullException("instance"); }

				return instance;
			}
		}



		/// <param name="niBoneNames">NiBoneNames</param>
		/// <returns>BSFaceGenNiNodeSkinned</returns>
		static public System.IntPtr GetBSFaceGenNiNodeSkinned(System.IntPtr niBoneNames)
		{
			if (niBoneNames == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niBoneNames"); }

			return niBoneNames + 0x190;
		}
	}
}
