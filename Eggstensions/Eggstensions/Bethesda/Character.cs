using static NetScriptFramework._IntPtrExtensions;



namespace Eggstensions.Bethesda
{
	static public class Character
	{
		/// <summary>&lt;SkyrimSE.exe&gt; + 0x5FC880 (VID36745)</summary>
		/// <param name="character">Character</param>
		/// <param name="target">Character</param>
		static public System.Boolean HasLineOfSight(System.IntPtr character, System.IntPtr target)
		{
			if (character == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("character"); }
			if (target == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("target"); }
			if (!TESForm.HasFormType(character, FormTypes.Character)) { throw new Eggceptions.Bethesda.ArgumentFormTypeException("character"); }
			if (!TESForm.HasFormType(target, FormTypes.Character)) { throw new Eggceptions.Bethesda.ArgumentFormTypeException("target"); }

			var functionAddress = NetScriptFramework.Main.GameInfo.GetAddressOf(36745);
			if (functionAddress == System.IntPtr.Zero) { throw new Eggceptions.NullException("functionAddress"); }

			// Character, Character, 3u
			return NetScriptFramework.Memory.InvokeCdecl(functionAddress, character, target, 3u).ToBool();
		}
	}
}
