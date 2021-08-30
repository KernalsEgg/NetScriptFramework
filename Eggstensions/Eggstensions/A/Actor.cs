namespace Eggstensions
{
	public enum EquipType : System.Int32
	{
		LeftHand	= 0,
		RightHand	= 1,
	}



	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x2B0)]
	unsafe public struct Actor
	{
		[System.Runtime.InteropServices.FieldOffset(0x0)] public TESObjectREFR TESObjectREFR;
		[System.Runtime.InteropServices.FieldOffset(0x98)] public MagicTarget MagicTarget;
		[System.Runtime.InteropServices.FieldOffset(0xB0)] public ActorValueOwner ActorValueOwner;
		[System.Runtime.InteropServices.FieldOffset(0xF0)] public ActorProcess* CurrentProcess;



		// Virtual
		static public MagicCaster* GetMagicCaster(Actor* actor, CastingSource castingSource)
		{
			var getMagicCaster = Memory.ReadVirtualFunction<Eggstensions.Delegates.Types.Actor.GetMagicCaster>(*(System.IntPtr*)actor, 0x5C);

			return getMagicCaster(actor, (System.Int32)castingSource);
		}



		// Member
		static public System.Boolean AddSpell(Actor* actor, SpellItem* spell)
		{
			return Eggstensions.Delegates.Instances.Actor.AddSpell(actor, spell) != 0;
		}

		static public System.Single GetActorValueModifier(Actor* actor, ActorValueModifier actorValueModifier, ActorValue actorValue)
		{
			return Eggstensions.Delegates.Instances.Actor.GetActorValueModifier(actor, (System.Int32)actorValueModifier, (System.Int32)actorValue);
		}

		static public System.Single GetMaximumWardPower(Actor* actor)
		{
			return Eggstensions.Delegates.Instances.Actor.GetMaximumWardPower(actor);
		}

		static public System.Boolean GetMovementActor(Actor* actor, NiPointer* movementActor)
		{
			return Eggstensions.Delegates.Instances.Actor.GetMovementActor(actor, movementActor) != 0;
		}

		static public void RemoveActorValueModifiers(Actor* actor, ActorValue actorValue)
		{
			Eggstensions.Delegates.Instances.Actor.RemoveActorValueModifiers(actor, (System.Int32)actorValue);
		}

		static public void RevertSelectedSpell(Actor* actor, EquipType equipType, MagicItem* magicItem)
		{
			Eggstensions.Delegates.Instances.Actor.RevertSelectedSpell(actor, (System.Int32)equipType, magicItem);
		}

		static public void SetMaximumWardPower(Actor* actor, System.Single maximumWardPower)
		{
			Eggstensions.Delegates.Instances.Actor.SetMaximumWardPower(actor, maximumWardPower);
		}

		static public void UpdateMovementSpeed(Actor* actor)
		{
			Eggstensions.Delegates.Instances.Actor.UpdateMovementSpeed(actor);
		}
	}
}
