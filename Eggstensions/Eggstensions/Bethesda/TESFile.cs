using static NetScriptFramework._IntPtrExtensions;



namespace Eggstensions.Bethesda
{
	static public class TESFile
	{
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
				NetScriptFramework.Memory.InvokeCdecl(VIDS.TESFile.GetGlobalFormID, file, allocation.Address);

				return NetScriptFramework.Memory.ReadUInt32(allocation.Address);
			}
		}

		/// <param name="file">TESFile</param>
		static public System.Boolean IsLoaded(System.IntPtr file)
		{
			if (file == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("file"); }

			return NetScriptFramework.Memory.InvokeCdecl(VIDS.TESFile.IsLoaded, file).ToBool();
		}
	}
}
