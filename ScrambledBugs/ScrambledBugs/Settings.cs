namespace ScrambledBugs
{
	public class Settings
	{
		public class Fixes
		{
			public System.Boolean activeEffectConditions { get; set; }
			public System.Boolean dualCasting { get; set; }
			public System.Boolean harvestedFlags { get; set; }
			public System.Boolean hitEffectRaceCondition { get; set; }
			public System.Boolean modArmorWeightPerkEntryPoint { get; set; }
			public System.Boolean speedMultUpdates { get; set; }
			public System.Boolean terrainDecals { get; set; }
			public System.Boolean trainingMenuText { get; set; }
		}

		public class Patches
		{
			public class ApplySpellPerkEntryPoints
			{
				public System.Boolean castSpells { get; set; }
				public System.Boolean multipleSpells { get; set; }
			}



			public Patches.ApplySpellPerkEntryPoints applySpellPerkEntryPoints { get; set; }
			public System.Boolean attachHitEffectArt { get; set; }
			public System.Boolean equipBestAmmo { get; set; }
			public System.Boolean lockpickingExperience { get; set; }
			public System.Boolean multipleHitEffects { get; set; }
			public System.Boolean pausedGameHitEffects { get; set; }
			public System.Boolean underfilledSoulGems { get; set; }
		}



		public Settings.Fixes fixes { get; set; }
		public Settings.Patches patches { get; set; }
	}
}
