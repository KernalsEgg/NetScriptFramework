using Eggstensions;



namespace ScrambledBugs
{
	namespace Offsets
	{
		namespace Fixes
		{
			namespace ApplySpellPerkEntryPoints
			{
				static internal class Arrows
				{
					/// <summary>ArrowProjectile::GetImpactData (SkyrimSE.exe + 0x732400)</summary>
					static public System.IntPtr ApplyCombatHitSpellArrowProjectile { get; } = AddressLibrary.GetAddress(42547, 0x28B);
				}
			}



			static internal class ActorValuePercentage
			{
				/// <summary>SkyrimSE.exe + 0x2D4C40</summary>
				static public System.IntPtr ActorValueCondition { get; }	= AddressLibrary.GetAddress(20967, 0x27);

				/// <summary>EnemyHealth::Update (SkyrimSE.exe + 0x882520)</summary>
				static public System.IntPtr ActorValueEnemyHealth { get; }	= AddressLibrary.GetAddress(50776, 0xE1);

				/// <summary>SkyrimSE.exe + 0x94ABB0</summary>
				static public System.IntPtr ActorValuePapyrus { get; }		= AddressLibrary.GetAddress(53868, 0x4D);

				/// <summary>SkyrimSE.exe + 0x2D9320</summary>
				static public System.IntPtr HealthCondition { get; }		= AddressLibrary.GetAddress(21068, 0x20);

				/// <summary>SkyrimSE.exe + 0x2D92A0</summary>
				static public System.IntPtr StaminaCondition { get; }		= AddressLibrary.GetAddress(21067, 0x20);
			}

			static internal class HarvestedFlags
			{
				/// <summary>TESObjectREFR::Respawn (SkyrimSE.exe + 0x278920)</summary>
				static public System.IntPtr RemoveHarvestedFlag { get; } = AddressLibrary.GetAddress(18843, 0x31C);
			}

			static internal class HitEffectRaceCondition
			{
				/// <summary>ActiveEffect::ShouldUpdate (SkyrimSE.exe + 0x53E670)</summary>
				static public System.IntPtr ShouldUpdate { get; } = AddressLibrary.GetAddress(33289, 0x5A);
			}

			static internal class MagicEffectConditions
			{
				/// <summary>ActiveEffect::UpdateConditions (SkyrimSE.exe + 0x53E3E0)</summary>
				static public System.IntPtr UpdateConditions { get; } = AddressLibrary.GetAddress(33287, 0xEA);
			}

			static internal class MagicEffectFlags
			{
				/// <summary>ActiveEffect::ResetElapsedTime (SkyrimSE.exe + 0x53E1B0)</summary>
				static public System.IntPtr ResetEffectiveness { get; }	= AddressLibrary.GetAddress(33283, 0x105);

				/// <summary>ActiveEffect::SetEffectiveness (SkyrimSE.exe + 0x53DEB0)</summary>
				static public System.IntPtr SetEffectiveness { get; }	= AddressLibrary.GetAddress(33277, 0x68);
			}

			static internal class ModArmorWeightPerkEntryPoint
			{
				/// <summary>TESObjectREFR::GetInventoryWeight (SkyrimSE.exe + 0x1E9130)</summary>
				static public System.IntPtr ModArmorWeightContainer { get; }		= AddressLibrary.GetAddress(15883, 0x159);

				/// <summary>TESObjectREFR::GetInventoryWeight (SkyrimSE.exe + 0x1E9130)</summary>
				static public System.IntPtr ModArmorWeightInventoryChanges { get; }	= AddressLibrary.GetAddress(15883, 0x29F);
			}

			static internal class QuickShot
			{
				/// <summary>SkyrimSE.exe + 0x74B170</summary>
				static public System.IntPtr CreateProjectile { get; }	= AddressLibrary.GetAddress(42928, 0x604);

				/// <summary>SkyrimSE.exe + 0x6CE720</summary>
				static public System.IntPtr KillCamera { get; }			= AddressLibrary.GetAddress(40230, 0x87C);
			}

