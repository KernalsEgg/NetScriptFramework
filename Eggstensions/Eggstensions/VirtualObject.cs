namespace Eggstensions
{
	public interface IVirtualObject : IUnmanagedObject
	{
	}



	namespace ExtensionMethods
	{
		unsafe static public class IVirtualObject
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining | System.Runtime.CompilerServices.MethodImplOptions.AggressiveOptimization)]
			static public void* VirtualFunction<TVirtualObject>(this ref TVirtualObject virtualObject, System.Int32 index)
				where TVirtualObject : unmanaged, Eggstensions.IVirtualObject
			{
				return (*(System.IntPtr**)virtualObject.AsPointer())[index].ToPointer();
			}
		}
	}
}
