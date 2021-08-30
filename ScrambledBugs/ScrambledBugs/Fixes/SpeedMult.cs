using Eggstensions;

using Events = Eggstensions.Events;



namespace ScrambledBugs.Fixes
{
	unsafe static internal class SpeedMult
	{
		[System.Flags]
		public enum SaveManagerFlags : System.UInt32
		{
			Loaded = 1 << 1
		}
		
		
		
		static public ScrambledBugs.Delegates.Types.Fixes.SpeedMult.ActorValueSink SpeedMultSink { get; set; }



		static public void Fix()
		{
			SpeedMult.SpeedMultSink = (Actor* actor, System.Int32 actorValue, System.Single old, System.Single delta) =>
			{
				// actor != null

				ScrambledBugs.Delegates.Instances.Fixes.SpeedMult.RemoveMovementFlags(actor);

				var saveManager = Memory.Read<System.IntPtr>(ScrambledBugs.Offsets.Fixes.SpeedMult.SaveManager);

				if (saveManager != System.IntPtr.Zero)
				{
					if (((SaveManagerFlags)Memory.Read<System.UInt32>(saveManager, 0x340) & SaveManagerFlags.Loaded) != SaveManagerFlags.Loaded)
					{
						Actor.UpdateMovementSpeed(actor);
					}
				}
			};

			Events.Initialize.After -= SpeedMult.OnInitialize;
			Events.Initialize.After += SpeedMult.OnInitialize;
		}

		static public void OnInitialize(System.Object sender, System.EventArgs arguments)
		{
			Events.Initialize.After -= SpeedMult.OnInitialize;

			Memory.Write<System.IntPtr>
			(
				ScrambledBugs.Offsets.Fixes.SpeedMult.ActorValueSinkFunctionTable,
				Memory.Size<System.IntPtr>.Unmanaged * (System.Int32)ActorValue.SpeedMult,
				System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<ScrambledBugs.Delegates.Types.Fixes.SpeedMult.ActorValueSink>(SpeedMult.SpeedMultSink)
			);
		}
	}
}
