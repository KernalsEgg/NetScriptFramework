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
					static public System.IntPtr ApplyCombatHitSpellArrowProjectile { get; } = AddressLibrary.GetAddress
					(
						42547, 0x28B, new System.Byte?[] // 0x5
						{
							0xE8, null, null, null, null // call
						}
					);
				}
			}



			static internal class ActorValuePercentage
			{
				/// <summary>SkyrimSE.exe + 0x2D4C40</summary>
				static public System.IntPtr ActorValueCondition { get; } = AddressLibrary.GetAddress
				(
					20967, 0x27, new System.Byte?[]		// 0x5
					{
						0xE8, null, null, null, null	// call
					}
				);

				/// <summary>EnemyHealth::Update (SkyrimSE.exe + 0x882520)</summary>
				static public System.IntPtr ActorValueEnemyHealth { get; } = AddressLibrary.GetAddress
				(
					50776, 0xE1, new System.Byte?[]		// 0x5
					{
						0xE8, null, null, null, null	// call
					}
				);

				/// <summary>SkyrimSE.exe + 0x94ABB0</summary>
				static public System.IntPtr ActorValuePapyrus { get; } = AddressLibrary.GetAddress
				(
					53868, 0x4D, new System.Byte?[]		// 0x5
					{
						0xE8, null, null, null, null	// call
					}
				);

				/// <summary>SkyrimSE.exe + 0x2D9320</summary>
				static public System.IntPtr HealthCondition { get; } = AddressLibrary.GetAddress
				(
					21068, 0x20, new System.Byte?[]		// 0x5
					{
						0xE8, null, null, null, null	// call
					}
				);

				/// <summary>SkyrimSE.exe + 0x2D92A0</summary>
				static public System.IntPtr StaminaCondition { get; } = AddressLibrary.GetAddress
				(
					21067, 0x20, new System.Byte?[]		// 0x5
					{
						0xE8, null, null, null, null	// call
					}
				);
			}

			static internal class HarvestedFlags
			{
				/// <summary>TESObjectREFR::Respawn (SkyrimSE.exe + 0x278920)</summary>
				static public System.IntPtr RemoveHarvestedFlag { get; } = AddressLibrary.GetAddress
				(
					18843, 0x31C, new System.Byte?[] // 0x5
					{
						0xE8, null, null, null, null // call
					}
				);
			}

			static internal class HitEffectRaceCondition
			{
				/// <summary>ActiveEffect::ShouldUpdate (SkyrimSE.exe + 0x53E670)</summary>
				static public System.IntPtr ShouldUpdate { get; } = AddressLibrary.GetAddress
				(
					33289, 0x5A, new System.Byte[]	// 3 + 3 + 2 = 0x8
					{
						0xC1, 0xE8, 0x07,			// shr eax, 7
						0xA8, 0x01,					// test al, 1
						0x75, 0x1C					// jne 1C
					}
				);
			}

			static internal class MagicEffectConditions
			{
				/// <summary>ActiveEffect::UpdateConditions (SkyrimSE.exe + 0x53E3E0)</summary>
				static public System.IntPtr UpdateConditions { get; } = AddressLibrary.GetAddress
				(
					33287, 0xEA, new System.Byte[] // 3 + 4 + 4 + 6 + 2 + 4 + 3 + 3 + 2 + 3 + 3 + 3 + 2 + 4 + 3 + 4 + 4 + 4 + 6 + 2 + 4 + 3 + 3 + 2 + 3 + 3 + 3 + 2 + 4 + 3 + 3 + 6 = 0x6C
					{
						0x0F, 0x28, 0xD3,					// movaps xmm2, xmm3
						0xF3, 0x0F, 0x59, 0xD1,				// mulss xmm2, xmm1
						0xF3, 0x0F, 0x2C, 0xCA,				// cvttss2si ecx, xmm2
						0x81, 0xF9, 0x00, 0x00, 0x00, 0x80,	// cmp ecx, 80000000
						0x74, 0x1E,							// je 1E
						0x66, 0x0F, 0x6E, 0xC1,				// movd xmm0, ecx
						0x0F, 0x5B, 0xC0,					// cvtdq2ps xmm0, xmm0
						0x0F, 0x2E, 0xC2,					// ucomiss xmm0, xmm2
						0x74, 0x12,							// je 12
						0x0F, 0x14, 0xD2,					// unpcklps xmm2, xmm2
						0x0F, 0x50, 0xC2,					// movmskps eax, xmm2
						0x83, 0xE0, 0x01,					// and eax, 1
						0x2B, 0xC8,							// sub ecx, eax
						0x66, 0x0F, 0x6E, 0xD1,				// movd xmm2, ecx
						0x0F, 0x5B, 0xD2,					// cvtdq2ps xmm2, xmm2
						0xF3, 0x0F, 0x58, 0xCE,				// addss xmm1, xmm6
						0xF3, 0x0F, 0x59, 0xCB,				// mulss xmm1, xmm3
						0xF3, 0x0F, 0x2C, 0xC9,				// cvttss2si ecx, xmm1
						0x81, 0xF9, 0x00, 0x00, 0x00, 0x80,	// cmp ecx, 80000000
						0x74, 0x1E,							// je 1E
						0x66, 0x0F, 0x6E, 0xC1,				// movd xmm0, ecx
						0x0F, 0x5B, 0xC0,					// cvtdq2ps xmm0, xmm0
						0x0F, 0x2E, 0xC1,					// ucomiss xmm0, xmm1
						0x74, 0x12,							// je 12
						0x0F, 0x14, 0xC9,					// unpcklps xmm1, xmm1
						0x0F, 0x50, 0xC1,					// movmskps eax, xmm1
						0x83, 0xE0, 0x01,					// and eax, 1
						0x2B, 0xC8,							// sub ecx, eax
						0x66, 0x0F, 0x6E, 0xC9,				// movd xmm1, ecx
						0x0F, 0x5B, 0xC9,					// cvtdq2ps xmm1, xmm1
						0x0F, 0x2E, 0xD1,					// ucomiss xmm2, xmm1
						0x0F, 0x84, 0x87, 0x00, 0x00, 0x00	// je 87
					}
				);
			}

			static internal class MagicEffectFlags
			{
				/// <summary>ActiveEffect::ResetElapsedTime (SkyrimSE.exe + 0x53E1B0)</summary>
				static public System.IntPtr ResetEffectiveness { get; } = AddressLibrary.GetAddress
				(
					33283, 0x105, new System.Byte?[] // 0x5
					{
						0xE8, null, null, null, null // call
					}
				);

				/// <summary>ActiveEffect::SetEffectiveness (SkyrimSE.exe + 0x53DEB0)</summary>
				static public System.IntPtr SetEffectiveness { get; } = AddressLibrary.GetAddress
				(
					33277, 0x68, new System.Byte?[]		// 0x5
					{
						0xE8, null, null, null, null	// call
					}
				);
			}

			static internal class ModArmorWeightPerkEntryPoint
			{
				/// <summary>TESObjectREFR::GetInventoryWeight (SkyrimSE.exe + 0x1E9130)</summary>
				static public System.IntPtr ModArmorWeightContainer { get; } = AddressLibrary.GetAddress
				(
					15883, 0x159, new System.Byte[]	// 3 + 2 = 0x5
					{
						0x8B, 0x55, 0x10,			// mov edx, [rbp+10]
						0x8B, 0x00					// mov eax, [rax]
					}
				);

				/// <summary>TESObjectREFR::GetInventoryWeight (SkyrimSE.exe + 0x1E9130)</summary>
				static public System.IntPtr ModArmorWeightInventoryChanges { get; } = AddressLibrary.GetAddress
				(
					15883, 0x29F, new System.Byte?[]							// 5 + 9 + 4 = 0x12
					{
						0xE8, null, null, null, null,							// call
						0xF3, 0x0F, 0x10, 0x8C, 0x24, 0xB0, 0x00, 0x00, 0x00,	// movss xmm1, [rsp+B0]
						0xF3, 0x0F, 0x58, 0xF1									// addss xmm6, xmm1
					}
				);
			}

			static internal class MovementSpeed
			{
				/// <summary>SkyrimSE.exe + 0x2F39A40</summary>
				static public System.IntPtr ActorValueSinkFunctionTable { get; } = AddressLibrary.GetAddress(517376);

				/// <summary>SkyrimSE.exe + 0x5ED420</summary>
				static public System.IntPtr RemoveMovementFlags { get; } = AddressLibrary.GetAddress(36585);

				/// <summary>SkyrimSE.exe + 0x2F266F8</summary>
				static public System.IntPtr SaveManager { get; } = AddressLibrary.GetAddress(516851);
			}

			static internal class QuickShot
			{
				/// <summary>SkyrimSE.exe + 0x74B170</summary>
				static public System.IntPtr CreateProjectile { get; } = AddressLibrary.GetAddress
				(
					42928, 0x604, new System.Byte?[] // 0x5
					{
						0xE8, null, null, null, null // call
					}
				);

				/// <summary>SkyrimSE.exe + 0x6CE720</summary>
				static public System.IntPtr KillCamera { get; } = AddressLibrary.GetAddress
				(
					40230, 0x87C, new System.Byte?[] // 0x5
					{
						0xE8, null, null, null, null // call
					}
				);
			}

			static internal class TerrainDecals
			{
				/// <summary>SkyrimSE.exe + 0x271BE0</summary>
				static public System.IntPtr UnloadHavokData { get; } = AddressLibrary.GetAddress
				(
					18711, 0xE7, new System.Byte?[]		// 0x5
					{
						0xE9, null, null, null, null	// jmp
					}
				);
			}

			static internal class TrainingMenuText
			{
				/// <summary>TrainingMenu::UpdateText (SkyrimSE.exe + 0x8CEA30)</summary>
				static public System.IntPtr GetPermanentActorValue { get; } = AddressLibrary.GetAddress
				(
					51794, 0x289, new System.Byte[]	// 0x3
					{
						0xFF, 0x50, 0x10			// call [rax+10]
					}
				);
			}

			static internal class WeaponCharge
			{
				/// <summary>SkyrimSE.exe + 0x6AE010</summary>
				static public System.IntPtr RemoveEquippedItemFlags { get; } = AddressLibrary.GetAddress(39498);

				/// <summary>SkyrimSE.exe + 0x86C640</summary>
				static public System.IntPtr Enchant { get; } = AddressLibrary.GetAddress
				(
					50450, 0x17E, new System.Byte?[] // 0x5
					{
						0xE8, null, null, null, null // call
					}
				);

				/// <summary>SkyrimSE.exe + 0x60B9E0</summary>
				static public System.IntPtr Equip { get; } = AddressLibrary.GetAddress
				(
					36976, 0x303, new System.Byte?[] // 0x5
					{
						0xE8, null, null, null, null // call
					}
				);

				/// <summary>SkyrimSE.exe + 0x88E890</summary>
				static public System.IntPtr Recharge { get; } = AddressLibrary.GetAddress
				(
					50980, 0x222, new System.Byte?[] // 0x5
					{
						0xE8, null, null, null, null // call
					}
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
					static public System.IntPtr ApplyBashingSpell { get; } = AddressLibrary.GetAddress
					(
						37673, 0x429, new System.Byte?[] // 0x5
						{
							0xE8, null, null, null, null // call
						}
					);

					/// <summary>Actor::ApplyWeaponHitSpells (SkyrimSE.exe + 0x6310A0)</summary>
					static public System.IntPtr ApplyCombatHitSpell { get; } = AddressLibrary.GetAddress
					(
						37799, 0x79, new System.Byte?[]		// 0x5
						{
							0xE8, null, null, null, null	// call
						}
					);

					/// <summary>ArrowProjectile::GetImpactData (SkyrimSE.exe + 0x732400)</summary>
					static public System.IntPtr ApplyCombatHitSpellArrowProjectile { get; } = AddressLibrary.GetAddress
					(
						42547, 0x2A7, new System.Byte?[] // 0x5
						{
							0xE8, null, null, null, null // call
						}
					);

					/// <summary>ReanimateEffect::GetUp (SkyrimSE.exe + 0x634BF0)</summary>
					static public System.IntPtr ApplyReanimateSpell { get; } = AddressLibrary.GetAddress
					(
						37865, 0xD2, new System.Byte?[] // 0x5
						{
							0xE8, null, null, null, null // call
						}
					);

					/// <summary>Actor::WeaponSwing (SkyrimSE.exe + 0x6260F0)</summary>
					static public System.IntPtr ApplyWeaponSwingSpell { get; } = AddressLibrary.GetAddress
					(
						37628, 0xC3, new System.Byte?[]		// 0x5
						{
							0xE8, null, null, null, null	// call
						}
					);
				}

				static internal class MultipleSpells
				{
					/// <summary>Actor::WeaponHit (SkyrimSE.exe + 0x628C20)</summary>
					static public System.IntPtr ApplyBashingSpell { get; } = AddressLibrary.GetAddress
					(
						37673, 0x40E, new System.Byte?[] // 0x5
						{
							0xE8, null, null, null, null // call
						}
					);

					/// <summary>Actor::ApplyWeaponHitSpells (SkyrimSE.exe + 0x6310A0)</summary>
					static public System.IntPtr ApplyCombatHitSpell { get; } = AddressLibrary.GetAddress
					(
						37799, 0x61, new System.Byte?[]		// 0x5
						{
							0xE8, null, null, null, null	// call
						}
					);

					/// <summary>ArrowProjectile::GetImpactData (SkyrimSE.exe + 0x732400)</summary>
					static public System.IntPtr ApplyCombatHitSpellArrowProjectile { get; } = AddressLibrary.GetAddress
					(
						42547, 0x28B, new System.Byte?[] // 0x5
						{
							0xE8, null, null, null, null // call
						}
					);

					/// <summary>ReanimateEffect::GetUp (SkyrimSE.exe + 0x634BF0)</summary>
					static public System.IntPtr ApplyReanimateSpell { get; } = AddressLibrary.GetAddress
					(
						37865, 0xBA, new System.Byte?[]		// 0x5
						{
							0xE8, null, null, null, null	// call
						}
					);

					/// <summary>Actor::SetSneaking (SkyrimSE.exe + 0x6089E0)</summary>
					static public System.IntPtr ApplySneakingSpell { get; } = AddressLibrary.GetAddress
					(
						36926, 0xB6, new System.Byte?[]		// 0x5
						{
							0xE8, null, null, null, null	// call
						}
					);

					/// <summary>Actor::WeaponSwing (SkyrimSE.exe + 0x6260F0)</summary>
					static public System.IntPtr ApplyWeaponSwingSpell { get; } = AddressLibrary.GetAddress
					(
						37628, 0xAB, new System.Byte?[]		// 0x5
						{
							0xE8, null, null, null, null	// call
						}
					);

					/// <summary>SkyrimSE.exe + 0x1DD3B20</summary>
					static public System.IntPtr SelectSpell { get; } = AddressLibrary.GetAddress(675819);

					/// <summary>SkyrimSE.exe + 0x1DD3BB0</summary>
					static public System.IntPtr SelectSpellResultCount { get; } = AddressLibrary.GetAddress(502190);
				}
			}



			static internal class AccumulatingMagnitude
			{
				/// <summary>AccumulatingValueModifierEffect::UpdateActorValue (SkyrimSE.exe + 0x53D770)</summary>
				static public System.IntPtr GetMaximumWardPower { get; } = AddressLibrary.GetAddress
				(
					33265, 0x91, new System.Byte?[]		// 0x5
					{
						0xE8, null, null, null, null	// call
					}
				);

				/// <summary>FindMaxMagnitudeVisitor::Visit (SkyrimSE.exe + 0x53D910)</summary>
				static public System.IntPtr GetMaximumMagnitude { get; } = AddressLibrary.GetAddress
				(
					33268, 0x35, new System.Byte[]						// 0x8
					{
						0xF3, 0x0F, 0x10, 0x83, 0x9C, 0x00, 0x00, 0x00	// movss xmm0, [rbx+9C]
					}
				);

				/// <summary>AccumulatingValueModifierEffect::UpdateActorValue (SkyrimSE.exe + 0x53D770)</summary>
				static public System.IntPtr GetMaximumMagnitudeAndRate { get; } = AddressLibrary.GetAddress
				(
					33265, 0x7D, new System.Byte[]						// 3 + 4 + 8 = 0xF
					{
						0x0F, 0x28, 0xF0,								// movaps xmm6, xmm0
						0xF3, 0x0F, 0x59, 0xF7,							// mulss xmm6, xmm7
						0xF3, 0x0F, 0x10, 0xBB, 0x9C, 0x00, 0x00, 0x00	// movss xmm7, [rbx+9C]
					}
				);

				/// <summary>AccumulatingValueModifierEffect::Constructor (SkyrimSE.exe + 0x53D2B0)</summary>
				static public System.IntPtr SetMaximumMagnitude { get; } = AddressLibrary.GetAddress
				(
					33256, 0x4C, new System.Byte[]						// 0x8
					{
						0xF3, 0x0F, 0x11, 0x87, 0x9C, 0x00, 0x00, 0x00	// movss [rdi+9C], xmm0
					}
				);

				/// <summary>AccumulatingValueModifierEffect::Constructor (SkyrimSE.exe + 0x53D2B0)</summary>
				static public System.IntPtr SetRate { get; } = AddressLibrary.GetAddress
				(
					33256, 0x8A, new System.Byte?[]						// 3 + 8 + 6 + 5 + 5 = 0x1B
					{
						0x0F, 0x28, 0xD0,								// movaps xmm2, xmm0
						0xF3, 0x0F, 0x10, 0x8F, 0x9C, 0x00, 0x00, 0x00,	// movss xmm1, [rdi+9C]
						0x8B, 0x8F, 0x90, 0x00, 0x00, 0x00,				// mov ecx, [rdi+90]
						0xE8, null, null, null, null,					// call
						0xF3, 0x0F, 0x11, 0x47, 0x78					// movss [rdi+78], xmm0
					}
				);
			}

			static internal class AlreadyCaughtPickpocketing
			{
				/// <summary>TESNPC::Activate (SkyrimSE.exe + 0x360C10)</summary>
				static public System.IntPtr IsAttackingOnSight { get; } = AddressLibrary.GetAddress
				(
					24211, 0x678, new System.Byte[]	// 0x2
					{
						0x75, 0x2E					// jne 2E
					}
				);

				/// <summary>TESNPC::Activate (SkyrimSE.exe + 0x360C10)</summary>
				static public System.IntPtr IsNotKnockedDown { get; } = AddressLibrary.GetAddress
				(
					24211, 0x684, new System.Byte[]	// 0x2
					{
						0x75, 0x10					// jne 10
					}
				);
			}

			static internal class AttachHitEffectArt
			{
				/// <summary>SkyrimSE.exe + 0x6314F0</summary>
				static public System.IntPtr AddNoHitEffectArtFlag { get; } = AddressLibrary.GetAddress
				(
					37804, 0x6F, new System.Byte[]	// 2 + 2 = 0x4
					{
						0x24, 0xF9,					// and al, F9
						0x0C, 0x01					// or al, 1
					}
				);

				/// <summary>ModelReferenceEffect::UpdatePosition (SkyrimSE.exe + 0x558220)</summary>
				static public System.IntPtr IsPerspectiveChange { get; } = AddressLibrary.GetAddress
				(
					33862, 0x9A, new System.Byte[]	// 0x2
					{
						0x74, 0x08					// je 8
					}
				);

				/// <summary>ModelReferenceEffect::Attach (SkyrimSE.exe + 0x558F20)</summary>
				static public System.IntPtr IsPlayerAttach { get; } = AddressLibrary.GetAddress
				(
					33872, 0x2B, new System.Byte?[]					// 7 + 2 = 0x9
					{
						0x48, 0x3B, 0x05, null, null, null, null,	// cmp rax, cs
						0x75, 0x55									// jne 55
					}
				);

				/// <summary>ModelReferenceEffect::UpdatePosition (SkyrimSE.exe + 0x558220)</summary>
				static public System.IntPtr IsPlayerUpdatePosition { get; } = AddressLibrary.GetAddress
				(
					33862, 0x7C, new System.Byte[]	// 0x2
					{
						0x75, 0x3B					// jne 3B
					}
				);
			}

			static internal class EquipBestAmmo
			{
				/// <summary>InventoryChanges::GetWorstAmmo (SkyrimSE.exe + 0x1E3090)</summary>
				static public System.IntPtr CompareDamageContainer { get; } = AddressLibrary.GetAddress
				(
					15846, 0x117, new System.Byte[]	// 0x2
					{
						0x0F, 0x2F, 0xC6,			// comiss xmm0, xmm6
						0x73, 0x06					// jnb 6
					}
				);

				/// <summary>InventoryChanges::GetWorstAmmo (SkyrimSE.exe + 0x1E3090)</summary>
				static public System.IntPtr CompareDamageInventoryChanges { get; } = AddressLibrary.GetAddress
				(
					15846, 0x1DE, new System.Byte[]	// 0x2
					{
						0x0F, 0x2F, 0xC6,			// comiss xmm0, xmm6
						0x73, 0x10					// jnb 10
					}
				);

				/// <summary>InventoryChanges::GetWorstAmmo (SkyrimSE.exe + 0x1E3090)</summary>
				static public System.IntPtr InitializeDamage { get; } = AddressLibrary.GetAddress
				(
					15846, 0x5F, new System.Byte?[]						// 0x8
					{
						0xF3, 0x0F, 0x10, 0x35, null, null, null, null	// movss xmm6, cs
					}
				);
			}

			static internal class LockpickingExperience
			{
				/// <summary>SkyrimSE.exe + 0x897E10</summary>
				static public System.IntPtr HasNotBeenUnlocked { get; } = AddressLibrary.GetAddress
				(
					51088, 0x2C, new System.Byte[]	// 0x2
					{
						0x75, 0x50					// jne 50
					}
				);
			}

			static internal class MultipleHitEffects
			{
				/// <summary>SkyrimSE.exe + 0x5468E0</summary>
				static public System.IntPtr IsNotCostliestEffect { get; } = AddressLibrary.GetAddress
				(
					33471, 0x15, new System.Byte[]	// 0x2
					{
						0x74, 0x0A					// je A
					}
				);
			}

			static internal class PausedGameHitEffects
			{
				/// <summary>SkyrimSE.exe + 0x5402D0</summary>
				static public System.IntPtr IsNotApplyingHitEffects { get; } = AddressLibrary.GetAddress
				(
					33319, 0x37, new System.Byte[]	// 0x2
					{
						0x74, 0x3F					// je 3F
					}
				);
			}

			static internal class PowerAttackStamina
			{
				/// <summary>SkyrimSE.exe + 0x80C020</summary>
				static public System.IntPtr GetStaminaCostActor { get; } = AddressLibrary.GetAddress
				(
					48139, 0x29B, new System.Byte?[] // 0x5
					{
						0xE8, null, null, null, null // call
					}
				);

				/// <summary>SkyrimSE.exe + 0x63CFB0</summary>
				static public System.IntPtr GetStaminaCostPlayerCharacter { get; } = AddressLibrary.GetAddress
				(
					38047, 0xBB, new System.Byte?[]		// 0x5
					{
						0xE8, null, null, null, null	// call
					}
				);

				/// <summary>SkyrimSE.exe + 0x80C020</summary>
				static public System.IntPtr HasStaminaActor { get; } = AddressLibrary.GetAddress
				(
					48139, 0x293, new System.Byte[]	// 0x2
					{
						0x75, 0x10					// jnz 10
					}
				);

				/// <summary>SkyrimSE.exe + 0x80C020</summary>
				static public System.IntPtr HasStaminaCostActor { get; } = AddressLibrary.GetAddress
				(
					48139, 0x2A0, new System.Byte[]	// 3 + 2 = 0x5
					{
						0x0F, 0x2F, 0xC7,			// comiss xmm0, xmm7
						0x77, 0x6E					// ja 6E
					}
				);

				/// <summary>SkyrimSE.exe + 0x63CFB0</summary>
				static public System.IntPtr HasStaminaCostPlayerCharacter { get; } = AddressLibrary.GetAddress
				(
					38047, 0xC3, new System.Byte[]	// 3 + 2 = 0x5
					{
						0x0F, 0x2F, 0xC6,			// comiss xmm0, xmm6
						0x76, 0x34					// jbe 34
					}
				);

				/// <summary>SkyrimSE.exe + 0x63CFB0</summary>
				static public System.IntPtr HasStaminaPlayerCharacter { get; } = AddressLibrary.GetAddress
				(
					38047, 0xE1, new System.Byte[]	// 0x2
					{
						0x77, 0x19					// ja 19
					}
				);
			}

			static internal class ReflectDamage
			{
				/// <summary>SkyrimSE.exe + 0x743510</summary>
				static public System.IntPtr CompareReflectDamage { get; } = AddressLibrary.GetAddress
				(
					42842, 0x544, new System.Byte[]	// 0x2
					{
						0x77, 0x03					// ja 3
					}
				);
			}

			static internal class TeammateDifficulty
			{
				/// <summary>SkyrimSE.exe + 0x5E4800/summary>
				static public System.IntPtr IsPlayer { get; } = AddressLibrary.GetAddress
				(
					36506, 0xB, new System.Byte[]		// 0x5
					{
						0xBA, 0x18, 0x00, 0x00, 0x00	// mov edx, 18
					}
				);
			}

			static internal class UnderfilledSoulGems
			{
				/// <summary>SkyrimSE.exe + 0x1E5050</summary>
				static public System.IntPtr CompareSoulLevelValue { get; } = AddressLibrary.GetAddress
				(
					15854, 0xE6, new System.Byte[]	// 0x2
					{
						0x72, 0x2E					// jb 2E
					}
				);
			}
		}
	}
}
