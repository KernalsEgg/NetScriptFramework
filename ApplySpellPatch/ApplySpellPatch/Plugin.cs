using Eggstensions.Bethesda;



namespace ApplySpellPatch
{
    public class Plugin : NetScriptFramework.Plugin
	{
		override public System.Int32 RequiredLibraryVersion	{ get { return 10; } }

		override public System.Int32 Version				{ get { return 1; } }

		override public System.String Author				{ get { return "meh321 and KernalsEgg"; } }

		override public System.String Key					{ get { return "ApplySpellPatch"; } }

		override public System.String Name					{ get { return "Apply Spell Patch"; } }



		override protected System.Boolean Initialize(System.Boolean loadedAny)
		{
			// loadedAny

			Plugin._spellItems = new System.Collections.Generic.Dictionary<System.Int64, System.Collections.Generic.HashSet<System.IntPtr>>();
			Plugin._key = 0;
			Plugin._lock = new System.Object();

			Plugin.WriteHooks();

			return true;
		}



		static Plugin()
		{
			Plugin._applyBashingSpell =					NetScriptFramework.Main.GameInfo.GetAddressOf(37673); // <SkyrimSE.exe> + 0x628C20
			Plugin._applyCombatHitSpellMelee =			NetScriptFramework.Main.GameInfo.GetAddressOf(37799); // <SkyrimSE.exe> + 0x6310A0
			Plugin._applyCombatHitSpellProjectile =		NetScriptFramework.Main.GameInfo.GetAddressOf(42547); // <SkyrimSE.exe> + 0x732400
			Plugin._applyReanimateSpell =				NetScriptFramework.Main.GameInfo.GetAddressOf(37865); // <SkyrimSE.exe> + 0x634BF0
			Plugin._applySneakingSpell =				NetScriptFramework.Main.GameInfo.GetAddressOf(36926); // <SkyrimSE.exe> + 0x6089E0
			Plugin._applyWeaponSwingSpell =				NetScriptFramework.Main.GameInfo.GetAddressOf(37628); // <SkyrimSE.exe> + 0x6260F0
			Plugin._setSpellPerkEntryPoint =			NetScriptFramework.Main.GameInfo.GetAddressOf(23089); // <SkyrimSE.exe> + 0x32FA00
		}



		readonly static private System.IntPtr _applyBashingSpell;
		readonly static private System.IntPtr _applyCombatHitSpellMelee;
		readonly static private System.IntPtr _applyCombatHitSpellProjectile;
		readonly static private System.IntPtr _applyReanimateSpell;
		readonly static private System.IntPtr _applySneakingSpell;
		readonly static private System.IntPtr _applyWeaponSwingSpell;
		readonly static private System.IntPtr _setSpellPerkEntryPoint;

		static private System.Collections.Generic.Dictionary<System.Int64, System.Collections.Generic.HashSet<System.IntPtr>> _spellItems;
		static private System.Int64 _key;
		static private System.Object _lock;



		static private void WriteHooks()
		{
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = Plugin._setSpellPerkEntryPoint + 0x53,
				Pattern = "48 8B 43 08" + "48 89 01",
				ReplaceLength = 7,
				IncludeLength = 0,
				Before = cpuRegisters => Plugin.SetSpellPerkEntryPoint(cpuRegisters.BX, cpuRegisters.CX),
			});



			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = Plugin._applyBashingSpell + 0x429,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 0,
				Before = cpuRegisters => Plugin.CastSpellPerkEntryPoint(cpuRegisters.CX, cpuRegisters.DX),
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = Plugin._applyCombatHitSpellMelee + 0x79,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 0,
				Before = cpuRegisters => Plugin.CastSpellPerkEntryPoint(cpuRegisters.CX, cpuRegisters.DX),
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = Plugin._applyCombatHitSpellProjectile + 0x2A7,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 0,
				Before = cpuRegisters => Plugin.CastSpellPerkEntryPoint(cpuRegisters.CX, cpuRegisters.DX),
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = Plugin._applyReanimateSpell + 0xD2,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 0,
				Before = cpuRegisters => Plugin.CastSpellPerkEntryPoint(cpuRegisters.CX, cpuRegisters.DX),
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = Plugin._applySneakingSpell + 0xCE,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 0,
				Before = cpuRegisters => Plugin.CastSpellPerkEntryPoint(cpuRegisters.CX, cpuRegisters.DX),
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = Plugin._applyWeaponSwingSpell + 0xC3,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 0,
				Before = cpuRegisters => Plugin.CastSpellPerkEntryPoint(cpuRegisters.CX, cpuRegisters.DX),
			});
		}

		/// <param name="perkEntryPoint">BGSEntryPointFunctionDataSpellItem</param>
		/// <param name="spellToSet">SpellItem</param>
		static private void SetSpellPerkEntryPoint(System.IntPtr perkEntryPoint, System.IntPtr spellToSet)
		{
			if (perkEntryPoint == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("perkEntryPoint"); }
			if (spellToSet == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("spellToSet"); }

			lock (Plugin._lock)
			{
				var key = NetScriptFramework.Memory.ReadInt64(spellToSet);

				while (key == 0)
				{
					key = System.Threading.Interlocked.Increment(ref Plugin._key);
					NetScriptFramework.Memory.WriteInt64(spellToSet, key);
				}

				if (Plugin._spellItems.TryGetValue(key, out var spellItems))
				{
					spellItems.Add(NetScriptFramework.Memory.ReadPointer(perkEntryPoint + 0x8));
				}
				else
				{
					spellItems = new System.Collections.Generic.HashSet<System.IntPtr>();
					spellItems.Add(NetScriptFramework.Memory.ReadPointer(perkEntryPoint + 0x8));
					Plugin._spellItems[key] = spellItems;
				}
			}
		}

		/// <param name="target">Actor</param>
		/// <param name="spellItemToSet">SpellItem</param>
		static private void CastSpellPerkEntryPoint(System.IntPtr target, System.IntPtr spellToSet)
		{
			if (target == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("target"); }
			if (spellToSet == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("spellToSet"); }

			lock (Plugin._lock)
			{
				var key = spellToSet.ToInt64();

				if (Plugin._spellItems.TryGetValue(key, out var spellItems))
				{
					Plugin._spellItems.Remove(key);

					foreach (var spellItem in spellItems)
					{
						Actor.CastSpellPerkEntryPoint(target, spellItem);
					}
				}
			}
		}
	}
}
