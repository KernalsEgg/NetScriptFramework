namespace Eggstensions.SkyrimSE
{
	static public class TESRaceData
	{
		public enum Flags : System.UInt32
		{
			Flying = 1u << 7
		}



		static public TESRaceData.Flags GetFlags(System.IntPtr raceData)
		{
			if (raceData == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(raceData)); }

			return (TESRaceData.Flags)NetScriptFramework.Memory.ReadUInt32(raceData + 0x20);
		}

		static public System.Boolean HasFlags(System.IntPtr raceData, TESRaceData.Flags flags)
		{
			if (raceData == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(raceData)); }

			return (TESRaceData.GetFlags(raceData) & flags) == flags;
		}

		static public System.Boolean IsFlying(System.IntPtr raceData)
		{
			if (raceData == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(raceData)); }

			return TESRaceData.HasFlags(raceData, TESRaceData.Flags.Flying);
		}
	}
	
	
	
	static public class TESRace
	{
		/// <param name = "race">TESRace</param>
		/// <returns>TESRace, System.IntPtr.Zero</returns>
		static public System.IntPtr GetArmorRace(System.IntPtr race)
		{
			if (race == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(race)); }

			var armorRace = NetScriptFramework.Memory.ReadPointer(race + 0x440); // General Data, Copied Data, Armor Race
			if (armorRace == System.IntPtr.Zero) { return System.IntPtr.Zero; }

			return armorRace;
		}

		static public System.IntPtr GetData(System.IntPtr race)
		{
			if (race == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(race)); }

			return race + 0xE8;
		}

		/// <summary>SkyrimSE.exe + 0x226D70 (VID 17359)</summary>
		/// <param name = "race">TESRace</param>
		/// <param name = "armorAddon">TESObjectARMA</param>
		static public System.Boolean CanUseArmorAddon(System.IntPtr race, System.IntPtr armorAddon)
		{
			if (race == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(race)); }
			if (armorAddon == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(armorAddon)); }

			var armorRace = TESRace.GetArmorRace(race);

			if (armorRace != System.IntPtr.Zero)
			{
				if (!TESForm.IsRace(armorRace)) { throw new Eggceptions.SkyrimSE.FormTypeException(nameof(armorRace)); }

				race = armorRace;
			}

			var armorAddonRace = TESObjectARMA.GetRace(armorAddon);
			if (armorAddonRace == race) { return true; }

			// BSTArray<TESRace*, BSTArrayHeapAllocator>
			foreach (var armorAddonAdditionalRace in new BSTArray(TESObjectARMA.GetAdditionalRaces(armorAddon)))
			{
				if (!TESForm.IsRace(armorAddonAdditionalRace)) { throw new Eggceptions.SkyrimSE.FormTypeException(nameof(armorAddonAdditionalRace)); }

				if (armorAddonAdditionalRace == race)
				{
					return true;
				}
			}

			return false;
		}
	}
}
