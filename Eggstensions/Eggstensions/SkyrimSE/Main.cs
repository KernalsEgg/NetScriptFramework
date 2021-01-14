namespace Eggstensions.SkyrimSE
{
	static public class Main
	{
		/// <returns>Main</returns>
		static public System.IntPtr Instance
		{
			get
			{
				var instance = NetScriptFramework.Memory.ReadPointer(VIDS.Main.Instance);
				if (instance == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(instance)); }

				return instance;
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
					(NetScriptFramework.Memory.ReadUInt8(VIDS.UI.IsInMenuModeBase + 0x2) != 0)
					||
					(UI.GetPauseGameCount(UI.Instance) > 0);
			}
		}
	}
}
