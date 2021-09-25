using Eggstensions;
using Eggstensions.ExtensionMethods;



namespace ScrambledBugs.Fixes
{
	unsafe static internal class ActorValuePercentage
	{
		static public void Fix()
		{
			var getActorValuePercentage = (delegate* unmanaged[Cdecl]<Actor*, System.Int32, System.Single>)&GetActorValuePercentage;

			Trampoline.WriteRelativeCall(ScrambledBugs.Offsets.Fixes.ActorValuePercentage.ActorValueCondition, getActorValuePercentage);
			Trampoline.WriteRelativeCall(ScrambledBugs.Offsets.Fixes.ActorValuePercentage.ActorValueEnemyHealth, getActorValuePercentage);
			Trampoline.WriteRelativeCall(ScrambledBugs.Offsets.Fixes.ActorValuePercentage.ActorValuePapyrus, getActorValuePercentage);

			[System.Runtime.InteropServices.UnmanagedCallersOnly(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
			static System.Single GetActorValuePercentage(Actor* actor, System.Int32 actorValue)
			{
				return ActorValuePercentage.GetActorValuePercentage(actor, (ActorValue)actorValue);
			}



			var getHealthPercentage = (delegate* unmanaged[Cdecl]<Actor*, System.Single>)&GetHealthPercentage;

			Trampoline.WriteRelativeCall(ScrambledBugs.Offsets.Fixes.ActorValuePercentage.HealthCondition, getHealthPercentage);

			[System.Runtime.InteropServices.UnmanagedCallersOnly(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
			static System.Single GetHealthPercentage(Actor* actor)
			{
				return ActorValuePercentage.GetActorValuePercentage(actor, ActorValue.Health);
			}



			var getStaminaPercentage = (delegate* unmanaged[Cdecl]<Actor*, System.Single>)&GetStaminaPercentage;

			Trampoline.WriteRelativeCall(ScrambledBugs.Offsets.Fixes.ActorValuePercentage.StaminaCondition, getStaminaPercentage);

			[System.Runtime.InteropServices.UnmanagedCallersOnly(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
			static System.Single GetStaminaPercentage(Actor* actor)
			{
				using var movementActor = new NiPointer();
				actor->GetMovementActor(&movementActor);

				return ActorValuePercentage.GetActorValuePercentage((Actor*)movementActor.Reference, ActorValue.Stamina);
			}
		}



		static System.Single GetActorValuePercentage(Actor* actor, ActorValue actorValue)
		{
			var permanentValue = actor->ActorValueOwner()->GetPermanentActorValue(actorValue);
			var temporaryValue = actor->GetActorValueModifier(ActorValueModifier.Temporary, actorValue);

			if (permanentValue + temporaryValue == 0.0F)
			{
				return 1.0F;
			}

			var value = actor->ActorValueOwner()->GetActorValue(actorValue);

			return value / (permanentValue + temporaryValue);
		}
	}
}
