namespace Eggstensions
{
	public interface ITESObjectREFR : ITESForm
	{
	}

	public struct TESObjectREFR : ITESObjectREFR
	{
		[System.Flags]
		public enum ChangeFlags : System.UInt32
		{
			Empty = 1U << 21
		}
	}



	namespace ExtensionMethods
	{
		unsafe static public class ITESObjectREFR
		{
			// Inheritance
			static public BSHandleRefObject* BSHandleRefObject<TTESObjectREFR>(this ref TTESObjectREFR reference)
				where TTESObjectREFR : unmanaged, Eggstensions.ITESObjectREFR
			{
				return (BSHandleRefObject*)reference.AddByteOffset(0x20);
			}

			static public IAnimationGraphManagerHolder* IAnimationGraphManagerHolder<TTESObjectREFR>(this ref TTESObjectREFR reference)
				where TTESObjectREFR : unmanaged, Eggstensions.ITESObjectREFR
			{
				return (IAnimationGraphManagerHolder*)reference.AddByteOffset(0x38);
			}



			// Field
			static public TESBoundObject* BaseObject<TTESObjectREFR>(this ref TTESObjectREFR reference)
				where TTESObjectREFR : unmanaged, Eggstensions.ITESObjectREFR
			{
				return *(TESBoundObject**)reference.AddByteOffset(0x40);
			}

			static public NiPoint3* Rotation<TTESObjectREFR>(this ref TTESObjectREFR reference)
				where TTESObjectREFR : unmanaged, Eggstensions.ITESObjectREFR
			{
				return (NiPoint3*)reference.AddByteOffset(0x4C);
			}

			static public NiPoint3* Position<TTESObjectREFR>(this ref TTESObjectREFR reference)
				where TTESObjectREFR : unmanaged, Eggstensions.ITESObjectREFR
			{
				return (NiPoint3*)reference.AddByteOffset(0x54);
			}



			// Virtual
			static public NiAVObject* GetCurrent3D<TTESObjectREFR>(this ref TTESObjectREFR reference)
				where TTESObjectREFR : unmanaged, Eggstensions.ITESObjectREFR
			{
				var getCurrent3D = (delegate* unmanaged[Cdecl]<TTESObjectREFR*, NiAVObject*>)reference.VirtualFunction(0x8D);

				return GetCurrent3D(reference.AsPointer());



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				NiAVObject* GetCurrent3D(TTESObjectREFR* reference)
				{
					return getCurrent3D(reference);
				}
			}



			// Member
			static public InventoryChanges* GetInventoryChanges<TTESObjectREFR>(this ref TTESObjectREFR reference)
				where TTESObjectREFR : unmanaged, Eggstensions.ITESObjectREFR
			{
				var getInventoryChanges = (delegate* unmanaged[Cdecl]<TTESObjectREFR*, InventoryChanges*>)Eggstensions.Offsets.TESObjectREFR.GetInventoryChanges;

				return GetInventoryChanges(reference.AsPointer());



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				InventoryChanges* GetInventoryChanges(TTESObjectREFR* reference)
				{
					return getInventoryChanges(reference);
				}
			}

			static public System.String GetReferenceName<TTESObjectREFR>(this ref TTESObjectREFR reference)
				where TTESObjectREFR : unmanaged, Eggstensions.ITESObjectREFR
			{
				var getReferenceName = (delegate* unmanaged[Cdecl]<TTESObjectREFR*, System.IntPtr>)Eggstensions.Offsets.TESObjectREFR.GetReferenceName;

				return Memory.ReadString(GetReferenceName(reference.AsPointer()));



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				System.IntPtr GetReferenceName(TTESObjectREFR* reference)
				{
					return getReferenceName(reference);
				}
			}
		}
	}
}
