namespace Eggstensions.SkyrimSE
{
	static public class BSTSmartPointer
	{
		/// <param name="bstSmartPointer">BSTSmartPointer</param>
		static public System.IntPtr GetValue(System.IntPtr bstSmartPointer)
		{
			if (bstSmartPointer == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(bstSmartPointer)); }

			return NetScriptFramework.Memory.ReadPointer(bstSmartPointer);
		}
	}
}
