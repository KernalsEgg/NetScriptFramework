using Eggstensions;



namespace ScrambledBugs
{
	static public class Plugin
	{
		[System.Runtime.InteropServices.UnmanagedCallersOnly(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
		static public void Initialize()
		{
			var path = System.IO.Path.Combine(Main.ExecutingAssemblyDirectoryName, $"{Main.ExecutingAssemblyName}.json");

			if (System.IO.File.Exists(path))
			{
				try
				{
					var settings = System.Text.Json.JsonSerializer.Deserialize<ScrambledBugs.JsonSettings>
					(
						System.IO.File.ReadAllText(path),
						new System.Text.Json.JsonSerializerOptions()
						{
							AllowTrailingCommas			= true,
							PropertyNameCaseInsensitive	= true,
							ReadCommentHandling			= System.Text.Json.JsonCommentHandling.Skip
						}
					);

					Log.Information($"In:\n{System.Text.Json.JsonSerializer.Serialize<ScrambledBugs.JsonSettings>(settings, new System.Text.Json.JsonSerializerOptions() { PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase, WriteIndented = true })}");

					// Fixes
					if (settings?.Fixes?.ActorValuePercentage ?? false)
					{
						settings.Fixes.ActorValuePercentage = ScrambledBugs.Fixes.ActorValuePercentage.Fix();
					}

					if (settings?.Fixes?.HarvestedFlags ?? false)
					{
						settings.Fixes.HarvestedFlags = ScrambledBugs.Fixes.HarvestedFlags.Fix();
					}

					if (settings?.Fixes?.HitEffectRaceCondition ?? false)
					{
						settings.Fixes.HitEffectRaceCondition = ScrambledBugs.Fixes.HitEffectRaceCondition.Fix();
					}

					if (settings?.Fixes?.MagicEffectConditions ?? false)
					{
						settings.Fixes.MagicEffectConditions = ScrambledBugs.Fixes.MagicEffectConditions.Fix();
					}

					if (settings?.Fixes?.MagicEffectFlags ?? false)
					{
						settings.Fixes.MagicEffectFlags = ScrambledBugs.Fixes.MagicEffectFlags.Fix();
					}

					if (settings?.Fixes?.ModArmorWeightPerkEntryPoint ?? false)
					{
						settings.Fixes.ModArmorWeightPerkEntryPoint = ScrambledBugs.Fixes.ModArmorWeightPerkEntryPoint.Fix();
					}

					if (settings?.Fixes?.MovementSpeed ?? false)
					{
						settings.Fixes.MovementSpeed = ScrambledBugs.Fixes.MovementSpeed.Fix();
					}

					if ((settings?.Fixes?.QuickShot ?? false) && (settings?.Fixes?.QuickShotPlaybackSpeed.HasValue ?? false))
					{
						settings.Fixes.QuickShot = ScrambledBugs.Fixes.QuickShot.Fix(settings.Fixes.QuickShotPlaybackSpeed.Value);
					}

					if (settings?.Fixes?.TerrainDecals ?? false)
					{
						settings.Fixes.TerrainDecals = ScrambledBugs.Fixes.TerrainDecals.Fix();
					}

					if (settings?.Fixes?.TrainingMenuText ?? false)
					{
						settings.Fixes.TrainingMenuText = ScrambledBugs.Fixes.TrainingMenuText.Fix();
					}

					if (settings?.Fixes?.WeaponCharge ?? false)
					{
						settings.Fixes.WeaponCharge = ScrambledBugs.Fixes.WeaponCharge.Fix();
					}

					// Patches
					if (settings?.Patches?.AccumulatingMagnitude ?? false)
					{
						settings.Patches.AccumulatingMagnitude = ScrambledBugs.Patches.AccumulatingMagnitude.Patch();
					}

					if (settings?.Patches?.AlreadyCaughtPickpocketing ?? false)
					{
						settings.Patches.AlreadyCaughtPickpocketing = ScrambledBugs.Patches.AlreadyCaughtPickpocketing.Patch();
					}

					if (settings?.Patches?.ApplySpellPerkEntryPoints?.MultipleSpells ?? false)
					{
						settings.Patches.ApplySpellPerkEntryPoints.MultipleSpells = ScrambledBugs.Patches.ApplySpellPerkEntryPoints.MultipleSpells.Patch(settings?.Patches?.ApplySpellPerkEntryPoints?.CastSpells ?? false);
					}
					else if (settings?.Patches?.ApplySpellPerkEntryPoints?.CastSpells ?? false)
					{
						settings.Patches.ApplySpellPerkEntryPoints.CastSpells = ScrambledBugs.Patches.ApplySpellPerkEntryPoints.CastSpells.Patch();
					}

					if (settings?.Patches?.AttachHitEffectArt ?? false)
					{
						settings.Patches.AttachHitEffectArt = ScrambledBugs.Patches.AttachHitEffectArt.Patch();
					}

					if (settings?.Patches?.EquipBestAmmo ?? false)
					{
						settings.Patches.EquipBestAmmo = ScrambledBugs.Patches.EquipBestAmmo.Patch();
					}

					if (settings?.Patches?.LockpickingExperience ?? false)
					{
						settings.Patches.LockpickingExperience = ScrambledBugs.Patches.LockpickingExperience.Patch();
					}

					if (settings?.Patches?.MultipleHitEffects ?? false)
					{
						settings.Patches.MultipleHitEffects = ScrambledBugs.Patches.MultipleHitEffects.Patch();
					}

					if (settings?.Patches?.PausedGameHitEffects ?? false)
					{
						settings.Patches.PausedGameHitEffects = ScrambledBugs.Patches.PausedGameHitEffects.Patch();
					}

					if (settings?.Patches?.PowerAttackStamina ?? false)
					{
						settings.Patches.PowerAttackStamina = ScrambledBugs.Patches.PowerAttackStamina.Patch();
					}

					if (settings?.Patches?.ReflectDamage ?? false)
					{
						settings.Patches.ReflectDamage = ScrambledBugs.Patches.ReflectDamage.Patch();
					}

					if (settings?.Patches?.TeammateDifficulty ?? false)
					{
						settings.Patches.TeammateDifficulty = ScrambledBugs.Patches.TeammateDifficulty.Patch();
					}

					if (settings?.Patches?.UnderfilledSoulGems ?? false)
					{
						settings.Patches.UnderfilledSoulGems = ScrambledBugs.Patches.UnderfilledSoulGems.Patch();
					}

					// Fixes
					if (settings?.Fixes?.ApplySpellPerkEntryPoints?.Arrows ?? false)
					{
						settings.Fixes.ApplySpellPerkEntryPoints.Arrows = ScrambledBugs.Fixes.ApplySpellPerkEntryPoints.Arrows.Fix();
					}

					Log.Information($"Out:\n{System.Text.Json.JsonSerializer.Serialize<ScrambledBugs.JsonSettings>(settings, new System.Text.Json.JsonSerializerOptions() { PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase, WriteIndented = true })}");

					Trampoline.Commit();
				}
				catch (System.Text.Json.JsonException jsonException)
				{
					Log.Information($"{jsonException}");
				}
			}
		}
	}
}
