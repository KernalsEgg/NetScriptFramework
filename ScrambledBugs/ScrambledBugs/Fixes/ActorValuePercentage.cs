using Eggstensions;



namespace ScrambledBugs.Fixes
{
	unsafe static internal class ActorValuePercentage
	{
		static public ScrambledBugs.Delegates.Types.Fixes.ActorValuePercentage.GetActorValuePercentage GetActorValuePercentage { get; set; }



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
				ScrambledBugs.Offsets.Fixes.ActorValuePercentage.Condition,
				ActorValuePercentage.GetActorValuePercentage
			);

			ScrambledBugs.Plugin.Trampoline.WriteRelativeCall<ScrambledBugs.Delegates.Types.Fixes.ActorValuePercentage.GetActorValuePercentage>
			(
				ScrambledBugs.Offsets.Fixes.ActorValuePercentage.Papyrus,
				ActorValuePercentage.GetActorValuePercentage
			);
		}
	}
}
