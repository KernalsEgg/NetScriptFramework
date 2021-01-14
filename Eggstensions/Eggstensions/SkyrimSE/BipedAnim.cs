namespace Eggstensions.SkyrimSE
{
	public enum BipedObjectSlots : System.UInt32
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



	static public class BipedAnim
	{
		/// <param name = "bipedAnim">BipedAnim</param>
		/// <returns>BipedObject</returns>
		static public System.IntPtr GetBipedObject(System.IntPtr bipedAnim, BipedObjectSlots bipedObjectSlot)
		{
			if (bipedAnim == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(bipedAnim)); }
			// bipedObjectSlot

			return bipedAnim + 0x10 + 0x78 * ((System.Int32)bipedObjectSlot - 0x1E);
		}

		/// <param name = "bipedAnim">BipedAnim</param>
		static public BSPointerHandle.ReferenceFromHandle GetActor(System.IntPtr bipedAnim)
		{
			if (bipedAnim == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(bipedAnim)); }

			return new BSPointerHandle.ReferenceFromHandle(bipedAnim + 0x2770);
		}

		/// <param name = "bipedAnim">BipedAnim</param>
		static public System.UInt32 GetActorHandle(System.IntPtr bipedAnim)
		{
			if (bipedAnim == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(bipedAnim)); }

			return NetScriptFramework.Memory.ReadUInt32(bipedAnim + 0x2770);
		}

		/// <param name = "bipedAnim">BipedAnim</param>
		static public System.IntPtr GetActorHandleAddress(System.IntPtr bipedAnim)
		{
			if (bipedAnim == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(bipedAnim)); }

			return bipedAnim + 0x2770;
		}

		/// <param name = "bipedAnim">BipedAnim</param>
		/// <returns>NiNode</returns>
		static public System.IntPtr GetRoot(System.IntPtr bipedAnim)
		{
			if (bipedAnim == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(bipedAnim)); }

			var root = NetScriptFramework.Memory.ReadPointer(bipedAnim + 0x8);
			if (root == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(root)); }

			return root;
		}
	}
}
