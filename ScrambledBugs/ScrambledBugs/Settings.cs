namespace ScrambledBugs
{
	public class JsonSettings
	{
		public class JsonFixes
		{
			public class JsonApplySpellPerkEntryPoints
			{
				public System.Boolean? Arrows { get; set; }
			}



			public System.Boolean? ActorValuePercentage { get; set; }
			public JsonFixes.JsonApplySpellPerkEntryPoints ApplySpellPerkEntryPoints { get; set; }
			public System.Boolean? HarvestedFlags { get; set; }
			public System.Boolean? HitEffectRaceCondition { get; set; }
			public System.Boolean? MagicEffectConditions { get; set; }
			public System.Boolean? MagicEffectFlags { get; set; }
			public System.Boolean? ModArmorWeightPerkEntryPoint { get; set; }
			public System.Boolean? QuickShot { get; set; }
			public System.Single? QuickShotPlaybackSpeed { get; set; }
			public System.Boolean? SpeedMultUpdates { get; set; }
			public System.Boolean? TerrainDecals { get; set; }
			public System.Boolean? TrainingMenuText { get; set; }
			public System.Boolean? WeaponCharge { get; set; }
		}

		public class JsonPatches
		{
			public class JsonApplySpellPerkEntryPoints
			{
				public System.Boolean? CastSpells { get; set; }
				public System.Boolean? MultipleSpells { get; set; }
			}



			public System.Boolean? AccumulatingMagnitude { get; set; }
			public System.Boolean? AlreadyCaughtPickpocketing { get; set; }
			public JsonPatches.JsonApplySpellPerkEntryPoints ApplySpellPerkEntryPoints { get; set; }
			public System.Boolean? AttachHitEffectArt { get; set; }
			public System.Boolean? EquipBestAmmo { get; set; }
			public System.Boolean? LeveledCharacters { get; set; }
			public System.Boolean? LockpickingExperience { get; set; }
			public System.Boolean? MultipleHitEffects { get; set; }
			public System.Boolean? PausedGameHitEffects { get; set; }
			public System.Boolean? PowerAttackStamina { get; set; }
			public System.Boolean? ReflectDamage { get; set; }
			public System.Boolean? TeammateDifficulty { get; set; }
			public System.Boolean? UnderfilledSoulGems { get; set; }
		}



		public JsonSettings.JsonFixes Fixes { get; set; }
		public JsonSettings.JsonPatches Patches { get; set; }
	}
}
