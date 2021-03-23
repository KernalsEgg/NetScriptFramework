﻿namespace ScrambledBugs
{
    public class Plugin : NetScriptFramework.Plugin
    {
		override public System.Int32 RequiredLibraryVersion { get; } = 10;

		override public System.Int32 Version { get; } = 1;

		override public System.String Author { get; } = "meh321 and KernalsEgg";

		override public System.String Key { get; } = "ScrambledBugs";

		override public System.String Name { get; } = "Scrambled Bugs";



		override protected System.Boolean Initialize(System.Boolean loadedAny)
		{
			var path = "Data//NetScriptFramework//Plugins//ScrambledBugs.json";

			if (System.IO.File.Exists(path))
			{
				var settings = Newtonsoft.Json.JsonConvert.DeserializeObject<ScrambledBugs.Settings>(System.IO.File.ReadAllText(path));

				if (settings.fixes.terrainDecals)
				{
					new TerrainDecals();
				}

				if (settings.patches.activeEffectDurations)
				{
					new ActiveEffectDurations();
				}

				if (settings.patches.applySpellPerkEntryPoints)
				{
					new ApplySpellPerkEntryPoints();
				}

				NetScriptFramework.Main.Log.AppendLine("\nterrainDecals: " + settings.fixes.terrainDecals + "\nactiveEffectDurations: " + settings.patches.activeEffectDurations + "\napplySpellPerkEntryPoints: " + settings.patches.applySpellPerkEntryPoints);
			}

			return true;
		}
	}

	
}