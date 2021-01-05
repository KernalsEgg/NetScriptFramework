namespace Eggstensions.Bethesda
{
	static public class ExtraFlags
	{
		public enum Flags : System.UInt32
		{
			None =					0u,
			BlockActivate =			1u << 0,
			BlockPlayerActivate =	1u << 1,
			BlockLoadEvents =		1u << 2,
			BlockActivateText =		1u << 3,
			PlayerHasTaken =		1u << 4
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
