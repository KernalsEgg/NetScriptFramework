using static NetScriptFramework._IntPtrExtensions;



namespace Eggstensions.Bethesda
{
	static public class PlayerCharacter
	{
		/// <summary>&lt;SkyrimSE.exe&gt; + 0x2F26EF8 (VID517014)</summary>
		/// <returns>PlayerCharacter</returns>
		static public System.IntPtr Instance
		{
			get
			{
				var instancePointer = NetScriptFramework.Main.GameInfo.GetAddressOf(517014);
				if (instancePointer == System.IntPtr.Zero) { throw new Eggceptions.NullException("instancePointer"); }

				var instance = NetScriptFramework.Memory.ReadPointer(instancePointer);
				if (instance == System.IntPtr.Zero) { throw new Eggceptions.NullException("instance"); }
				if (!TESForm.HasFormType(instance, FormTypes.Character)) { throw new Eggceptions.Bethesda.FormTypeException("instance"); }

				return instance;
			}
		}



		/// <summary>&lt;SkyrimSE.exe&gt; + 0x6A4A00 (VID39444)</summary>
		/// <param name="playerCharacter">PlayerCharacter</param>
		/// <param name="target">TESObjectREFR</param>
		static public System.Boolean HasLineOfSight(System.IntPtr playerCharacter, System.IntPtr target)
		{
			if (playerCharacter == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("playerCharacter"); }
			if (target == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("target"); }

			using (var allocation = NetScriptFramework.Memory.Allocate(0x1))
			{
				allocation.Zero();

				var functionAddress = NetScriptFramework.Main.GameInfo.GetAddressOf(39444);
				if (functionAddress == System.IntPtr.Zero) { throw new Eggceptions.NullException("functionAddress"); }

				// PlayerCharacter, TESObjectREFR, System.Byte*
				return NetScriptFramework.Memory.InvokeCdecl(functionAddress, playerCharacter, target, allocation.Address).ToBool();
			}
		}
	}
}
