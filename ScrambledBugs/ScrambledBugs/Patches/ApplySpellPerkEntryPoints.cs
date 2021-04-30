using static NetScriptFramework._IntPtrExtensions;



namespace ScrambledBugs.Patches
{
	internal class ApplySpellPerkEntryPoints
	{
		static protected class Offsets
		{
			static Offsets()
			{
				Offsets.AddSpell							= NetScriptFramework.Main.GameInfo.GetAddressOf(37771);
				Offsets.ApplyBashingSpell					= NetScriptFramework.Main.GameInfo.GetAddressOf(37673);
				Offsets.ApplyCombatHitSpell					= NetScriptFramework.Main.GameInfo.GetAddressOf(37799);
				Offsets.ApplyCombatHitSpellArrowProjectile	= NetScriptFramework.Main.GameInfo.GetAddressOf(42547);
				Offsets.ApplyReanimateSpell					= NetScriptFramework.Main.GameInfo.GetAddressOf(37865);
				Offsets.ApplyWeaponSwingSpell				= NetScriptFramework.Main.GameInfo.GetAddressOf(37628);
				Offsets.HandleEntryPoint					= NetScriptFramework.Main.GameInfo.GetAddressOf(23073);
			}



			/// <summary> SkyrimSE.exe + 0x62F560 </summary>
			static internal System.IntPtr AddSpell { get; }

			/// <summary> SkyrimSE.exe + 0x628C20 </summary>
			static internal System.IntPtr ApplyBashingSpell { get; }

			/// <summary> SkyrimSE.exe + 0x6310A0 </summary>
			static internal System.IntPtr ApplyCombatHitSpell { get; }

			/// <summary> SkyrimSE.exe + 0x732400 </summary>
			static internal System.IntPtr ApplyCombatHitSpellArrowProjectile { get; }

			/// <summary> SkyrimSE.exe + 0x634BF0 </summary>
			static internal System.IntPtr ApplyReanimateSpell { get; }

			/// <summary> SkyrimSE.exe + 0x6260F0 </summary>
			static internal System.IntPtr ApplyWeaponSwingSpell { get; }

			/// <summary> SkyrimSE.exe + 0x32ECE0 </summary>
			static internal System.IntPtr HandleEntryPoint { get; }
		}



		static protected class Actor
		{
			static internal System.Boolean AddSpell(System.IntPtr actor, System.IntPtr spell)
			{
				return NetScriptFramework.Memory.InvokeCdecl(ApplySpellPerkEntryPoints.Offsets.AddSpell, actor, spell).ToBool();
			}

			static internal System.IntPtr GetMagicCaster(System.IntPtr actor, ApplySpellPerkEntryPoints.SpellItem.CastingSource castingSource)
			{
				var virtualFunctionTable = NetScriptFramework.Memory.ReadPointer(actor);
				var getMagicCaster = NetScriptFramework.Memory.ReadPointer(virtualFunctionTable + 0x2E0);

				return NetScriptFramework.Memory.InvokeThisCall(actor, getMagicCaster, (System.Int32)castingSource);
			}
		}

		static protected class BGSPerkEntry
		{
			internal enum EntryPoints : System.Int32
			{
				ApplyCombatHitSpell		= 51,
				ApplyBashingSpell		= 52,
				ApplyReanimateSpell		= 53,
				ApplyWeaponSwingSpell	= 67,
				ApplySneakingSpell		= 69
			}



			// EntryPoints entryPoint, Character* perkOwner, void* argument1, void* argument2
			static internal System.IntPtr HandleEntryPoint(BGSPerkEntry.EntryPoints entryPoint, System.IntPtr perkOwner, System.IntPtr argument1)
			{
				using (var result = NetScriptFramework.Memory.Allocate(0x8))
				{
					result.Zero();
					NetScriptFramework.Memory.InvokeCdecl(ApplySpellPerkEntryPoints.Offsets.HandleEntryPoint, (System.Int32)entryPoint, perkOwner, argument1, result.Address);

					return NetScriptFramework.Memory.ReadPointer(result.Address);
				}
			}

			// EntryPoints entryPoint, Character* perkOwner, void* argument1, void* argument2, void* argument3
			static internal System.IntPtr HandleEntryPoint(BGSPerkEntry.EntryPoints entryPoint, System.IntPtr perkOwner, System.IntPtr argument1, System.IntPtr argument2)
			{
				using (var result = NetScriptFramework.Memory.Allocate(0x8))
				{
					result.Zero();
					NetScriptFramework.Memory.InvokeCdecl(ApplySpellPerkEntryPoints.Offsets.HandleEntryPoint, (System.Int32)entryPoint, perkOwner, argument1, argument2, result.Address);

					return NetScriptFramework.Memory.ReadPointer(result.Address);
				}
			}
		}

		static protected class MagicCaster
		{
			static internal void Cast(System.IntPtr magicCaster, System.IntPtr spell, System.Boolean noHitEffectArt, System.IntPtr target, System.Single unknownArgument1, System.Boolean unknownArgument2, System.Single unknownArgument3, System.Single magnitudeOverride)
			{
				var virtualFunctionTable = NetScriptFramework.Memory.ReadPointer(magicCaster);
				var cast = NetScriptFramework.Memory.ReadPointer(virtualFunctionTable + 0x8);

				NetScriptFramework.Memory.InvokeThisCall(magicCaster, cast, spell, noHitEffectArt, target, unknownArgument1, unknownArgument2, unknownArgument3, magnitudeOverride);
			}
		}

