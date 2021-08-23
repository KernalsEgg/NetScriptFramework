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
						ActorValuePercentage			= default(System.Boolean),
						ApplySpellPerkEntryPoints		= new
						{
							Arrows						= default(System.Boolean)
						},
						HarvestedFlags					= default(System.Boolean),
						HitEffectRaceCondition			= default(System.Boolean),
						MagicEffectConditions			= default(System.Boolean),
						MagicEffectFlags				= default(System.Boolean),
						ModArmorWeightPerkEntryPoint	= default(System.Boolean),
						MovementSpeed					= default(System.Boolean),
						TerrainDecals					= default(System.Boolean),
						TrainingMenuText				= default(System.Boolean),
						WeaponCharge					= default(System.Boolean)
					},
					Patches								= new
					{
						AccumulatingMagnitude			= default(System.Boolean),
						AlreadyCaughtPickpocketing		= default(System.Boolean),
						ApplySpellPerkEntryPoints		= new
						{
							CastSpells					= default(System.Boolean),
							MultipleSpells				= default(System.Boolean)
						},
						AttachHitEffectArt				= default(System.Boolean),
						EquipBestAmmo					= default(System.Boolean),
						LockpickingExperience			= default(System.Boolean),
						MultipleHitEffects				= default(System.Boolean),
						PausedGameHitEffects			= default(System.Boolean),
						ReflectDamage					= default(System.Boolean),
						TeammateDifficulty				= default(System.Boolean),
						UnderfilledSoulGems				= default(System.Boolean)
					}
				};

				settings = Newtonsoft.Json.JsonConvert.DeserializeAnonymousType(System.IO.File.ReadAllText(path), settings);
				NetScriptFramework.Main.Log.AppendLine(settings.ToString());

				// Fixes
				if (settings?.Fixes?.ActorValuePercentage ?? default)
				{
					ScrambledBugs.Fixes.ActorValuePercentage.Fix();
				}

				if (settings?.Fixes?.HarvestedFlags ?? default)
				{
					ScrambledBugs.Fixes.HarvestedFlags.Fix();
				}

				if (settings?.Fixes?.HitEffectRaceCondition ?? default)
				{
					ScrambledBugs.Fixes.HitEffectRaceCondition.Fix();
				}

				if (settings?.Fixes?.MagicEffectConditions ?? default)
				{
					ScrambledBugs.Fixes.MagicEffectConditions.Fix();
				}

				if (settings?.Fixes?.MagicEffectFlags ?? default)
				{
					ScrambledBugs.Fixes.MagicEffectFlags.Fix();
				}

				if (settings?.Fixes?.ModArmorWeightPerkEntryPoint ?? default)
				{
					ScrambledBugs.Fixes.ModArmorWeightPerkEntryPoint.Fix();
				}

				if (settings?.Fixes?.MovementSpeed ?? default)
				{
					ScrambledBugs.Fixes.MovementSpeed.Fix();
				}

				if (settings?.Fixes?.TerrainDecals ?? default)
				{
					ScrambledBugs.Fixes.TerrainDecals.Fix();
				}

				if (settings?.Fixes?.TrainingMenuText ?? default)
				{
					ScrambledBugs.Fixes.TrainingMenuText.Fix();
				}

				if (settings?.Fixes?.WeaponCharge ?? default)
				{
					ScrambledBugs.Fixes.WeaponCharge.Fix();
				}

				// Patches
				if (settings?.Patches?.AccumulatingMagnitude ?? default)
				{
					ScrambledBugs.Patches.AccumulatingMagnitude.Patch();
				}

				if (settings?.Patches?.AlreadyCaughtPickpocketing ?? default)
				{
					ScrambledBugs.Patches.AlreadyCaughtPickpocketing.Patch();
				}

				if (settings?.Patches?.ApplySpellPerkEntryPoints?.MultipleSpells ?? default)
				{
					ScrambledBugs.Patches.ApplySpellPerkEntryPoints.MultipleSpells.Patch(settings?.Patches?.ApplySpellPerkEntryPoints?.CastSpells ?? default);
				}
				else if (settings?.Patches?.ApplySpellPerkEntryPoints?.CastSpells ?? default)
				{
					ScrambledBugs.Patches.ApplySpellPerkEntryPoints.CastSpells.Patch();
				}

				if (settings?.Patches?.AttachHitEffectArt ?? default)
				{
					ScrambledBugs.Patches.AttachHitEffectArt.Patch();
				}

				if (settings?.Patches?.EquipBestAmmo ?? default)
				{
					ScrambledBugs.Patches.EquipBestAmmo.Patch();
				}

				if (settings?.Patches?.LockpickingExperience ?? default)
				{
					ScrambledBugs.Patches.LockpickingExperience.Patch();
				}

				if (settings?.Patches?.MultipleHitEffects ?? default)
				{
					ScrambledBugs.Patches.MultipleHitEffects.Patch();
				}

				if (settings?.Patches?.PausedGameHitEffects ?? default)
				{
					ScrambledBugs.Patches.PausedGameHitEffects.Patch();
				}

				if (settings?.Patches?.ReflectDamage ?? default)
				{
					ScrambledBugs.Patches.ReflectDamage.Patch();
				}

				if (settings?.Patches?.TeammateDifficulty ?? default)
				{
					ScrambledBugs.Patches.TeammateDifficulty.Patch();
				}

				if (settings?.Patches?.UnderfilledSoulGems ?? default)
				{
					ScrambledBugs.Patches.UnderfilledSoulGems.Patch();
				}

				// Fixes
				if (settings?.Fixes?.ApplySpellPerkEntryPoints.Arrows ?? default)
				{
					ScrambledBugs.Fixes.ApplySpellPerkEntryPoints.Arrows.Fix();
				}

				Plugin.Trampoline.Commit();
			}

			return true;
		}
	}
}
