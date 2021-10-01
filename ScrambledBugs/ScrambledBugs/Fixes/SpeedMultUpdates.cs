using Eggstensions;
using Eggstensions.ExtensionMethods;

using Events = Eggstensions.Events;



namespace ScrambledBugs.Fixes
{
	unsafe static internal class SpeedMultUpdates
	{
		[System.Flags]
		public enum SaveManagerFlags : System.UInt32
		{
			Loaded = 1 << 1
		}



		[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x348)]
		public struct SaveManager
		{
			[System.Runtime.InteropServices.FieldOffset(0x340)] public SaveManagerFlags Flags;



			static public SaveManager* Instance
			{
				get
				{
					return *(SpeedMultUpdates.SaveManager**)ScrambledBugs.Offsets.Fixes.SpeedMultUpdates.SaveManager;
				}
			}
		}



		static public System.Boolean Fix()
		{
			Events.InitializeThread.After -= SpeedMultUpdates.OnInitializeThread;
			Events.InitializeThread.After += SpeedMultUpdates.OnInitializeThread;

			return true;
		}



		static public void OnInitializeThread(System.Object sender, System.EventArgs arguments)
		{
			Events.InitializeThread.After -= SpeedMultUpdates.OnInitializeThread;

			if (!ScrambledBugs.Patterns.Fixes.SpeedMultUpdates.SpeedMultSink)
			{
				return;
			}

			SpeedMultUpdates.OnSpeedMultUpdate();
		}

		static public void OnSpeedMultUpdate()
		{
			var onSpeedMultUpdate = (delegate* unmanaged[Cdecl]<Actor*, System.Int32, System.Single, System.Single, void>)&OnSpeedMultUpdate;

			((delegate* unmanaged[Cdecl]<Actor*, System.Int32, System.Single, System.Single, void>*)ScrambledBugs.Offsets.Fixes.SpeedMultUpdates.ActorValueSinkFunctionTable)[(System.Int32)ActorValue.SpeedMult] = onSpeedMultUpdate;

			[System.Runtime.InteropServices.UnmanagedCallersOnly(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
			static void OnSpeedMultUpdate(Actor* actor, System.Int32 actorValue, System.Single old, System.Single delta)
			{
				// actor != null

				actor->RemoveMovementFlags();

				var saveManager = SpeedMultUpdates.SaveManager.Instance;

				if (saveManager != null)
				{
					if ((saveManager->Flags & SpeedMultUpdates.SaveManagerFlags.Loaded) != SpeedMultUpdates.SaveManagerFlags.Loaded)
					{
						actor->UpdateMovementSpeed();
					}
				}
			}
		}



		static public void RemoveMovementFlags<TActor>(this ref TActor actor)
			where TActor : unmanaged, Eggstensions.IActor
		{
			var removeMovementFlags = (delegate* unmanaged[Cdecl]<TActor*, void>)ScrambledBugs.Offsets.Fixes.SpeedMultUpdates.RemoveMovementFlags;

			RemoveMovementFlags(actor.AsPointer());



			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			void RemoveMovementFlags(TActor* actor)
			{
				removeMovementFlags(actor);
			}
		}
	}
}
