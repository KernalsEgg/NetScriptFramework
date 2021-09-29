using Eggstensions;
using Eggstensions.ExtensionMethods;



namespace ScrambledBugs.Fixes
{
	unsafe static internal class QuickShot
	{
		static public System.Boolean Fix(System.Single quickShotPlaybackSpeed)
		{
			if
			(
				!ScrambledBugs.Patterns.Fixes.QuickShot.CreateProjectile
				||
				!ScrambledBugs.Patterns.Fixes.QuickShot.KillCamera
			)
			{
				return false;
			}

			QuickShot.quickShotPlaybackSpeed = quickShotPlaybackSpeed;
			
			var getArrowPower = (delegate* unmanaged[Cdecl]<System.Single, System.Single, System.Single>)&GetArrowPower;

			Trampoline.WriteRelativeCall(ScrambledBugs.Offsets.Fixes.QuickShot.CreateProjectile, getArrowPower);
			Trampoline.WriteRelativeCall(ScrambledBugs.Offsets.Fixes.QuickShot.KillCamera, getArrowPower);

			[System.Runtime.InteropServices.UnmanagedCallersOnly(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
			static System.Single GetArrowPower(System.Single drawTime, System.Single bowSpeed)
			{
				if (bowSpeed <= 0.0F)
				{
					bowSpeed = 1.0F;
				}

				System.Byte animationVariable;
				System.Single pullTime;

				var player			= PlayerCharacter.Instance;
				var arrowBowMinTime	= SettingT.GameSettingCollection.ArrowBowMinTime->Setting.Value.Single;

				using var animationVariableName = new BSFixedString("bPerkQuickDraw");

				if (player->IAnimationGraphManagerHolder()->GetAnimationVariableBool(&animationVariableName, &animationVariable) && (animationVariable != 0))
				{
					pullTime = drawTime - (arrowBowMinTime / QuickShot.quickShotPlaybackSpeed);
				}
				else
				{
					pullTime = drawTime - arrowBowMinTime;
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
			}

			return true;
		}



		static public System.Single quickShotPlaybackSpeed;
	}
}
