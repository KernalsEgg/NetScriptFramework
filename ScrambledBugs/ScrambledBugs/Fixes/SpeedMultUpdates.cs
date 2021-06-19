using Eggstensions;

using Events = Eggstensions.Events;



namespace ScrambledBugs.Fixes
{
	internal class SpeedMultUpdates
	{
		public SpeedMultUpdates()
		{
			Events.Initialize.After -= SpeedMultUpdates.OnInitialize;
			Events.Initialize.After += SpeedMultUpdates.OnInitialize;
		}



		static public Delegates.Types.Fixes.SpeedMultUpdates.ActorValueSink NewSpeedMultSink { get; } = SpeedMultUpdates.SpeedMultSink;



		static public void OnInitialize(System.Object sender, System.EventArgs arguments)
		{
			Events.Initialize.After -= SpeedMultUpdates.OnInitialize;

			Memory.Write<System.IntPtr>(Offsets.Fixes.SpeedMultUpdates.ActorValueSinkFunctionTable + (System.Int32)ActorValue.SpeedMult * Memory<System.IntPtr>.Size, System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(SpeedMultUpdates.NewSpeedMultSink));
		}

		/// <param name="actorAddress">Actor</param>
		/// <param name="actorValue">ActorValue</param>
		static public void SpeedMultSink(System.IntPtr actorAddress, System.Int32 actorValue, System.Single old, System.Single delta)
		{
			// actorAddress != System.IntPtr.Zero

			Delegates.Instances.Fixes.SpeedMultUpdates.RemoveMovementFlags(actorAddress);

			var saveManager = Memory.Read<System.IntPtr>(Offsets.Fixes.SpeedMultUpdates.SaveManager);

			if (saveManager != System.IntPtr.Zero)
			{
				if (((Memory.Read<System.UInt32>(saveManager, 0x340) >> 1) & 1) == 0)
				{
					Delegates.Instances.Fixes.SpeedMultUpdates.UpdateMovementSpeed(actorAddress);
				}
			}
		}
	}
}
