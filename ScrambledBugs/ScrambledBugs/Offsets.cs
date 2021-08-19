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
					static public System.IntPtr ApplyCombatHitSpellArrow { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf
					(
						42547, 0x28B, 0, // 0x5
						"E8 ?? ?? ?? ??" // call
					);
				}
			}



			static internal class ActorValuePercentage
			{
				/// <summary>SkyrimSE.exe + 0x2D4C40</summary>
				static public System.IntPtr Condition { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf
				(
					20967, 0x27, 0,		// 0x5
					"E8 ?? ?? ?? ??"	// call
				);

				/// <summary>SkyrimSE.exe + 0x94ABB0</summary>
				static public System.IntPtr Papyrus { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf
				(
					53868, 0x4D, 0,		// 0x5
					"E8 ?? ?? ?? ??"	// call
				);
			}

			static internal class HarvestedFlags
			{
				/// <summary>TESObjectREFR::Respawn (SkyrimSE.exe + 0x278920)</summary>
				static public System.IntPtr RemoveHarvestedFlag { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf
				(
					18843, 0x31C, 0, // 0x5
					"E8 ?? ?? ?? ??" // call
				);
			}

			static internal class HitEffectRaceCondition
			{
				/// <summary>ActiveEffect::ShouldUpdate (SkyrimSE.exe + 0x53E670)</summary>
				static public System.IntPtr ShouldUpdate { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf
				(
					33289, 0x5A, 0, // 3 + 3 + 2 = 0x8
					"C1 E8 07" +	// shr eax, 07
					"A8 01" +		// test al, 01
					"75 1C"			// jne 1C
				);
			}

			static internal class MagicEffectConditions
			{
				/// <summary>ActiveEffect::UpdateConditions (SkyrimSE.exe + 0x53E3E0)</summary>
				static public System.IntPtr UpdateConditions { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf
				(
					33287, 0xEA, 0,		// 3 + 4 + 4 + 6 + 2 + 4 + 3 + 3 + 2 + 3 + 3 + 3 + 2 + 4 + 3 + 4 + 4 + 4 + 6 + 2 + 4 + 3 + 3 + 2 + 3 + 3 + 3 + 2 + 4 + 3 + 3 + 6 = 0x6C
					"0F28 D3" +			// movaps xmm2, xmm3
					"F3 0F59 D1" +		// mulss xmm2, xmm1
					"F3 0F2C CA" +		// cvttss2si ecx, xmm2
					"81 F9 00000080" +	// cmp ecx, 80000000
					"74 1E" +			// je 1E
					"66 0F6E C1" +		// movd xmm0, ecx
					"0F5B C0" +			// cvtdq2ps xmm0, xmm0
					"0F2E C2" +			// ucomiss xmm0, xmm2
					"74 12" +			// je 12
					"0F14 D2" +			// unpcklps xmm2, xmm2
					"0F50 C2" +			// movmskps eax, xmm2
					"83 E0 01" +		// and eax, 01
					"2B C8" +			// sub ecx, eax
					"66 0F6E D1" +		// movd xmm2, ecx
					"0F5B D2" +			// cvtdq2ps xmm2, xmm2
					"F3 0F58 CE" +		// addss xmm1, xmm6
					"F3 0F59 CB" +		// mulss xmm1, xmm3
					"F3 0F2C C9" +		// cvttss2si ecx, xmm1
					"81 F9 00000080" +	// cmp ecx, 80000000
					"74 1E" +			// je 1E
					"66 0F6E C1" +		// movd xmm0, ecx
					"0F5B C0" +			// cvtdq2ps xmm0, xmm0
					"0F2E C1" +			// ucomiss xmm0, xmm1
					"74 12" +			// je 12
					"0F14 C9" +			// unpcklps xmm1, xmm1
					"0F50 C1" +			// movmskps eax, xmm1
					"83 E0 01" +		// and eax, 01
					"2B C8" +			// sub ecx, eax
					"66 0F6E C9" +		// movd xmm1, ecx
					"0F5B C9" +			// cvtdq2ps xmm1, xmm1
					"0F2E D1" +			// ucomiss xmm2, xmm1
					"0F84 87000000"		// je 87
				);
			}

			static internal class MagicEffectFlags
			{
				/// <summary>ActiveEffect::ResetElapsedTime (SkyrimSE.exe + 0x53E1B0)</summary>
				static public System.IntPtr ResetEffectiveness { get; }	= NetScriptFramework.Main.GameInfo.GetAddressOf
				(
					33283, 0x105, 0, // 0x5
					"E8 ?? ?? ?? ??" // call
				);

				/// <summary>ActiveEffect::SetEffectiveness (SkyrimSE.exe + 0x53DEB0)</summary>
				static public System.IntPtr SetEffectiveness { get; }	= NetScriptFramework.Main.GameInfo.GetAddressOf
				(
					33277, 0x68, 0,		// 0x5
					"E8 ?? ?? ?? ??"	// call
				);
			}

			static internal class ModArmorWeightPerkEntryPoint
			{
				/// <summary>TESObjectREFR::GetInventoryWeight (SkyrimSE.exe + 0x1E9130)</summary>
				static public System.IntPtr ModArmorWeightContainer { get; }		= NetScriptFramework.Main.GameInfo.GetAddressOf
				(
					15883, 0x159, 0,	// 3 + 2 = 0x5
					"8B 55 10" +		// mov edx, [rbp+10]
					"8B 00"				// mov eax, [rax]
				);

				/// <summary>TESObjectREFR::GetInventoryWeight (SkyrimSE.exe + 0x1E9130)</summary>
				static public System.IntPtr ModArmorWeightInventoryChanges { get; }	= NetScriptFramework.Main.GameInfo.GetAddressOf
				(
					15883, 0x29F, 0,			// 5 + 9 + 4 = 0x12
					"E8 ?? ?? ?? ??" +			// call
					"F3 0F 10 8C 24 B0000000" +	// movss xmm1, [rsp+B0]
					"F3 0F58 F1"				// addss xmm6, xmm1
				);
			}

			static internal class MovementSpeed
			{
				/// <summary>SkyrimSE.exe + 0x2F39A40</summary>
				static public System.IntPtr ActorValueSinkFunctionTable { get; }	= NetScriptFramework.Main.GameInfo.GetAddressOf(517376);

				/// <summary>SkyrimSE.exe + 0x5ED420</summary>
				static public System.IntPtr RemoveMovementFlags { get; }			= NetScriptFramework.Main.GameInfo.GetAddressOf(36585);

				/// <summary>SkyrimSE.exe + 0x2F266F8</summary>
				static public System.IntPtr SaveManager { get; }					= NetScriptFramework.Main.GameInfo.GetAddressOf(516851);
			}

			static internal class TerrainDecals
			{
				/// <summary>SkyrimSE.exe + 0x271BE0</summary>
				static public System.IntPtr UnloadHavokData { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf
				(
					18711, 0xE7, 0,		// 0x5
					"E9 ?? ?? ?? ??"	// jmp
				);
			}

			static internal class TrainingMenuText
			{
				/// <summary>SkyrimSE.exe + 0x8CEA30</summary>
				static public System.IntPtr UpdateText { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf
				(
					51794, 0x289, 0,	// 0x3
					"FF 50 10"			// call [rax+10]
				);
			}

			static internal class WeaponCharge
			{
				/// <summary>SkyrimSE.exe + 0x6AE010</summary>
				static public System.IntPtr RemoveEquippedItemFlags { get; }	= NetScriptFramework.Main.GameInfo.GetAddressOf(39498);

				/// <summary>SkyrimSE.exe + 0x86C640</summary>
				static public System.IntPtr Enchant { get; }					= NetScriptFramework.Main.GameInfo.GetAddressOf
				(
					50450, 0x17E, 0, // 0x5
					"E8 ?? ?? ?? ??" // call
				);

				/// <summary>SkyrimSE.exe + 0x60B9E0</summary>
				static public System.IntPtr Equip { get; }						= NetScriptFramework.Main.GameInfo.GetAddressOf
				(
					36976, 0x303, 0, // 0x5
					"E8 ?? ?? ?? ??" // call
				);

				/// <summary>SkyrimSE.exe + 0x88E890</summary>
				static public System.IntPtr Recharge { get; }					= NetScriptFramework.Main.GameInfo.GetAddressOf
				(
					50980, 0x222, 0, // 0x5
					"E8 ?? ?? ?? ??" // call
				);
			}
		}

		namespace Patches
		{
			namespace ApplySpellPerkEntryPoints
			{
				static internal class CastSpells
				{
					/// <summary>Actor::WeaponHit (SkyrimSE.exe + 0x628C20)</summary>
					static public System.IntPtr ApplyBashingSpell { get; }			= NetScriptFramework.Main.GameInfo.GetAddressOf
					(
						37673, 0x429, 0, // 0x5
						"E8 ?? ?? ?? ??" // call
					);

					/// <summary>Actor::ApplyWeaponHitSpells (SkyrimSE.exe + 0x6310A0)</summary>
					static public System.IntPtr ApplyCombatHitSpell { get; }		= NetScriptFramework.Main.GameInfo.GetAddressOf
					(
						37799, 0x79, 0,		// 0x5
						"E8 ?? ?? ?? ??"	// call
					);

					/// <summary>ArrowProjectile::GetImpactData (SkyrimSE.exe + 0x732400)</summary>
					static public System.IntPtr ApplyCombatHitSpellArrow { get; }	= NetScriptFramework.Main.GameInfo.GetAddressOf
					(
						42547, 0x2A7, 0, // 0x5
						"E8 ?? ?? ?? ??" // call
					);

					/// <summary>ReanimateEffect::GetUp (SkyrimSE.exe + 0x634BF0)</summary>
					static public System.IntPtr ApplyReanimateSpell { get; }		= NetScriptFramework.Main.GameInfo.GetAddressOf
					(
						37865, 0xD2, 0,		// 0x5
						"E8 ?? ?? ?? ??"	// call
					);

					/// <summary>Actor::WeaponSwing (SkyrimSE.exe + 0x6260F0)</summary>
					static public System.IntPtr ApplyWeaponSwingSpell { get; }		= NetScriptFramework.Main.GameInfo.GetAddressOf
					(
						37628, 0xC3, 0,		// 0x5
						"E8 ?? ?? ?? ??"	// call
					);
				}
				
				static internal class MultipleSpells
				{
					/// <summary>Actor::WeaponHit (SkyrimSE.exe + 0x628C20)</summary>
					static public System.IntPtr ApplyBashingSpell { get; }			= NetScriptFramework.Main.GameInfo.GetAddressOf
					(
						37673, 0x40E, 0, // 0x5
						"E8 ?? ?? ?? ??" // call
					);

					/// <summary>Actor::ApplyWeaponHitSpells (SkyrimSE.exe + 0x6310A0)</summary>
					static public System.IntPtr ApplyCombatHitSpell { get; }		= NetScriptFramework.Main.GameInfo.GetAddressOf
					(
						37799, 0x61, 0,		// 0x5
						"E8 ?? ?? ?? ??"	// call
					);

					/// <summary>ArrowProjectile::GetImpactData (SkyrimSE.exe + 0x732400)</summary>
					static public System.IntPtr ApplyCombatHitSpellArrow { get; }	= NetScriptFramework.Main.GameInfo.GetAddressOf
					(
						42547, 0x28B, 0, // 0x5
						"E8 ?? ?? ?? ??" // call
					);

					/// <summary>ReanimateEffect::GetUp (SkyrimSE.exe + 0x634BF0)</summary>
					static public System.IntPtr ApplyReanimateSpell { get; }		= NetScriptFramework.Main.GameInfo.GetAddressOf
					(
						37865, 0xBA, 0,		// 0x5
						"E8 ?? ?? ?? ??"	// call
					);

					/// <summary>Actor::SetSneaking (SkyrimSE.exe + 0x6089E0)</summary>
					static public System.IntPtr ApplySneakingSpell { get; }			= NetScriptFramework.Main.GameInfo.GetAddressOf
					(
						36926, 0xB6, 0,		// 0x5
						"E8 ?? ?? ?? ??"	// call
					);

					/// <summary>Actor::WeaponSwing (SkyrimSE.exe + 0x6260F0)</summary>
					static public System.IntPtr ApplyWeaponSwingSpell { get; }		= NetScriptFramework.Main.GameInfo.GetAddressOf
					(
						37628, 0xAB, 0,		// 0x5
						"E8 ?? ?? ?? ??"	// call
					);

					/// <summary>SkyrimSE.exe + 0x1DD3B20</summary>
					static public System.IntPtr SelectSpell { get; }				= NetScriptFramework.Main.GameInfo.GetAddressOf(675819);

					/// <summary>SkyrimSE.exe + 0x1DD3BB0</summary>
					static public System.IntPtr SelectSpellResultCount { get; }		= NetScriptFramework.Main.GameInfo.GetAddressOf(502190);
				}
			}



			static internal class AlreadyCaughtPickpocketing
			{
				/// <summary>TESNPC::Activate (SkyrimSE.exe + 0x360C10)</summary>
				static public System.IntPtr IsAttackingOnSight { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf
				(
					24211, 0x678, 0,    // 0x2
					"75 2E"             // jne 2E
				);

				/// <summary>TESNPC::Activate (SkyrimSE.exe + 0x360C10)</summary>
				static public System.IntPtr IsNotKnockedDown { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf
				(
					24211, 0x684, 0,	// 0x2
					"75 10"				// jne 10
				);
			}

			static internal class AttachHitEffectArt
			{
				/// <summary>SkyrimSE.exe + 0x6314F0</summary>
				static public System.IntPtr AddNoHitEffectArtFlag { get; }		= NetScriptFramework.Main.GameInfo.GetAddressOf
				(
					37804, 0x6F, 0,	// 2 + 2 = 0x4
					"24 F9" +		// and al, F9
					"0C 01"			// or al, 1
				);

				/// <summary>ModelReferenceEffect::Attach (SkyrimSE.exe + 0x558F20)</summary>
				static public System.IntPtr Attach { get; }						= NetScriptFramework.Main.GameInfo.GetAddressOf
				(
					33872, 0x2B, 0,				// 7 + 2 = 0x9
					"48 3B 05 ?? ?? ?? ??" +	// cmp rax, cs
					"75 55"						// jne 55
				);

				/// <summary>SkyrimSE.exe + 0x558220</summary>
				static public System.IntPtr AttachOnPerspectiveChange { get; }	= NetScriptFramework.Main.GameInfo.GetAddressOf
				(
					33862, 0x9A, 0,	// 0x2
					"74 08"			// je 08
				);

				/// <summary>SkyrimSE.exe + 0x558220</summary>
				static public System.IntPtr AttachToPlayer { get; }				= NetScriptFramework.Main.GameInfo.GetAddressOf
				(
					33862, 0x7C, 0,	// 0x2
					"75 3B"			// jne 3B
				);
			}

			static internal class EquipBestAmmo
			{
				/// <summary>InventoryChanges::GetWorstAmmo (SkyrimSE.exe + 0x1E3090)</summary>
				static public System.IntPtr CompareDamageContainer { get; }			= NetScriptFramework.Main.GameInfo.GetAddressOf
				(
					15846, 0x117, 0,    // 0x2
					"0F2F C6" +			// comiss xmm0, xmm6
					"73 06"				// jnb 06
				);

				/// <summary>InventoryChanges::GetWorstAmmo (SkyrimSE.exe + 0x1E3090)</summary>
				static public System.IntPtr CompareDamageInventoryChanges { get; }	= NetScriptFramework.Main.GameInfo.GetAddressOf
				(
					15846, 0x1DE, 0,    // 0x2
					"0F2F C6" +			// comiss xmm0, xmm6
					"73 10"				// jnb 10
				);

				/// <summary>InventoryChanges::GetWorstAmmo (SkyrimSE.exe + 0x1E3090)</summary>
				static public System.IntPtr InitializeDamage { get; }				= NetScriptFramework.Main.GameInfo.GetAddressOf
				(
					15846, 0x5F, 0,				// 0x8
					"F3 0F10 35 ?? ?? ?? ??"	// movss xmm6, cs
				);
			}

			static internal class LockpickingExperience
			{
				/// <summary>SkyrimSE.exe + 0x897E10</summary>
				static public System.IntPtr HasNotBeenUnlocked { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf
				(
					51088, 0x2C, 0,	// 0x2
					"75 50"			// jne 50
				);
			}

			static internal class MultipleHitEffects
			{
				/// <summary>SkyrimSE.exe + 0x5468E0</summary>
				static public System.IntPtr IsNotCostliestEffect { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf
				(
					33471, 0x15, 0,	// 0x2
					"74 0A"			// je 0A
				);
			}

			static internal class PausedGameHitEffects
			{
				/// <summary>SkyrimSE.exe + 0x5402D0</summary>
				static public System.IntPtr IsNotApplyingHitEffects { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf
				(
					33319, 0x37, 0,	// 0x2
					"74 3F"			// je 3F
				);
			}

			static internal class ReflectDamage
			{
				/// <summary>SkyrimSE.exe + 0x743510</summary>
				static public System.IntPtr CompareReflectDamage { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf
				(
					42842, 0x544, 0,	// 0x2
					"77 03"				// ja 3
				);
			}

			static internal class TeammateDifficulty
			{
				/// <summary>SkyrimSE.exe + 0x5E4800/summary>
				static public System.IntPtr IsPlayer { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf
				(
					36506, 0xB, 0,	// 0x5
					"BA 18000000"	// mov edx, 00000018
				);
			}

			static internal class UnderfilledSoulGems
			{
				/// <summary>SkyrimSE.exe + 0x1E5050</summary>
				static public System.IntPtr CompareSoulLevelValue { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf
				(
					15854, 0xE6, 0,	// 0x2
					"72 2E"			// jb 2E
				);
			}
		}
	}
}
