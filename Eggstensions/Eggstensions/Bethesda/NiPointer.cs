namespace Eggstensions.Bethesda
{
	static public class NiPointer
	{
		/// <param name="niPointer">NiPointer&lt;T&gt;</param>
		/// <returns>T</returns>
		static public System.IntPtr GetValue(System.IntPtr niPointer)
		{
			if (niPointer == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niPointer"); }

			return NetScriptFramework.Memory.ReadPointer(niPointer);
		}
	}
}
