namespace Eggstensions
{
	public enum ActorValue : System.Int32
	{
		None			= -1,
		Health			= 24,
		Magicka			= 25,
		Stamina			= 26,
		SpeedMult		= 30,
		WardPower		= 63,
		RightItemCharge	= 64,
		LeftItemCharge	= 82
	}

	public enum ActorValueModifier : System.Int32
	{
		Permanent	= 0,
		Temporary	= 1,
		Damage		= 2
	}



	public interface IActorValueOwner : IVirtualObject
	{
	}

	public struct ActorValueOwner : IActorValueOwner
	{
	}



	namespace ExtensionMethods
	{
		unsafe static public class IActorValueOwner
		{
			// Virtual
			static public System.Single GetActorValue<TActorValueOwner>(this ref TActorValueOwner actorValueOwner, ActorValue actorValue)
				where TActorValueOwner : unmanaged, Eggstensions.IActorValueOwner
			{
				var getActorValue = (delegate* unmanaged[Cdecl]<TActorValueOwner*, System.Int32, System.Single>)actorValueOwner.VirtualFunction(0x1);

				return GetActorValue(actorValueOwner.AsPointer(), (System.Int32)actorValue);



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				System.Single GetActorValue(TActorValueOwner* actorValueOwner, System.Int32 actorValue)
				{
					return getActorValue(actorValueOwner, actorValue);
				}
			}

			static public System.Single GetPermanentActorValue<TActorValueOwner>(this ref TActorValueOwner actorValueOwner, ActorValue actorValue)
				where TActorValueOwner : unmanaged, Eggstensions.IActorValueOwner
			{
				var getPermanentActorValue = (delegate* unmanaged[Cdecl]<TActorValueOwner*, System.Int32, System.Single>)actorValueOwner.VirtualFunction(0x2);

				return GetPermanentActorValue(actorValueOwner.AsPointer(), (System.Int32)actorValue);



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				System.Single GetPermanentActorValue(TActorValueOwner* actorValueOwner, System.Int32 actorValue)
				{
					return getPermanentActorValue(actorValueOwner, actorValue);
				}
			}

			static public void RestoreActorValue<TActorValueOwner>(this ref TActorValueOwner actorValueOwner, ActorValueModifier actorValueModifier, ActorValue actorValue, System.Single value)
				where TActorValueOwner : unmanaged, Eggstensions.IActorValueOwner
			{
				var restoreActorValue = (delegate* unmanaged[Cdecl]<TActorValueOwner*, System.Int32, System.Int32, System.Single, void>)actorValueOwner.VirtualFunction(0x6);

				RestoreActorValue(actorValueOwner.AsPointer(), (System.Int32)actorValueModifier, (System.Int32)actorValue, value);



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				void RestoreActorValue(TActorValueOwner* actorValueOwner, System.Int32 actorValueModifier, System.Int32 actorValue, System.Single value)
				{
					restoreActorValue(actorValueOwner, actorValueModifier, actorValue, value);
				}
			}

			static public void SetActorValue<TActorValueOwner>(this ref TActorValueOwner actorValueOwner, ActorValue actorValue, System.Single value)
				where TActorValueOwner : unmanaged, Eggstensions.IActorValueOwner
			{
				var setActorValue = (delegate* unmanaged[Cdecl]<TActorValueOwner*, System.Int32, System.Single, void>)actorValueOwner.VirtualFunction(0x7);

				SetActorValue(actorValueOwner.AsPointer(), (System.Int32)actorValue, value);



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				void SetActorValue(TActorValueOwner* actorValueOwner, System.Int32 actorValue, System.Single value)
				{
					setActorValue(actorValueOwner, actorValue, value);
				}
			}
		}
	}
}
