using Eggstensions;



namespace ScrambledBugs.Fixes
{
	unsafe static internal class ActorValuePercentage
	{
		static public ScrambledBugs.Delegates.Types.Fixes.ActorValuePercentage.GetActorValuePercentage GetActorValuePercentage { get; set; }
		static public ScrambledBugs.Delegates.Types.Fixes.ActorValuePercentage.GetHealthPercentage GetHealthPercentage { get; set; }
		static public ScrambledBugs.Delegates.Types.Fixes.ActorValuePercentage.GetStaminaPercentage GetStaminaPercentage { get; set; }



		static public void Fix()
		{
			ActorValuePercentage.GetActorValuePercentage = (Actor* actor, System.Int32 actorValue) =>
			{
				var permanentValue = ActorValueOwner.GetPermanentActorValue(&actor->ActorValueOwner, (ActorValue)actorValue);
				var temporaryValue = Actor.GetActorValueModifier(actor, ActorValueModifier.Temporary, (ActorValue)actorValue);

				if (permanentValue + temporaryValue == 0.0F)
				{
					return 1.0F;
				}

				var value = ActorValueOwner.GetActorValue(&actor->ActorValueOwner, (ActorValue)actorValue);

				return value / (permanentValue + temporaryValue);
			};

			ScrambledBugs.Plugin.Trampoline.WriteRelativeCall<ScrambledBugs.Delegates.Types.Fixes.ActorValuePercentage.GetActorValuePercentage>
			(
				ScrambledBugs.Offsets.Fixes.ActorValuePercentage.ActorValueCondition,
				ActorValuePercentage.GetActorValuePercentage
			);

			ScrambledBugs.Plugin.Trampoline.WriteRelativeCall<ScrambledBugs.Delegates.Types.Fixes.ActorValuePercentage.GetActorValuePercentage>
			(
				ScrambledBugs.Offsets.Fixes.ActorValuePercentage.ActorValueEnemyHealth,
				ActorValuePercentage.GetActorValuePercentage
			);

			ScrambledBugs.Plugin.Trampoline.WriteRelativeCall<ScrambledBugs.Delegates.Types.Fixes.ActorValuePercentage.GetActorValuePercentage>
			(
				ScrambledBugs.Offsets.Fixes.ActorValuePercentage.ActorValuePapyrus,
				ActorValuePercentage.GetActorValuePercentage
			);



			ActorValuePercentage.GetHealthPercentage = (Actor* actor) =>
			{
				return ActorValuePercentage.GetActorValuePercentage(actor, (System.Int32)ActorValue.Health);
			};

			ScrambledBugs.Plugin.Trampoline.WriteRelativeCall<ScrambledBugs.Delegates.Types.Fixes.ActorValuePercentage.GetHealthPercentage>
			(
				ScrambledBugs.Offsets.Fixes.ActorValuePercentage.HealthCondition,
				ActorValuePercentage.GetHealthPercentage
			);



			ActorValuePercentage.GetStaminaPercentage = (Actor* actor) =>
			{
				using (var movementActor = new NiPointer())
				{
					Actor.GetMovementActor(actor, &movementActor);
					
					return ActorValuePercentage.GetActorValuePercentage(movementActor.Actor, (System.Int32)ActorValue.Stamina);
				}
			};

			ScrambledBugs.Plugin.Trampoline.WriteRelativeCall<ScrambledBugs.Delegates.Types.Fixes.ActorValuePercentage.GetStaminaPercentage>
			(
				ScrambledBugs.Offsets.Fixes.ActorValuePercentage.StaminaCondition,
				ActorValuePercentage.GetStaminaPercentage
			);
		}
	}
}
