using Eggstensions;



namespace ScrambledBugs
{
	public class Plugin : NetScriptFramework.Plugin
	{
		override public System.Int32 RequiredLibraryVersion { get; }	= 10;
		override public System.Int32 Version { get; }					= 13;
		override public System.String Author { get; }					= "meh321 and KernalsEgg";
		override public System.String Key { get; }						= "ScrambledBugs";
		override public System.String Name { get; }						= "Scrambled Bugs";



		static public Trampoline Trampoline { get; } = new Trampoline(Memory.GetProcessModule("SkyrimSE.exe"));



		override protected System.Boolean Initialize(System.Boolean pluginLoaded)
		{
			var path = "Data//NetScriptFramework//Plugins//ScrambledBugs.json";

			if (System.IO.File.Exists(path))
			{
				var settings							= new
				{
					Fixes								= new
					{
						ActorValuePercentage			= default(System.Boolean?),
						ApplySpellPerkEntryPoints		= new
						{
							Arrows						= default(System.Boolean?)
						},
						HarvestedFlags					= default(System.Boolean?),
						HitEffectRaceCondition			= default(System.Boolean?),
						MagicEffectConditions			= default(System.Boolean?),
						MagicEffectFlags				= default(System.Boolean?),
						ModArmorWeightPerkEntryPoint	= default(System.Boolean?),
						MovementSpeed					= default(System.Boolean?),
						QuickShot						= default(System.Boolean?),
						QuickShotPlaybackSpeed			= default(System.Single?),
						TerrainDecals					= default(System.Boolean?),
						TrainingMenuText				= default(System.Boolean?),
						WeaponCharge					= default(System.Boolean?)
					},
					Patches								= new
					{
						AccumulatingMagnitude			= default(System.Boolean?),
						AlreadyCaughtPickpocketing		= default(System.Boolean?),
						ApplySpellPerkEntryPoints		= new
						{
							CastSpells					= default(System.Boolean?),
							MultipleSpells				= default(System.Boolean?)
						},
						AttachHitEffectArt				= default(System.Boolean?),
						EquipBestAmmo					= default(System.Boolean?),
						LockpickingExperience			= default(System.Boolean?),
						MultipleHitEffects				= default(System.Boolean?),
						PausedGameHitEffects			= default(System.Boolean?),
						PowerAttackStamina				= default(System.Boolean?),
						ReflectDamage					= default(System.Boolean?),
						TeammateDifficulty				= default(System.Boolean?),
						UnderfilledSoulGems				= default(System.Boolean?)
					}
				};

				settings = Newtonsoft.Json.JsonConvert.DeserializeAnonymousType(System.IO.File.ReadAllText(path), settings);
				NetScriptFramework.Main.Log.AppendLine(settings.ToString());

				// Fixes
				if (settings?.Fixes?.ActorValuePercentage ?? false)
				{
					ScrambledBugs.Fixes.ActorValuePercentage.Fix();
				}

				if (settings?.Fixes?.HarvestedFlags ?? false)
				{
					ScrambledBugs.Fixes.HarvestedFlags.Fix();
				}

				if (settings?.Fixes?.HitEffectRaceCondition ?? false)
				{
					ScrambledBugs.Fixes.HitEffectRaceCondition.Fix();
				}

				if (settings?.Fixes?.MagicEffectConditions ?? false)
				{
					ScrambledBugs.Fixes.MagicEffectConditions.Fix();
				}

				if (settings?.Fixes?.MagicEffectFlags ?? false)
				{
					ScrambledBugs.Fixes.MagicEffectFlags.Fix();
				}

				if (settings?.Fixes?.ModArmorWeightPerkEntryPoint ?? false)
				{
					ScrambledBugs.Fixes.ModArmorWeightPerkEntryPoint.Fix();
				}

				if (settings?.Fixes?.MovementSpeed ?? false)
				{
					ScrambledBugs.Fixes.MovementSpeed.Fix();
				}

				if ((settings?.Fixes?.QuickShot ?? false) && (settings?.Fixes?.QuickShotPlaybackSpeed.HasValue ?? false))
				{
					ScrambledBugs.Fixes.QuickShot.Fix(settings.Fixes.QuickShotPlaybackSpeed.Value);
				}

				if (settings?.Fixes?.TerrainDecals ?? false)
				{
					ScrambledBugs.Fixes.TerrainDecals.Fix();
				}

				if (settings?.Fixes?.TrainingMenuText ?? false)
				{
					ScrambledBugs.Fixes.TrainingMenuText.Fix();
				}

				if (settings?.Fixes?.WeaponCharge ?? false)
				{
					ScrambledBugs.Fixes.WeaponCharge.Fix();
				}

				// Patches
				if (settings?.Patches?.AccumulatingMagnitude ?? false)
				{
					ScrambledBugs.Patches.AccumulatingMagnitude.Patch();
				}

				if (settings?.Patches?.AlreadyCaughtPickpocketing ?? false)
				{
					ScrambledBugs.Patches.AlreadyCaughtPickpocketing.Patch();
				}

				if (settings?.Patches?.ApplySpellPerkEntryPoints?.MultipleSpells ?? false)
				{
					ScrambledBugs.Patches.ApplySpellPerkEntryPoints.MultipleSpells.Patch(settings?.Patches?.ApplySpellPerkEntryPoints?.CastSpells ?? false);
				}
				else if (settings?.Patches?.ApplySpellPerkEntryPoints?.CastSpells ?? false)
				{
					ScrambledBugs.Patches.ApplySpellPerkEntryPoints.CastSpells.Patch();
				}

				if (settings?.Patches?.AttachHitEffectArt ?? false)
				{
					ScrambledBugs.Patches.AttachHitEffectArt.Patch();
				}

				if (settings?.Patches?.EquipBestAmmo ?? false)
				{
					ScrambledBugs.Patches.EquipBestAmmo.Patch();
				}

				if (settings?.Patches?.LockpickingExperience ?? false)
				{
					ScrambledBugs.Patches.LockpickingExperience.Patch();
				}

				if (settings?.Patches?.MultipleHitEffects ?? false)
				{
					ScrambledBugs.Patches.MultipleHitEffects.Patch();
				}

				if (settings?.Patches?.PausedGameHitEffects ?? false)
				{
					ScrambledBugs.Patches.PausedGameHitEffects.Patch();
				}

				if (settings?.Patches?.PowerAttackStamina ?? false)
				{
					ScrambledBugs.Patches.PowerAttackStamina.Patch();
				}

				if (settings?.Patches?.ReflectDamage ?? false)
				{
					ScrambledBugs.Patches.ReflectDamage.Patch();
				}

				if (settings?.Patches?.TeammateDifficulty ?? false)
				{
					ScrambledBugs.Patches.TeammateDifficulty.Patch();
				}

				if (settings?.Patches?.UnderfilledSoulGems ?? false)
				{
					ScrambledBugs.Patches.UnderfilledSoulGems.Patch();
				}

				// Fixes
				if (settings?.Fixes?.ApplySpellPerkEntryPoints?.Arrows ?? false)
				{
					ScrambledBugs.Fixes.ApplySpellPerkEntryPoints.Arrows.Fix();
				}

				Plugin.Trampoline.Commit();
			}

			return true;
		}
	}
}
