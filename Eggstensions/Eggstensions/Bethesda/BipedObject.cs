namespace Eggstensions.Bethesda
{
	static public class BipedObject
	{
		/// <param name = "bipedObject">BipedObject</param>
		/// <returns>TESObjectARMO, TESObjectARMA, System.IntPtr.Zero</returns>
		static public System.IntPtr GetArmor(System.IntPtr bipedObject)
		{
			if (bipedObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bipedObject"); }

			var armor = NetScriptFramework.Memory.ReadPointer(bipedObject);
			if (armor == System.IntPtr.Zero) { return System.IntPtr.Zero; }
			if (!TESForm.HasFormType(armor, FormTypes.TESObjectARMO, FormTypes.TESObjectARMA)) { throw new Eggceptions.Bethesda.FormTypeException("armor"); }

			return armor;
		}

		/// <param name = "bipedObject">BipedObject</param>
		/// <returns>TESObjectARMA, System.IntPtr.Zero</returns>
		static public System.IntPtr GetArmorAddon(System.IntPtr bipedObject)
		{
			if (bipedObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bipedObject"); }

			var armorAddon = NetScriptFramework.Memory.ReadPointer(bipedObject + 0x8);
			if (armorAddon == System.IntPtr.Zero) { return System.IntPtr.Zero; }
			if (!TESForm.HasFormType(armorAddon, FormTypes.TESObjectARMA)) { throw new Eggceptions.Bethesda.FormTypeException("armorAddon"); }
			
			return armorAddon;
		}

		/// <param name = "bipedObject">BipedObject</param>
		/// <returns>TESModel, System.IntPtr.Zero</returns>
		static public System.IntPtr GetModel(System.IntPtr bipedObject)
		{
			if (bipedObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bipedObject"); }

			return NetScriptFramework.Memory.ReadPointer(bipedObject + 0x10);
		}

		/// <param name = "bipedObject">BipedObject</param>
		/// <returns>NiPointer&lt;NiAVObject&gt;, System.IntPtr.Zero</returns>
		static public System.IntPtr GetObject(System.IntPtr bipedObject)
		{
			if (bipedObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bipedObject"); }

			return NiPointer.GetValue(bipedObject + 0x20);
		}

		/// <param name = "bipedObject">BipedObject</param>
		/// <returns>BGSTextureSet, System.IntPtr.Zero</returns>
		static public System.IntPtr GetTexture(System.IntPtr bipedObject)
		{
			if (bipedObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bipedObject"); }

			return NetScriptFramework.Memory.ReadPointer(bipedObject + 0x18);
		}
	}
}
