using Eggstensions;

using Events = Eggstensions.Events;



namespace ScrambledBugs.Fixes
{
	unsafe internal class SpeedMultUpdates
	{
		static SpeedMultUpdates()
		{
			SpeedMultUpdates.SpeedMultSink = (Actor* actor, System.Int32 actorValue, System.Single old, System.Single delta) =>
			{
				// actor != null

				ScrambledBugs.Delegates.Instances.Fixes.SpeedMultUpdates.RemoveMovementFlags(actor);

				var saveManager = Memory.Read<System.IntPtr>(ScrambledBugs.Offsets.Fixes.SpeedMultUpdates.SaveManager);

				if (saveManager != System.IntPtr.Zero)
				{
					if (((Memory.Read<System.UInt32>(saveManager, 0x340) >> 1) & 1) == 0)
					{
						Actor.UpdateMovementSpeed(actor);
					}
				}
			};

			Events.Initialize.After -= SpeedMultUpdates.OnInitialize;
			Events.Initialize.After += SpeedMultUpdates.OnInitialize;
		}



		static public ScrambledBugs.Delegates.Types.Fixes.SpeedMultUpdates.ActorValueSink SpeedMultSink { get; }



		static public void OnInitialize(System.Object sender, System.EventArgs arguments)
		{
			Events.Initialize.After -= SpeedMultUpdates.OnInitialize;

			Memory.Write<System.IntPtr>
			(
				ScrambledBugs.Offsets.Fixes.SpeedMultUpdates.ActorValueSinkFunctionTable + Memory.Size<System.IntPtr>.Unmanaged * (System.Int32)ActorValue.SpeedMult,
				System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<ScrambledBugs.Delegates.Types.Fixes.SpeedMultUpdates.ActorValueSink>(SpeedMultUpdates.SpeedMultSink)
			);
		}
	}
}
