namespace Eggstensions.SkyrimSE
{
	static public class BSExtraData
	{
		/// <param name="extraData">BSExtraData</param>
		/// <returns>BSExtraData, System.IntPtr.Zero</returns>
		static public System.IntPtr GetNext(System.IntPtr extraData)
		{
			if (extraData == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(extraData)); }

			return NetScriptFramework.Memory.ReadPointer(extraData + 0x8);
		}
	}
}
