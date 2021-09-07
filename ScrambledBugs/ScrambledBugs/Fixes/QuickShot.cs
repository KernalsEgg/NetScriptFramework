using Eggstensions;



namespace ScrambledBugs.Fixes
{
	unsafe static internal class QuickShot
	{
		static public ScrambledBugs.Delegates.Types.Fixes.QuickShot.GetArrowPower GetArrowPower { get; set; }



		static public void Fix(System.Single quickShotPlaybackSpeed)
		{
			QuickShot.GetArrowPower = (System.Single drawTime, System.Single bowSpeed) =>
			{
				if (bowSpeed <= 0.0F)
				{
					bowSpeed = 1.0F;
				}

				System.Byte animationVariable;
				System.Single pullTime;

				var animationVariableName	= new BSFixedString();
				var player					= PlayerCharacter.Instance;
				var arrowBowMinTime			= SettingT.GameSettingCollection.ArrowBowMinTime->Setting.Value.Single;

				try
				{
					BSFixedString.Initialize(&animationVariableName, "bPerkQuickDraw");

					if (IAnimationGraphManagerHolder.GetAnimationVariableBool(&player->Actor.TESObjectREFR.IAnimationGraphManagerHolder, &animationVariableName, &animationVariable) && (animationVariable != 0))
					{
						pullTime = drawTime - (arrowBowMinTime / quickShotPlaybackSpeed);
					}
					else
					{
						pullTime = drawTime - arrowBowMinTime;
					}
				}
				finally
				{
					BSFixedString.Release(&animationVariableName);
				}

				var arrowMinPower = SettingT.GameSettingCollection.ArrowMinPower->Setting.Value.Single;

				if (pullTime <= 0.0F)
				{
					return arrowMinPower;
				}

				var bowDrawTime		= SettingT.GameSettingCollection.BowDrawTime->Setting.Value.Single;
				var maximumPullTime	= (bowDrawTime - arrowBowMinTime) / bowSpeed;

				if (pullTime >= maximumPullTime)
				{
					return 1.0F;
				}
				else
				{
					return arrowMinPower + ((pullTime / maximumPullTime) * (1.0F - arrowMinPower));
				}
			};

			ScrambledBugs.Plugin.Trampoline.WriteRelativeCall<ScrambledBugs.Delegates.Types.Fixes.QuickShot.GetArrowPower>
			(
				ScrambledBugs.Offsets.Fixes.QuickShot.CreateProjectile,
				QuickShot.GetArrowPower
			);

			ScrambledBugs.Plugin.Trampoline.WriteRelativeCall<ScrambledBugs.Delegates.Types.Fixes.QuickShot.GetArrowPower>
			(
				ScrambledBugs.Offsets.Fixes.QuickShot.KillCamera,
				QuickShot.GetArrowPower
			);
		}
	}
}
