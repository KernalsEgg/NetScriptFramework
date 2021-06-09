namespace Eggstensions
{
	public class TESFullName : VirtualObject
	{
		public TESFullName(System.IntPtr address) : base(address)
		{
		}

		public TESFullName(System.IntPtr address, System.Int32 offset) : this(address + offset)
		{
		}



		virtual public System.String GetFullName()
		{
			var getFullName = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.TESFullName.GetFullName>(this[0x5]);

			return Memory.ReadString(getFullName(this));
		}



		static public implicit operator TESFullName(System.IntPtr address)
		{
			return new TESFullName(address);
		}
	}
}
