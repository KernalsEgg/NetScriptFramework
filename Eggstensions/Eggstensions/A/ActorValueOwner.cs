namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x8)]
	unsafe public struct ActorValueOwner
	{
		// Virtual
		static public void RestoreActorValue(ActorValueOwner* actorValueOwner, ActorValueModifier actorValueModifier, ActorValue actorValue, System.Single value)
		{
			var restoreActorValue = Memory.ReadVirtualFunction<Eggstensions.Delegates.Types.ActorValueOwner.RestoreActorValue>(*(System.IntPtr*)actorValueOwner, 0x6);

			restoreActorValue(actorValueOwner, (System.Int32)actorValueModifier, (System.Int32)actorValue, value);
		}

		static public void SetActorValue(ActorValueOwner* actorValueOwner, ActorValue actorValue, System.Single value)
		{
			var setActorValue = Memory.ReadVirtualFunction<Eggstensions.Delegates.Types.ActorValueOwner.SetActorValue>(*(System.IntPtr*)actorValueOwner, 0x7);

			setActorValue(actorValueOwner, (System.Int32)actorValue, value);
		}
	}
}