			static internal class SpeedMultUpdates
			{
				/// <summary>SkyrimSE.exe + 0x2F39A40</summary>
				static public System.IntPtr ActorValueSinkFunctionTable { get; } = AddressLibrary.GetAddress(517376);

				/// <summary>SkyrimSE.exe + 0x5ED420</summary>
				static public System.IntPtr RemoveMovementFlags { get; } = AddressLibrary.GetAddress(36585);

				/// <summary>SkyrimSE.exe + 0x2F266F8</summary>
				static public System.IntPtr SaveManager { get; } = AddressLibrary.GetAddress(516851);
			}

			static internal class TerrainDecals
			{
				/// <summary>SkyrimSE.exe + 0x271BE0</summary>
				static public System.IntPtr UnloadHavokData { get; } = AddressLibrary.GetAddress(18711, 0xE7);
			}

			static internal class TrainingMenuText
			{
				/// <summary>TrainingMenu::UpdateText (SkyrimSE.exe + 0x8CEA30)</summary>
				static public System.IntPtr GetPermanentActorValue { get; } = AddressLibrary.GetAddress(51794, 0x289);
			}

			static internal class WeaponCharge
			{
				/// <summary>SkyrimSE.exe + 0x6AE010</summary>
				static public System.IntPtr RemoveEquippedItemFlags { get; }	= AddressLibrary.GetAddress(39498);

				/// <summary>SkyrimSE.exe + 0x86C640</summary>
				static public System.IntPtr Enchant { get; }					= AddressLibrary.GetAddress(50450, 0x17E);

				/// <summary>SkyrimSE.exe + 0x60B9E0</summary>
				static public System.IntPtr Equip { get; }						= AddressLibrary.GetAddress(36976, 0x303);

				/// <summary>SkyrimSE.exe + 0x88E890</summary>
				static public System.IntPtr Recharge { get; }					= AddressLibrary.GetAddress(50980, 0x222);
			}
		}

		namespace Patches
		{
			namespace ApplySpellPerkEntryPoints
			{
				static internal class CastSpells
				{
					/// <summary>Actor::WeaponHit (SkyrimSE.exe + 0x628C20)</summary>
					static public System.IntPtr ApplyBashingSpell { get; }					= AddressLibrary.GetAddress(37673, 0x429);

					/// <summary>Actor::ApplyWeaponHitSpells (SkyrimSE.exe + 0x6310A0)</summary>
					static public System.IntPtr ApplyCombatHitSpell { get; }				= AddressLibrary.GetAddress(37799, 0x79);

					/// <summary>ArrowProjectile::GetImpactData (SkyrimSE.exe + 0x732400)</summary>
					static public System.IntPtr ApplyCombatHitSpellArrowProjectile { get; }	= AddressLibrary.GetAddress(42547, 0x2A7);

					/// <summary>ReanimateEffect::GetUp (SkyrimSE.exe + 0x634BF0)</summary>
					static public System.IntPtr ApplyReanimateSpell { get; }				= AddressLibrary.GetAddress(37865, 0xD2);

					/// <summary>Actor::WeaponSwing (SkyrimSE.exe + 0x6260F0)</summary>
					static public System.IntPtr ApplyWeaponSwingSpell { get; }				= AddressLibrary.GetAddress(37628, 0xC3);
				}

				static internal class MultipleSpells
				{
					/// <summary>Actor::WeaponHit (SkyrimSE.exe + 0x628C20)</summary>
					static public System.IntPtr ApplyBashingSpell { get; }					= AddressLibrary.GetAddress(37673, 0x40E);

					/// <summary>Actor::ApplyWeaponHitSpells (SkyrimSE.exe + 0x6310A0)</summary>
					static public System.IntPtr ApplyCombatHitSpell { get; }				= AddressLibrary.GetAddress(37799, 0x61);

