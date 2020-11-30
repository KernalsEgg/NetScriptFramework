using static NetScriptFramework._IntPtrExtensions;



namespace Eggstensions.Bethesda
{
	static public class Main
	{
		/// <summary>&lt;SkyrimSE.exe&gt; + 0x2F26BF8 (VID516943)</summary>
		/// <returns>Main</returns>
		static public System.IntPtr Instance
		{
			get
			{
				var instancePointer = NetScriptFramework.Main.GameInfo.GetAddressOf(516943);
				if (instancePointer == System.IntPtr.Zero) { throw new Eggceptions.NullException("instancePointer"); }

				var instance = NetScriptFramework.Memory.ReadPointer(instancePointer);
				if (instance == System.IntPtr.Zero) { throw new Eggceptions.NullException("instance"); }

				return instance;
			}
		}

		/// <summary>&lt;SkyrimSE.exe&gt; + 0x9B8750 (VID56476)</summary>
		static public System.Boolean IsInMenuMode
		{
			get
			{
				var functionAddress = NetScriptFramework.Main.GameInfo.GetAddressOf(56476);
				if (functionAddress == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("functionAddress"); }

				return NetScriptFramework.Memory.InvokeCdecl(functionAddress).ToBool();
			}
		}

		/// <summary>NetScriptFramework.SkyrimSE.Main.IsGamePaused</summary>
		static public System.Boolean IsTimePassing
		{
			get
			{
				return
					((NetScriptFramework.Memory.ReadUInt8(Main.Instance + (System.Int32)NetScriptFramework.Main.GameInfo.CachedValues[233]) & 1) != 0) // ToggleFlyCam 1
					||
					(NetScriptFramework.Memory.ReadUInt8(NetScriptFramework.Main.GameInfo.GetAddressOf(516933) + 2) != 0) // IsInMenuModeBase
					||
					(UI.GetPauseGameCount(UI.Instance) > 0);
			}
		}
	}
}
