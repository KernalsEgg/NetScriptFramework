namespace HorsingAround
{
	static public class VIDS
	{
		static public class ActivateHandler
		{
			static ActivateHandler()
			{
				_processButton = NetScriptFramework.Main.GameInfo.GetAddressOf(41346);
			}



			readonly static private System.IntPtr _processButton;



			/// <summary>SkyrimSE.exe + 0x708BF0 (VID41346)<br/>VTable + 0x20</summary>
			static public System.IntPtr ProcessButton { get { return _processButton; } }
		}

		static public class CrosshairPickData
		{
			static CrosshairPickData()
			{
				_pick = NetScriptFramework.Main.GameInfo.GetAddressOf(25591);
			}



			readonly static private System.IntPtr _pick;



			/// <summary>SkyrimSE.exe + 0x3AA4B0 (VID25591)</summary>
			static public System.IntPtr Pick { get { return _pick; } }
		}

		static public class HorseCameraState
		{
			static HorseCameraState()
			{
				_handleLookInput = NetScriptFramework.Main.GameInfo.GetAddressOf(49839);
			}



			readonly static private System.IntPtr _handleLookInput;



			/// <summary>SkyrimSE.exe + 0x849930 (VID49839)<br/>VTable + 0x78</summary>
			static public System.IntPtr HandleLookInput { get { return _handleLookInput; } }
		}

		static public class HUDMenu
		{
			static HUDMenu()
			{
				_processMessage = NetScriptFramework.Main.GameInfo.GetAddressOf(50718);
			}



			readonly static private System.IntPtr _processMessage;



			/// <summary>SkyrimSE.exe + 0x87D580 (VID50718)<br/>VTable + 0x20</summary>
			static public System.IntPtr ProcessMessage { get { return _processMessage; } }
		}

		static public class PlayerCamera
		{
			static PlayerCamera()
			{
				_mount =				NetScriptFramework.Main.GameInfo.GetAddressOf(49888);
				_updateWeaponDrawn =	NetScriptFramework.Main.GameInfo.GetAddressOf(49908);
			}



			readonly static private System.IntPtr _mount;

			readonly static private System.IntPtr _updateWeaponDrawn;



			/// <summary>SkyrimSE.exe + 0x84BE40 (VID49888)</summary>
			static public System.IntPtr Mount				{ get { return _mount; } }

			/// <summary>SkyrimSE.exe + 0x84D630 (VID49908)</summary>
			static public System.IntPtr UpdateWeaponDrawn	{ get { return _updateWeaponDrawn; } }
		}

		static public class PlayerCharacter
		{
			static PlayerCharacter()
			{
				_hudData =					NetScriptFramework.Main.GameInfo.GetAddressOf(39535);
				_pickCrosshairReference =	NetScriptFramework.Main.GameInfo.GetAddressOf(39534);
				_placeWaitCommandMarker =	NetScriptFramework.Main.GameInfo.GetAddressOf(39550);
				_processActivate =			NetScriptFramework.Main.GameInfo.GetAddressOf(39471);
			}



			readonly static private System.IntPtr _hudData;

			readonly static private System.IntPtr _pickCrosshairReference;

			readonly static private System.IntPtr _placeWaitCommandMarker;

			readonly static private System.IntPtr _processActivate;



			/// <summary>SkyrimSE.exe + 0x6B0570 (VID39535)</summary>
			static public System.IntPtr HUDData					{ get { return _hudData; } }

			/// <summary>SkyrimSE.exe + 0x6B01E0 (VID39534)</summary>
			static public System.IntPtr PickCrosshairReference	{ get { return _pickCrosshairReference; } }

			/// <summary>SkyrimSE.exe + 0x6B11C0 (VID39550)</summary>
			static public System.IntPtr PlaceWaitCommandMarker	{ get { return _placeWaitCommandMarker; } }

			/// <summary>SkyrimSE.exe + 0x6A9F90 (VID39471)</summary>
			static public System.IntPtr ProcessActivate			{ get { return _processActivate; } }
		}

		static public class RightHandWeaponDrawHandler
		{
			static RightHandWeaponDrawHandler()
			{
				_executeHandler = NetScriptFramework.Main.GameInfo.GetAddressOf(41743);
			}



			readonly static private System.IntPtr _executeHandler;



			/// <summary>SkyrimSE.exe + 0x720FB0 (VID41743)<br/>VTable + 0x8</summary>
			static public System.IntPtr ExecuteHandler { get { return _executeHandler; } }
		}

		static public class SneakHandler
		{
			static SneakHandler()
			{
				_processButton = NetScriptFramework.Main.GameInfo.GetAddressOf(41357);
			}



			readonly static private System.IntPtr _processButton;



			/// <summary>SkyrimSE.exe + 0x7094C0 (VID41357)<br/>VTable + 0x20</summary>
			static public System.IntPtr ProcessButton { get { return _processButton; } }
		}

		static public class TESFurniture
		{
			static TESFurniture()
			{
				_activate = NetScriptFramework.Main.GameInfo.GetAddressOf(17034);
			}



			readonly static private System.IntPtr _activate;



			/// <summary>SkyrimSE.exe + 0x21A4B0 (VID17034)<br/>VTable + 0x1B8</summary>
			static public System.IntPtr Activate { get { return _activate; } }
		}
	}
}
