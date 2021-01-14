namespace Eggstensions.SkyrimSE
{
	static public class TESDataHandler
	{
		/// <returns>TESDataHandler</returns>
		static public System.IntPtr Instance
		{
			get
			{
				var instance = NetScriptFramework.Memory.ReadPointer(VIDS.TESDataHandler.Instance);
				if (instance == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(instance)); }

				return instance;
			}
		}



		/// <param name="dataHandler">TESDataHandler</param>
		/// <returns>TESFile, System.IntPtr.Zero</returns>
		static public System.IntPtr GetFile(System.IntPtr dataHandler, System.String fileName)
		{
			if (dataHandler == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(dataHandler)); }
			if (System.String.IsNullOrWhiteSpace(fileName)) { throw new Eggceptions.ArgumentNullOrWhiteSpaceException(nameof(fileName)); }

			using (var fileNameAllocation = NetScriptFramework.Memory.AllocateString(fileName, false))
			{
				return NetScriptFramework.Memory.InvokeCdecl(VIDS.TESDataHandler.GetFile, dataHandler, fileNameAllocation.Address);
			}
		}

		/// <param name="dataHandler">TESDataHandler</param>
		/// <returns>TESFileCollection</returns>
		static public System.IntPtr GetFileCollection(System.IntPtr dataHandler)
		{
			if (dataHandler == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(dataHandler)); }

			return dataHandler + 0xD70;
		}

		/// <param name="dataHandler">TESDataHandler</param>
		/// <returns>TESFile, System.IntPtr.Zero</returns>
		static public System.IntPtr GetFileFromIndex(System.IntPtr dataHandler, System.Byte index)
		{
			if (dataHandler == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(dataHandler)); }

			var files = new BSTArray(TESFileCollection.GetFiles(TESDataHandler.GetFileCollection(dataHandler)));

			foreach (var file in files)
			{
				if (TESFile.GetIndex(file) == index)
				{
					return file;
				}
			}

			return System.IntPtr.Zero;
		}

		/// <param name="dataHandler">TESDataHandler</param>
		/// <returns>TESFile, System.IntPtr.Zero</returns>
		static public System.IntPtr GetLightFileFromIndex(System.IntPtr dataHandler, System.UInt16 index)
		{
			if (dataHandler == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(dataHandler)); }

			var lightFiles = new BSTArray(TESFileCollection.GetLightFiles(TESDataHandler.GetFileCollection(dataHandler)));

			foreach (var lightFile in lightFiles)
			{
				if (TESFile.GetLightIndex(lightFile) == index)
				{
					return lightFile;
				}
			}

			return System.IntPtr.Zero;
		}
	}
}
