namespace Eggstensions
{
	public interface ITESObjectARMO : ITESBoundObject
	{
	}

	public struct TESObjectARMO : ITESObjectARMO
	{
	}



	namespace ExtensionMethods
	{
		unsafe static public class ITESObjectARMO
		{
			// Inheritance
			static public TESFullName* TESFullName<TTESObjectARMO>(this ref TTESObjectARMO armor)
				where TTESObjectARMO : unmanaged, Eggstensions.ITESObjectARMO
			{
				return (TESFullName*)armor.AddByteOffset(0x30);
			}
		}
	}
}
