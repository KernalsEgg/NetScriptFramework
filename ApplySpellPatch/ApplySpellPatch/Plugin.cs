using Eggstensions.SkyrimSE;



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

			Plugin._settings = new Settings();
			Plugin._settings.Load();

			Plugin._spellItems = new System.Collections.Generic.Dictionary<System.IntPtr, System.Collections.Generic.HashSet<System.IntPtr>>();
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
			Plugin._applyWeaponSwingSpell =				NetScriptFramework.Main.GameInfo.GetAddressOf(37628); // <SkyrimSE.exe> + 0x6260F0 Actor::WeaponSwingCallBack
			Plugin._setSpellPerkEntryPoint =			NetScriptFramework.Main.GameInfo.GetAddressOf(23089); // <SkyrimSE.exe> + 0x32FA00 Actor::SetSpellPerkEntryPoint
		}



		readonly static private System.IntPtr _applyBashingSpell;
		readonly static private System.IntPtr _applyCombatHitSpellMelee;
		readonly static private System.IntPtr _applyCombatHitSpellProjectile;
		readonly static private System.IntPtr _applyReanimateSpell;
		readonly static private System.IntPtr _applySneakingSpell;
		readonly static private System.IntPtr _applyWeaponSwingSpell;
		readonly static private System.IntPtr _setSpellPerkEntryPoint;

		readonly static private System.String _messageBox =
			"Apply Spell Patch has thrown an exception." +
			"\nLogs are written to Data\\NetScriptFramework\\NetScriptFramework.log.txt.";

		static private Settings _settings;
		static private System.Collections.Generic.Dictionary<System.IntPtr, System.Collections.Generic.HashSet<System.IntPtr>> _spellItems;
		static private System.Object _lock;


		
		static private void WriteHooks()
		{
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = Plugin._setSpellPerkEntryPoint + 0x53,
				Pattern = "48 8B 43 08" + "48 89 01",
				ReplaceLength = 7,
				IncludeLength = 7,
				After = cpuRegisters => Plugin.SetSpellPerkEntryPoint(cpuRegisters.CX, cpuRegisters.AX), // RCX: HandleEntryPointVisitor->*SpellItem, RAX: SpellItem, RBX: BGSEntryPointFunctionDataSpellItem
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = Plugin._applyBashingSpell + 0x429,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 0,
				Before = cpuRegisters => Plugin.CastSpellPerkEntryPoint(cpuRegisters.SP + 0x118, cpuRegisters.CX),
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = Plugin._applyCombatHitSpellMelee + 0x79,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 0,
				Before = cpuRegisters => Plugin.CastSpellPerkEntryPoint(cpuRegisters.SP + 0x78, cpuRegisters.CX),
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = Plugin._applyCombatHitSpellProjectile + 0x2A7,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 0,
				Before = cpuRegisters => Plugin.CastSpellPerkEntryPoint(cpuRegisters.SP + 0x50, cpuRegisters.CX),
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = Plugin._applyReanimateSpell + 0xD2,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 0,
				Before = cpuRegisters => Plugin.CastSpellPerkEntryPoint(cpuRegisters.SP + 0x50, cpuRegisters.CX),
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = Plugin._applySneakingSpell + 0xCE,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 0,
				Before = cpuRegisters => Plugin.CastSpellPerkEntryPoint(cpuRegisters.SP + 0x40, cpuRegisters.CX),
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = Plugin._applyWeaponSwingSpell + 0xC3,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 0,
				Before = cpuRegisters => Plugin.CastSpellPerkEntryPoint(cpuRegisters.SP + 0x70, cpuRegisters.CX),
			});
		}

		/// <param name="spellItem">SpellItem</param>
		static private void SetSpellPerkEntryPoint(System.IntPtr address, System.IntPtr spellItem)
		{
			if (address == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(address)); }
			if (spellItem == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(spellItem)); }

			lock (Plugin._lock)
			{
				if (Plugin._spellItems.TryGetValue(address, out var spellItems))
				{
					spellItems.Add(spellItem);
				}
				else
				{
					spellItems = new System.Collections.Generic.HashSet<System.IntPtr>();
					spellItems.Add(spellItem);
					Plugin._spellItems[address] = spellItems;
				}
			}
		}

		/// <param name="target">Actor</param>
		static private void CastSpellPerkEntryPoint(System.IntPtr address, System.IntPtr target)
		{
			if (address == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(address)); }
			if (target == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(target)); }

			lock (Plugin._lock)
			{
				try
				{
					if (Plugin._spellItems.TryGetValue(address, out var spellItems))
					{
						Plugin._spellItems.Remove(address);

						foreach (var spellItem in spellItems)
						{
							Actor.CastSpellPerkEntryPoint(target, spellItem);
						}
					}
					else
					{
						throw new Eggceptions.NullException(nameof(spellItems));
					}
				}
				catch (Eggceptions.Eggception eggception)
				{
					if (Plugin._settings.LogHandledExceptions) { NetScriptFramework.Main.Log.Append(eggception); }
					if (Plugin._settings.ShowHandledExceptions) { UI.ShowMessageBox(Plugin._messageBox); }
				}
			}
		}
	}
}
