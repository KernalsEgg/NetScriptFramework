namespace ScrambledBugs.Patches
{
	internal class ApplySpellPerkEntryPoints
	{
		internal ApplySpellPerkEntryPoints()
		{
			// RAX: SpellItem, RCX: HandleEntryPointVisitor.SpellItem*
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = ApplySpellPerkEntryPoints._setSpell + 0x53,
				Pattern = "48 8B 43 08" + "48 89 01",
				ReplaceLength = 7,
				IncludeLength = 7,
				After = cpuRegisters => ApplySpellPerkEntryPoints.SetSpell(cpuRegisters.AX, cpuRegisters.CX),
			});

			// RCX: Character, RDX: SpellItem
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = ApplySpellPerkEntryPoints._applyBashingSpell + 0x429,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 5,
				Before = cpuRegisters => { if (ApplySpellPerkEntryPoints.AddSpells(cpuRegisters.CX, cpuRegisters.SP + 0x118)) { cpuRegisters.Skip(); } },
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = ApplySpellPerkEntryPoints._applyCombatHitSpell + 0x79,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 5,
				Before = cpuRegisters => { if (ApplySpellPerkEntryPoints.AddSpells(cpuRegisters.CX, cpuRegisters.SP + 0x78)) { cpuRegisters.Skip(); } },
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = ApplySpellPerkEntryPoints._applyCombatHitSpellArrowProjectile + 0x2A7,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 5,
				Before = cpuRegisters => { if (ApplySpellPerkEntryPoints.AddSpells(cpuRegisters.CX, cpuRegisters.SP + 0x50)) { cpuRegisters.Skip(); } },
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = ApplySpellPerkEntryPoints._applyReanimateSpell + 0xD2,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 5,
				Before = cpuRegisters => { if (ApplySpellPerkEntryPoints.AddSpells(cpuRegisters.CX, cpuRegisters.SP + 0x50)) { cpuRegisters.Skip(); } },
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = ApplySpellPerkEntryPoints._applySneakingSpell + 0xCE,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 5,
				Before = cpuRegisters => { if (ApplySpellPerkEntryPoints.AddSpells(cpuRegisters.CX, cpuRegisters.SP + 0x40)) { cpuRegisters.Skip(); } },
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = ApplySpellPerkEntryPoints._applyWeaponSwingSpell + 0xC3,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 5,
				Before = cpuRegisters => { if (ApplySpellPerkEntryPoints.AddSpells(cpuRegisters.CX, cpuRegisters.SP + 0x70)) { cpuRegisters.Skip(); } },
			});
		}

		static ApplySpellPerkEntryPoints()
		{
			ApplySpellPerkEntryPoints._addSpell = NetScriptFramework.Main.GameInfo.GetAddressOf(37817);								// SkyrimSE.exe + 0x632180
			ApplySpellPerkEntryPoints._applyBashingSpell = NetScriptFramework.Main.GameInfo.GetAddressOf(37673);					// SkyrimSE.exe + 0x628C20
			ApplySpellPerkEntryPoints._applyCombatHitSpell = NetScriptFramework.Main.GameInfo.GetAddressOf(37799);					// SkyrimSE.exe + 0x6310A0
			ApplySpellPerkEntryPoints._applyCombatHitSpellArrowProjectile = NetScriptFramework.Main.GameInfo.GetAddressOf(42547);	// SkyrimSE.exe + 0x732400
			ApplySpellPerkEntryPoints._applyReanimateSpell = NetScriptFramework.Main.GameInfo.GetAddressOf(37865);					// SkyrimSE.exe + 0x634BF0
			ApplySpellPerkEntryPoints._applySneakingSpell = NetScriptFramework.Main.GameInfo.GetAddressOf(36926);					// SkyrimSE.exe + 0x6089E0
			ApplySpellPerkEntryPoints._applyWeaponSwingSpell = NetScriptFramework.Main.GameInfo.GetAddressOf(37628);				// SkyrimSE.exe + 0x6260F0
			ApplySpellPerkEntryPoints._setSpell = NetScriptFramework.Main.GameInfo.GetAddressOf(23089);                             // SkyrimSE.exe + 0x32FA00

			ApplySpellPerkEntryPoints._spellItems = new System.Collections.Generic.Dictionary<System.IntPtr, System.Collections.Generic.HashSet<System.IntPtr>>();
			ApplySpellPerkEntryPoints._lock = new System.Object();
		}



		readonly static private System.IntPtr _addSpell;

		readonly static private System.IntPtr _applyBashingSpell;

		readonly static private System.IntPtr _applyCombatHitSpell;

		readonly static private System.IntPtr _applyCombatHitSpellArrowProjectile;

		readonly static private System.IntPtr _applyReanimateSpell;

		readonly static private System.IntPtr _applySneakingSpell;

		readonly static private System.IntPtr _applyWeaponSwingSpell;

		readonly static private System.IntPtr _setSpell;



		static private System.Collections.Generic.Dictionary<System.IntPtr, System.Collections.Generic.HashSet<System.IntPtr>> _spellItems;

		static private System.Object _lock;



		static private System.Boolean AddSpells(System.IntPtr target, System.IntPtr spellItemPointer)
		{
			if (target == System.IntPtr.Zero) { return false; }
			if (spellItemPointer == System.IntPtr.Zero) { return false; }
			
			lock (ApplySpellPerkEntryPoints._lock)
			{
				if (ApplySpellPerkEntryPoints._spellItems.TryGetValue(spellItemPointer, out var spellItems))
				{
					ApplySpellPerkEntryPoints._spellItems.Remove(spellItemPointer);

					foreach (var spellItem in spellItems)
					{
						NetScriptFramework.Memory.InvokeCdecl(ApplySpellPerkEntryPoints._addSpell, target, spellItem);
					}

					return true;
				}

				return false;
			}
		}

		static private void SetSpell(System.IntPtr spellItem, System.IntPtr spellItemPointer)
		{
			if (spellItem == System.IntPtr.Zero) { return; }
			if (spellItemPointer == System.IntPtr.Zero) { return; }
			
			lock (ApplySpellPerkEntryPoints._lock)
			{
				if (ApplySpellPerkEntryPoints._spellItems.TryGetValue(spellItemPointer, out var spellItems))
				{
					spellItems.Add(spellItem);
				}
				else
				{
					spellItems = new System.Collections.Generic.HashSet<System.IntPtr>();
					spellItems.Add(spellItem);
					ApplySpellPerkEntryPoints._spellItems[spellItemPointer] = spellItems;
				}
			}
		}
	}
}
