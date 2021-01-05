namespace Eggstensions.Bethesda
{
	public enum ActorBaseFlags : System.UInt32
	{
		None =		0u,
		Female =	1u << 0
	}



	static public class TESNPC
	{
		/// <param name = "npc">TESNPC</param>
		static public ActorBaseFlags GetActorBaseFlags(System.IntPtr npc)
		{
			if (npc == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("npc"); }
			
			return (ActorBaseFlags)NetScriptFramework.Memory.ReadUInt32(npc + 0x38);
		}

		/// <param name = "npc">TESNPC</param>
		/// <returns>TESRace</returns>
		static public System.IntPtr GetRace(System.IntPtr npc)
		{
			if (npc == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("npc"); }

			var race = NetScriptFramework.Memory.ReadPointer(npc + 0x158);
			if (race == System.IntPtr.Zero) { throw new Eggceptions.NullException("race"); }

			return race;
		}

		/// <summary>&lt;SkyrimSE.exe&gt; + 0x363000 (VID24221)</summary>
		/// <param name = "npc">TESNPC</param>
		/// <returns>TESObjectARMO</returns>
		static public System.IntPtr GetSkin(System.IntPtr npc)
		{
			if (npc == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("npc"); }

			var npcSkin = NetScriptFramework.Memory.ReadPointer(npc + 0x108);
			if (npcSkin != System.IntPtr.Zero) { return npcSkin; }

			var raceSkin = NetScriptFramework.Memory.ReadPointer(TESNPC.GetRace(npc) + 0x58);
			if (raceSkin == System.IntPtr.Zero) { throw new Eggceptions.NullException("raceSkin"); }

			return raceSkin;
		}

		/// <param name = "npc">TESNPC</param>
		static public System.Boolean HasActorBaseFlags(System.IntPtr npc, ActorBaseFlags actorBaseFlags)
		{
			if (npc == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("npc"); }
			// actorBaseFlags

			return (TESNPC.GetActorBaseFlags(npc) & actorBaseFlags) == actorBaseFlags;
		}
	}
}
