using static NetScriptFramework._IntPtrExtensions;



namespace Eggstensions.Bethesda
{
	static public class TESFile
	{
		/// <summary>&lt;SkyrimSE.exe&gt; + 0x17E180 (VID13915)</summary>
		/// <param name="file">TESFile</param>
		/// <returns>FormID, 0</returns>
		static public System.UInt32 GetGlobalFormID(System.IntPtr file, System.UInt32 localFormID)
		{
			if (file == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("file"); }
			// localFormID

			using (var allocation = NetScriptFramework.Memory.Allocate(0x10))
			{
				allocation.Zero();
				NetScriptFramework.Memory.WriteUInt32(allocation.Address, localFormID);

				var functionAddress = NetScriptFramework.Main.GameInfo.GetAddressOf(13915);
				if (functionAddress == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("functionAddress"); }

				NetScriptFramework.Memory.InvokeCdecl(functionAddress, file, allocation.Address);

				return NetScriptFramework.Memory.ReadUInt32(allocation.Address);
			}
		}

		/// <summary>&lt;SkyrimSE.exe&gt; + 0x17C670 (VID13882)</summary>
		/// <param name="file">TESFile</param>
		static public System.Boolean IsLoaded(System.IntPtr file)
		{
			if (file == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("file"); }

			var functionAddress = NetScriptFramework.Main.GameInfo.GetAddressOf(13882);
			if (functionAddress == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("functionAddress"); }

			return NetScriptFramework.Memory.InvokeCdecl(functionAddress, file).ToBool();
		}
	}
}
