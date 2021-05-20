namespace Eggstensions
{
	namespace Offsets
	{
		static public class ActiveEffect
		{
			/// <summary> SkyrimSE.exe + 0x2F25CE8 </summary>
			static public System.IntPtr ConditionUpdateFrequency { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf(516661);
		}
		
		static public class Actor
		{
			/// <summary>SkyrimSE.exe + 0x62F560</summary>
			static public System.IntPtr AddSpell { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf(37771);
		}

		static public class BGSPerkEntry
		{
			/// <summary>SkyrimSE.exe + 0x32ECE0</summary>
			static public System.IntPtr HandlePerkEntry { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf(23073);
		}

		static public class BSTEventSource
		{
			/// <summary>SkyrimSE.exe + 0x93D490</summary>
			static public System.IntPtr AddEventSink { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf(53619);
		}

		static public class InventoryEntryData
		{
			/// <summary>SkyrimSE.exe + 0x1D6A40</summary>
			static public System.IntPtr IsWorn { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf(15763);
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

		static public class TESObjectWEAP
		{
			/// <summary>SkyrimSE.exe + 0x2EFF868</summary>
			static public System.IntPtr Unarmed { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf(514923);
		}
	}
}
