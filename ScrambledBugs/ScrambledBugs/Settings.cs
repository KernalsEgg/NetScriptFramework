namespace ScrambledBugs
{
	public class Settings
	{
		public class Fixes
		{
			public System.Boolean activeEffectConditions { get; set; }
			public System.Boolean terrainDecals { get; set; }
		}

		public class Patches
		{
			public System.Boolean applySpellPerkEntryPoints { get; set; }
			public System.Boolean underfilledSoulGems { get; set; }
		}



		public Settings.Fixes fixes { get; set; }
		public Settings.Patches patches { get; set; }
	}
}
