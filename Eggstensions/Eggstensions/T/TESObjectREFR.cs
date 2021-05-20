using Eggstensions.Interoperability.Managed; // Memory



namespace Eggstensions
{
	public class TESObjectREFR : TESForm
	{
		[System.Flags]
		public enum ChangeFlags : System.UInt32
		{
			Empty = 1 << 21
		}
		
		
		
		public TESObjectREFR(System.IntPtr address) : base(address)
		{
		}



		public TESBoundObject BaseObject
		{
			get
			{
				return Memory.ReadIntPtr(this, 0x40);
			}
		}



		public NiAVObject GetCurrent3D()
		{
			var getCurrent3D = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.TESObjectREFR.GetCurrent3D>(this[0x8D]);

			return getCurrent3D(this);
		}



		static public implicit operator TESObjectREFR(System.IntPtr address)
		{
			return new TESObjectREFR(address);
		}
	}
}
