namespace Eggstensions.Bethesda
{
	static public class NiTObjectArray
	{
		/// <param name = "niTObjectArray">NiTObjectArray&lt;T&gt;</param>
		static public System.UInt16 GetActualCount(System.IntPtr niTObjectArray)
		{
			if (niTObjectArray == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niTObjectArray"); }

			return NetScriptFramework.Memory.ReadUInt16(niTObjectArray + 0x14);
		}

		/// <param name = "niTObjectArray">NiTObjectArray&lt;T&gt;</param>
		static public System.UInt16 GetCapacity(System.IntPtr niTObjectArray)
		{
			if (niTObjectArray == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niTObjectArray"); }

			return NetScriptFramework.Memory.ReadUInt16(niTObjectArray + 0x10);
		}

		/// <param name = "niTObjectArray">NiTObjectArray&lt;T&gt;</param>
		static public System.IntPtr GetElements(System.IntPtr niTObjectArray)
		{
			if (niTObjectArray == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niTObjectArray"); }

			var elements = NetScriptFramework.Memory.ReadPointer(niTObjectArray + 0x8);
			if (elements == System.IntPtr.Zero) { throw new Eggceptions.NullException("elements"); }

			return elements;
		}

		/// <param name = "niTObjectArray">NiTObjectArray&lt;T&gt;</param>
		static public System.UInt16 GetGrowCount(System.IntPtr niTObjectArray)
		{
			if (niTObjectArray == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niTObjectArray"); }

			return NetScriptFramework.Memory.ReadUInt16(niTObjectArray + 0x16);
		}

		/// <param name = "niTObjectArray">NiTObjectArray&lt;T&gt;</param>
		static public System.UInt16 GetSparseCount(System.IntPtr niTObjectArray)
		{
			if (niTObjectArray == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niTObjectArray"); }

			return NetScriptFramework.Memory.ReadUInt16(niTObjectArray + 0x12);
		}
	}
}
