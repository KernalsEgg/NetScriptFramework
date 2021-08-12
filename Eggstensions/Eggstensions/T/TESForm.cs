﻿namespace Eggstensions
{
	public enum FormType : System.Byte
	{
		Armor	= 0x1A,
		Tree	= 0x26,
		Flora	= 0x27,
		Weapon	= 0x29,
		Actor	= 0x3E
	}



	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x20)]
	unsafe public struct TESForm
	{
		[System.Runtime.InteropServices.FieldOffset(0x14)] public System.UInt32 FormId;
		[System.Runtime.InteropServices.FieldOffset(0x1A)] public FormType FormType;



		// Virtual
		static public void RemoveChanges(TESForm* form, System.UInt32 changeFlags)
		{
			var removeChanges = Memory.ReadVirtualFunction<Eggstensions.Delegates.Types.TESForm.RemoveChanges>(*(System.IntPtr*)form, 0xB);

			removeChanges(form, changeFlags);
		}



		// Member
		static public EnchantmentItem* GetEnchantment(TESForm* form, ExtraDataList* extraDataList)
		{
			return Eggstensions.Delegates.Instances.TESForm.GetEnchantment(form, extraDataList);
		}

		static public System.String GetFullName(TESForm* form)
		{
			return Memory.ReadString(Eggstensions.Delegates.Instances.TESForm.GetFullName(form));
		}

		static public System.UInt16 GetMaximumCharge(TESForm* form, ExtraDataList* extraDataList)
		{
			return Eggstensions.Delegates.Instances.TESForm.GetMaximumCharge(form, extraDataList);
		}
	}
}
