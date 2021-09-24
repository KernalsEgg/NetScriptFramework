namespace Eggstensions
{
	namespace Offsets
	{
		static public class AccumulatingValueModifierEffect
		{
			/// <summary>SkyrimSE.exe + 0x1636880</summary>
			static public System.IntPtr VirtualFunctionTable { get; } = AddressLibrary.GetAddress(257549);
		}

		static public class ActiveEffect
		{
			/// <summary>SkyrimSE.exe + 0x53E380</summary>
			static public System.IntPtr Dispel { get; }					= AddressLibrary.GetAddress(33286);

			/// <summary>SkyrimSE.exe + 0x53E120</summary>
			static public System.IntPtr GetCurrentMagnitude { get; }	= AddressLibrary.GetAddress(33282);
		}

		static public class Actor
		{
			/// <summary>SkyrimSE.exe + 0x62F560</summary>
			static public System.IntPtr AddSpell { get; }					= AddressLibrary.GetAddress(37771);

			/// <summary>SkyrimSE.exe + 0x621350</summary>
			static public System.IntPtr GetActorValueModifier { get; }		= AddressLibrary.GetAddress(37524);

			/// <summary>SkyrimSE.exe + 0x625EB0</summary>
			static public System.IntPtr GetEquippedWeapon { get; }			= AddressLibrary.GetAddress(37621);

			/// <summary>SkyrimSE.exe + 0x6338F0</summary>
			static public System.IntPtr GetMaximumWardPower { get; }		= AddressLibrary.GetAddress(37837);

			/// <summary>SkyrimSE.exe + 0x62F170</summary>
			static public System.IntPtr GetMovementActor { get; }			= AddressLibrary.GetAddress(37762);

			/// <summary>SkyrimSE.exe + 0x621590</summary>
			static public System.IntPtr RemoveActorValueModifiers { get; }	= AddressLibrary.GetAddress(37527);

			/// <summary>SkyrimSE.exe + 0x632270</summary>
			static public System.IntPtr RevertSelectedSpell { get; }		= AddressLibrary.GetAddress(37819);

			/// <summary>SkyrimSE.exe + 0x633910</summary>
			static public System.IntPtr SetMaximumWardPower { get; }		= AddressLibrary.GetAddress(37838);

			/// <summary>SkyrimSE.exe + 0x607FA0</summary>
			static public System.IntPtr UpdateMovementSpeed { get; }		= AddressLibrary.GetAddress(36916);
		}

		static public class BGSEntryPointPerkEntry
		{
			/// <summary>SkyrimSE.exe + 0x32ECE0</summary>
			static public System.IntPtr HandleEntryPoints { get; }		= AddressLibrary.GetAddress(23073);

			/// <summary>SkyrimSE.exe + 0x1598610</summary>
			static public System.IntPtr VirtualFunctionTable { get; }	= AddressLibrary.GetAddress(241053);
		}

		static public class BSFixedString
		{
			/// <summary>SkyrimSE.exe + 0xC28BF0</summary>
			static public System.IntPtr Initialize { get; }	= AddressLibrary.GetAddress(67819);

			/// <summary>SkyrimSE.exe + 0xC28D40</summary>
			static public System.IntPtr Release { get; }	= AddressLibrary.GetAddress(67822);
		}

		static public class BSPointerHandle
		{
			/// <summary>SkyrimSE.exe + 0x1EE670</summary>
			static public System.IntPtr GetHandle { get; }			= AddressLibrary.GetAddress(15967);

			/// <summary>SkyrimSE.exe + 0x1329D0</summary>
			static public System.IntPtr GetSmartPointer { get; }	= AddressLibrary.GetAddress(12204);
		}

		static public class BSTArray
		{
			static public class IntPtr
			{
				/// <summary>SkyrimSE.exe + 0x19D170</summary>
				static public System.IntPtr Push { get; } = AddressLibrary.GetAddress(14698);
			}



			/// <summary>SkyrimSE.exe + 0xC04EC0</summary>
			static public System.IntPtr Deallocate { get; } = AddressLibrary.GetAddress(66915);
		}

		static public class BSTEventSource
		{
			/// <summary>SkyrimSE.exe + 0x19D600</summary>
			static public System.IntPtr AddEventSink { get; }		= AddressLibrary.GetAddress(14705);

			/// <summary>SkyrimSE.exe + 0x19D7C0</summary>
			static public System.IntPtr RemoveEventSink { get; }	= AddressLibrary.GetAddress(14707);

			/// <summary>SkyrimSE.exe + 0x19D270</summary>
			static public System.IntPtr SendEvent { get; }			= AddressLibrary.GetAddress(14703);
		}

		static public class ExtraDataList
		{
			/// <summary>SkyrimSE.exe + 0x113890</summary>
			static public System.IntPtr GetCharge { get; }		= AddressLibrary.GetAddress(11560);

			/// <summary>SkyrimSE.exe + 0x1EE7E0</summary>
			static public System.IntPtr HasExtraData { get; }	= AddressLibrary.GetAddress(15971);
		}

		static public class FindMaxMagnitudeVisitor
		{
			/// <summary>SkyrimSE.exe + 0x1636990</summary>
			static public System.IntPtr VirtualFunctionTable { get; } = AddressLibrary.GetAddress(257550);
		}

		static public class InitTESThread
		{
			/// <summary>SkyrimSE.exe + 0x164D900</summary>
			static public System.IntPtr VirtualFunctionTable { get; } = AddressLibrary.GetAddress(259694);
		}

		static public class InventoryChanges
		{
			/// <summary>SkyrimSE.exe + 0x1EBD50</summary>
			static public System.IntPtr ResetWeight { get; } = AddressLibrary.GetAddress(15897);
		}

		static public class InventoryEntryData
		{
			/// <summary>SkyrimSE.exe + 0x1D6A40</summary>
			static public System.IntPtr IsWorn { get; } = AddressLibrary.GetAddress(15763);
		}

		static public class MagicItem
		{
			/// <summary>SkyrimSE.exe + 0x101A30</summary>
			static public System.IntPtr GetCost { get; }			= AddressLibrary.GetAddress(11213);

			/// <summary>SkyrimSE.exe + 0x556780</summary>
			static public System.IntPtr GetCostActorValue { get; }	= AddressLibrary.GetAddress(33817);
		}

		static public class MagicTarget
		{
			/// <summary>SkyrimSE.exe + 0x553E90</summary>
			static public System.IntPtr GetActor { get; }			= AddressLibrary.GetAddress(33745);

			/// <summary>SkyrimSE.exe + 0x554500</summary>
			static public System.IntPtr VisitActiveEffects { get; }	= AddressLibrary.GetAddress(33756);
		}

		static public class PlayerCharacter
		{
			/// <summary>SkyrimSE.exe + 0x2F26EF8</summary>
			static public System.IntPtr Instance { get; } = AddressLibrary.GetAddress(517014);
		}

		static public class ScriptEventSourceHolder
		{
			/// <summary>SkyrimSE.exe + 0x186790</summary>
			static public System.IntPtr GetInstance { get; } = AddressLibrary.GetAddress(14108);
		}

		static public class SettingT
		{
			static public class GameSettingCollection
			{
				/// <summary>SkyrimSE.exe + 0x1DE0D88</summary>
				static public System.IntPtr ArrowBowMinTime { get; }	= AddressLibrary.GetAddress(505061);

				/// <summary>SkyrimSE.exe + 0x1DE0DE8</summary>
				static public System.IntPtr ArrowMinPower { get; }		= AddressLibrary.GetAddress(505069);

				/// <summary>SkyrimSE.exe + 0x1DE0DD0</summary>
				static public System.IntPtr BowDrawTime { get; }		= AddressLibrary.GetAddress(505067);
			}
		}

		static public class SpellItem
		{
			/// <summary>SkyrimSE.exe + 0x1007F0</summary>
			static public System.IntPtr ShouldAddSpell { get; } = AddressLibrary.GetAddress(11183);
		}

		static public class TESDataHandler
		{
			/// <summary>SkyrimSE.exe + 0x194230</summary>
			static public System.IntPtr GetForm { get; } = AddressLibrary.GetAddress(14461);
		}

		static public class TESForm
		{
			/// <summary>SkyrimSE.exe + 0x190D50</summary>
			static public System.IntPtr GetEnchantment { get; }		= AddressLibrary.GetAddress(14411);

			/// <summary>SkyrimSE.exe + 0x196E10</summary>
			static public System.IntPtr GetFormName { get; }		= AddressLibrary.GetAddress(14548);

			/// <summary>SkyrimSE.exe + 0x190DC0</summary>
			static public System.IntPtr GetMaximumCharge { get; }	= AddressLibrary.GetAddress(14412);
		}

		static public class TESObjectREFR
		{
			/// <summary>SkyrimSE.exe + 0x1D8E40</summary>
			static public System.IntPtr GetInventoryChanges { get; }	= AddressLibrary.GetAddress(15802);

			/// <summary>SkyrimSE.exe + 0x296460</summary>
			static public System.IntPtr GetReferenceName { get; }		= AddressLibrary.GetAddress(19355);
		}

		static public class UI
		{
			/// <summary>SkyrimSE.exe + 0x8DA3D0</summary>
			static public System.IntPtr Notification { get; } = AddressLibrary.GetAddress(52050);
		}
	}
}
