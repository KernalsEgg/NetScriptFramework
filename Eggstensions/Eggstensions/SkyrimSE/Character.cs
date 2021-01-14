using static NetScriptFramework._IntPtrExtensions;



namespace Eggstensions.SkyrimSE
{
	static public class Character
	{
		/// <param name="character">Character</param>
		/// <param name="target">Character</param>
		static public System.Boolean HasLineOfSight(System.IntPtr character, System.IntPtr target)
		{
			if (character == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(character)); }
			if (target == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(target)); }

			// GetLineOfSight == 3u, AutoAimActor == 5u
			return NetScriptFramework.Memory.InvokeCdecl(VIDS.Character.HasLineOfSight, character, target, 3u).ToBool();
		}
	}
}
