namespace Eggstensions.Bethesda
{
	static public class Setting
	{
		static public System.Boolean GetBoolean(System.IntPtr setting)
		{
			if (setting == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("setting"); }

			return NetScriptFramework.Memory.ReadUInt8(setting + 0x8) != 0;
		}

		static public System.Int32 GetInt32(System.IntPtr setting)
		{
			if (setting == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("setting"); }

			return NetScriptFramework.Memory.ReadInt32(setting + 0x8);
		}

		static public System.String GetName(System.IntPtr setting)
		{
			if (setting == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("setting"); }

			return NetScriptFramework.Memory.ReadString(setting + 0x10, false);
		}

		static public System.Single GetSingle(System.IntPtr setting)
		{
			if (setting == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("setting"); }

			return NetScriptFramework.Memory.ReadFloat(setting + 0x8);
		}

		static public System.String GetString(System.IntPtr setting)
		{
			if (setting == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("setting"); }

			return NetScriptFramework.Memory.ReadString(setting + 0x8, false);
		}

		static public System.UInt32 GetUInt32(System.IntPtr setting)
		{
			if (setting == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("setting"); }

			return NetScriptFramework.Memory.ReadUInt32(setting + 0x8);
		}
	}
}
