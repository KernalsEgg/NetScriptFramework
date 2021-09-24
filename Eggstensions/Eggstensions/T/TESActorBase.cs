namespace Eggstensions
{
	public interface ITESActorBase : ITESBoundObject
	{
	}

	public struct TESActorBase : ITESActorBase
	{
	}



	namespace ExtensionMethods
	{
		unsafe static public class ITESActorBase
		{
			// Inheritance
			static public TESFullName* TESFullName<TTESActorBase>(this ref TTESActorBase actorBase)
				where TTESActorBase : unmanaged, Eggstensions.ITESActorBase
			{
				return (TESFullName*)actorBase.AddByteOffset(0xD8);
			}
		}
	}
}
