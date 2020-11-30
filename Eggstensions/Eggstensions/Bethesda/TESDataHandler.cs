namespace Eggstensions.Bethesda
{
	static public class TESDataHandler
	{
		/// <summary>&lt;SkyrimSE.exe&gt; + 0x1EBE428 (VID514141)</summary>
		/// <returns>TESDataHandler</returns>
		static public System.IntPtr Instance
		{
			get
			{
				var instancePointer = NetScriptFramework.Main.GameInfo.GetAddressOf(514141);
				if (instancePointer == System.IntPtr.Zero) { throw new Eggceptions.NullException("instancePointer"); }

				var instance = NetScriptFramework.Memory.ReadPointer(instancePointer);
				if (instance == System.IntPtr.Zero) { throw new Eggceptions.NullException("instance"); }

				return instance;
			}
		}



		/// <summary>&lt;SkyrimSE.exe&gt; + 0x16D1B0 (VID13632)</summary>
		/// <param name="dataHandler">TESDataHandler</param>
		/// <returns>TESFile, System.IntPtr.Zero</returns>
		static public System.IntPtr GetFile(System.IntPtr dataHandler, System.String fileName)
		{
			if (dataHandler == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("dataHandler"); }
			if (System.String.IsNullOrWhiteSpace(fileName)) { throw new Eggceptions.ArgumentNullOrWhiteSpaceException("fileName"); }

			using (var allocation = NetScriptFramework.Memory.AllocateString(fileName, false))
			{
				var functionAddress = NetScriptFramework.Main.GameInfo.GetAddressOf(13632);
				if (functionAddress == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("functionAddress"); }

				return NetScriptFramework.Memory.InvokeCdecl(functionAddress, dataHandler, allocation.Address);
			}
		}
	}
}
