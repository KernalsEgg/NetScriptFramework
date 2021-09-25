using Eggstensions;



namespace ScrambledBugs
{
	static public class Plugin
	{
		[System.Runtime.InteropServices.UnmanagedCallersOnly(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) }, EntryPoint = "Initialize")]
		static public void Initialize()
		{
			var path = System.IO.Path.Combine(Main.ExecutingAssemblyDirectoryName, $"{Main.ExecutingAssemblyName}.json");

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

				try
				{
					settings = Json.DeserializeAnonymousType
					(
						System.IO.File.ReadAllText(path),
						settings,
						new System.Text.Json.JsonSerializerOptions()
						{
							AllowTrailingCommas			= true,
							PropertyNameCaseInsensitive	= true,
							ReadCommentHandling			= System.Text.Json.JsonCommentHandling.Skip
						}
					);

					Log.WriteLine($"{settings}");

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

					Trampoline.Commit();
				}
				catch (System.Text.Json.JsonException jsonException)
				{
					Log.WriteLine($"{jsonException}");
				}
			}
		}
	}
}
