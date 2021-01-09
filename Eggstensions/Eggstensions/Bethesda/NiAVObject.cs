namespace Eggstensions.Bethesda
{
	static public class NiAVObject
	{
		public enum Flags : System.UInt32
		{
			None =								0u,
			Hidden =							1u << 0,
			SelectiveUpdate =					1u << 1,
			SelectiveUpdateTransforms =			1u << 2,
			SelectiveUpdateController =			1u << 3,
			SelectiveUpdateRigid =				1u << 4,
			DisplayObject =						1u << 5,
			DisableSorting =					1u << 6,
			SelectiveUpdateTransformsOverride =	1u << 7,
			// Unknown
			IgnoreLocalTransform =				1u << 9,
			NoDecals =							1u << 10,
			AlwaysDraw =						1u << 11,
			MeshLOD =							1u << 12,
			FixedBounds =						1u << 13,
			TopFadeNode =						1u << 14,
			IgnoreFade =						1u << 15,
			NoAnimationSyncX =					1u << 16,
			NoAnimationSyncY =					1u << 17,
			NoAnimationSyncZ =					1u << 18,
			NoAnimationSyncS =					1u << 19,
			NoDismember =						1u << 20,
			NoDismemberValidity =				1u << 21,
			RenderUse =							1u << 22,
			MaterialsApplied =					1u << 23,
			HighDetail =						1u << 24,
			ForceUpdate =						1u << 25,
			PreProcessedNode =					1u << 26
		}



		/// <param name = "niAVObject">NiAVObject</param>
		static public void AddNiAVObjectFlags(System.IntPtr niAVObject, NiAVObject.Flags niAVObjectFlags)
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

		/// <param name="niAVObject">NiAVObject</param>
		/// <returns>NiTransform</returns>
		static public System.IntPtr GetLocalTransform(System.IntPtr niAVObject)
		{
			if (niAVObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niAVObject"); }

			return niAVObject + 0x48;
		}

		/// <param name = "niAVObject">NiAVObject</param>
		static public NiAVObject.Flags GetNiAVObjectFlags(System.IntPtr niAVObject)
		{
			if (niAVObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niAVObject"); }

			return (NiAVObject.Flags)NetScriptFramework.Memory.ReadUInt32(niAVObject + 0xF4);
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

		/// <param name="niAVObject">NiAVObject</param>
		/// <returns>NiBound</returns>
		static public System.IntPtr GetWorldBound(System.IntPtr niAVObject)
		{
			if (niAVObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niAVObject"); }

			return niAVObject + 0xE4;
		}

		/// <param name="niAVObject">NiAVObject</param>
		/// <returns>NiTransform</returns>
		static public System.IntPtr GetWorldTransform(System.IntPtr niAVObject)
		{
			if (niAVObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niAVObject"); }

			return niAVObject + 0x7C;
		}

		/// <param name = "niAVObject">NiAVObject</param>
		static public System.Boolean HasNiAVObjectFlags(System.IntPtr niAVObject, NiAVObject.Flags niAVObjectFlags)
		{
			if (niAVObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niAVObject"); }
			// niAVObjectFlags

			return (NiAVObject.GetNiAVObjectFlags(niAVObject) & niAVObjectFlags) == niAVObjectFlags;
		}

		static public System.Boolean IsHidden(System.IntPtr niAVObject)
		{
			if (niAVObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niAVObject"); }

			return NiAVObject.HasNiAVObjectFlags(niAVObject, NiAVObject.Flags.Hidden);
		}

		/// <param name="niAVObject">NiAVObject</param>
		static public void RemoveNiAVObjectFlags(System.IntPtr niAVObject, NiAVObject.Flags niAVObjectFlags)
		{
			if (niAVObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niAVObject"); }
			// niAVObjectFlags

			NiAVObject.SetNiAVObjectFlags(niAVObject, niAVObjectFlags & ~NiAVObject.GetNiAVObjectFlags(niAVObject));
		}

		/// <param name = "niAVObject">NiAVObject</param>
		static public void SetNiAVObjectFlags(System.IntPtr niAVObject, NiAVObject.Flags niAVObjectFlags)
		{
			if (niAVObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niAVObject"); }
			// niAVObjectFlags

			NetScriptFramework.Memory.WriteUInt32(niAVObject + 0xF4, (System.UInt32)niAVObjectFlags);
		}
	}
}
