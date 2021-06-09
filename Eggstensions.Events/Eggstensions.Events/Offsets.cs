namespace Eggstensions
{
	namespace Offsets
	{
		static public class Events
		{
			/// <summary>SkyrimSE.exe + 0x99CB0</summary>
			static public System.IntPtr AddActorValueEventSinks { get; }	= NetScriptFramework.Main.GameInfo.GetAddressOf(5998);

			/// <summary>SkyrimSE.exe + 0x5C9D70</summary>
			static public System.IntPtr AddMiscStatEventSinks { get; }		= NetScriptFramework.Main.GameInfo.GetAddressOf(36034);

			/// <summary>SkyrimSE.exe + 0x92C260</summary>
			static public System.IntPtr AddScriptEventSinks { get; }		= NetScriptFramework.Main.GameInfo.GetAddressOf(53216);

			/// <summary>SkyrimSE.exe + 0x5C9FE0</summary>
			static public System.IntPtr RemoveMiscStatEventSinks { get; }	= NetScriptFramework.Main.GameInfo.GetAddressOf(36035);
		}
	}
}
