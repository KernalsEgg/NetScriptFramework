using static NetScriptFramework._IntPtrExtensions;



namespace Eggstensions.Bethesda
{
	static public class PlayerCharacter
	{
		/// <returns>PlayerCharacter</returns>
		static public System.IntPtr Instance
		{
			get
			{
				var instance = NetScriptFramework.Memory.ReadPointer(VIDS.PlayerCharacter.Instance);
				if (instance == System.IntPtr.Zero) { throw new Eggceptions.NullException("instance"); }

				return instance;
			}
		}



		/// <param name="playerCharacter">PlayerCharacter</param>
		/// <param name="target">TESObjectREFR</param>
		static public System.Boolean HasLineOfSight(System.IntPtr playerCharacter, System.IntPtr target)
		{
			if (playerCharacter == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("playerCharacter"); }
			if (target == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("target"); }

			using (var allocation = NetScriptFramework.Memory.Allocate(0x1))
			{
				allocation.Zero();

				// PlayerCharacter, TESObjectREFR, System.Byte*
				return NetScriptFramework.Memory.InvokeCdecl(VIDS.PlayerCharacter.HasLineOfSight, playerCharacter, target, allocation.Address).ToBool();
			}
		}
	}
}
