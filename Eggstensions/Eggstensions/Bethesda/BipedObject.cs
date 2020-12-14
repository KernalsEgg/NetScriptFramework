namespace Eggstensions.Bethesda
{
	static public class BipedObject
	{
		/// <param name = "bipedObject">BipedObject</param>
		/// <returns>TESObjectARMO, TESObjectARMA, System.IntPtr.Zero</returns>
		static public System.IntPtr GetArmor(System.IntPtr bipedObject)
		{
			if (bipedObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bipedObject"); }

			return NetScriptFramework.Memory.ReadPointer(bipedObject);
		}

		/// <param name = "bipedObject">BipedObject</param>
		/// <returns>TESObjectARMA, System.IntPtr.Zero</returns>
		static public System.IntPtr GetArmorAddon(System.IntPtr bipedObject)
		{
			if (bipedObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bipedObject"); }

			return NetScriptFramework.Memory.ReadPointer(bipedObject + 0x8);
		}

		/// <param name = "bipedObject">BipedObject</param>
		/// <returns>TESModel, System.IntPtr.Zero</returns>
		static public System.IntPtr GetModel(System.IntPtr bipedObject)
		{
			if (bipedObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bipedObject"); }

			return NetScriptFramework.Memory.ReadPointer(bipedObject + 0x10);
		}

		/// <param name = "bipedObject">BipedObject</param>
		/// <returns>NiAVObject, System.IntPtr.Zero</returns>
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
