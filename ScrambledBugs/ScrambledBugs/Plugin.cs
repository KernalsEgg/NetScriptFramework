namespace ScrambledBugs
{
    public class Plugin : NetScriptFramework.Plugin
    {
		override public System.Int32 RequiredLibraryVersion { get; } = 10;

		override public System.Int32 Version { get; } = 4;

		override public System.String Author { get; } = "meh321 and KernalsEgg";

		override public System.String Key { get; } = "ScrambledBugs";

		override public System.String Name { get; } = "Scrambled Bugs";



		override protected System.Boolean Initialize(System.Boolean loadedAny)
		{
			var path = "Data//NetScriptFramework//Plugins//ScrambledBugs.json";

			if (System.IO.File.Exists(path))
			{
				var settings = Newtonsoft.Json.JsonConvert.DeserializeObject<ScrambledBugs.Settings>(System.IO.File.ReadAllText(path));

				// Fixes
				if (settings.fixes.activeEffectConditions)
				{
					new ScrambledBugs.Fixes.ActiveEffectConditions();
				}

				if (settings.fixes.harvestedFlags)
				{
					new ScrambledBugs.Fixes.HarvestedFlags();
				}

				if (settings.fixes.modArmorWeightPerkEntryPoint)
				{
					new ScrambledBugs.Fixes.ModArmorWeightPerkEntryPoint();
				}

				if (settings.fixes.speedMultUpdates)
				{
					new ScrambledBugs.Fixes.SpeedMultUpdates();
				}

				if (settings.fixes.terrainDecals)
				{
					new ScrambledBugs.Fixes.TerrainDecals();
				}

				if (settings.fixes.trainingMenuText)
				{
					new ScrambledBugs.Fixes.TrainingMenuText();
				}

				// Patches
				if (settings.patches.applySpellPerkEntryPoints)
				{
					new ScrambledBugs.Patches.ApplySpellPerkEntryPoints();
				}

				if (settings.patches.equipBestAmmo)
				{
					new ScrambledBugs.Patches.EquipBestAmmo();
				}

				if (settings.patches.lockpickingExperience)
				{
					new ScrambledBugs.Patches.LockpickingExperience();
				}

				if (settings.patches.underfilledSoulGems)
				{
					new ScrambledBugs.Patches.UnderfilledSoulGems();
				}
			}

			return true;
		}
	}
}