					/// <summary>ArrowProjectile::GetImpactData (SkyrimSE.exe + 0x732400)</summary>
					static public System.IntPtr ApplyCombatHitSpellArrowProjectile { get; }	= AddressLibrary.GetAddress(42547, 0x28B);

					/// <summary>ReanimateEffect::GetUp (SkyrimSE.exe + 0x634BF0)</summary>
					static public System.IntPtr ApplyReanimateSpell { get; }				= AddressLibrary.GetAddress(37865, 0xBA);

					/// <summary>Actor::SetSneaking (SkyrimSE.exe + 0x6089E0)</summary>
					static public System.IntPtr ApplySneakingSpell { get; }					= AddressLibrary.GetAddress(36926, 0xB6);

					/// <summary>Actor::WeaponSwing (SkyrimSE.exe + 0x6260F0)</summary>
					static public System.IntPtr ApplyWeaponSwingSpell { get; }				= AddressLibrary.GetAddress(37628, 0xAB);

					/// <summary>SkyrimSE.exe + 0x1DD3B20</summary>
					static public System.IntPtr SelectSpell { get; }						= AddressLibrary.GetAddress(675819);

					/// <summary>SkyrimSE.exe + 0x1DD3BB0</summary>
					static public System.IntPtr SelectSpellResultCount { get; }				= AddressLibrary.GetAddress(502190);
				}
			}



			static internal class AccumulatingMagnitude
			{
				/// <summary>FindMaxMagnitudeVisitor::Visit (SkyrimSE.exe + 0x53D910)</summary>
				static public System.IntPtr GetMaximumMagnitude { get; }		= AddressLibrary.GetAddress(33268, 0x35);

				/// <summary>AccumulatingValueModifierEffect::UpdateActorValue (SkyrimSE.exe + 0x53D770)</summary>
				static public System.IntPtr GetMaximumMagnitudeAndRate { get; }	= AddressLibrary.GetAddress(33265, 0x7D);

				/// <summary>AccumulatingValueModifierEffect::UpdateActorValue (SkyrimSE.exe + 0x53D770)</summary>
				static public System.IntPtr GetMaximumWardPower { get; }		= AddressLibrary.GetAddress(33265, 0x91);

				/// <summary>AccumulatingValueModifierEffect::Constructor (SkyrimSE.exe + 0x53D2B0)</summary>
				static public System.IntPtr SetMaximumMagnitude { get; }		= AddressLibrary.GetAddress(33256, 0x4C);

				/// <summary>AccumulatingValueModifierEffect::Constructor (SkyrimSE.exe + 0x53D2B0)</summary>
				static public System.IntPtr SetRate { get; }					= AddressLibrary.GetAddress(33256, 0x8A);
			}

			static internal class AlreadyCaughtPickpocketing
			{
				/// <summary>TESNPC::Activate (SkyrimSE.exe + 0x360C10)</summary>
				static public System.IntPtr IsAttackingOnSight { get; }	= AddressLibrary.GetAddress(24211, 0x678);

				/// <summary>TESNPC::Activate (SkyrimSE.exe + 0x360C10)</summary>
				static public System.IntPtr IsNotKnockedDown { get; }	= AddressLibrary.GetAddress(24211, 0x684);
			}

			static internal class AttachHitEffectArt
			{
				/// <summary>SkyrimSE.exe + 0x6314F0</summary>
				static public System.IntPtr AddNoHitEffectArtFlag { get; }	= AddressLibrary.GetAddress(37804, 0x6F);

				/// <summary>ModelReferenceEffect::UpdatePosition (SkyrimSE.exe + 0x558220)</summary>
				static public System.IntPtr IsPerspectiveChange { get; }	= AddressLibrary.GetAddress(33862, 0x9A);

				/// <summary>ModelReferenceEffect::Attach (SkyrimSE.exe + 0x558F20)</summary>
				static public System.IntPtr IsPlayerAttach { get; }			= AddressLibrary.GetAddress(33872, 0x2B);

				/// <summary>ModelReferenceEffect::UpdatePosition (SkyrimSE.exe + 0x558220)</summary>
				static public System.IntPtr IsPlayerUpdatePosition { get; }	= AddressLibrary.GetAddress(33862, 0x7C);
			}

