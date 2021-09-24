namespace Eggstensions
{
	public interface ITESAmmo : ITESBoundObject
	{
	}

	public struct TESAmmo : ITESAmmo
	{
	}



	namespace ExtensionMethods
	{
		unsafe static public class ITESAmmo
		{
			// Virtual
			static public System.Boolean IsPlayable<TTESAmmo>(this ref TTESAmmo ammo)
				where TTESAmmo : unmanaged, Eggstensions.ITESAmmo
			{
				var isPlayable = (delegate* unmanaged[Cdecl]<TTESAmmo*, System.Byte>)ammo.VirtualFunction(0x19);

				return IsPlayable(ammo.AsPointer()) != 0;



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				System.Byte IsPlayable(TTESAmmo* ammo)
				{
					return isPlayable(ammo);
				}
			}
		}
	}
}
