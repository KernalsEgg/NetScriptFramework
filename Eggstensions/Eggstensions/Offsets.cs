namespace Eggstensions
{
	namespace Offsets
	{
		static public class ActiveEffect
		{
			/// <summary>SkyrimSE.exe + 0x2F25CE8</summary>
			static public System.IntPtr ConditionUpdateFrequency { get; }	= NetScriptFramework.Main.GameInfo.GetAddressOf(516661);

			/// <summary>SkyrimSE.exe + 0x53E380</summary>
			static public System.IntPtr Dispel { get; }						= NetScriptFramework.Main.GameInfo.GetAddressOf(33286);
		}
		
		static public class Actor
		{
			/// <summary>SkyrimSE.exe + 0x62F560</summary>
			static public System.IntPtr AddSpell { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf(37771);
		}

		static public class BGSEntryPointPerkEntry
		{
			/// <summary>SkyrimSE.exe + 0x32ECE0</summary>
			static public System.IntPtr HandleEntryPoints { get; }		= NetScriptFramework.Main.GameInfo.GetAddressOf(23073);

			/// <summary>SkyrimSE.exe + 0x1598610</summary>
			static public System.IntPtr VirtualFunctionTable { get; }	= NetScriptFramework.Main.GameInfo.GetAddressOf(241053);
		}

		static public class BSTArray
		{
			static public class IntPtr
			{
				/// <summary>SkyrimSE.exe + 0x19D170</summary>
				static public System.IntPtr Push { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf(14698);
			}



			/// <summary>SkyrimSE.exe + 0xC04EC0</summary>
			static public System.IntPtr Deallocate { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf(66915);
		}

		static public class BSTEventSink
		{
			/// <summary>SkyrimSE.exe + 0x19C820</summary>
			static public System.IntPtr AddHarvestEventSink { get; }	= NetScriptFramework.Main.GameInfo.GetAddressOf(14685);

			/// <summary>SkyrimSE.exe + 0x19C850</summary>
			static public System.IntPtr RemoveHarvestEventSink { get; }	= NetScriptFramework.Main.GameInfo.GetAddressOf(14686);
		}

		static public class BSTEventSource
		{
			/// <summary>SkyrimSE.exe + 0x19D600</summary>
			static public System.IntPtr AddEventSink { get; }		= NetScriptFramework.Main.GameInfo.GetAddressOf(14705);

			/// <summary>SkyrimSE.exe + 0x19D7C0</summary>
			static public System.IntPtr RemoveEventSink { get; }	= NetScriptFramework.Main.GameInfo.GetAddressOf(14707);

			/// <summary>SkyrimSE.exe + 0x19D270</summary>
			static public System.IntPtr SendEvent { get; }			= NetScriptFramework.Main.GameInfo.GetAddressOf(14703);
		}

		static public class InitTESThread
		{
			/// <summary>SkyrimSE.exe + 0x164D900</summary>
			static public System.IntPtr VirtualFunctionTable { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf(259694);
		}

		static public class InventoryChanges
		{
			/// <summary>SkyrimSE.exe + 0x1EBD50</summary>
			static public System.IntPtr ResetWeight { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf(15897);
		}

		static public class InventoryEntryData
		{
			/// <summary>SkyrimSE.exe + 0x1D6A40</summary>
			static public System.IntPtr IsWorn { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf(15763);
		}

		static public class PlayerCharacter
		{
			/// <summary>SkyrimSE.exe + 0x2F26EF8</summary>
			static public System.IntPtr Instance { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf(517014);
		}

		static public class ScriptEventSourceHolder
		{
			/// <summary>SkyrimSE.exe + 0x186790</summary>
			static public System.IntPtr GetInstance { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf(14108);
		}

		static public class TESDataHandler
		{
			/// <summary>SkyrimSE.exe + 0x194230</summary>
			static public System.IntPtr GetForm { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf(14461);
		}

		static public class TESObjectREFR
		{
			/// <summary>SkyrimSE.exe + 0x1D8E40</summary>
			static public System.IntPtr GetInventoryChanges { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf(15802);
		}

		static public class TESObjectWEAP
		{
			/// <summary>SkyrimSE.exe + 0x2EFF868</summary>
			static public System.IntPtr Unarmed { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf(514923);
		}

		static public class UI
		{
			/// <summary>SkyrimSE.exe + 0x8DA3D0</summary>
			static public System.IntPtr Notification { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf(52050);
		}
	}
}
