namespace Eggstensions.Bethesda
{
	static public class TESDataHandler
	{
		/// <returns>TESDataHandler</returns>
		static public System.IntPtr Instance
		{
			get
			{
				var instance = NetScriptFramework.Memory.ReadPointer(VIDS.TESDataHandler.Instance);
				if (instance == System.IntPtr.Zero) { throw new Eggceptions.NullException("instance"); }

				return instance;
			}
		}



		/// <param name="dataHandler">TESDataHandler</param>
		/// <returns>TESFile, System.IntPtr.Zero</returns>
		static public System.IntPtr GetFile(System.IntPtr dataHandler, System.String fileName)
		{
			if (dataHandler == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("dataHandler"); }
			if (System.String.IsNullOrWhiteSpace(fileName)) { throw new Eggceptions.ArgumentNullOrWhiteSpaceException("fileName"); }

			using (var allocation = NetScriptFramework.Memory.AllocateString(fileName, false))
			{
				return NetScriptFramework.Memory.InvokeCdecl(VIDS.TESDataHandler.GetFile, dataHandler, allocation.Address);
			}
		}
	}
}
