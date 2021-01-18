namespace Eggstensions.SkyrimSE
{
	static public class BipedObject
	{
		public enum Slots : System.UInt32
		{
			/// <summary>Head</summary>
			BipedObjectSlot30 = 0x1Eu,
			/// <summary>Hair</summary>
			BipedObjectSlot31 = 0x1Fu,
			/// <summary>Body</summary>
			BipedObjectSlot32 = 0x20u,
			/// <summary>Hands</summary>
			BipedObjectSlot33 = 0x21u,

			/// <summary>Forearms</summary>
			BipedObjectSlot34 = 0x22u,
			/// <summary>Amulet</summary>
			BipedObjectSlot35 = 0x23u,
			/// <summary>Ring</summary>
			BipedObjectSlot36 = 0x24u,
			/// <summary>Feet</summary>
			BipedObjectSlot37 = 0x25u,

			/// <summary>Calves</summary>
			BipedObjectSlot38 = 0x26u,
			/// <summary>Shield</summary>
			BipedObjectSlot39 = 0x27u,
			/// <summary>Unnamed</summary>
			BipedObjectSlot40 = 0x28u,
			/// <summary>Long hair</summary>
			BipedObjectSlot41 = 0x29u,

			/// <summary>Circlet</summary>
			BipedObjectSlot42 = 0x2Au,
			/// <summary>Ears</summary>
			BipedObjectSlot43 = 0x2Bu,
			/// <summary>Unnamed</summary>
			BipedObjectSlot44 = 0x2Cu,
			/// <summary>Unnamed</summary>
			BipedObjectSlot45 = 0x2Du,

			/// <summary>Unnamed</summary>
			BipedObjectSlot46 = 0x2Eu,
			/// <summary>Unnamed</summary>
			BipedObjectSlot47 = 0x2Fu,
			/// <summary>Unnamed</summary>
			BipedObjectSlot48 = 0x30u,
			/// <summary>Unnamed</summary>
			BipedObjectSlot49 = 0x31u,

			/// <summary>Unnamed</summary>
			BipedObjectSlot50 = 0x32u,
			/// <summary>Unnamed</summary>
			BipedObjectSlot51 = 0x33u,
			/// <summary>Unnamed</summary>
			BipedObjectSlot52 = 0x34u,
			/// <summary>Unnamed</summary>
			BipedObjectSlot53 = 0x35u,

			/// <summary>Unnamed</summary>
			BipedObjectSlot54 = 0x36u,
			/// <summary>Unnamed</summary>
			BipedObjectSlot55 = 0x37u,
			/// <summary>Unnamed</summary>
			BipedObjectSlot56 = 0x38u,
			/// <summary>Unnamed</summary>
			BipedObjectSlot57 = 0x39u,

			/// <summary>Unnamed</summary>
			BipedObjectSlot58 = 0x3Au,
			/// <summary>Unnamed</summary>
			BipedObjectSlot59 = 0x3Bu,
			/// <summary>Unnamed</summary>
			BipedObjectSlot60 = 0x3Cu,
			/// <summary>FX01</summary>
			BipedObjectSlot61 = 0x3Du
		}



		/// <param name = "bipedObject">BipedObject</param>
		/// <returns>TESObjectARMO, TESObjectARMA, System.IntPtr.Zero</returns>
		static public System.IntPtr GetArmor(System.IntPtr bipedObject)
		{
			if (bipedObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(bipedObject)); }

			return NetScriptFramework.Memory.ReadPointer(bipedObject);
		}

		/// <param name = "bipedObject">BipedObject</param>
		/// <returns>TESObjectARMA, System.IntPtr.Zero</returns>
		static public System.IntPtr GetArmorAddon(System.IntPtr bipedObject)
		{
			if (bipedObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(bipedObject)); }

			return NetScriptFramework.Memory.ReadPointer(bipedObject + 0x8);
		}

		/// <param name = "bipedObject">BipedObject</param>
		/// <returns>TESModel, System.IntPtr.Zero</returns>
		static public System.IntPtr GetModel(System.IntPtr bipedObject)
		{
			if (bipedObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(bipedObject)); }

			return NetScriptFramework.Memory.ReadPointer(bipedObject + 0x10);
		}

		/// <param name = "bipedObject">BipedObject</param>
		/// <returns>NiAVObject, System.IntPtr.Zero</returns>
		static public System.IntPtr GetObject(System.IntPtr bipedObject)
		{
			if (bipedObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(bipedObject)); }

			return NiPointer.GetValue(bipedObject + 0x20);
		}

		/// <param name = "bipedObject">BipedObject</param>
		/// <returns>BGSTextureSet, System.IntPtr.Zero</returns>
		static public System.IntPtr GetTexture(System.IntPtr bipedObject)
		{
			if (bipedObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(bipedObject)); }

			return NetScriptFramework.Memory.ReadPointer(bipedObject + 0x18);
		}
	}
}
