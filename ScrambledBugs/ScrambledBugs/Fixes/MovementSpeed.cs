using Eggstensions;
using Eggstensions.ExtensionMethods;

using Events = Eggstensions.Events;



namespace ScrambledBugs.Fixes
{
	unsafe static internal class MovementSpeed
	{
		[System.Flags]
		public enum SaveManagerFlags : System.UInt32
		{
			Loaded = 1 << 1
		}



		[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit)]
		unsafe public struct SaveManager
		{
			[System.Runtime.InteropServices.FieldOffset(0x340)] public SaveManagerFlags Flags;



			static public SaveManager* Instance
			{
				get
				{
					return *(MovementSpeed.SaveManager**)ScrambledBugs.Offsets.Fixes.MovementSpeed.SaveManager;
				}
			}
		}



		static public void Fix()
		{
			Events.InitializeThread.After -= MovementSpeed.OnInitializeThread;
			Events.InitializeThread.After += MovementSpeed.OnInitializeThread;
		}



		static public void OnInitializeThread(System.Object sender, System.EventArgs arguments)
		{
			Events.InitializeThread.After -= MovementSpeed.OnInitializeThread;



			var speedMultSink = (delegate* unmanaged[Cdecl]<Actor*, System.Int32, System.Single, System.Single, void>)&SpeedMultSink;

			((delegate* unmanaged[Cdecl]<Actor*, System.Int32, System.Single, System.Single, void>*)ScrambledBugs.Offsets.Fixes.MovementSpeed.ActorValueSinkFunctionTable)[(System.Int32)ActorValue.SpeedMult] = speedMultSink;

			[System.Runtime.InteropServices.UnmanagedCallersOnly(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
			static void SpeedMultSink(Actor* actor, System.Int32 actorValue, System.Single old, System.Single delta)
			{
				// actor != null

				actor->RemoveMovementFlags();

				var saveManager = MovementSpeed.SaveManager.Instance;

				if (saveManager != null)
				{
					if ((saveManager->Flags & MovementSpeed.SaveManagerFlags.Loaded) != MovementSpeed.SaveManagerFlags.Loaded)
					{
						actor->UpdateMovementSpeed();
					}
				}
			}
		}

		static void RemoveMovementFlags<TActor>(this ref TActor actor)
			where TActor : unmanaged, Eggstensions.IActor
		{
			var removeMovementFlags = (delegate* unmanaged[Cdecl]<TActor*, void>)ScrambledBugs.Offsets.Fixes.MovementSpeed.RemoveMovementFlags;

			RemoveMovementFlags(actor.AsPointer());



			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			void RemoveMovementFlags(TActor* actor)
			{
				removeMovementFlags(actor);
			}
		}
	}
}