			static internal class EquipBestAmmo
			{
				/// <summary>InventoryChanges::GetWorstAmmo (SkyrimSE.exe + 0x1E3090)</summary>
				static public System.IntPtr CompareDamageContainer { get; }			= AddressLibrary.GetAddress(15846, 0x117);

				/// <summary>InventoryChanges::GetWorstAmmo (SkyrimSE.exe + 0x1E3090)</summary>
				static public System.IntPtr CompareDamageInventoryChanges { get; }	= AddressLibrary.GetAddress(15846, 0x1DE);

				/// <summary>InventoryChanges::GetWorstAmmo (SkyrimSE.exe + 0x1E3090)</summary>
				static public System.IntPtr InitializeDamage { get; }				= AddressLibrary.GetAddress(15846, 0x5F);
			}

			static internal class LeveledCharacters
			{
				/// <summary>SkyrimSE.exe + 0x1384D0</summary>
				static public System.IntPtr IsVeryHard { get; } = AddressLibrary.GetAddress(12448, 0xA);
			}

			static internal class LockpickingExperience
			{
				/// <summary>SkyrimSE.exe + 0x897E10</summary>
				static public System.IntPtr HasNotBeenUnlocked { get; } = AddressLibrary.GetAddress(51088, 0x2C);
			}

			static internal class MultipleHitEffects
			{
				/// <summary>SkyrimSE.exe + 0x5468E0</summary>
				static public System.IntPtr IsNotCostliestEffect { get; } = AddressLibrary.GetAddress(33471, 0x15);
			}

			static internal class PausedGameHitEffects
			{
				/// <summary>SkyrimSE.exe + 0x5402D0</summary>
				static public System.IntPtr IsNotApplyingHitEffects { get; } = AddressLibrary.GetAddress(33319, 0x37);
			}

			static internal class PowerAttackStamina
			{
				/// <summary>SkyrimSE.exe + 0x80C020</summary>
				static public System.IntPtr GetStaminaCostActor { get; }			= AddressLibrary.GetAddress(48139, 0x29B);

				/// <summary>SkyrimSE.exe + 0x63CFB0</summary>
				static public System.IntPtr GetStaminaCostPlayerCharacter { get; }	= AddressLibrary.GetAddress(38047, 0xBB);

				/// <summary>SkyrimSE.exe + 0x80C020</summary>
				static public System.IntPtr HasStaminaActor { get; }				= AddressLibrary.GetAddress(48139, 0x293);

				/// <summary>SkyrimSE.exe + 0x80C020</summary>
				static public System.IntPtr HasStaminaCostActor { get; }			= AddressLibrary.GetAddress(48139, 0x2A0);

				/// <summary>SkyrimSE.exe + 0x63CFB0</summary>
				static public System.IntPtr HasStaminaCostPlayerCharacter { get; }	= AddressLibrary.GetAddress(38047, 0xC3);

				/// <summary>SkyrimSE.exe + 0x63CFB0</summary>
				static public System.IntPtr HasStaminaPlayerCharacter { get; }		= AddressLibrary.GetAddress(38047, 0xE1);
			}

			static internal class ReflectDamage
			{
				/// <summary>SkyrimSE.exe + 0x743510</summary>
				static public System.IntPtr CompareReflectDamage { get; } = AddressLibrary.GetAddress(42842, 0x544);
			}

			static internal class TeammateDifficulty
			{
				/// <summary>SkyrimSE.exe + 0x5E4800/summary>
				static public System.IntPtr IsPlayer { get; } = AddressLibrary.GetAddress(36506, 0xB);
			}

			static internal class UnderfilledSoulGems
			{
				/// <summary>SkyrimSE.exe + 0x1E5050</summary>
				static public System.IntPtr CompareSoulLevelValue { get; } = AddressLibrary.GetAddress(15854, 0xE6);
			}
		}
	}
}
