namespace Eggstensions.Bethesda
{
	static public class NiTObjectArray
	{
		/// <param name = "niTObjectArray">NiTObjectArray&lt;T&gt;</param>
		static public System.IntPtr GetBegin(System.IntPtr niTObjectArray)
		{
			if (niTObjectArray == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niTObjectArray"); }

			var begin = NetScriptFramework.Memory.ReadPointer(niTObjectArray + 0x8);
			if (begin == System.IntPtr.Zero) { throw new Eggceptions.NullException("begin"); }

			return begin;
		}

		/// <param name = "niTObjectArray">NiTObjectArray&lt;T&gt;</param>
		static public System.UInt16 GetCapacity(System.IntPtr niTObjectArray)
		{
			if (niTObjectArray == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niTObjectArray"); }

			return NetScriptFramework.Memory.ReadUInt16(niTObjectArray + 0x10);
		}

		/// <param name = "niTObjectArray">NiTObjectArray&lt;T&gt;</param>
		static public System.UInt16 GetCount(System.IntPtr niTObjectArray)
		{
			if (niTObjectArray == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niTObjectArray"); }

			return NetScriptFramework.Memory.ReadUInt16(niTObjectArray + 0x14);
		}

		/// <param name = "niTObjectArray">NiTObjectArray&lt;T&gt;</param>
		static public System.UInt16 GetFreeIndex(System.IntPtr niTObjectArray)
		{
			if (niTObjectArray == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niTObjectArray"); }

			return NetScriptFramework.Memory.ReadUInt16(niTObjectArray + 0x12);
		}

		/// <param name = "niTObjectArray">NiTObjectArray&lt;T&gt;</param>
		static public System.UInt16 GetGrowCount(System.IntPtr niTObjectArray)
		{
			if (niTObjectArray == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niTObjectArray"); }

			return NetScriptFramework.Memory.ReadUInt16(niTObjectArray + 0x16);
		}
	}
}
