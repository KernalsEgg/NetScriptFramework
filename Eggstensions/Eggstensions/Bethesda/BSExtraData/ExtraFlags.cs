namespace Eggstensions.Bethesda
{
	static public class ExtraFlags
	{
		public enum Flags
		{
			None =					0,
			BlockActivate =			1 << 0,
			BlockPlayerActivate =	1 << 1,
			BlockLoadEvents =		1 << 2,
			BlockActivateText =		1 << 3,
			PlayerHasTaken =		1 << 4
		}



		static public ExtraFlags.Flags GetFlags(System.IntPtr extraFlags)
		{
			if (extraFlags == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("extraFlags"); }

			return (ExtraFlags.Flags)NetScriptFramework.Memory.ReadUInt32(extraFlags + 0x10);
		}
		
		static public System.Boolean IsActivationBlocked(System.IntPtr extraFlags)
		{
			if (extraFlags == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("extraFlags"); }

			return (ExtraFlags.GetFlags(extraFlags) & ExtraFlags.Flags.BlockActivate) != 0;
		}
	}
}
