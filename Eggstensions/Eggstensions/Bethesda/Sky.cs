namespace Eggstensions.Bethesda
{
	static public class Sky
	{
		/// <summary>&lt;SkyrimSE.exe&gt; + 0x177790 (VID13789)</summary>
		/// <returns>Sky</returns>
		static public System.IntPtr Instance
		{
			get
			{
				var functionAddress = NetScriptFramework.Main.GameInfo.GetAddressOf(13789);
				if (functionAddress == System.IntPtr.Zero) { throw new Eggceptions.NullException("functionAddress"); }

				var instance = NetScriptFramework.Memory.InvokeCdecl(functionAddress);
				if (instance == System.IntPtr.Zero) { throw new Eggceptions.NullException("instance"); }

				return instance;
			}
		}
	}
}
