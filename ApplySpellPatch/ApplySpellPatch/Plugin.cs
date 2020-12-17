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

			Events.SetSpellPerkEntryPointEvent.Register(SetSpellPerkEntryPoint);
			Events.CastSpellPerkEntryPointEvent.Register(CastSpellPerkEntryPoint);

			return true;
		}



		static private System.Collections.Generic.Dictionary<System.Int64, System.Collections.Generic.HashSet<System.IntPtr>> _spellItems;

		static private System.Int64 _key;

		static private System.Object _lock;



		static private void SetSpellPerkEntryPoint(Events.SetSpellPerkEntryPointEventArguments arguments)
		{
			lock (Plugin._lock)
			{
				var key = NetScriptFramework.Memory.ReadInt64(arguments.Result);

				while (key == 0)
				{
					key = System.Threading.Interlocked.Increment(ref Plugin._key);
					NetScriptFramework.Memory.WriteInt64(arguments.Result, key);
				}

				if (Plugin._spellItems.TryGetValue(key, out var spellItems))
				{
					spellItems.Add(NetScriptFramework.Memory.ReadPointer(arguments.PerkEntryPoint + 0x8));
				}
				else
				{
					spellItems = new System.Collections.Generic.HashSet<System.IntPtr>();
					spellItems.Add(NetScriptFramework.Memory.ReadPointer(arguments.PerkEntryPoint + 0x8));
					Plugin._spellItems[key] = spellItems;
				}

				arguments.Skip = true;
			}
		}

		static private void CastSpellPerkEntryPoint(Events.CastSpellPerkEntryPointEventArguments arguments)
		{
			lock (Plugin._lock)
			{
				var key = arguments.SpellItem.ToInt64();

				if (Plugin._spellItems.TryGetValue(key, out var spellItems))
				{
					Plugin._spellItems.Remove(key);

					foreach (var spellItem in spellItems)
					{
						Actor.CastSpellPerkEntryPoint(arguments.Target, spellItem);
					}
				}

				arguments.Skip = true;
			}
		}
	}
}
