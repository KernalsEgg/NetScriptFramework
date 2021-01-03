namespace Eggstensions.Bethesda
{
	static public class TESRaceData
	{
		public enum Flags : System.UInt32
		{
			Flying = 1u << 7
		}



		static public System.Boolean IsFlying(System.IntPtr raceData)
		{
			if (raceData == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("raceData"); }

			return (NetScriptFramework.Memory.ReadUInt32(raceData + 0x20) & (System.UInt32)TESRaceData.Flags.Flying) != 0;
		}
	}
	
	
	
	static public class TESRace
	{
		/// <param name = "race">TESRace</param>
		/// <returns>TESRace, System.IntPtr.Zero</returns>
		static public System.IntPtr GetArmorRace(System.IntPtr race)
		{
			if (race == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("race"); }

			var armorRace = NetScriptFramework.Memory.ReadPointer(race + 0x440); // General Data, Copied Data, Armor Race
			if (armorRace == System.IntPtr.Zero) { return System.IntPtr.Zero; }

			return armorRace;
		}

		static public System.IntPtr GetData(System.IntPtr race)
		{
			if (race == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("race"); }

			return race + 0xE8;
		}

		/// <summary>&lt;SkyrimSE.exe&gt; + 0x226D70 (VID17359)</summary>
		/// <param name = "race">TESRace</param>
		/// <param name = "armorAddon">TESObjectARMA</param>
		static public System.Boolean CanUseArmorAddon(System.IntPtr race, System.IntPtr armorAddon)
		{
			if (race == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("race"); }
			if (armorAddon == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("armorAddon"); }

			var armorRace = TESRace.GetArmorRace(race);

			if (armorRace != System.IntPtr.Zero)
			{
				if (!TESForm.IsRace(armorRace)) { throw new Eggceptions.Bethesda.FormTypeException("armorRace"); }

				race = armorRace;
			}

			var armorAddonRace = TESObjectARMA.GetRace(armorAddon);
			if (armorAddonRace == race) { return true; }

			// BSTArray<TESRace*, BSTArrayHeapAllocator>
			foreach (var armorAddonAdditionalRace in BSTArray.IntPtr(TESObjectARMA.GetAdditionalRaces(armorAddon)))
			{
				if (!TESForm.IsRace(armorAddonAdditionalRace)) { throw new Eggceptions.Bethesda.FormTypeException("armorAddonAdditionalRace"); }

				if (armorAddonAdditionalRace == race)
				{
					return true;
				}
			}

			return false;
		}
	}
}
