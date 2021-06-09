using Eggstensions;
using Eggstensions.Events;



namespace ScrambledBugs.Fixes
{
	internal class SpeedMultUpdates
	{
		public SpeedMultUpdates()
		{
			AddActorValueEventSinks.EventHandler -= SpeedMultUpdates.OnAddActorValueEventSinks;
			AddActorValueEventSinks.EventHandler += SpeedMultUpdates.OnAddActorValueEventSinks;
		}



		static public Delegates.Types.Fixes.SpeedMultUpdates.ActorValueSink SpeedMultSinkDelegate { get; } = SpeedMultUpdates.SpeedMultSink;

		static public System.IntPtr SaveManager
		{
			get
			{
				return Memory.Read<System.IntPtr>(Offsets.Fixes.SpeedMultUpdates.SaveManager);
			}
		}



		static public void OnAddActorValueEventSinks(System.Object sender, System.EventArgs arguments)
		{
			AddActorValueEventSinks.EventHandler -= SpeedMultUpdates.OnAddActorValueEventSinks;

			var functionTableAddress	= NetScriptFramework.Main.GameInfo.GetAddressOf(517376, Memory<System.IntPtr>.Size * (System.Int32)ActorValue.SpeedMult, 0, "00 00 00 00 00 00 00 00"); // SkyrimSE.exe + 0x2F39A40
			var functionAddress			= System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(SpeedMultUpdates.SpeedMultSinkDelegate);

			Memory.Write<System.IntPtr>(functionTableAddress, functionAddress);
		}

		static public void RemoveMovementFlags(System.IntPtr actor)
		{
			Delegates.Instances.Fixes.SpeedMultUpdates.RemoveMovementFlags(actor);
		}

		/// <param name="actor">Actor*</param>
		/// <param name="actorValue">ActorValue</param>
		static public void SpeedMultSink(System.IntPtr actor, System.Int32 actorValue, System.Single old, System.Single delta)
		{
			// actor != System.IntPtr.Zero

			SpeedMultUpdates.RemoveMovementFlags(actor);

			var saveManager = SpeedMultUpdates.SaveManager;

			if (saveManager != System.IntPtr.Zero)
			{
				if (((Memory.Read<System.UInt32>(saveManager, 0x340) >> 1) & 1) == 0)
				{
					SpeedMultUpdates.UpdateMovementSpeed(actor);
				}
			}
		}

		static public void UpdateMovementSpeed(System.IntPtr actor)
		{
			Delegates.Instances.Fixes.SpeedMultUpdates.UpdateMovementSpeed(actor);
		}
	}
}
