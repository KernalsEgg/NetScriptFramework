namespace Eggstensions
{
	public interface ITESQuest : ITESForm
	{
	}

	public struct TESQuest : ITESQuest
	{
	}



	namespace ExtensionMethods
	{
		unsafe static public class ITESQuest
		{
			// Inheritance
			static public TESFullName* TESFullName<TTESQuest>(this ref TTESQuest quest)
				where TTESQuest : unmanaged, Eggstensions.ITESObjectARMO
			{
				return (TESFullName*)quest.AddByteOffset(0x28);
			}
		}
	}
}
