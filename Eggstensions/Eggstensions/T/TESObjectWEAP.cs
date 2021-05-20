using Eggstensions.Interoperability.Managed; // Memory



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
				return Memory.ReadIntPtr(Offsets.TESObjectWEAP.Unarmed);
			}
		}



		static public implicit operator TESObjectWEAP(System.IntPtr address)
		{
			return new TESObjectWEAP(address);
		}
	}
}
