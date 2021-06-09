namespace Eggstensions
{
	namespace Events
	{
		static public class AddActorValueEventSinks
		{
			static AddActorValueEventSinks()
			{
				NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
				{
					Address			= Offsets.Events.AddActorValueEventSinks + 0xF,
					Pattern			= "48 83 C4 28" + "C3",
					ReplaceLength	= 4 + 1, // 5
					IncludeLength	= 4 + 1, // 5
					Before			= registers => AddActorValueEventSinks.OnAddActorValueEventSinks(System.EventArgs.Empty)
				});
			}



			static public event System.EventHandler<System.EventArgs> EventHandler;

			readonly static private System.Object eventLock = new System.Object();



			static private void OnAddActorValueEventSinks(System.EventArgs eventArguments)
			{
				lock (AddActorValueEventSinks.eventLock)
				{
					AddActorValueEventSinks.EventHandler?.Invoke(null, eventArguments);
				}
			}
		}

		static public class AddMiscStatEventSinks
		{
			static AddMiscStatEventSinks()
			{
				NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
				{
					Address			= Offsets.Events.AddMiscStatEventSinks + 0x12,
					Pattern			= "E8 ?? ?? ?? ??",
					ReplaceLength	= 5,
					IncludeLength	= 5,
					Before			= registers => AddMiscStatEventSinks.OnAddMiscStatEventSinks(System.EventArgs.Empty)
				});
			}



			static public event System.EventHandler<System.EventArgs> EventHandler;

			readonly static private System.Object eventLock = new System.Object();



			static private void OnAddMiscStatEventSinks(System.EventArgs eventArguments)
			{
				lock (AddMiscStatEventSinks.eventLock)
				{
					AddMiscStatEventSinks.EventHandler?.Invoke(null, eventArguments);
				}
			}
		}

		static public class AddScriptEventSinks
		{
			static AddScriptEventSinks()
			{
				NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
				{
					Address			= Offsets.Events.AddScriptEventSinks + 0x38,
					Pattern			= "E8 ?? ?? ?? ??",
					ReplaceLength	= 5,
					IncludeLength	= 5,
					Before			= registers => AddScriptEventSinks.OnAddScriptEventSinks(System.EventArgs.Empty)
				});
			}



			static public event System.EventHandler<System.EventArgs> EventHandler;

			readonly static private System.Object eventLock = new System.Object();



			static private void OnAddScriptEventSinks(System.EventArgs eventArguments)
			{
				lock (AddScriptEventSinks.eventLock)
				{
					AddScriptEventSinks.EventHandler?.Invoke(null, eventArguments);
				}
			}
		}

		static public class RemoveMiscStatEventSinks
		{
			static RemoveMiscStatEventSinks()
			{
				NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
				{
					Address			= Offsets.Events.RemoveMiscStatEventSinks + 0xB,
					Pattern			= "E8 ?? ?? ?? ??",
					ReplaceLength	= 5,
					IncludeLength	= 5,
					Before			= registers => RemoveMiscStatEventSinks.OnRemoveMiscStatEventSinks(System.EventArgs.Empty)
				});
			}



			static public event System.EventHandler<System.EventArgs> EventHandler;

			readonly static private System.Object eventLock = new System.Object();



			static private void OnRemoveMiscStatEventSinks(System.EventArgs eventArguments)
			{
				lock (RemoveMiscStatEventSinks.eventLock)
				{
					RemoveMiscStatEventSinks.EventHandler?.Invoke(null, eventArguments);
				}
			}
		}
	}
}
