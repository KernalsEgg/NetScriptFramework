using Eggstensions;
using Eggstensions.ExtensionMethods;



namespace ScrambledBugs.Fixes
{
	unsafe static internal class ActorValuePercentage
	{
		static public System.Boolean Fix()
		{
			if
			(
				!ScrambledBugs.Patterns.Fixes.ActorValuePercentage.ActorValueCondition
				||
				!ScrambledBugs.Patterns.Fixes.ActorValuePercentage.ActorValueEnemyHealth
				||
				!ScrambledBugs.Patterns.Fixes.ActorValuePercentage.ActorValuePapyrus
				||
				!ScrambledBugs.Patterns.Fixes.ActorValuePercentage.HealthCondition
				||
				!ScrambledBugs.Patterns.Fixes.ActorValuePercentage.StaminaCondition
			)
			{
				return false;
			}

			ActorValuePercentage.GetActorValuePercentage();
			ActorValuePercentage.GetHealthPercentage();
			ActorValuePercentage.GetStaminaPercentage();

			return true;
		}



		static public void GetActorValuePercentage()
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
		}

		static public void GetHealthPercentage()
		{
			var getHealthPercentage = (delegate* unmanaged[Cdecl]<Actor*, System.Single>)&GetHealthPercentage;

			Trampoline.WriteRelativeCall(ScrambledBugs.Offsets.Fixes.ActorValuePercentage.HealthCondition, getHealthPercentage);

			[System.Runtime.InteropServices.UnmanagedCallersOnly(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
			static System.Single GetHealthPercentage(Actor* actor)
			{
				return ActorValuePercentage.GetActorValuePercentage(actor, ActorValue.Health);
			}
		}

		static public void GetStaminaPercentage()
		{
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



		static public System.Single GetActorValuePercentage(Actor* actor, ActorValue actorValue)
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
