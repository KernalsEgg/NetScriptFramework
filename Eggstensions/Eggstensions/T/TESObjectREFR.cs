namespace Eggstensions
{
	public class TESObjectREFR : TESForm
	{
		[System.Flags]
		public enum ChangeFlags : System.UInt32
		{
			Empty = 1U << 21
		}
		
		
		
		public TESObjectREFR(System.IntPtr address) : base(address)
		{
		}



		/// <summary>TESBoundObject</summary>
		public System.IntPtr BaseObject
		{
			get
			{
				return Memory.Read<System.IntPtr>(this, 0x40);
			}
		}



		virtual public NiAVObject GetCurrent3D()
		{
			var getCurrent3D = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.TESObjectREFR.GetCurrent3D>(this[0x8D]);

			return getCurrent3D(this);
		}



		public InventoryChanges GetInventoryChanges()
		{
			return Delegates.Instances.TESObjectREFR.GetInventoryChanges(this);
		}



		static public implicit operator TESObjectREFR(System.IntPtr address)
		{
			return new TESObjectREFR(address);
		}
	}
}
