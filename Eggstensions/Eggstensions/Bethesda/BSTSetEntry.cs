namespace Eggstensions.Bethesda
{
	static public class BSTSetEntry
	{
		/// <param name="bstSetEntry">BSTSetEntry</param>
		/// <returns>BSTSetEntry, System.IntPtr.Zero</returns>
		static public System.IntPtr GetNext(System.IntPtr bstSetEntry)
		{
			if (bstSetEntry == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bstSetEntry"); }

			return NetScriptFramework.Memory.ReadPointer(bstSetEntry + 0x8);
		}

		/// <param name="bstSetEntry">BSTSetEntry</param>
		/// <returns>T, System.IntPtr.Zero</returns>
		static public System.IntPtr GetValue(System.IntPtr bstSetEntry)
		{
			if (bstSetEntry == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bstSetEntry"); }

			return NetScriptFramework.Memory.ReadPointer(bstSetEntry);
		}
	}
}
