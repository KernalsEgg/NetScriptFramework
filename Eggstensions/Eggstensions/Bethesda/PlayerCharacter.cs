using static NetScriptFramework._IntPtrExtensions;



namespace Eggstensions.Bethesda
{
	static public class PlayerCharacter
	{
		static public System.Single ActivateDistance
		{
			get
			{
				return NetScriptFramework.Memory.ReadFloat(VIDS.PlayerCharacter.ActivateDistance);
			}
		}

		static public System.Single CommandDistance
		{
			get
			{
				return NetScriptFramework.Memory.ReadFloat(VIDS.PlayerCharacter.CommandDistance);
			}
		}
		
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
		static public (System.Boolean fieldOfView, System.Boolean lineOfSight) HasLineOfSight(System.IntPtr playerCharacter, System.IntPtr target)
		{
			if (playerCharacter == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("playerCharacter"); }
			if (target == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("target"); }

			using (var allocation = NetScriptFramework.Memory.Allocate(0x8))
			{
				allocation.Zero();

				// PlayerCharacter, TESObjectREFR, System.Byte*
				var lineOfSight = NetScriptFramework.Memory.InvokeCdecl(VIDS.PlayerCharacter.HasLineOfSight, playerCharacter, target, allocation.Address).ToBool();
				var fieldOfView = NetScriptFramework.Memory.ReadUInt8(allocation.Address) != 0;

				return (fieldOfView, lineOfSight);
			}
		}

		/// <param name="playerCharacter">PlayerCharacter</param>
		static public System.Boolean IsCommandingActor(System.IntPtr playerCharacter)
		{
			if (playerCharacter == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("playerCharacter"); }

			return NetScriptFramework.Memory.InvokeCdecl(VIDS.PlayerCharacter.IsCommandingActor, playerCharacter).ToBool();
		}
	}
}
