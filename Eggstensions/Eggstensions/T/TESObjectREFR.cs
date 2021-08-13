﻿namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x98)]
	unsafe public struct TESObjectREFR
	{
		[System.Flags]
		public enum ChangeFlags : System.UInt32
		{
			Empty = 1U << 21
		}



		[System.Runtime.InteropServices.FieldOffset(0x0)] public TESForm TESForm;
		[System.Runtime.InteropServices.FieldOffset(0x40)] public TESBoundObject* BaseObject;



		// Virtual
		static public NiAVObject* GetCurrent3D(TESObjectREFR* reference)
		{
			var getCurrent3D = Memory.ReadVirtualFunction<Eggstensions.Delegates.Types.TESObjectREFR.GetCurrent3D>(*(System.IntPtr*)reference, 0x8D);

			return getCurrent3D(reference);
		}



		// Member
		static public InventoryChanges* GetInventoryChanges(TESObjectREFR* reference)
		{
			return Eggstensions.Delegates.Instances.TESObjectREFR.GetInventoryChanges(reference);
		}
	}
}
