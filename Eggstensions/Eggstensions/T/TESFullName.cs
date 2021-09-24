namespace Eggstensions
{
	public interface ITESFullName : IVirtualObject
	{
	}

	public struct TESFullName : ITESFullName
	{
	}



	namespace ExtensionMethods
	{
		unsafe static public class ITESFullName
		{
			// Virtual
			static public System.String GetFullName<TTESFullName>(this ref TTESFullName fullName)
				where TTESFullName : unmanaged, Eggstensions.ITESFullName
			{
				var getFullName = (delegate* unmanaged[Cdecl]<TTESFullName*, System.IntPtr>)fullName.VirtualFunction(0x5);

				return Memory.ReadString(GetFullName(fullName.AsPointer()));



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				System.IntPtr GetFullName(TTESFullName* fullName)
				{
					return getFullName(fullName);
				}
			}
		}
	}
}
