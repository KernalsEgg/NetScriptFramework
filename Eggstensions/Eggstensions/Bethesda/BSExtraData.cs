namespace Eggstensions.Bethesda
{
	static public class BSExtraData
	{
		/*
		static public class Flags
		{
			static public System.Boolean GetBlockActivate
		}
		*/
		
		
		/// <param name="extraData">BSExtraData</param>
		/// <returns>BSExtraData, System.IntPtr.Zero</returns>
		static public System.IntPtr GetNext(System.IntPtr extraData)
		{
			if (extraData == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("extraData"); }

			return NetScriptFramework.Memory.ReadPointer(extraData + 0x8);
		}
	}
}
