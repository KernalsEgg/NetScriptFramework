namespace Eggstensions
{
	public class TESActorBase : TESBoundObject
	{
		public TESActorBase(System.IntPtr address) : base(address)
		{
		}



		static public explicit operator TESFullName(TESActorBase actorBase)
		{
			return new TESFullName(actorBase, 0xD8);
		}



		static public implicit operator TESActorBase(System.IntPtr address)
		{
			return new TESActorBase(address);
		}
	}
}
