namespace Eggstensions
{
	public enum FormType : System.Byte
	{
		Armor	= 0x1A,
		Tree	= 0x26,
		Flora	= 0x27,
		Weapon	= 0x29,
		Actor	= 0x3E
	}



	public class TESForm : VirtualObject
	{
		public TESForm(System.IntPtr address) : base(address)
		{
		}



		public FormType FormType
		{
			get
			{
				return (FormType)Memory.Read<System.Byte>(this, 0x1A);
			}
		}



		virtual public void RemoveChanges(System.UInt32 changeFlags)
		{
			var removeChanges = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.TESForm.RemoveChanges>(this[0xB]);

			removeChanges(this, changeFlags);
		}



		static public implicit operator TESForm(System.IntPtr address)
		{
			return new TESForm(address);
		}
	}
}
