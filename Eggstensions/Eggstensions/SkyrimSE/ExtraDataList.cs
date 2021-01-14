namespace Eggstensions.SkyrimSE
{
	public enum ExtraDataTypes : System.Byte
	{
		None =			0x0,
		Flags =			0xA0,
		Interaction =	0xA9
	}



	static public class PresenceBitfield
	{
		static public System.UInt32 Length { get; } = 0x18;
		
		
		
		static public System.Boolean HasType(System.IntPtr presenceBitfield, ExtraDataTypes type)
		{
			if (presenceBitfield == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(presenceBitfield)); }
			// type

			var index = (System.Byte)type >> 3;

			if (index < PresenceBitfield.Length)
			{
				var mask = (System.Byte)(1 << ((System.Byte)type % 8));

				return (NetScriptFramework.Memory.ReadUInt8(presenceBitfield + 0x1 * index) & mask) != 0;
			}

			return false;
		}

		static public void MarkType(System.IntPtr presenceBitfield, ExtraDataTypes type, System.Boolean cleared)
		{
			if (presenceBitfield == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(presenceBitfield)); }
			// type
			// cleared

			var index = (System.Byte)type >> 3;

			if (index < PresenceBitfield.Length)
			{
				var address = presenceBitfield + 0x1 * index;
				var mask = (System.Byte)(1 << ((System.Byte)type % 8));

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
	}

	public class ExtraDataList : System.Collections.Generic.IEnumerable<System.IntPtr>
	{
		public ExtraDataList(System.IntPtr extraDataList)
		{
			if (extraDataList == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(extraDataList)); }

			Address = extraDataList;
		}



		public System.IntPtr Address { get; }



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
			if (extraDataList == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(extraDataList)); }

			var extraData = NetScriptFramework.Memory.ReadPointer(extraDataList);
			if (extraData == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(extraData)); }

			return extraData;
		}

		/// <param name="extraDataList">ExtraDataList</param>
		/// <returns>PresenceBitfield</returns>
		static public System.IntPtr GetPresenceBitfield(System.IntPtr extraDataList)
		{
			if (extraDataList == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(extraDataList)); }

			return extraDataList + 0x8;
		}

		/// <param name="extraDataList">ExtraDataList</param>
		static public BSReadLockGuard GetReadLock(System.IntPtr extraDataList)
		{
			if (extraDataList == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(extraDataList)); }

			return new BSReadLockGuard(extraDataList + 0x10);
		}

		/// <param name="extraDataList">ExtraDataList</param>
		static public BSWriteLockGuard GetWriteLock(System.IntPtr extraDataList)
		{
			if (extraDataList == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(extraDataList)); }

			return new BSWriteLockGuard(extraDataList + 0x10);
		}

		/// <param name="extraDataList">ExtraDataList</param>
		static public System.Boolean HasExtraDataType(System.IntPtr extraDataList, ExtraDataTypes extraDataType)
		{
			if (extraDataList == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(extraDataList)); }
			// extraDataType

			using (ExtraDataList.GetReadLock(extraDataList))
			{
				return PresenceBitfield.HasType(ExtraDataList.GetPresenceBitfield(extraDataList), extraDataType);
			}
		}

		/// <param name="extraDataList">ExtraDataList</param>
		static public System.Boolean HasInteraction(System.IntPtr extraDataList)
		{
			if (extraDataList == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(extraDataList)); }

			return ExtraDataList.HasExtraDataType(extraDataList, ExtraDataTypes.Interaction);
		}
	}
}
