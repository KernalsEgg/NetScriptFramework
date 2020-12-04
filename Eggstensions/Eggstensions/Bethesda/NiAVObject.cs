namespace Eggstensions.Bethesda
{
	public enum NiAVObjectFlags : System.UInt32
	{
		None =		0u,
		Hidden =	1u << 0x0
	}



	static public class NiAVObject
	{
		/// <param name = "niAVObject">NiAVObject</param>
		static public void AddNiAVObjectFlags(System.IntPtr niAVObject, NiAVObjectFlags niAVObjectFlags)
		{
			if (niAVObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niAVObject"); }
			// niAVObjectFlags

			NiAVObject.SetNiAVObjectFlags(niAVObject, niAVObjectFlags | NiAVObject.GetNiAVObjectFlags(niAVObject));
		}

		/// <param name = "niAVObject">NiAVObject</param>
		/// <param name = "bsFixedString">BSFixedString</param>
		/// <returns>NiNode, System.IntPtr.Zero</returns>
		static public System.IntPtr GetBoneNodeByName(System.IntPtr niAVObject, System.IntPtr bsFixedString)
		{
			if (niAVObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niAVObject"); }
			if (bsFixedString == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bsFixedString"); }

			return NetScriptFramework.Memory.InvokeCdecl(VIDS.NiAVObject.GetBoneNodeByName, niAVObject, bsFixedString, 1);
		}

		/// <param name = "niAVObject">NiAVObject</param>
		static public NiAVObjectFlags GetNiAVObjectFlags(System.IntPtr niAVObject)
		{
			if (niAVObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niAVObject"); }

			return (NiAVObjectFlags)NetScriptFramework.Memory.ReadUInt32(niAVObject + 0xF4);
		}

		/// <param name = "niAVObject">NiAVObject</param>
		/// <param name = "bsFixedString">BSFixedString</param>
		/// <returns>NiNode, System.IntPtr.Zero</returns>
		static public System.IntPtr GetNodeByName(System.IntPtr niAVObject, System.IntPtr bsFixedString)
		{
			if (niAVObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niAVObject"); }
			if (bsFixedString == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bsFixedString"); }

			return VirtualObject.InvokeVTableThisCall(niAVObject, 0x150, bsFixedString);
		}

		/// <param name = "niAVObject">NiAVObject</param>
		/// <returns>NiNode, System.IntPtr.Zero</returns>
		static public System.IntPtr GetParent(System.IntPtr niAVObject)
		{
			if (niAVObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niAVObject"); }

			return NetScriptFramework.Memory.ReadPointer(niAVObject + 0x30);
		}

		/// <param name = "niAVObject">NiAVObject</param>
		/// <returns>TESObjectREFR, System.IntPtr.Zero</returns>
		static public System.IntPtr GetOwner(System.IntPtr niAVObject)
		{
			if (niAVObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niAVObject"); }

			return NetScriptFramework.Memory.ReadPointer(niAVObject + 0xF8); // userData
		}

		/// <param name = "niAVObject">NiAVObject</param>
		/// <returns>TESObjectREFR, System.IntPtr.Zero</returns>
		static public System.IntPtr GetOwnerRecursive(System.IntPtr niAVObject)
		{
			if (niAVObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niAVObject"); }

			var owner = NiAVObject.GetOwner(niAVObject);
			if (owner != System.IntPtr.Zero) { return owner; }

			var parent = NiAVObject.GetParent(niAVObject);
			if (parent != System.IntPtr.Zero) { return NiAVObject.GetOwnerRecursive(parent); }

			return System.IntPtr.Zero;
		}

		/// <param name = "niAVObject">NiAVObject</param>
		static public System.Boolean HasNiAVObjectFlags(System.IntPtr niAVObject, NiAVObjectFlags niAVObjectFlags)
		{
			if (niAVObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niAVObject"); }
			// niAVObjectFlags

			return (NiAVObject.GetNiAVObjectFlags(niAVObject) & niAVObjectFlags) == niAVObjectFlags;
		}

		static public System.Boolean IsHidden(System.IntPtr niAVObject)
		{
			if (niAVObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niAVObject"); }

			return NiAVObject.HasNiAVObjectFlags(niAVObject, NiAVObjectFlags.Hidden);
		}

		/// <param name="niAVObject">NiAVObject</param>
		static public void RemoveNiAVObjectFlags(System.IntPtr niAVObject, NiAVObjectFlags niAVObjectFlags)
		{
			if (niAVObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niAVObject"); }
			// niAVObjectFlags

			NiAVObject.SetNiAVObjectFlags(niAVObject, niAVObjectFlags & ~NiAVObject.GetNiAVObjectFlags(niAVObject));
		}

		/// <param name = "niAVObject">NiAVObject</param>
		static public void SetNiAVObjectFlags(System.IntPtr niAVObject, NiAVObjectFlags niAVObjectFlags)
		{
			if (niAVObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niAVObject"); }
			// niAVObjectFlags

			NetScriptFramework.Memory.WriteUInt32(niAVObject + 0xF4, (System.UInt32)niAVObjectFlags);
		}
	}
}
