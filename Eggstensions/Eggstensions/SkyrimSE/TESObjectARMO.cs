namespace Eggstensions.SkyrimSE
{
	static public class TESObjectARMO
	{
		/// <param name = "armor">TESObjectARMO</param>
		/// <param name = "race">TESRace</param>
		/// <returns>TESObjectARMA, System.IntPtr.Zero</returns>
		static public System.IntPtr GetArmorAddon(System.IntPtr armor, BipedObjectSlots bipedObjectSlot, System.IntPtr race)
		{
			if (armor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(armor)); }
			// bipedObjectSlot
			if (race == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(race)); }

			var armorAddons = TESObjectARMO.GetArmorAddons(armor, race);

			foreach (var armorAddon in armorAddons)
			{
				if (TESObjectARMA.HasBipedObjectSlot(armorAddon, bipedObjectSlot))
				{
					return armorAddon;
				}
			}

			return System.IntPtr.Zero;
		}

		/// <param name = "armor">TESObjectARMO</param>
		/// <returns>BSTArray&lt;TESObjectARMA, BSTArrayHeapAllocator&gt;</returns>
		static public System.IntPtr GetArmorAddons(System.IntPtr armor)
		{
			if (armor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(armor)); }

			return armor + 0x208;
		}

		/// <summary>SkyrimSE.exe + 0x228AD0 (VID17392)</summary>
		/// <param name = "armor">TESObjectARMO</param>
		/// <param name = "race">TESRace</param>
		/// <returns>System.Collections.Generic.List&lt;TESObjectARMA&gt;</returns>
		static public System.Collections.Generic.List<System.IntPtr> GetArmorAddons(System.IntPtr armor, System.IntPtr race)
		{
			if (armor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(armor)); }
			if (race == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(race)); }

			var armorAddons = new System.Collections.Generic.List<System.IntPtr>();

			// BSTArray<TESObjectARMA*, BSTArrayHeapAllocator>
			foreach (var armorAddon in new BSTArray(TESObjectARMO.GetArmorAddons(armor)))
			{
				if (!TESForm.IsArmorAddon(armorAddon)) { throw new Eggceptions.SkyrimSE.FormTypeException(nameof(armorAddon)); }

				if (TESRace.CanUseArmorAddon(race, armorAddon))
				{
					armorAddons.Add(armorAddon);
				}
			}

			return armorAddons;
		}

		/// <param name = "armor">TESObjectARMO</param>
		static public System.UInt32 GetBipedObjectSlots(System.IntPtr armor)
		{
			if (armor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(armor)); }

			return NetScriptFramework.Memory.ReadUInt32(armor + 0x1B8);
		}

		/// <param name = "armor">TESObjectARMO</param>
		static public System.Boolean HasBipedObjectSlot(System.IntPtr armor, BipedObjectSlots bipedObjectSlot)
		{
			if (armor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(armor)); }
			// bipedObjectSlot

			return (TESObjectARMO.GetBipedObjectSlots(armor) & (1u << ((System.Int32)bipedObjectSlot - 0x1E))) != 0;
		}
	}
}
