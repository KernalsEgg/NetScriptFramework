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



	public interface ITESForm : IVirtualObject
	{
	}

	public struct TESForm : ITESForm
	{
	}



	namespace ExtensionMethods
	{
		unsafe static public class ITESForm
		{
			// Field
			static public System.UInt32 FormId<TTESForm>(this ref TTESForm form)
				where TTESForm : unmanaged, Eggstensions.ITESForm
			{
				return *(System.UInt32*)form.AddByteOffset(0x14);
			}

			static public FormType FormType<TTESForm>(this ref TTESForm form)
				where TTESForm : unmanaged, Eggstensions.ITESForm
			{
				return (FormType)(*(System.Byte*)form.AddByteOffset(0x1A));
			}



			// Virtual
			static public void RemoveChanges<TTESForm>(this ref TTESForm form, System.UInt32 changeFlags)
				where TTESForm : unmanaged, Eggstensions.ITESForm
			{
				var removeChanges = (delegate* unmanaged[Cdecl]<TTESForm*, System.UInt32, void>)form.VirtualFunction(0xB);

				RemoveChanges(form.AsPointer(), changeFlags);



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				void RemoveChanges(TTESForm* form, System.UInt32 changeFlags)
				{
					removeChanges(form, changeFlags);
				}
			}



			// Member
			static public EnchantmentItem* GetEnchantment<TTESForm>(this ref TTESForm form, ExtraDataList* extraDataList)
				where TTESForm : unmanaged, Eggstensions.ITESForm
			{
				var getEnchantment = (delegate* unmanaged[Cdecl]<TTESForm*, ExtraDataList*, EnchantmentItem*>)Eggstensions.Offsets.TESForm.GetEnchantment;

				return GetEnchantment(form.AsPointer(), extraDataList);



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				EnchantmentItem* GetEnchantment(TTESForm* form, ExtraDataList* extraDataList)
				{
					return getEnchantment(form, extraDataList);
				}
			}

			static public System.String GetFormName<TTESForm>(this ref TTESForm form)
				where TTESForm : unmanaged, Eggstensions.ITESForm
			{
				var getFormName = (delegate* unmanaged[Cdecl]<TTESForm*, System.IntPtr>)Eggstensions.Offsets.TESForm.GetFormName;

				return Memory.ReadString(GetFormName(form.AsPointer()));



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				System.IntPtr GetFormName(TTESForm* form)
				{
					return getFormName(form);
				}
			}

			static public System.UInt16 GetMaximumCharge<TTESForm>(this ref TTESForm form, ExtraDataList* extraDataList)
				where TTESForm : unmanaged, Eggstensions.ITESForm
			{
				var getMaximumCharge = (delegate* unmanaged[Cdecl]<TTESForm*, ExtraDataList*, System.UInt16>)Eggstensions.Offsets.TESForm.GetMaximumCharge;

				return GetMaximumCharge(form.AsPointer(), extraDataList);



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				System.UInt16 GetMaximumCharge(TTESForm* form, ExtraDataList* extraDataList)
				{
					return getMaximumCharge(form, extraDataList);
				}
			}
		}
	}
}
