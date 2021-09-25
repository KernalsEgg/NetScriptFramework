namespace Eggstensions
{
	public enum EquipType : System.Int32
	{
		LeftHand	= 0,
		RightHand	= 1,
	}



	public interface IActor : ITESObjectREFR
	{
	}

	public struct Actor : IActor
	{
	}



	namespace ExtensionMethods
	{
		unsafe static public class IActor
		{
			// Inheritance
			static public MagicTarget* MagicTarget<TActor>(this ref TActor actor)
				where TActor : unmanaged, Eggstensions.IActor
			{
				return (MagicTarget*)actor.AddByteOffset(0x98);
			}

			static public ActorValueOwner* ActorValueOwner<TActor>(this ref TActor actor)
				where TActor : unmanaged, Eggstensions.IActor
			{
				return (ActorValueOwner*)actor.AddByteOffset(0xB0);
			}



			// Field
			static public ActorProcess* CurrentProcess<TActor>(this ref TActor actor)
				where TActor : unmanaged, Eggstensions.IActor
			{
				return *(ActorProcess**)actor.AddByteOffset(0xF0);
			}



			// Virtual
			static public MagicCaster* GetMagicCaster<TActor>(this ref TActor actor, CastingSource castingSource)
				where TActor : unmanaged, Eggstensions.IActor
			{
				var getMagicCaster = (delegate* unmanaged[Cdecl]<TActor*, System.Int32, MagicCaster*>)actor.VirtualFunction(0x5C);

				return GetMagicCaster(actor.AsPointer(), (System.Int32)castingSource);



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				MagicCaster* GetMagicCaster(TActor* actor, System.Int32 castingSource)
				{
					return getMagicCaster(actor, castingSource);
				}
			}



			// Member
			static public System.Boolean AddSpell<TActor, TSpellItem>(this ref TActor actor, TSpellItem* spell)
				where TActor : unmanaged, Eggstensions.IActor
				where TSpellItem : unmanaged, Eggstensions.ISpellItem
			{
				var addSpell = (delegate* unmanaged[Cdecl]<TActor*, TSpellItem*, System.Byte>)Eggstensions.Offsets.Actor.AddSpell;

				return AddSpell(actor.AsPointer(), spell) != 0;



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				System.Byte AddSpell(TActor* actor, TSpellItem* spell)
				{
					return addSpell(actor, spell);
				}
			}

			static public System.Single GetActorValueModifier<TActor>(this ref TActor actor, ActorValueModifier actorValueModifier, ActorValue actorValue)
				where TActor : unmanaged, Eggstensions.IActor
			{
				var getActorValueModifier = (delegate* unmanaged[Cdecl]<TActor*, System.Int32, System.Int32, System.Single>)Eggstensions.Offsets.Actor.GetActorValueModifier;

				return GetActorValueModifier(actor.AsPointer(), (System.Int32)actorValueModifier, (System.Int32)actorValue);



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				System.Single GetActorValueModifier(TActor* actor, System.Int32 actorValueModifier, System.Int32 actorValue)
				{
					return getActorValueModifier(actor, actorValueModifier, actorValue);
				}
			}

			static public TESObjectWEAP* GetEquippedWeapon<TActor>(this ref TActor actor, System.Boolean leftHand)
				where TActor : unmanaged, Eggstensions.IActor
			{
				var getEquippedWeapon = (delegate* unmanaged[Cdecl]<TActor*, System.Byte, TESObjectWEAP*>)Eggstensions.Offsets.Actor.GetEquippedWeapon;

				return GetEquippedWeapon(actor.AsPointer(), (System.Byte)(leftHand ? 1 : 0));



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				TESObjectWEAP* GetEquippedWeapon(TActor* actor, System.Byte leftHand)
				{
					return getEquippedWeapon(actor, leftHand);
				}
			}

			static public System.Single GetMaximumWardPower<TActor>(this ref TActor actor)
				where TActor : unmanaged, Eggstensions.IActor
			{
				var getMaximumWardPower = (delegate* unmanaged[Cdecl]<TActor*, System.Single>)Eggstensions.Offsets.Actor.GetMaximumWardPower;

				return GetMaximumWardPower(actor.AsPointer());



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				System.Single GetMaximumWardPower(TActor* actor)
				{
					return getMaximumWardPower(actor);
				}
			}

			static public System.Boolean GetMovementActor<TActor>(this ref TActor actor, NiPointer* movementActor)
				where TActor : unmanaged, Eggstensions.IActor
			{
				var getMovementActor = (delegate* unmanaged[Cdecl]<TActor*, NiPointer*, System.Byte>)Eggstensions.Offsets.Actor.GetMovementActor;

				return GetMovementActor(actor.AsPointer(), movementActor) != 0;



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				System.Byte GetMovementActor(TActor* actor, NiPointer* movementActor)
				{
					return getMovementActor(actor, movementActor);
				}
			}

			static public void RemoveActorValueModifiers<TActor>(this ref TActor actor, ActorValue actorValue)
				where TActor : unmanaged, Eggstensions.IActor
			{
				var removeActorValueModifiers = (delegate* unmanaged[Cdecl]<TActor*, System.Int32, void>)Eggstensions.Offsets.Actor.RemoveActorValueModifiers;

				RemoveActorValueModifiers(actor.AsPointer(), (System.Int32)actorValue);



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				void RemoveActorValueModifiers(TActor* actor, System.Int32 actorValue)
				{
					removeActorValueModifiers(actor, actorValue);
				}
			}

			static public void RevertSelectedSpell<TActor, TMagicItem>(this ref TActor actor, EquipType equipType, TMagicItem* magicItem)
				where TActor : unmanaged, Eggstensions.IActor
				where TMagicItem : unmanaged, Eggstensions.IMagicItem
			{
				var revertSelectedSpell = (delegate* unmanaged[Cdecl]<TActor*, System.Int32, TMagicItem*, void>)Eggstensions.Offsets.Actor.RevertSelectedSpell;

				RevertSelectedSpell(actor.AsPointer(), (System.Int32)equipType, magicItem);



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				void RevertSelectedSpell(TActor* actor, System.Int32 equipType, TMagicItem* magicItem)
				{
					revertSelectedSpell(actor, equipType, magicItem);
				}
			}

			static public void SetMaximumWardPower<TActor>(this ref TActor actor, System.Single maximumWardPower)
				where TActor : unmanaged, Eggstensions.IActor
			{
				var setMaximumWardPower = (delegate* unmanaged[Cdecl]<TActor*, System.Single, void>)Eggstensions.Offsets.Actor.SetMaximumWardPower;

				SetMaximumWardPower(actor.AsPointer(), maximumWardPower);



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				void SetMaximumWardPower(TActor* actor, System.Single maximumWardPower)
				{
					setMaximumWardPower(actor, maximumWardPower);
				}
			}

			static public void UpdateMovementSpeed<TActor>(this ref TActor actor)
				where TActor : unmanaged, Eggstensions.IActor
			{
				var updateMovementSpeed = (delegate* unmanaged[Cdecl]<TActor*, void>)Eggstensions.Offsets.Actor.UpdateMovementSpeed;

				UpdateMovementSpeed(actor.AsPointer());



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				void UpdateMovementSpeed(TActor* actor)
				{
					updateMovementSpeed(actor);
				}
			}
		}
	}
}
