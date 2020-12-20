namespace Eggstensions.Bethesda
{
	static public class MiddleHighProcessData
	{
		/// <param name="middleHighProcessData">MiddleHighProcessData</param>
		/// <returns>bhkCharacterController</returns>
		static public System.IntPtr GetCharacterController(System.IntPtr middleHighProcessData)
		{
			if (middleHighProcessData == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("middleHighProcessData"); }

			return NiPointer.GetValue(middleHighProcessData + 0x250);
		}
	}
}
