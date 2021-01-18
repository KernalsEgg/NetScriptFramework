namespace Eggstensions.SkyrimSE
{
	static public class TESNPC
	{
		public enum Flags : System.UInt32
		{
			None =		0u,
			Female =	1u << 0
		}



		/// <param name = "npc">TESNPC</param>
		static public TESNPC.Flags GetActorBaseFlags(System.IntPtr npc)
		{
			if (npc == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(npc)); }
			
			return (TESNPC.Flags)NetScriptFramework.Memory.ReadUInt32(npc + 0x38);
		}

		/// <param name = "npc">TESNPC</param>
		/// <returns>TESRace</returns>
		static public System.IntPtr GetRace(System.IntPtr npc)
		{
			if (npc == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(npc)); }

			var race = NetScriptFramework.Memory.ReadPointer(npc + 0x158);
			if (race == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(race)); }

			return race;
		}

		/// <summary>SkyrimSE.exe + 0x363000 (VID 24221)</summary>
		/// <param name = "npc">TESNPC</param>
		/// <returns>TESObjectARMO</returns>
		static public System.IntPtr GetSkin(System.IntPtr npc)
		{
			if (npc == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(npc)); }

			var npcSkin = NetScriptFramework.Memory.ReadPointer(npc + 0x108);
			if (npcSkin != System.IntPtr.Zero) { return npcSkin; }

			var raceSkin = NetScriptFramework.Memory.ReadPointer(TESNPC.GetRace(npc) + 0x58);
			if (raceSkin == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(raceSkin)); }

			return raceSkin;
		}

		/// <param name = "npc">TESNPC</param>
		static public System.Boolean HasActorBaseFlags(System.IntPtr npc, TESNPC.Flags actorBaseFlags)
		{
			if (npc == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(npc)); }
			// actorBaseFlags

			return (TESNPC.GetActorBaseFlags(npc) & actorBaseFlags) == actorBaseFlags;
		}
	}
}
