namespace Eggstensions
{
	namespace ExtensionMethods
	{
		unsafe static public class Unsafe
		{
			static public void* AddByteOffset<T>(this ref T source, System.Int32 byteOffset)
				where T : unmanaged
			{
				return System.Runtime.CompilerServices.Unsafe.Add<System.Byte>(source.AsPointer(), byteOffset);
			}

			static public T* AsPointer<T>(this ref T value)
				where T : unmanaged
			{
				return (T*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref value);
			}
		}
	}
}
