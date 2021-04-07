﻿namespace ScrambledBugs.Patches
{
	internal class ApplySpellPerkEntryPoints
	{
		static protected class Offsets
		{
			static Offsets()
			{
				Offsets.ApplyBashingSpell =						NetScriptFramework.Main.GameInfo.GetAddressOf(37673);
				Offsets.ApplyCombatHitSpell =					NetScriptFramework.Main.GameInfo.GetAddressOf(37799);
				Offsets.ApplyCombatHitSpellArrowProjectile =	NetScriptFramework.Main.GameInfo.GetAddressOf(42547);
				Offsets.ApplyReanimateSpell =					NetScriptFramework.Main.GameInfo.GetAddressOf(37865);
				Offsets.ApplySneakingSpell =					NetScriptFramework.Main.GameInfo.GetAddressOf(36926);
				Offsets.ApplySpell =							NetScriptFramework.Main.GameInfo.GetAddressOf(37817);
				Offsets.ApplyWeaponSwingSpell =					NetScriptFramework.Main.GameInfo.GetAddressOf(37628);
				Offsets.SelectSpell =							NetScriptFramework.Main.GameInfo.GetAddressOf(23089);
			}



			/// <summary> SkyrimSE.exe + 0x628C20 </summary>
			static internal System.IntPtr ApplyBashingSpell { get; }

			/// <summary> SkyrimSE.exe + 0x6310A0 </summary>
			static internal System.IntPtr ApplyCombatHitSpell { get; }

			/// <summary> SkyrimSE.exe + 0x732400 </summary>
			static internal System.IntPtr ApplyCombatHitSpellArrowProjectile { get; }

			/// <summary> SkyrimSE.exe + 0x634BF0 </summary>
			static internal System.IntPtr ApplyReanimateSpell { get; }

			/// <summary> SkyrimSE.exe + 0x6089E0 </summary>
			static internal System.IntPtr ApplySneakingSpell { get; }

			/// <summary> SkyrimSE.exe + 0x632180 </summary>
			static internal System.IntPtr ApplySpell { get; }

			/// <summary> SkyrimSE.exe + 0x6260F0 </summary>
			static internal System.IntPtr ApplyWeaponSwingSpell { get; }

			/// <summary> SkyrimSE.exe + 0x32FA00 </summary>
			static internal System.IntPtr SelectSpell { get; }
		}
		
		
		
		internal ApplySpellPerkEntryPoints()
		{
			// RCX: Character, RDX: SpellItem
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = ApplySpellPerkEntryPoints.Offsets.ApplyBashingSpell + 0x429,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 5,
				Before = cpuRegisters => ApplySpellPerkEntryPoints.ApplySpells(cpuRegisters.CX, cpuRegisters.DX, cpuRegisters.SP + 0x118),
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = ApplySpellPerkEntryPoints.Offsets.ApplyCombatHitSpell + 0x79,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 5,
				Before = cpuRegisters => ApplySpellPerkEntryPoints.ApplySpells(cpuRegisters.CX, cpuRegisters.DX, cpuRegisters.SP + 0x78),
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = ApplySpellPerkEntryPoints.Offsets.ApplyCombatHitSpellArrowProjectile + 0x2A7,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 5,
				Before = cpuRegisters => ApplySpellPerkEntryPoints.ApplySpells(cpuRegisters.CX, cpuRegisters.DX, cpuRegisters.SP + 0x50),
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = ApplySpellPerkEntryPoints.Offsets.ApplyReanimateSpell + 0xD2,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 5,
				Before = cpuRegisters => ApplySpellPerkEntryPoints.ApplySpells(cpuRegisters.CX, cpuRegisters.DX, cpuRegisters.SP + 0x50),
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = ApplySpellPerkEntryPoints.Offsets.ApplySneakingSpell + 0xCE,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 5,
				Before = cpuRegisters => ApplySpellPerkEntryPoints.ApplySpells(cpuRegisters.CX, cpuRegisters.DX, cpuRegisters.SP + 0x40),
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = ApplySpellPerkEntryPoints.Offsets.ApplyWeaponSwingSpell + 0xC3,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 5,
				Before = cpuRegisters => ApplySpellPerkEntryPoints.ApplySpells(cpuRegisters.CX, cpuRegisters.DX, cpuRegisters.SP + 0x70),
			});

			// RAX: SpellItem, RCX: HandleEntryPointVisitor.SpellItem*
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = ApplySpellPerkEntryPoints.Offsets.SelectSpell + 0x53,
				Pattern = "48 8B 43 08" + "48 89 01",
				ReplaceLength = 4 + 3, // 7
				IncludeLength = 4 + 3, // 7
				After = cpuRegisters => ApplySpellPerkEntryPoints.SelectSpell(cpuRegisters.AX, cpuRegisters.CX),
			});
		}

		static ApplySpellPerkEntryPoints()
		{
			ApplySpellPerkEntryPoints.SpellDictionary = new System.Collections.Generic.Dictionary<System.IntPtr, System.Collections.Generic.List<System.IntPtr>>();
			ApplySpellPerkEntryPoints.SpellDictionaryLock = new System.Object();
		}



		static private System.Collections.Generic.Dictionary<System.IntPtr, System.Collections.Generic.List<System.IntPtr>> SpellDictionary;

		static private System.Object SpellDictionaryLock;



		static private void ApplySpells(System.IntPtr target, System.IntPtr spell, System.IntPtr spellPointer)
		{
			// target != System.IntPtr.Zero
			// spell != System.IntPtr.Zero
			// spellPointer != System.IntPtr.Zero
			
			lock (ApplySpellPerkEntryPoints.SpellDictionaryLock)
			{
				if (ApplySpellPerkEntryPoints.SpellDictionary.TryGetValue(spellPointer, out var spellList))
				{
					ApplySpellPerkEntryPoints.SpellDictionary.Remove(spellPointer);
					spellList.Remove(spell);

					foreach (var spellItem in spellList)
					{
						NetScriptFramework.Memory.InvokeCdecl(ApplySpellPerkEntryPoints.Offsets.ApplySpell, target, spellItem);
					}
				}
			}
		}

		static private void SelectSpell(System.IntPtr spell, System.IntPtr spellPointer)
		{
			if (spell == System.IntPtr.Zero) { return; }
			if (spellPointer == System.IntPtr.Zero) { return; }
			
			lock (ApplySpellPerkEntryPoints.SpellDictionaryLock)
			{
				if (ApplySpellPerkEntryPoints.SpellDictionary.TryGetValue(spellPointer, out var spellList))
				{
					spellList.Add(spell);
				}
				else
				{
					spellList = new System.Collections.Generic.List<System.IntPtr>();
					spellList.Add(spell);
					ApplySpellPerkEntryPoints.SpellDictionary[spellPointer] = spellList;
				}
			}
		}
	}
}
