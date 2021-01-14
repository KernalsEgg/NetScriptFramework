namespace Eggstensions.SkyrimSE
{
	static public class MiddleHighProcessData
	{
		/// <param name="middleHighProcessData">MiddleHighProcessData</param>
		/// <returns>bhkCharacterController</returns>
		static public System.IntPtr GetCharacterController(System.IntPtr middleHighProcessData)
		{
			if (middleHighProcessData == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(middleHighProcessData)); }

			return NiPointer.GetValue(middleHighProcessData + 0x250);
		}

		/// <param name="middleHighProcessData">MiddleHighProcessData</param>
		static public BSPointerHandle.ReferenceFromHandle GetOccupiedFurniture(System.IntPtr middleHighProcessData)
		{
			if (middleHighProcessData == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(middleHighProcessData)); }

			return new BSPointerHandle.ReferenceFromHandle(middleHighProcessData + 0x208);
		}

		/// <param name="middleHighProcessData">MiddleHighProcessData</param>
		static public System.UInt32 GetOccupiedFurnitureHandle(System.IntPtr middleHighProcessData)
		{
			if (middleHighProcessData == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(middleHighProcessData)); }

			return NetScriptFramework.Memory.ReadUInt32(middleHighProcessData + 0x208);
		}

		/// <param name="middleHighProcessData">MiddleHighProcessData</param>
		static public System.IntPtr GetOccupiedFurnitureHandleAddress(System.IntPtr middleHighProcessData)
		{
			if (middleHighProcessData == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(middleHighProcessData)); }

			return middleHighProcessData + 0x208;
		}
	}
}
