namespace Eggstensions
{
	public interface IValueModifierEffect : IActiveEffect
	{
	}

	public struct ValueModifierEffect : IValueModifierEffect
	{
	}



	namespace ExtensionMethods
	{
		unsafe static public class IValueModifierEffect
		{
			// Field
			static public ActorValue ActorValue<TValueModifierEffect>(this ref TValueModifierEffect valueModifierEffect)
				where TValueModifierEffect : unmanaged, Eggstensions.IValueModifierEffect
			{
				return (ActorValue)(*(System.Int32*)valueModifierEffect.AddByteOffset(0x90));
			}



			// Virtual
			static public void ModifyActorValue<TValueModifierEffect, TActor>(this ref TValueModifierEffect valueModifierEffect, TActor* actor, System.Single magnitude, ActorValue actorValue)
				where TValueModifierEffect : unmanaged, Eggstensions.IValueModifierEffect
				where TActor : unmanaged, Eggstensions.IActor
			{
				var modifyActorValue = (delegate* unmanaged[Cdecl]<TValueModifierEffect*, TActor*, System.Single, System.Int32, void>)valueModifierEffect.VirtualFunction(0x20);

				ModifyActorValue(valueModifierEffect.AsPointer(), actor, magnitude, (System.Int32)actorValue);



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				void ModifyActorValue(TValueModifierEffect* valueModifierEffect, TActor* actor, System.Single magnitude, System.Int32 actorValue)
				{
					modifyActorValue(valueModifierEffect, actor, magnitude, actorValue);
				}
			}
		}
	}
}
