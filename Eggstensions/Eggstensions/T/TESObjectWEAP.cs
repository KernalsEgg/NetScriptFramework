namespace Eggstensions
{
	public class TESObjectWEAP : TESBoundObject
	{
		public TESObjectWEAP(System.IntPtr address) : base(address)
		{
		}



		static public TESObjectWEAP Unarmed
		{
			get
			{
				return Memory.Read<System.IntPtr>(Offsets.TESObjectWEAP.Unarmed);
			}
		}



		static public implicit operator TESObjectWEAP(System.IntPtr address)
		{
			return new TESObjectWEAP(address);
		}
	}
}
