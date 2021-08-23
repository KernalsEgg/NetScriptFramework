namespace Eggstensions
{
	public enum ActorValue : System.Int32
	{
		None			= -1,
		Magicka			= 25,
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



	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x8)]
	unsafe public struct ActorValueOwner
	{
		// Virtual
		static public System.Single GetActorValue(ActorValueOwner* actorValueOwner, ActorValue actorValue)
		{
			var getActorValue = Memory.ReadVirtualFunction<Eggstensions.Delegates.Types.ActorValueOwner.GetActorValue>(*(System.IntPtr*)actorValueOwner, 0x1);

			return getActorValue(actorValueOwner, (System.Int32)actorValue);
		}

		static public System.Single GetPermanentActorValue(ActorValueOwner* actorValueOwner, ActorValue actorValue)
		{
			var getPermanentActorValue = Memory.ReadVirtualFunction<Eggstensions.Delegates.Types.ActorValueOwner.GetPermanentActorValue>(*(System.IntPtr*)actorValueOwner, 0x2);

			return getPermanentActorValue(actorValueOwner, (System.Int32)actorValue);
		}

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
