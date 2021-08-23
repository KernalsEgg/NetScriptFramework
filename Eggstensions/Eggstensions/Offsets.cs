namespace Eggstensions
{
	namespace Offsets
	{
		static public class AccumulatingValueModifierEffect
		{
			/// <summary>SkyrimSE.exe + 0x1636880</summary>
			static public System.IntPtr VirtualFunctionTable { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf(257549);
		}

		static public class ActiveEffect
		{
			/// <summary>SkyrimSE.exe + 0x53E380</summary>
			static public System.IntPtr Dispel { get; }					= NetScriptFramework.Main.GameInfo.GetAddressOf(33286);

			/// <summary>SkyrimSE.exe + 0x53E120</summary>
			static public System.IntPtr GetCurrentMagnitude { get; }	= NetScriptFramework.Main.GameInfo.GetAddressOf(33282);
		}

		static public class Actor
		{
			/// <summary>SkyrimSE.exe + 0x62F560</summary>
			static public System.IntPtr AddSpell { get; }					= NetScriptFramework.Main.GameInfo.GetAddressOf(37771);

			/// <summary>SkyrimSE.exe + 0x621350</summary>
			static public System.IntPtr GetActorValueModifier { get; }		= NetScriptFramework.Main.GameInfo.GetAddressOf(37524);

			/// <summary>SkyrimSE.exe + 0x6338F0</summary>
			static public System.IntPtr GetMaximumWardPower { get; }		= NetScriptFramework.Main.GameInfo.GetAddressOf(37837);

			/// <summary>SkyrimSE.exe + 0x621590</summary>
			static public System.IntPtr RemoveActorValueModifiers { get; }	= NetScriptFramework.Main.GameInfo.GetAddressOf(37527);

			/// <summary>SkyrimSE.exe + 0x632270</summary>
			static public System.IntPtr RevertSelectedSpell { get; }		= NetScriptFramework.Main.GameInfo.GetAddressOf(37819);

			/// <summary>SkyrimSE.exe + 0x633910</summary>
			static public System.IntPtr SetMaximumWardPower { get; }		= NetScriptFramework.Main.GameInfo.GetAddressOf(37838);

			/// <summary>SkyrimSE.exe + 0x607FA0</summary>
			static public System.IntPtr UpdateMovementSpeed { get; }		= NetScriptFramework.Main.GameInfo.GetAddressOf(36916);
		}

		static public class BGSEntryPointPerkEntry
		{
			/// <summary>SkyrimSE.exe + 0x32ECE0</summary>
			static public System.IntPtr HandleEntryPoints { get; }		= NetScriptFramework.Main.GameInfo.GetAddressOf(23073);

			/// <summary>SkyrimSE.exe + 0x1598610</summary>
			static public System.IntPtr VirtualFunctionTable { get; }	= NetScriptFramework.Main.GameInfo.GetAddressOf(241053);
		}

		static public class BSPointerHandle
		{
			/// <summary>SkyrimSE.exe + 0x1EE670</summary>
			static public System.IntPtr GetHandle { get; }			= NetScriptFramework.Main.GameInfo.GetAddressOf(15967);

			/// <summary>SkyrimSE.exe + 0x1329D0</summary>
			static public System.IntPtr GetSmartPointer { get; }	= NetScriptFramework.Main.GameInfo.GetAddressOf(12204);
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

		static public class BSTEventSource
		{
			/// <summary>SkyrimSE.exe + 0x19D600</summary>
			static public System.IntPtr AddEventSink { get; }		= NetScriptFramework.Main.GameInfo.GetAddressOf(14705);

			/// <summary>SkyrimSE.exe + 0x19D7C0</summary>
			static public System.IntPtr RemoveEventSink { get; }	= NetScriptFramework.Main.GameInfo.GetAddressOf(14707);

			/// <summary>SkyrimSE.exe + 0x19D270</summary>
			static public System.IntPtr SendEvent { get; }			= NetScriptFramework.Main.GameInfo.GetAddressOf(14703);
		}

		static public class ExtraDataList
		{
			/// <summary>SkyrimSE.exe + 0x113890</summary>
			static public System.IntPtr GetCharge { get; }		= NetScriptFramework.Main.GameInfo.GetAddressOf(11560);

			/// <summary>SkyrimSE.exe + 0x1EE7E0</summary>
			static public System.IntPtr HasExtraData { get; }	= NetScriptFramework.Main.GameInfo.GetAddressOf(15971);
		}

		static public class FindMaxMagnitudeVisitor
		{
			/// <summary>SkyrimSE.exe + 0x1636990</summary>
			static public System.IntPtr VirtualFunctionTable { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf(257550);
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

		static public class MagicItem
		{
			/// <summary>SkyrimSE.exe + 0x101A30</summary>
			static public System.IntPtr GetCost { get; }			= NetScriptFramework.Main.GameInfo.GetAddressOf(11213);

			/// <summary>SkyrimSE.exe + 0x556780</summary>
			static public System.IntPtr GetCostActorValue { get; }	= NetScriptFramework.Main.GameInfo.GetAddressOf(33817);
		}

		static public class MagicTarget
		{
			/// <summary>SkyrimSE.exe + 0x553E90</summary>
			static public System.IntPtr GetActor { get; }			= NetScriptFramework.Main.GameInfo.GetAddressOf(33745);

			/// <summary>SkyrimSE.exe + 0x554500</summary>
			static public System.IntPtr VisitActiveEffects { get; }	= NetScriptFramework.Main.GameInfo.GetAddressOf(33756);
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

		static public class SpellItem
		{
			/// <summary>SkyrimSE.exe + 0x1007F0</summary>
			static public System.IntPtr ShouldAddSpell { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf(11183);
		}

		static public class TESDataHandler
		{
			/// <summary>SkyrimSE.exe + 0x194230</summary>
			static public System.IntPtr GetForm { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf(14461);
		}

		static public class TESForm
		{
			/// <summary>SkyrimSE.exe + 0x190D50</summary>
			static public System.IntPtr GetEnchantment { get; }		= NetScriptFramework.Main.GameInfo.GetAddressOf(14411);

			/// <summary>SkyrimSE.exe + 0x196E10</summary>
			static public System.IntPtr GetFullName { get; }		= NetScriptFramework.Main.GameInfo.GetAddressOf(14548);

			/// <summary>SkyrimSE.exe + 0x190DC0</summary>
			static public System.IntPtr GetMaximumCharge { get; }	= NetScriptFramework.Main.GameInfo.GetAddressOf(14412);
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
