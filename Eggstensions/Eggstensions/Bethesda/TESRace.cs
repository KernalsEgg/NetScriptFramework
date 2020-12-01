namespace Eggstensions.Bethesda
{
	static public class TESRace
	{
		/// <param name = "race">TESRace</param>
		/// <returns>TESRace, System.IntPtr.Zero</returns>
		static public System.IntPtr GetArmorRace(System.IntPtr race)
		{
			if (race == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("race"); }

			var armorRace = NetScriptFramework.Memory.ReadPointer(race + 0x440); // General Data, Copied Data, Armor Race
			if (armorRace == System.IntPtr.Zero) { return System.IntPtr.Zero; }
			if (!TESForm.HasFormType(armorRace, FormTypes.TESRace)) { throw new Eggceptions.Bethesda.FormTypeException("armorRace"); }

			return armorRace;
		}

		/// <summary>&lt;SkyrimSE.exe&gt; + 0x226D70 (VID17359)</summary>
		/// <param name = "race">TESRace</param>
		/// <param name = "armorAddon">TESObjectARMA</param>
		static public System.Boolean CanUseArmorAddon(System.IntPtr race, System.IntPtr armorAddon)
		{
			if (race == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("race"); }
			if (armorAddon == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("armorAddon"); }

			var armorRace = TESRace.GetArmorRace(race);
			race = armorRace == System.IntPtr.Zero ? race : armorRace;

			var armorAddonRace = TESObjectARMA.GetRace(armorAddon);

			if (armorAddonRace == race)
			{
				return true;
			}

			var armorAddonAdditionalRaces = TESObjectARMA.GetAdditionalRaces(armorAddon); // BSTArray<TESRace*, BSTArrayHeapAllocator>

			foreach (var armorAddonAdditionalRace in new BSTArray.IntPtr(armorAddonAdditionalRaces))
			{
				if (!TESForm.HasFormType(armorAddonAdditionalRace, FormTypes.TESRace)) { throw new Eggceptions.Bethesda.FormTypeException("armorAddonAdditionalRace"); }

				if (armorAddonAdditionalRace == race)
				{
					return true;
				}
			}

			return false;
		}
	}
}
