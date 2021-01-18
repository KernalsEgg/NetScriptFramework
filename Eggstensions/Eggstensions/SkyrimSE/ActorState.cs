namespace Eggstensions.SkyrimSE
{
	static public class ActorState
	{
		public enum States1 : System.UInt32
		{
			
		}

		public enum States2 : System.UInt32
		{
			weapon1 = 1u << 4,
			weapon2 = 1u << 5,
			weapon3 = 1u << 6
		}



		/// <param name = "actorState">ActorState</param>
		static public ActorState.States1 GetActorState1(System.IntPtr actorState)
		{
			if (actorState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(actorState)); }

			return (ActorState.States1)NetScriptFramework.Memory.ReadUInt32(actorState + 0x8);
		}

		/// <param name = "actorState">ActorState</param>
		static public ActorState.States2 GetActorState2(System.IntPtr actorState)
		{
			if (actorState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(actorState)); }

			return (ActorState.States2)NetScriptFramework.Memory.ReadUInt32(actorState + 0xC);
		}
	}
}
