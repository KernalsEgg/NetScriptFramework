namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x98)]
	unsafe public struct ValueModifierEffect
	{
		[System.Runtime.InteropServices.FieldOffset(0x0)] public ActiveEffect ActiveEffect;
		[System.Runtime.InteropServices.FieldOffset(0x90)] public ActorValue ActorValue;



		// Virtual
		static public void ModifyActorValue(ValueModifierEffect* valueModifierEffect, Actor* actor, System.Single magnitude, ActorValue actorValue)
		{
			var modifyActorValue = Memory.ReadVirtualFunction<Eggstensions.Delegates.Types.ValueModifierEffect.ModifyActorValue>(*(System.IntPtr*)valueModifierEffect, 0x20);

			modifyActorValue(valueModifierEffect, actor, magnitude, (System.Int32)actorValue);
		}
	}
}
