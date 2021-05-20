using Eggstensions;
using Eggstensions.Interoperability.Events;		// AddActorValueEventSinks
using Eggstensions.Interoperability.Managed;	// Memory



namespace ScrambledBugs.Fixes
{
	namespace Delegates
	{
		namespace Instances
		{
			static internal class SpeedMultUpdates
			{
				static public Delegates.Types.SpeedMultUpdates.RemoveMovementFlags RemoveMovementFlags { get; }	= System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.SpeedMultUpdates.RemoveMovementFlags>(Offsets.SpeedMultUpdates.RemoveMovementFlags);

				static public Delegates.Types.SpeedMultUpdates.ActorValueSink SpeedMultSink { get; }			= ScrambledBugs.Fixes.SpeedMultUpdates.SpeedMultSink;

				static public Delegates.Types.SpeedMultUpdates.UpdateMovementSpeed UpdateMovementSpeed { get; }	= System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.SpeedMultUpdates.UpdateMovementSpeed>(Offsets.SpeedMultUpdates.UpdateMovementSpeed);
			}
		}

		namespace Types
		{
			static internal class SpeedMultUpdates
			{
				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate void ActorValueSink(System.IntPtr actor, System.Int32 actorValue, System.Single old, System.Single delta);

				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate void RemoveMovementFlags(System.IntPtr actor);

				[System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.Cdecl)]
				public delegate void UpdateMovementSpeed(System.IntPtr actor);
			}
		}
	}
	
	namespace Offsets
	{
		static internal class SpeedMultUpdates
		{
			/// <summary> SkyrimSE.exe + 0x5ED420 </summary>
			static public System.IntPtr RemoveMovementFlags { get; }		= NetScriptFramework.Main.GameInfo.GetAddressOf(36585);

			/// <summary> SkyrimSE.exe + 0x2F266F8 </summary>
			static public System.IntPtr SaveStateManager { get; }			= NetScriptFramework.Main.GameInfo.GetAddressOf(516851);

			/// <summary> SkyrimSE.exe + 0x607FA0 </summary>
			static public System.IntPtr UpdateMovementSpeed { get; }		= NetScriptFramework.Main.GameInfo.GetAddressOf(36916);
		}
	}
	


	internal class SpeedMultUpdates
	{
		public SpeedMultUpdates()
		{
			AddActorValueEventSinks.Handler -= SpeedMultUpdates.OnAddActorValueEventSinks;
			AddActorValueEventSinks.Handler += SpeedMultUpdates.OnAddActorValueEventSinks;
		}



		static public void OnAddActorValueEventSinks(System.Object sender, System.EventArgs arguments)
		{
			AddActorValueEventSinks.Handler -= SpeedMultUpdates.OnAddActorValueEventSinks;

			var functionTableAddress = NetScriptFramework.Main.GameInfo.GetAddressOf(517376, 0x8 * (System.Int32)ActorValue.SpeedMult, 0, "00 00 00 00 00 00 00 00"); // SkyrimSE.exe + 0x2F39A40
			var functionAddress = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(Delegates.Instances.SpeedMultUpdates.SpeedMultSink);
			Memory.WriteIntPtr(functionTableAddress, functionAddress);
		}

		static public void SpeedMultSink(System.IntPtr actor, System.Int32 actorValue, System.Single old, System.Single delta)
		{
			// actor != System.IntPtr.Zero

			Delegates.Instances.SpeedMultUpdates.RemoveMovementFlags(actor);

			var saveStateManager = Memory.ReadIntPtr(Offsets.SpeedMultUpdates.SaveStateManager);

			if (saveStateManager != System.IntPtr.Zero)
			{
				if (((Memory.ReadUInt32(saveStateManager, 0x340) >> 1) & 1) == 0)
				{
					Delegates.Instances.SpeedMultUpdates.UpdateMovementSpeed(actor);
				}
			}
		}
	}
}
