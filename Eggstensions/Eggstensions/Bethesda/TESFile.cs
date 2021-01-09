using static NetScriptFramework._IntPtrExtensions;



namespace Eggstensions.Bethesda
{
	static public class TESFile
	{
		/// <param name="file">TESFile</param>
		static public System.String GetFileName(System.IntPtr file)
		{
			if (file == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("file"); }

			return NetScriptFramework.Memory.ReadString(file + 0x58, false);
		}
		
		/// <param name="file">TESFile</param>
		/// <returns>FormID, 0</returns>
		static public System.UInt32 GetGlobalFormID(System.IntPtr file, System.UInt32 localFormID)
		{
			if (file == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("file"); }
			// localFormID

			using (var localFormIDAllocation = NetScriptFramework.Memory.Allocate(0x8))
			{
				localFormIDAllocation.Zero();
				NetScriptFramework.Memory.WriteUInt32(localFormIDAllocation.Address, localFormID);
				NetScriptFramework.Memory.InvokeCdecl(VIDS.TESFile.GetGlobalFormID, file, localFormIDAllocation.Address);

				return NetScriptFramework.Memory.ReadUInt32(localFormIDAllocation.Address);
			}
		}

		/// <param name="file">TESFile</param>
		static public System.Byte GetIndex(System.IntPtr file)
		{
			if (file == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("file"); }

			return NetScriptFramework.Memory.ReadUInt8(file + 0x478);
		}

		/// <param name="file">TESFile</param>
		static public System.UInt16 GetLightIndex(System.IntPtr file)
		{
			if (file == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("file"); }

			return NetScriptFramework.Memory.ReadUInt16(file + 0x47A);
		}

		/// <param name="file">TESFile</param>
		static public System.Boolean IsLoaded(System.IntPtr file)
		{
			if (file == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("file"); }

			return NetScriptFramework.Memory.InvokeCdecl(VIDS.TESFile.IsLoaded, file).ToBool();
		}
	}
}
