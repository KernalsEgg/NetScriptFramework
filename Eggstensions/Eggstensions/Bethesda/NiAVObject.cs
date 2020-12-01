namespace Eggstensions.Bethesda
{
	public enum NiAVFlags : System.UInt32
	{
		None =		0u,
		Hidden =	1u << 0x0
	}



	static public class NiAVObject
	{
		/// <param name = "niAVObject">NiAVObject</param>
		static public void AddNiAVFlags(System.IntPtr niAVObject, NiAVFlags niAVFlags)
		{
			if (niAVObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niAVObject"); }
			// niAVFlags

			NiAVObject.SetNiAVFlags(niAVObject, niAVFlags | NiAVObject.GetNiAVFlags(niAVObject));
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
		static public NiAVFlags GetNiAVFlags(System.IntPtr niAVObject)
		{
			if (niAVObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niAVObject"); }

			return (NiAVFlags)NetScriptFramework.Memory.ReadUInt32(niAVObject + 0xF4);
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

			if (owner != System.IntPtr.Zero)
			{
				return owner;
			}

			var parent = NiAVObject.GetParent(niAVObject);

			if (parent != System.IntPtr.Zero)
			{
				return NiAVObject.GetOwnerRecursive(parent);
			}

			return System.IntPtr.Zero;
		}

		/// <param name = "niAVObject">NiAVObject</param>
		static public System.Boolean HasNiAVFlags(System.IntPtr niAVObject, NiAVFlags niAVFlags)
		{
			if (niAVObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niAVObject"); }
			// niAVFlags

			return (NiAVObject.GetNiAVFlags(niAVObject) & niAVFlags) == niAVFlags;
		}

		/// <param name="niAVObject">NiAVObject</param>
		static public void RemoveNiAVFlags(System.IntPtr niAVObject, NiAVFlags niAVFlags)
		{
			if (niAVObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niAVObject"); }
			// niAVFlags

			NiAVObject.SetNiAVFlags(niAVObject, niAVFlags & ~NiAVObject.GetNiAVFlags(niAVObject));
		}

		/// <param name = "niAVObject">NiAVObject</param>
		static public void SetNiAVFlags(System.IntPtr niAVObject, NiAVFlags niAVFlags)
		{
			if (niAVObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niAVObject"); }
			// niAVFlags

			NetScriptFramework.Memory.WriteUInt32(niAVObject + 0xF4, (System.UInt32)niAVFlags);
		}
	}
}