		static protected class SpellItem
		{
			internal enum CastingSource : System.Int32
			{
				LeftHand	= 0,
				RightHand	= 1,
				Other		= 2,
				Instant		= 3
			}
			
			internal enum SpellType : System.Int32
			{
				Spell				= 0,
				Disease				= 1,
				Power				= 2,
				LesserPower			= 3,
				Ability				= 4,
				Poison				= 5,
				Enchantment			= 6,
				Potion				= 7,
				Ingredient			= 8,
				LeveledSpell		= 9,
				Addiction			= 10,
				VoicePower			= 11,
				StaffEnchantment	= 12,
				Scroll				= 13,

				AddSpell = (1 << Disease) | (1 << Ability) | (1 << Addiction)
			}
			


			static internal SpellItem.SpellType GetSpellType(System.IntPtr spell)
			{
				var virtualFunctionTable = NetScriptFramework.Memory.ReadPointer(spell);
				var getSpellType = NetScriptFramework.Memory.ReadPointer(virtualFunctionTable + 0x298);

				return (SpellItem.SpellType)NetScriptFramework.Memory.InvokeThisCall(spell, getSpellType).ToInt32Safe();
			}
		}



		internal ApplySpellPerkEntryPoints()
		{
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = ApplySpellPerkEntryPoints.Offsets.ApplyBashingSpell + 0x40E,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 0,
				Before = cpuRegisters =>
				{
					var entryPoint = (ApplySpellPerkEntryPoints.BGSPerkEntry.EntryPoints)cpuRegisters.CX.ToInt32Safe();
					var source = cpuRegisters.DX;
					var target = cpuRegisters.R8;
					var spell = ApplySpellPerkEntryPoints.BGSPerkEntry.HandleEntryPoint(entryPoint, source, target);

					ApplySpellPerkEntryPoints.Cast(spell, source, target);
				},
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = ApplySpellPerkEntryPoints.Offsets.ApplyCombatHitSpell + 0x61,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 0,
				Before = cpuRegisters =>
				{
					var entryPoint = (ApplySpellPerkEntryPoints.BGSPerkEntry.EntryPoints)cpuRegisters.CX.ToInt32Safe();
					var source = cpuRegisters.DX;
					var weapon = cpuRegisters.R8;
					var target = cpuRegisters.R9;
					var spell = ApplySpellPerkEntryPoints.BGSPerkEntry.HandleEntryPoint(entryPoint, source, weapon, target);

					ApplySpellPerkEntryPoints.Cast(spell, source, target);
				},
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = ApplySpellPerkEntryPoints.Offsets.ApplyCombatHitSpellArrowProjectile + 0x28B,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 0,
				Before = cpuRegisters =>
				{
					var entryPoint = (ApplySpellPerkEntryPoints.BGSPerkEntry.EntryPoints)cpuRegisters.CX.ToInt32Safe();
					var source = cpuRegisters.DX;
					var weapon = cpuRegisters.R8;
					var target = cpuRegisters.R9;
					var spell = ApplySpellPerkEntryPoints.BGSPerkEntry.HandleEntryPoint(entryPoint, source, weapon, target);

					ApplySpellPerkEntryPoints.Cast(spell, source, target);
				},
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = ApplySpellPerkEntryPoints.Offsets.ApplyReanimateSpell + 0xBA,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 0,
				Before = cpuRegisters =>
				{
					var entryPoint = (ApplySpellPerkEntryPoints.BGSPerkEntry.EntryPoints)cpuRegisters.CX.ToInt32Safe();
					var source = cpuRegisters.DX;
					var weapon = cpuRegisters.R8;
					var target = cpuRegisters.R9;
					var spell = ApplySpellPerkEntryPoints.BGSPerkEntry.HandleEntryPoint(entryPoint, source, weapon, target);

					ApplySpellPerkEntryPoints.Cast(spell, source, target);
				},
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = ApplySpellPerkEntryPoints.Offsets.ApplyWeaponSwingSpell + 0xAB,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 0,
				Before = cpuRegisters =>
				{
					var entryPoint = (ApplySpellPerkEntryPoints.BGSPerkEntry.EntryPoints)cpuRegisters.CX.ToInt32Safe();
					var target = cpuRegisters.DX;
					var source = cpuRegisters.R8;
					var weapon = cpuRegisters.R9;
					var spell = ApplySpellPerkEntryPoints.BGSPerkEntry.HandleEntryPoint(entryPoint, target, source, weapon);

					ApplySpellPerkEntryPoints.Cast(spell, source, target);
				},
			});
		}



		// SpellItem* spell, Character* source, Character* target
		static private void Cast(System.IntPtr spell, System.IntPtr source, System.IntPtr target)
		{
			if (spell != System.IntPtr.Zero)
			{
				var spellType = ApplySpellPerkEntryPoints.SpellItem.GetSpellType(spell);

				if (((1 << (System.Int32)spellType) & (System.Int32)ApplySpellPerkEntryPoints.SpellItem.SpellType.AddSpell) != 0)
				{
					ApplySpellPerkEntryPoints.Actor.AddSpell(spell, target);
				}
				else
				{
					var magicCaster = ApplySpellPerkEntryPoints.Actor.GetMagicCaster(source, ApplySpellPerkEntryPoints.SpellItem.CastingSource.Instant);

					ApplySpellPerkEntryPoints.MagicCaster.Cast(magicCaster, spell, false, target, 1.0F, false, 0.0F, 0.0F);
				}
			}
		}
	}
}
