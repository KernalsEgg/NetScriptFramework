using Eggstensions;



namespace ScrambledBugs
{
	public class Plugin : NetScriptFramework.Plugin
	{
		override public System.Int32 RequiredLibraryVersion { get; }	= 10;
		override public System.Int32 Version { get; }					= 12;
		override public System.String Author { get; }					= "meh321 and KernalsEgg";
		override public System.String Key { get; }						= "ScrambledBugs";
		override public System.String Name { get; }						= "Scrambled Bugs";



		static public Trampoline Trampoline { get; } = new Trampoline(Memory.GetProcessModule("SkyrimSE.exe"));



		override protected System.Boolean Initialize(System.Boolean pluginLoaded)
		{
			var path = "Data//NetScriptFramework//Plugins//ScrambledBugs.json";

			if (System.IO.File.Exists(path))
			{
				var settings = Newtonsoft.Json.JsonConvert.DeserializeObject<ScrambledBugs.Settings>(System.IO.File.ReadAllText(path));
				
				// Fixes
				if (settings.fixes.harvestedFlags)
				{
					new ScrambledBugs.Fixes.HarvestedFlags();
				}

				if (settings.fixes.hitEffectRaceCondition)
				{
					new ScrambledBugs.Fixes.HitEffectRaceCondition();
				}

				if (settings.fixes.magicEffectConditions)
				{
					new ScrambledBugs.Fixes.MagicEffectConditions();
				}

				if (settings.fixes.magicEffectFlags)
				{
					new ScrambledBugs.Fixes.MagicEffectFlags();
				}

				if (settings.fixes.modArmorWeightPerkEntryPoint)
				{
					new ScrambledBugs.Fixes.ModArmorWeightPerkEntryPoint();
				}

				if (settings.fixes.movementSpeed)
				{
					new ScrambledBugs.Fixes.MovementSpeed();
				}

				if (settings.fixes.terrainDecals)
				{
					new ScrambledBugs.Fixes.TerrainDecals();
				}

				if (settings.fixes.trainingMenuText)
				{
					new ScrambledBugs.Fixes.TrainingMenuText();
				}

				if (settings.fixes.weaponCharge)
				{
					new ScrambledBugs.Fixes.WeaponCharge();
				}

				// Patches
				if (settings.patches.applySpellPerkEntryPoints.multipleSpells)
				{
					new ScrambledBugs.Patches.ApplySpellPerkEntryPoints.MultipleSpells();

					ScrambledBugs.Patches.ApplySpellPerkEntryPoints.MultipleSpells.CastSpells = settings.patches.applySpellPerkEntryPoints.castSpells;
				}
				else if (settings.patches.applySpellPerkEntryPoints.castSpells)
				{
					new ScrambledBugs.Patches.ApplySpellPerkEntryPoints.CastSpells();
				}

				if (settings.patches.attachHitEffectArt)
				{
					new ScrambledBugs.Patches.AttachHitEffectArt();
				}

				if (settings.patches.equipBestAmmo)
				{
					new ScrambledBugs.Patches.EquipBestAmmo();
				}

				if (settings.patches.lockpickingExperience)
				{
					new ScrambledBugs.Patches.LockpickingExperience();
				}

				if (settings.patches.multipleHitEffects)
				{
					new ScrambledBugs.Patches.MultipleHitEffects();
				}

				if (settings.patches.pausedGameHitEffects)
				{
					new ScrambledBugs.Patches.PausedGameHitEffects();
				}

				if (settings.patches.reflectDamage)
				{
					new ScrambledBugs.Patches.ReflectDamage();
				}

				if (settings.patches.underfilledSoulGems)
				{
					new ScrambledBugs.Patches.UnderfilledSoulGems();
				}

				// Fixes
				if (settings.fixes.applySpellPerkEntryPoints.arrows)
				{
					new ScrambledBugs.Fixes.ApplySpellPerkEntryPoints.Arrows();
				}

				Plugin.Trampoline.Commit();
			}

			return true;
		}
	}
}
