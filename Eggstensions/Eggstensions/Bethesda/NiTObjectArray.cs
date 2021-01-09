namespace Eggstensions.Bethesda
{
	public class NiTObjectArray : System.Collections.Generic.IEnumerable<System.IntPtr>
	{
		public NiTObjectArray(System.IntPtr niTObjectArray)
		{
			if (niTObjectArray == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niTObjectArray"); }

			Address = niTObjectArray;
		}



		public System.IntPtr Address { get; }



		public System.Collections.Generic.IEnumerator<System.IntPtr> GetEnumerator()
		{
			var niTObjectArray = Address;
			var capacity = NiTObjectArray.GetCapacity(niTObjectArray);
			var begin = NiTObjectArray.GetBegin(niTObjectArray);
			if (begin == System.IntPtr.Zero) { yield break; }

			for (var i = 0; i < capacity; i++)
			{
				var element = NetScriptFramework.Memory.ReadPointer(begin + 0x8 * i);
				if (element == System.IntPtr.Zero) { continue; }
				
				yield return element;
			}
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}



		/// <param name = "niTObjectArray">NiTObjectArray&lt;T&gt;</param>
		static public System.IntPtr GetBegin(System.IntPtr niTObjectArray)
		{
			if (niTObjectArray == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niTObjectArray"); }

			return NetScriptFramework.Memory.ReadPointer(niTObjectArray + 0x8);
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
