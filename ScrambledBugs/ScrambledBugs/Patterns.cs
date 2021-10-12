using Eggstensions;



namespace ScrambledBugs
{
	namespace Patterns
	{
		namespace Fixes
		{
			namespace ApplySpellPerkEntryPoints
			{
				static internal class Arrows
				{
					static public System.Boolean ApplyCombatHitSpellArrowProjectile
					{
						get
						{
							return AddressLibrary.MatchPattern
							(
								ScrambledBugs.Offsets.Fixes.ApplySpellPerkEntryPoints.Arrows.ApplyCombatHitSpellArrowProjectile,
								new System.Byte?[5]
								{
									0xE8, null, null, null, null // call BGSEntryPointPerkEntry.HandleEntryPoints
								}
							);
						}
					}
				}
			}



			static internal class ActorValuePercentage
			{
				static public System.Boolean ActorValueCondition
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Fixes.ActorValuePercentage.ActorValueCondition,
							new System.Byte?[5]
							{
								0xE8, null, null, null, null // call Actor.GetActorValuePercentage
							}
						);
					}
				}

				static public System.Boolean ActorValueEnemyHealth
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Fixes.ActorValuePercentage.ActorValueEnemyHealth,
							new System.Byte?[5]
							{
								0xE8, null, null, null, null // call Actor.GetActorValuePercentage
							}
						);
					}
				}

				static public System.Boolean ActorValuePapyrus
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Fixes.ActorValuePercentage.ActorValuePapyrus,
							new System.Byte?[5]
							{
								0xE8, null, null, null, null // call Actor.GetActorValuePercentage
							}
						);
					}
				}

				static public System.Boolean HealthCondition
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Fixes.ActorValuePercentage.HealthCondition,
							new System.Byte?[5]
							{
								0xE8, null, null, null, null // call Actor.GetHealthPercentage
							}
						);
					}
				}

				static public System.Boolean StaminaCondition
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Fixes.ActorValuePercentage.StaminaCondition,
							new System.Byte?[5]
							{
								0xE8, null, null, null, null // call Actor.GetStaminaPercentage
							}
						);
					}
				}
			}

			static internal class HarvestedFlags
			{
				static public System.Boolean RemoveHarvestedFlag
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Fixes.HarvestedFlags.RemoveHarvestedFlag,
							new System.Byte?[5]
							{
								0xE8, null, null, null, null // call TESObjectREFR.SetHarvestedFlag
							}
						);
					}
				}
			}

			static internal class HitEffectRaceCondition
			{
				static public System.Boolean ShouldUpdate
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Fixes.HitEffectRaceCondition.ShouldUpdate,
							new System.Byte[3 + 2 + 2] // 0x7
							{
								0xC1, 0xE8, 0x07,	// shr eax, 7
								0xA8, 0x01,			// test al, 1
								0x75, 0x1C			// jne 1C
							}
						);
					}
				}
			}

			static internal class MagicEffectConditions
			{
				static public System.Boolean UpdateConditions
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Fixes.MagicEffectConditions.UpdateConditions,
							new System.Byte[3 + 4 + 4 + 6 + 2 + 4 + 3 + 3 + 2 + 3 + 3 + 3 + 2 + 4 + 3 + 4 + 4 + 4 + 6 + 2 + 4 + 3 + 3 + 2 + 3 + 3 + 3 + 2 + 4 + 3 + 3 + 6] // 0x6C
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
				}
			}

			static internal class MagicEffectFlags
			{
				static public System.Boolean ResetEffectiveness
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Fixes.MagicEffectFlags.ResetEffectiveness,
							new System.Byte?[5]
							{
								0xE8, null, null, null, null // call ActiveEffect.SetEffectiveness
							}
						);
					}
				}

				static public System.Boolean SetEffectiveness
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Fixes.MagicEffectFlags.SetEffectiveness,
							new System.Byte?[5]
							{
								0xE8, null, null, null, null // call ActiveEffect.SetEffectiveness
							}
						);
					}
				}
			}

			static internal class ModArmorWeightPerkEntryPoint
			{
				static public System.Boolean ModArmorWeightContainer
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Fixes.ModArmorWeightPerkEntryPoint.ModArmorWeightContainer,
							new System.Byte[3 + 2] // 0x5
							{
								0x8B, 0x55, 0x10,	// mov edx, [rbp+10]
								0x8B, 0x00			// mov eax, [rax]
							}
						);
					}
				}

				static public System.Boolean ModArmorWeightInventoryChanges
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Fixes.ModArmorWeightPerkEntryPoint.ModArmorWeightInventoryChanges,
							new System.Byte?[5 + 9 + 4] // 0x12
							{
								0xE8, null, null, null, null,							// call BGSEntryPointPerkEntry.HandleEntryPoints
								0xF3, 0x0F, 0x10, 0x8C, 0x24, 0xB0, 0x00, 0x00, 0x00,	// movss xmm1, [rsp+B0]
								0xF3, 0x0F, 0x58, 0xF1									// addss xmm6, xmm1
							}
						);
					}
				}
			}

			static internal class QuickShot
			{
				static public System.Boolean CreateProjectile
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Fixes.QuickShot.CreateProjectile,
							new System.Byte?[5]
							{
								0xE8, null, null, null, null // call ArrowProjectile.GetArrowPower
							}
						);
					}
				}

				static public System.Boolean KillCamera
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Fixes.QuickShot.KillCamera,
							new System.Byte?[5]
							{
								0xE8, null, null, null, null // call ArrowProjectile.GetArrowPower
							}
						);
					}
				}
			}

			static internal class SpeedMultUpdates
			{
				static public System.Boolean SpeedMultSink
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Fixes.SpeedMultUpdates.ActorValueSinkFunctionTable + System.Runtime.CompilerServices.Unsafe.SizeOf<System.IntPtr>() * (System.Int32)ActorValue.SpeedMult,
							new System.Byte[8]
							{
								0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 // null
							}
						);
					}
				}
			}

			static internal class TerrainDecals
			{
				static public System.Boolean UnloadHavokData
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Fixes.TerrainDecals.UnloadHavokData,
							new System.Byte?[5]
							{
								0xE9, null, null, null, null // jmp
							}
						);
					}
				}
			}

			static internal class TrainingMenuText
			{
				static public System.Boolean GetPermanentActorValue
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Fixes.TrainingMenuText.GetPermanentActorValue,
							new System.Byte[3]
							{
								0xFF, 0x50, 0x10 // call [rax+10] (ActorValueOwner.GetPermanentActorValue)
							}
						);
					}
				}
			}

			static internal class WeaponCharge
			{
				static public System.Boolean Enchant
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Fixes.WeaponCharge.Enchant,
							new System.Byte?[5]
							{
								0xE8, null, null, null, null // call Actor.HandleEquippedItem
							}
						);
					}
				}

				static public System.Boolean Equip
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Fixes.WeaponCharge.Equip,
							new System.Byte?[5]
							{
								0xE8, null, null, null, null // call Actor.HandleEquippedItem
							}
						);
					}
				}

				static public System.Boolean Recharge
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Fixes.WeaponCharge.Recharge,
							new System.Byte?[5]
							{
								0xE8, null, null, null, null // call Actor.HandleEquippedItem
							}
						);
					}
				}
			}
		}

		namespace Patches
		{
			namespace ApplySpellPerkEntryPoints
			{
				static internal class CastSpells
				{
					static public System.Boolean ApplyBashingSpell
					{
						get
						{
							return AddressLibrary.MatchPattern
							(
								ScrambledBugs.Offsets.Patches.ApplySpellPerkEntryPoints.CastSpells.ApplyBashingSpell,
								new System.Byte?[5]
								{
									0xE8, null, null, null, null // call Actor.ApplySpell
								}
							);
						}
					}

					static public System.Boolean ApplyCombatHitSpell
					{
						get
						{
							return AddressLibrary.MatchPattern
							(
								ScrambledBugs.Offsets.Patches.ApplySpellPerkEntryPoints.CastSpells.ApplyCombatHitSpell,
								new System.Byte?[5]
								{
									0xE8, null, null, null, null // call Actor.ApplySpell
								}
							);
						}
					}

					static public System.Boolean ApplyCombatHitSpellArrowProjectile
					{
						get
						{
							return AddressLibrary.MatchPattern
							(
								ScrambledBugs.Offsets.Patches.ApplySpellPerkEntryPoints.CastSpells.ApplyCombatHitSpellArrowProjectile,
								new System.Byte?[5]
								{
									0xE8, null, null, null, null // call Actor.ApplySpell
								}
							);
						}
					}

					static public System.Boolean ApplyReanimateSpell
					{
						get
						{
							return AddressLibrary.MatchPattern
							(
								ScrambledBugs.Offsets.Patches.ApplySpellPerkEntryPoints.CastSpells.ApplyReanimateSpell,
								new System.Byte?[5]
								{
									0xE8, null, null, null, null // call Actor.ApplySpell
								}
							);
						}
					}

					static public System.Boolean ApplyWeaponSwingSpell
					{
						get
						{
							return AddressLibrary.MatchPattern
							(
								ScrambledBugs.Offsets.Patches.ApplySpellPerkEntryPoints.CastSpells.ApplyWeaponSwingSpell,
								new System.Byte?[5]
								{
									0xE8, null, null, null, null // call Actor.ApplySpell
								}
							);
						}
					}
				}

				static internal class MultipleSpells
				{
					static public System.Boolean ApplyBashingSpell
					{
						get
						{
							return AddressLibrary.MatchPattern
							(
								ScrambledBugs.Offsets.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplyBashingSpell,
								new System.Byte?[5]
								{
									0xE8, null, null, null, null // call BGSEntryPointPerkEntry.HandleEntryPoints
								}
							);
						}
					}

					static public System.Boolean ApplyCombatHitSpell
					{
						get
						{
							return AddressLibrary.MatchPattern
							(
								ScrambledBugs.Offsets.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplyCombatHitSpell,
								new System.Byte?[5]
								{
									0xE8, null, null, null, null // call BGSEntryPointPerkEntry.HandleEntryPoints
								}
							);
						}
					}

					static public System.Boolean ApplyCombatHitSpellArrowProjectile
					{
						get
						{
							return AddressLibrary.MatchPattern
							(
								ScrambledBugs.Offsets.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplyCombatHitSpellArrowProjectile,
								new System.Byte?[5]
								{
									0xE8, null, null, null, null // call BGSEntryPointPerkEntry.HandleEntryPoints
								}
							);
						}
					}

					static public System.Boolean ApplyReanimateSpell
					{
						get
						{
							return AddressLibrary.MatchPattern
							(
								ScrambledBugs.Offsets.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplyReanimateSpell,
								new System.Byte?[5]
								{
									0xE8, null, null, null, null // call BGSEntryPointPerkEntry.HandleEntryPoints
								}
							);
						}
					}

					static public System.Boolean ApplySneakingSpell
					{
						get
						{
							return AddressLibrary.MatchPattern
							(
								ScrambledBugs.Offsets.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplySneakingSpell,
								new System.Byte?[5]
								{
									0xE8, null, null, null, null // call BGSEntryPointPerkEntry.HandleEntryPoints
								}
							);
						}
					}

					static public System.Boolean ApplyWeaponSwingSpell
					{
						get
						{
							return AddressLibrary.MatchPattern
							(
								ScrambledBugs.Offsets.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplyWeaponSwingSpell,
								new System.Byte?[5]
								{
									0xE8, null, null, null, null // call BGSEntryPointPerkEntry.HandleEntryPoints
								}
							);
						}
					}
				}
			}



			static internal class AccumulatingMagnitude
			{
				static public System.Boolean GetMaximumMagnitude
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Patches.AccumulatingMagnitude.GetMaximumMagnitude,
							new System.Byte[8]
							{
								0xF3, 0x0F, 0x10, 0x83, 0x9C, 0x00, 0x00, 0x00 // movss xmm0, [rbx+9C]
							}
						);
					}
				}

				static public System.Boolean GetMaximumMagnitudeAndRate
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Patches.AccumulatingMagnitude.GetMaximumMagnitudeAndRate,
							new System.Byte[3 + 4 + 8] // 0xF
							{
								0x0F, 0x28, 0xF0,								// movaps xmm6, xmm0
								0xF3, 0x0F, 0x59, 0xF7,							// mulss xmm6, xmm7
								0xF3, 0x0F, 0x10, 0xBB, 0x9C, 0x00, 0x00, 0x00	// movss xmm7, [rbx+9C]
							}
						);
					}
				}

				static public System.Boolean GetMaximumWardPower
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Patches.AccumulatingMagnitude.GetMaximumWardPower,
							new System.Byte?[5]
							{
								0xE8, null, null, null, null // call Actor.GetMaximumWardPower
							}
						);
					}
				}

				static public System.Boolean SetMaximumMagnitude
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Patches.AccumulatingMagnitude.SetMaximumMagnitude,
							new System.Byte[8]
							{
								0xF3, 0x0F, 0x11, 0x87, 0x9C, 0x00, 0x00, 0x00 // movss [rdi+9C], xmm0
							}
						);
					}
				}

				static public System.Boolean SetRate
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Patches.AccumulatingMagnitude.SetRate,
							new System.Byte?[3 + 8 + 6 + 5 + 5] // 0x1B
							{
								0x0F, 0x28, 0xD0,								// movaps xmm2, xmm0
								0xF3, 0x0F, 0x10, 0x8F, 0x9C, 0x00, 0x00, 0x00,	// movss xmm1, [rdi+9C]
								0x8B, 0x8F, 0x90, 0x00, 0x00, 0x00,				// mov ecx, [rdi+90]
								0xE8, null, null, null, null,					// call AccumulatingValueModifierEffect.GetRate
								0xF3, 0x0F, 0x11, 0x47, 0x78					// movss [rdi+78], xmm0
							}
						);
					}
				}
			}

			static internal class AlreadyCaughtPickpocketing
			{
				static public System.Boolean IsAttackingOnSight
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Patches.AlreadyCaughtPickpocketing.IsAttackingOnSight,
							new System.Byte[2]
							{
								0x75, 0x2E // jne 2E
							}
						);
					}
				}

				static public System.Boolean IsNotKnockedDown
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Patches.AlreadyCaughtPickpocketing.IsNotKnockedDown,
							new System.Byte[2]
							{
								0x75, 0x10 // jne 10
							}
						);
					}
				}
			}

			static internal class AttachHitEffectArt
			{
				static public System.Boolean AddNoHitEffectArtFlag
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Patches.AttachHitEffectArt.AddNoHitEffectArtFlag,
							new System.Byte[2 + 2] // 0x4
							{
								0x24, 0xF9,	// and al, F9
								0x0C, 0x01	// or al, 1
							}
						);
					}
				}

				static public System.Boolean IsPerspectiveChange
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Patches.AttachHitEffectArt.IsPerspectiveChange,
							new System.Byte[2]
							{
								0x74, 0x08 // je 8
							}
						);
					}
				}

				static public System.Boolean IsPlayerAttach
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Patches.AttachHitEffectArt.IsPlayerAttach,
							new System.Byte?[7 + 2] // 0x9
							{
								0x48, 0x3B, 0x05, null, null, null, null,	// cmp rax, cs
								0x75, 0x55									// jne 55
							}
						);
					}
				}

				static public System.Boolean IsPlayerUpdatePosition
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Patches.AttachHitEffectArt.IsPlayerUpdatePosition,
							new System.Byte[2]
							{
								0x75, 0x3B // jne 3B
							}
						);
					}
				}
			}

			static internal class EquipBestAmmo
			{
				static public System.Boolean CompareDamageContainer
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Patches.EquipBestAmmo.CompareDamageContainer,
							new System.Byte[3 + 2] // 0x5
							{
								0x0F, 0x2F, 0xC6,	// comiss xmm0, xmm6
								0x73, 0x06			// jnb 6
							}
						);
					}
				}

				static public System.Boolean CompareDamageInventoryChanges
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Patches.EquipBestAmmo.CompareDamageInventoryChanges,
							new System.Byte[3 + 2] // 0x5
							{
								0x0F, 0x2F, 0xC6,	// comiss xmm0, xmm6
								0x73, 0x10			// jnb 10
							}
						);
					}
				}

				static public System.Boolean InitializeDamage
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Patches.EquipBestAmmo.InitializeDamage,
							new System.Byte?[8]
							{
								0xF3, 0x0F, 0x10, 0x35, null, null, null, null // movss xmm6, cs
							}
						);
					}
				}
			}

			static internal class LeveledCharacters
			{
				static public System.Boolean IsVeryHard
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Patches.LeveledCharacters.IsVeryHard,
							new System.Byte[2]
							{
								0x74, 0x0C // jz C
							}
						);
					}
				}
			}

			static internal class LockpickingExperience
			{
				static public System.Boolean HasNotBeenUnlocked
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Patches.LockpickingExperience.HasNotBeenUnlocked,
							new System.Byte[2]
							{
								0x75, 0x50 // jne 50
							}
						);
					}
				}
			}

			static internal class MultipleHitEffects
			{
				static public System.Boolean IsNotCostliestEffect
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Patches.MultipleHitEffects.IsNotCostliestEffect,
							new System.Byte[2]
							{
								0x74, 0x0A // je A
							}
						);
					}
				}
				
			}

			static internal class PausedGameHitEffects
			{
				static public System.Boolean IsNotApplyingHitEffects
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Patches.PausedGameHitEffects.IsNotApplyingHitEffects,
							new System.Byte[2]
							{
								0x74, 0x3F // je 3F
							}
						);
					}
				}
			}

			static internal class PowerAttackStamina
			{
				static public System.Boolean GetStaminaCostActor
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Patches.PowerAttackStamina.GetStaminaCostActor,
							new System.Byte?[5]
							{
								0xE8, null, null, null, null // call ActorValueOwner.GetStaminaCost
							}
						);
					}
				}

				static public System.Boolean GetStaminaCostPlayerCharacter
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Patches.PowerAttackStamina.GetStaminaCostPlayerCharacter,
							new System.Byte?[5]
							{
								0xE8, null, null, null, null // call ActorValueOwner.GetStaminaCost
							}
						);
					}
				}

				static public System.Boolean HasStaminaActor
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Patches.PowerAttackStamina.HasStaminaActor,
							new System.Byte[2]
							{
								0x75, 0x10 // jnz 10
							}
						);
					}
				}

				static public System.Boolean HasStaminaCostActor
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Patches.PowerAttackStamina.HasStaminaCostActor,
							new System.Byte[3 + 2] // 0x5
							{
								0x0F, 0x2F, 0xC7,	// comiss xmm0, xmm7
								0x77, 0x6E			// ja 6E
							}
						);
					}
				}

				static public System.Boolean HasStaminaCostPlayerCharacter
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Patches.PowerAttackStamina.HasStaminaCostPlayerCharacter,
							new System.Byte[3 + 2] // 0x5
							{
								0x0F, 0x2F, 0xC6,	// comiss xmm0, xmm6
								0x76, 0x34			// jbe 34
							}
						);
					}
				}

				static public System.Boolean HasStaminaPlayerCharacter
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Patches.PowerAttackStamina.HasStaminaPlayerCharacter,
							new System.Byte[2]
							{
								0x77, 0x19 // ja 19
							}
						);
					}
				}
			}

			static internal class ReflectDamage
			{
				static public System.Boolean CompareReflectDamage
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Patches.ReflectDamage.CompareReflectDamage,
							new System.Byte[2]
							{
								0x77, 0x03 // ja 3
							}
						);
					}
				}
			}

			static internal class TeammateDifficulty
			{
				static public System.Boolean IsPlayer
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Patches.TeammateDifficulty.IsPlayer,
							new System.Byte[5]
							{
								0xBA, 0x18, 0x00, 0x00, 0x00 // mov edx, 18
							}
						);
					}
				}
			}

			static internal class UnderfilledSoulGems
			{
				static public System.Boolean CompareSoulLevelValue
				{
					get
					{
						return AddressLibrary.MatchPattern
						(
							ScrambledBugs.Offsets.Patches.UnderfilledSoulGems.CompareSoulLevelValue,
							new System.Byte[2]
							{
								0x72, 0x2E // jb 2E
							}
						);
					}
				}
			}
		}
	}
}
