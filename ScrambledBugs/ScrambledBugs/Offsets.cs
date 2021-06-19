namespace ScrambledBugs
{
	namespace Offsets
	{
		namespace Fixes
		{
			static internal class ActiveEffectConditions
			{
				/// <summary>SkyrimSE.exe + 0x53E3E0</summary>
				static public System.IntPtr UpdateConditions { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf(33287);
			}

			static internal class HarvestedFlags
			{
				/// <summary>SkyrimSE.exe + 0x278920</summary>
				static public System.IntPtr Respawn { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf(18843);
			}

			static internal class ModArmorWeightPerkEntryPoint
			{
				/// <summary>SkyrimSE.exe + 0x1E9130</summary>
				static public System.IntPtr GetInventoryWeight { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf(15883);
			}

			static internal class SpeedMultUpdates
			{
				/// <summary>SkyrimSE.exe + 0x2F39A40</summary>
				static public System.IntPtr ActorValueSinkFunctionTable { get; }	= NetScriptFramework.Main.GameInfo.GetAddressOf(517376);

				/// <summary>SkyrimSE.exe + 0x5ED420</summary>
				static public System.IntPtr RemoveMovementFlags { get; }			= NetScriptFramework.Main.GameInfo.GetAddressOf(36585);

				/// <summary>SkyrimSE.exe + 0x2F266F8</summary>
				static public System.IntPtr SaveManager { get; }					= NetScriptFramework.Main.GameInfo.GetAddressOf(516851);

				/// <summary>SkyrimSE.exe + 0x607FA0</summary>
				static public System.IntPtr UpdateMovementSpeed { get; }			= NetScriptFramework.Main.GameInfo.GetAddressOf(36916);
			}

			static internal class HitEffectRaceCondition
			{
				/// <summary>SkyrimSE.exe + 0x53E670</summary>
				static public System.IntPtr ShouldUpdate { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf(33289);
			}

			static internal class TerrainDecals
			{
				/// <summary>SkyrimSE.exe + 0x271BE0</summary>
				static public System.IntPtr UnloadHavokData { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf(18711, 0xE7, 0, "E9 ?? ?? ?? ??"); // 5
			}

			static internal class TrainingMenuText
			{
				/// <summary>SkyrimSE.exe + 0x8CEA30</summary>
				static public System.IntPtr UpdateText { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf(51794, 0x289, 0, "FF 50 10"); // 3
			}
		}

		namespace Patches
		{
			namespace ApplySpellPerkEntryPoints
			{
				static internal class MultipleSpells
				{
					/// <summary>SkyrimSE.exe + 0x628C20</summary>
					static public System.IntPtr ApplyBashingSpell { get; }					= NetScriptFramework.Main.GameInfo.GetAddressOf(37673);

					/// <summary>SkyrimSE.exe + 0x6310A0</summary>
					static public System.IntPtr ApplyCombatHitSpell { get; }				= NetScriptFramework.Main.GameInfo.GetAddressOf(37799);

					/// <summary>SkyrimSE.exe + 0x732400</summary>
					static public System.IntPtr ApplyCombatHitSpellArrowProjectile { get; }	= NetScriptFramework.Main.GameInfo.GetAddressOf(42547);

					/// <summary>SkyrimSE.exe + 0x634BF0</summary>
					static public System.IntPtr ApplyReanimateSpell { get; }				= NetScriptFramework.Main.GameInfo.GetAddressOf(37865);

					/// <summary>SkyrimSE.exe + 0x6089E0</summary>
					static public System.IntPtr ApplySneakingSpell { get; }					= NetScriptFramework.Main.GameInfo.GetAddressOf(36926);

					/// <summary>SkyrimSE.exe + 0x6260F0</summary>
					static public System.IntPtr ApplyWeaponSwingSpell { get; }				= NetScriptFramework.Main.GameInfo.GetAddressOf(37628);

					/// <summary>SkyrimSE.exe + 0x1DD3B20</summary>
					static public System.IntPtr SelectSpell { get; }						= NetScriptFramework.Main.GameInfo.GetAddressOf(675819);

					/// <summary>SkyrimSE.exe + 0x1DD3BB0</summary>
					static public System.IntPtr SelectSpellResultCount { get; }				= NetScriptFramework.Main.GameInfo.GetAddressOf(502190);
				}
			}



			static internal class AttachHitEffectArt
			{
				/// <summary>SkyrimSE.exe + 0x6314F0</summary>
				static public System.IntPtr AddNoHitEffectArtFlag { get; }		= NetScriptFramework.Main.GameInfo.GetAddressOf(37804, 0x6F, 0, "24 F9" + "0C 01"); // 2 + 2

				/// <summary>SkyrimSE.exe + 0x558F20</summary>
				static public System.IntPtr Attach { get; }						= NetScriptFramework.Main.GameInfo.GetAddressOf(33872);

				/// <summary>SkyrimSE.exe + 0x558220</summary>
				static public System.IntPtr AttachOnPerspectiveChange { get; }	= NetScriptFramework.Main.GameInfo.GetAddressOf(33862, 0x9A, 0, "74 08"); // 2

				/// <summary>SkyrimSE.exe + 0x558220</summary>
				static public System.IntPtr AttachToPlayer { get; }				= NetScriptFramework.Main.GameInfo.GetAddressOf(33862, 0x7C, 0, "75 3B"); // 2
			}

			static internal class EquipBestAmmo
			{
				/// <summary>SkyrimSE.exe + 0x1E3090</summary>
				static public System.IntPtr CompareDamageContainer { get; }			= NetScriptFramework.Main.GameInfo.GetAddressOf(15846, 0x11A, 0, "73 06"); // 2

				/// <summary>SkyrimSE.exe + 0x1E3090</summary>
				static public System.IntPtr CompareDamageInventoryChanges { get; }	= NetScriptFramework.Main.GameInfo.GetAddressOf(15846, 0x1E1, 0, "73 10"); // 2

				/// <summary>SkyrimSE.exe + 0x1E3090</summary>
				static public System.IntPtr GetWorstAmmo { get; }					= NetScriptFramework.Main.GameInfo.GetAddressOf(15846);
			}

			static internal class LockpickingExperience
			{
				/// <summary>SkyrimSE.exe + 0x897E10</summary>
				static public System.IntPtr HasNotBeenUnlocked { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf(51088, 0x2C, 0, "75 50"); // 2
			}

			static internal class MultipleHitEffects
			{
				/// <summary>SkyrimSE.exe + 0x5468E0</summary>
				static public System.IntPtr IsNotCostliestEffect { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf(33471, 0x15, 0, "74 0A"); // 2
			}

			static internal class PausedGameHitEffects
			{
				/// <summary>SkyrimSE.exe + 0x5402D0</summary>
				static public System.IntPtr IsNotApplyingHitEffects { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf(33319, 0x37, 0, "74 3F"); // 2
			}

			static internal class UnderfilledSoulGems
			{
				/// <summary>SkyrimSE.exe + 0x1E5050</summary>
				static public System.IntPtr FindBestSoulGem { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf(15854, 0xE6, 0, "72 2E"); // 2
			}
		}
	}
}
