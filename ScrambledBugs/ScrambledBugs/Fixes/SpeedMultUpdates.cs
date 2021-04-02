namespace ScrambledBugs.Fixes
{
	internal class SpeedMultUpdates
	{
		internal enum ActorValues : System.Byte
		{
			SpeedMult = 30
		}
		


		static protected class Offsets
		{
			static Offsets()
			{
				Offsets.AddActorValueUpdateListeners = NetScriptFramework.Main.GameInfo.GetAddressOf(5998);
				Offsets.UpdateMovementSpeed = NetScriptFramework.Main.GameInfo.GetAddressOf(36916);
				Offsets.RemoveMovementFlags = NetScriptFramework.Main.GameInfo.GetAddressOf(36585);
				Offsets.SaveStateManager = NetScriptFramework.Main.GameInfo.GetAddressOf(516851);
			}



			/// <summary> SkyrimSE.exe + 0x99CB0 </summary>
			static internal System.IntPtr AddActorValueUpdateListeners { get; }

			/// <summary> SkyrimSE.exe + 0x607FA0 </summary>
			static internal System.IntPtr UpdateMovementSpeed { get; }

			/// <summary> SkyrimSE.exe + 0x5ED420 </summary>
			static internal System.IntPtr RemoveMovementFlags { get; }

			/// <summary> SkyrimSE.exe + 0x2F266F8 </summary>
			static internal System.IntPtr SaveStateManager { get; }
		}



		internal SpeedMultUpdates()
		{
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = SpeedMultUpdates.Offsets.AddActorValueUpdateListeners + 4,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 5,
				After = cpuRegisters =>
				{
					var speedMultUpdateListenerAddress = NetScriptFramework.Main.GameInfo.GetAddressOf(517376, 0x8 * (System.Byte)SpeedMultUpdates.ActorValues.SpeedMult, 0, "00 00 00 00 00 00 00 00"); // SkyrimSE.exe + 0x2F39A40
					NetScriptFramework.Memory.WritePointer(speedMultUpdateListenerAddress, SpeedMultUpdateListenerAllocation.Address);
				},
			});
		}

		static SpeedMultUpdates()
		{
			SpeedMultUpdates.SpeedMultUpdateListenerAllocation = NetScriptFramework.Memory.Allocate(0x20, 0, true);
			SpeedMultUpdates.SpeedMultUpdateListenerAllocation.Pin();
			NetScriptFramework.Memory.WriteNop(SpeedMultUpdates.SpeedMultUpdateListenerAllocation.Address, 0x20);
			NetScriptFramework.Memory.WriteBytes(SpeedMultUpdates.SpeedMultUpdateListenerAllocation.Address + 13, new System.Byte[] { 0xC3 });

			// RCX: Actor, RDX: ActorValues.SpeedMult, XMM2f: ActorValue (previous), XMM3f: ActorValue (delta)
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = SpeedMultUpdates.SpeedMultUpdateListenerAllocation.Address,
				Pattern = "",
				ReplaceLength = 13,
				IncludeLength = 0,
				Before = cpuRegisters => SpeedMultUpdates.SpeedMultUpdateListener(cpuRegisters.CX),
			});
		}



		static private NetScriptFramework.MemoryAllocation SpeedMultUpdateListenerAllocation;



		static private void SpeedMultUpdateListener(System.IntPtr actor)
		{
			// actor != System.IntPtr.Zero

			NetScriptFramework.Memory.InvokeCdecl(SpeedMultUpdates.Offsets.RemoveMovementFlags, actor);

			var saveStateManager = NetScriptFramework.Memory.ReadPointer(SpeedMultUpdates.Offsets.SaveStateManager);

			if (saveStateManager != System.IntPtr.Zero)
			{
				if (((NetScriptFramework.Memory.ReadUInt32(saveStateManager + 0x340) >> 1) & 1) == 0)
				{
					NetScriptFramework.Memory.InvokeCdecl(SpeedMultUpdates.Offsets.UpdateMovementSpeed, actor);
				}
			}
		}
	}
}
