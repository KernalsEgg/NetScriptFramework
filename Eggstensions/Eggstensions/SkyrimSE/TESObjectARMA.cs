namespace Eggstensions.SkyrimSE
{
	static public class TESObjectARMA
	{
		/// <param name = "armorAddon">TESObjectARMA</param>
		/// <returns>BSTArray&lt;TESRace, BSTArrayHeapAllocator&gt;</returns>
		static public System.IntPtr GetAdditionalRaces(System.IntPtr armorAddon)
		{
			if (armorAddon == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(armorAddon)); }

			var additionalRaces = NetScriptFramework.Memory.ReadPointer(armorAddon + 0x150);
			if (additionalRaces == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(additionalRaces)); }

			return additionalRaces;
		}

		/// <param name = "armorAddon">TESObjectARMA</param>
		static public System.UInt32 GetBipedObjectSlots(System.IntPtr armorAddon)
		{
			if (armorAddon == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(armorAddon)); }

			return NetScriptFramework.Memory.ReadUInt32(armorAddon + 0x38);
		}

		/// <param name = "armorAddon">TESObjectARMA</param>
		/// <returns>TESRace</returns>
		static public System.IntPtr GetRace(System.IntPtr armorAddon)
		{
			if (armorAddon == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(armorAddon)); }

			var race = NetScriptFramework.Memory.ReadPointer(armorAddon + 0x28);
			if (race == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(race)); }

			return race;
		}

		/// <param name = "armorAddon">TESObjectARMA</param>
		static public System.Boolean HasBipedObjectSlot(System.IntPtr armorAddon, BipedObjectSlots bipedObjectSlot)
		{
			if (armorAddon == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(armorAddon)); }
			// bipedObjectSlot

			return (TESObjectARMA.GetBipedObjectSlots(armorAddon) & (1u << ((System.Int32)bipedObjectSlot - 0x1E))) != 0;
		}
	}
}
