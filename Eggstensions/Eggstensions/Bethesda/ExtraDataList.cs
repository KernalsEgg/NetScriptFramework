namespace Eggstensions.Bethesda
{
	public enum ExtraDataTypes : System.Byte
	{
		None = 0x0,
		Flags = 0xA0
	}



	static public class PresenceBitfield
	{
		static public System.UInt32 Length { get { return 0x18; } }
		
		
		
		static public System.Boolean HasExtraDataType(System.IntPtr presenceBitfield, ExtraDataTypes extraDataType)
		{
			if (presenceBitfield == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("presenceBitfield"); }
			// extraDataType

			var index = (System.Byte)extraDataType >> 3;
			if (index >= PresenceBitfield.Length) { throw new Eggceptions.OutOfRangeException("index"); }

			var mask = 1 << ((System.Byte)extraDataType % 8);

			return (NetScriptFramework.Memory.ReadUInt8(presenceBitfield + 0x1 * index) & mask) != 0;
		}

		static public void MarkExtraDataType(System.IntPtr presenceBitfield, ExtraDataTypes extraDataType, System.Boolean cleared)
		{
			if (presenceBitfield == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("presenceBitfield"); }
			// extraDataType
			// cleared

			var index = (System.Byte)extraDataType >> 3;
			var address = presenceBitfield + 0x1 * index;
			var mask = (System.Byte)(1 << ((System.Byte)extraDataType % 8));

			if (cleared)
			{
				NetScriptFramework.Memory.WriteUInt8(address, (System.Byte)(NetScriptFramework.Memory.ReadUInt8(address) & ~mask));
			}
			else
			{
				NetScriptFramework.Memory.WriteUInt8(address, (System.Byte)(NetScriptFramework.Memory.ReadUInt8(address) | mask));
			}
		}
	}

	public class ExtraDataList : System.Collections.Generic.IEnumerable<System.IntPtr>
	{
		public System.IntPtr Address { get; }



		public ExtraDataList(System.IntPtr extraDataList)
		{
			if (extraDataList == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("extraDataList"); }

			Address = extraDataList;
		}



		public System.Collections.Generic.IEnumerator<System.IntPtr> GetEnumerator()
		{
			for (var extraData = ExtraDataList.GetExtraData(Address); extraData != System.IntPtr.Zero; extraData = BSExtraData.GetNext(extraData))
			{
				yield return extraData;
			}
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}



		/// <param name="extraDataList">ExtraDataList</param>
		/// <returns>BSExtraData</returns>
		static public System.IntPtr GetExtraData(System.IntPtr extraDataList)
		{
			if (extraDataList == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("extraDataList"); }

			var extraData = NetScriptFramework.Memory.ReadPointer(extraDataList);
			if (extraData == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("extraData"); }

			return extraData;
		}

		/// <param name="extraDataList">ExtraDataList</param>
		/// <returns>PresenceBitfield</returns>
		static public System.IntPtr GetPresenceBitfield(System.IntPtr extraDataList)
		{
			if (extraDataList == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("extraDataList"); }

			var presenceBitfield = NetScriptFramework.Memory.ReadPointer(extraDataList + 0x8);
			if (presenceBitfield == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("presenceBitfield"); }

			return presenceBitfield;
		}

		/// <param name="extraDataList">ExtraDataList</param>
		/// <returns>BSReadWriteLock</returns>
		static public System.IntPtr GetReadWriteLock(System.IntPtr extraDataList)
		{
			if (extraDataList == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("extraDataList"); }

			return extraDataList + 0x10;
		}
	}
}
