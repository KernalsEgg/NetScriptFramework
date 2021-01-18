namespace Eggstensions.SkyrimSE
{
	static public class BipedAnim
	{
		/// <param name = "bipedAnim">BipedAnim</param>
		/// <returns>BipedObject</returns>
		static public System.IntPtr GetBipedObject(System.IntPtr bipedAnim, BipedObject.Slots bipedObjectSlot)
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
