namespace Eggstensions.SkyrimSE
{
	static public class BSExtraData
	{
		public enum ExtraDataTypes : System.Byte
		{
			None =			0x0,
			Flags =			0xA0,
			Interaction =	0xA9
		}



		/// <param name="extraData">BSExtraData</param>
		/// <returns>BSExtraData, System.IntPtr.Zero</returns>
		static public System.IntPtr GetNext(System.IntPtr extraData)
		{
			if (extraData == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(extraData)); }

			return NetScriptFramework.Memory.ReadPointer(extraData + 0x8);
		}
	}
}
