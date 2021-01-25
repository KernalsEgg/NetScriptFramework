namespace HorsingAround
{
	static public class VIDS
	{
		static public class ActivateHandler
		{
			static ActivateHandler()
			{
				ProcessButton = NetScriptFramework.Main.GameInfo.GetAddressOf(41346);
			}



			/// <summary>SkyrimSE.exe + 0x708BF0 (VID 41346)<br/>VTable + 0x20</summary>
			static public System.IntPtr ProcessButton { get; }
		}

		static public class Actor
		{
			static Actor()
			{
				SetRotationX = NetScriptFramework.Main.GameInfo.GetAddressOf(36602);
			}



			/// <summary>SkyrimSE.exe + 0x5EDD50 (VID 36602)</summary>
			static public System.IntPtr SetRotationX { get; }
		}

		static public class CrosshairPickData
		{
			static CrosshairPickData()
			{
				Pick = NetScriptFramework.Main.GameInfo.GetAddressOf(25591);
			}



			/// <summary>SkyrimSE.exe + 0x3AA4B0 (VID 25591)</summary>
			static public System.IntPtr Pick { get; }
		}

		static public class HorseCameraState
		{
			static HorseCameraState()
			{
				HandleLookInput = NetScriptFramework.Main.GameInfo.GetAddressOf(49839);
			}



			/// <summary>SkyrimSE.exe + 0x849930 (VID 49839)<br/>VTable + 0x78</summary>
			static public System.IntPtr HandleLookInput { get; }
		}

		static public class HUDMenu
		{
			static HUDMenu()
			{
				ProcessMessage = NetScriptFramework.Main.GameInfo.GetAddressOf(50718);
			}



			/// <summary>SkyrimSE.exe + 0x87D580 (VID 50718)<br/>VTable + 0x20</summary>
			static public System.IntPtr ProcessMessage { get; }
		}

		static public class PlayerCamera
		{
			static PlayerCamera()
			{
				Mount =				NetScriptFramework.Main.GameInfo.GetAddressOf(49888);
				UpdateWeaponDrawn =	NetScriptFramework.Main.GameInfo.GetAddressOf(49908);
			}



			/// <summary>SkyrimSE.exe + 0x84BE40 (VID 49888)</summary>
			static public System.IntPtr Mount { get; }

			/// <summary>SkyrimSE.exe + 0x84D630 (VID 49908)</summary>
			static public System.IntPtr UpdateWeaponDrawn { get; }
		}

		static public class PlayerCharacter
		{
			static PlayerCharacter()
			{
				PickCrosshairReference =	NetScriptFramework.Main.GameInfo.GetAddressOf(39534);
				PlaceWaitCommandMarker =	NetScriptFramework.Main.GameInfo.GetAddressOf(39550);
				ProcessActivate =			NetScriptFramework.Main.GameInfo.GetAddressOf(39471);
				SetHUDData =				NetScriptFramework.Main.GameInfo.GetAddressOf(39535);
			}



			/// <summary>SkyrimSE.exe + 0x6B01E0 (VID 39534)</summary>
			static public System.IntPtr PickCrosshairReference { get; }

			/// <summary>SkyrimSE.exe + 0x6B11C0 (VID 39550)</summary>
			static public System.IntPtr PlaceWaitCommandMarker { get; }

			/// <summary>SkyrimSE.exe + 0x6A9F90 (VID 39471)</summary>
			static public System.IntPtr ProcessActivate { get; }

			/// <summary>SkyrimSE.exe + 0x6B0570 (VID 39535)</summary>
			static public System.IntPtr SetHUDData { get; }
		}

		static public class RightHandWeaponDrawHandler
		{
			static RightHandWeaponDrawHandler()
			{
				ExecuteHandler = NetScriptFramework.Main.GameInfo.GetAddressOf(41743);
			}



			/// <summary>SkyrimSE.exe + 0x720FB0 (VID 41743)<br/>VTable + 0x8</summary>
			static public System.IntPtr ExecuteHandler { get; }
		}

		static public class SneakHandler
		{
			static SneakHandler()
			{
				ProcessButton = NetScriptFramework.Main.GameInfo.GetAddressOf(41357);
			}



			/// <summary>SkyrimSE.exe + 0x7094C0 (VID 41357)<br/>VTable + 0x20</summary>
			static public System.IntPtr ProcessButton { get; }
		}

		static public class TESFurniture
		{
			static TESFurniture()
			{
				Activate = NetScriptFramework.Main.GameInfo.GetAddressOf(17034);
			}



			/// <summary>SkyrimSE.exe + 0x21A4B0 (VID 17034)<br/>VTable + 0x1B8</summary>
			static public System.IntPtr Activate { get; }
		}
	}
}
