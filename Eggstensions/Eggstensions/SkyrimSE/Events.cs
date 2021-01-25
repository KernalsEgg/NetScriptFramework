using static NetScriptFramework._IntPtrExtensions;



namespace Eggstensions.SkyrimSE
{
	static public class Events
	{
		sealed public class ActivateFloraEventArguments : NetScriptFramework.HookedEventArgs
		{
			public ActivateFloraEventArguments(System.IntPtr baseForm, System.IntPtr target, System.IntPtr activator)
			{
				BaseForm = baseForm;
				Target = target;
				Activator = activator;
			}



			/// <summary>TESObjectREFR</summary>
			public System.IntPtr Activator { get; }

			/// <summary>TESForm</summary>
			public System.IntPtr BaseForm { get; }

			/// <summary>TESObjectREFR</summary>
			public System.IntPtr Target { get; }
		}

		sealed public class ActivateTreeEventArguments : NetScriptFramework.HookedEventArgs
		{
			public ActivateTreeEventArguments(System.IntPtr baseForm, System.IntPtr target, System.IntPtr activator)
			{
				BaseForm = baseForm;
				Target = target;
				Activator = activator;
			}



			/// <summary>TESObjectREFR</summary>
			public System.IntPtr Activator { get; }

			/// <summary>TESForm</summary>
			public System.IntPtr BaseForm { get; }

			/// <summary>TESObjectREFR</summary>
			public System.IntPtr Target { get; }
		}

		sealed public class AttachPrecipitationObjectEventArguments : NetScriptFramework.HookedEventArgs
		{
			public AttachPrecipitationObjectEventArguments(System.IntPtr weatherNode, System.IntPtr precipitationObject)
			{
				PrecipitationObject = precipitationObject;
				WeatherNode = weatherNode;
			}



			public System.IntPtr PrecipitationObject { get; }

			public System.IntPtr WeatherNode { get; }
		}

		sealed public class DetachPrecipitationObjectEventArguments : NetScriptFramework.HookedEventArgs
		{
			public DetachPrecipitationObjectEventArguments(System.IntPtr weatherNode, System.IntPtr precipitationObject)
			{
				PrecipitationObject = precipitationObject;
				WeatherNode = weatherNode;
			}



			public System.IntPtr PrecipitationObject { get; }

			public System.IntPtr WeatherNode { get; }
		}

		sealed public class GetIsCreatureTypeEventArguments : NetScriptFramework.HookedEventArgs
		{
			public GetIsCreatureTypeEventArguments(System.IntPtr subject, System.Int32 argument1)
			{
				Subject = subject;
				Argument1 = argument1;
			}



			public System.Double Result { get; set; } = -1.0d;

			public System.Int32 Argument1 { get; }

			/// <summary>TESObjectREFR</summary>
			public System.IntPtr Subject { get; }

			public System.String Text { get; set; } = "Handled Exception >> %0.2f";
		}

		sealed public class PlayHarvestSoundEventArguments : NetScriptFramework.HookedEventArgs
		{
			public PlayHarvestSoundEventArguments(System.IntPtr sound)
			{
				Sound = sound;
			}



			/// <summary>BGSSoundDescriptorForm</summary>
			public System.IntPtr Sound { get; }

			public System.Boolean Skip { get; set; } = false;
		}

		sealed public class ShowHarvestNotificationEventArguments : NetScriptFramework.HookedEventArgs
		{
			public ShowHarvestNotificationEventArguments(System.IntPtr ingredient)
			{
				Ingredient = ingredient;
			}



			/// <summary>TESBoundObject</summary>
			public System.IntPtr Ingredient { get; }

			public System.Boolean Skip { get; set; } = false;
		}



		static public class ActivateFloraEvent
		{
			static ActivateFloraEvent()
			{
				_activateFloraEvent =
					new NetScriptFramework.EventHook<Events.ActivateFloraEventArguments>
					(
						NetScriptFramework.EventHookFlags.None,
						"ActivateFlora",
						new NetScriptFramework.EventHookParameters<Events.ActivateFloraEventArguments>
						(
							address: VIDS.TESFlora.Activate,
							pattern: "48 81 C1 C8 00 00 00",
							replaceLength: 7,
							includeLength: 7,
							argFunc: cpuRegisters => new Events.ActivateFloraEventArguments(cpuRegisters.CX, cpuRegisters.DX, cpuRegisters.R8),
							afterFunc: null
						)
					);
			}



			readonly static private NetScriptFramework.Event<Events.ActivateFloraEventArguments> _activateFloraEvent;



			static public void Register(NetScriptFramework.Event<Events.ActivateFloraEventArguments>.EventHandler eventHandler, System.Int32 priority = 0, System.Int32 count = 0, NetScriptFramework.EventRegistrationFlags eventRegistrationFlags = NetScriptFramework.EventRegistrationFlags.Distinct)
			{
				_activateFloraEvent.Register(eventHandler, priority, count, eventRegistrationFlags);
			}
		}

		static public class ActivateTreeEvent
		{
			static ActivateTreeEvent()
			{
				_activateTreeEvent =
					new NetScriptFramework.EventHook<Events.ActivateTreeEventArguments>
					(
						NetScriptFramework.EventHookFlags.None,
						"ActivateTree",
						new NetScriptFramework.EventHookParameters<Events.ActivateTreeEventArguments>
						(
							address: VIDS.TESObjectTREE.Activate + 0xF,
							pattern: "48 8B 41 58" + "48 8B D9",
							replaceLength: 7,
							includeLength: 7,
							argFunc: cpuRegisters => new Events.ActivateTreeEventArguments(cpuRegisters.CX, cpuRegisters.DX, cpuRegisters.R8),
							afterFunc: null
						)
					);
			}



			readonly static private NetScriptFramework.Event<Events.ActivateTreeEventArguments> _activateTreeEvent;



			static public void Register(NetScriptFramework.Event<Events.ActivateTreeEventArguments>.EventHandler eventHandler, System.Int32 priority = 0, System.Int32 count = 0, NetScriptFramework.EventRegistrationFlags eventRegistrationFlags = NetScriptFramework.EventRegistrationFlags.Distinct)
			{
				_activateTreeEvent.Register(eventHandler, priority, count, eventRegistrationFlags);
			}
		}

		static public class AttachPrecipitationObjectEvent
		{
			static AttachPrecipitationObjectEvent()
			{
				_attachPrecipitationObject =
					new NetScriptFramework.EventHook<Events.AttachPrecipitationObjectEventArguments>
					(
						NetScriptFramework.EventHookFlags.None,
						"AttachPrecipitationObject",
						new NetScriptFramework.EventHookParameters<Events.AttachPrecipitationObjectEventArguments>
						(
							address: VIDS.Events.AttachPrecipitationObject + 0x91,
							pattern: "FF 90 A8010000",
							replaceLength: 6,
							includeLength: 6,
							argFunc: cpuRegisters => new Events.AttachPrecipitationObjectEventArguments(cpuRegisters.CX, cpuRegisters.DX),
							afterFunc: null
						)
					);
			}



			readonly static private NetScriptFramework.Event<Events.AttachPrecipitationObjectEventArguments> _attachPrecipitationObject;



			static public void Register(NetScriptFramework.Event<Events.AttachPrecipitationObjectEventArguments>.EventHandler eventHandler, System.Int32 priority = 0, System.Int32 count = 0, NetScriptFramework.EventRegistrationFlags eventRegistrationFlags = NetScriptFramework.EventRegistrationFlags.Distinct)
			{
				_attachPrecipitationObject.Register(eventHandler, priority, count, eventRegistrationFlags);
			}
		}

		static public class DetachPrecipitationObjectEvent
		{
			static DetachPrecipitationObjectEvent()
			{
				_detachPrecipitationObject =
					new NetScriptFramework.EventHook<Events.DetachPrecipitationObjectEventArguments>
					(
						NetScriptFramework.EventHookFlags.None,
						"DetachPrecipitationObject",
						new NetScriptFramework.EventHookParameters<Events.DetachPrecipitationObjectEventArguments>
						(
							address: VIDS.Events.DetachPrecipitationObject1 + 0x25D,
							pattern: "FF 90 C0010000",
							replaceLength: 6,
							includeLength: 6,
							argFunc: cpuRegisters => new Events.DetachPrecipitationObjectEventArguments(cpuRegisters.CX, cpuRegisters.DX),
							afterFunc: null
						),
						new NetScriptFramework.EventHookParameters<Events.DetachPrecipitationObjectEventArguments>
						(
							address: VIDS.Events.DetachPrecipitationObject1 + 0x32A,
							pattern: "FF 90 C0010000",
							replaceLength: 6,
							includeLength: 6,
							argFunc: cpuRegisters => new Events.DetachPrecipitationObjectEventArguments(cpuRegisters.CX, cpuRegisters.DX),
							afterFunc: null
						),
						new NetScriptFramework.EventHookParameters<Events.DetachPrecipitationObjectEventArguments>
						(
							address: VIDS.Events.DetachPrecipitationObject2 + 0x28,
							pattern: "FF 90 C0010000",
							replaceLength: 6,
							includeLength: 6,
							argFunc: cpuRegisters => new Events.DetachPrecipitationObjectEventArguments(cpuRegisters.CX, cpuRegisters.DX),
							afterFunc: null
						),
						new NetScriptFramework.EventHookParameters<Events.DetachPrecipitationObjectEventArguments>
						(
							address: VIDS.Events.DetachPrecipitationObject2 + 0x73,
							pattern: "FF 90 C0010000",
							replaceLength: 6,
							includeLength: 6,
							argFunc: cpuRegisters => new Events.DetachPrecipitationObjectEventArguments(cpuRegisters.CX, cpuRegisters.DX),
							afterFunc: null
						)
					);
			}



			readonly static private NetScriptFramework.Event<Events.DetachPrecipitationObjectEventArguments> _detachPrecipitationObject;



			static public void Register(NetScriptFramework.Event<Events.DetachPrecipitationObjectEventArguments>.EventHandler eventHandler, System.Int32 priority = 0, System.Int32 count = 0, NetScriptFramework.EventRegistrationFlags eventRegistrationFlags = NetScriptFramework.EventRegistrationFlags.Distinct)
			{
				_detachPrecipitationObject.Register(eventHandler, priority, count, eventRegistrationFlags);
			}
		}

		static public class GetIsCreatureTypeEvent
		{
			static GetIsCreatureTypeEvent()
			{
				var address = VIDS.Events.GetIsCreatureType;
				var hookLength = 0xD;
				var hookOffset1 = 0x4;

				/*
					mov ecx, [rip + ????????]
					mov rax, gs:[00000058]
					mov edx, 00000600
					mov qword ptr [r9], 00000000
					mov rax, [rax + rcx * 8]
					cmp byte ptr [rdx + rax], 00
					je 0x40
					mov rcx, [rip + ????????]
					lea rdx, [rip + ????????]
					xorps xmm2, xmm2
					movq r8, xmm2
					call ????????
					mov al, 01
				*/
				if (!NetScriptFramework.Memory.VerifyBytes
					(
						address + hookOffset1,
						"8B 0D ?? ?? ?? ??" +
						"65 48 8B 04 25 58000000" +
						"BA 00060000" +
						"49 C7 01 00000000" +
						"48 8B 04 C8" +
						"80 3C 02 00" +
						"74 1B" +
						"48 8B 0D ?? ?? ?? ??" +
						"48 8D 15 ?? ?? ?? ??" +
						"0F57 D2" +
						"66 49 0F7E D0" +
						"E8 ?? ?? ?? ??" +
						"B0 01",
						false
					))
				{
					throw new Eggceptions.FormatException(System.String.Join(", ", nameof(address), nameof(hookOffset1)));
				}

				NetScriptFramework.Memory.WriteBytes(address + hookOffset1, new System.Byte[] { 0x8B, 0x05 }, true); // mov eax, [rip + ?? ?? ?? ??]
				hookOffset1 += 0x6;

				NetScriptFramework.Memory.WriteBytes(address + hookOffset1, new System.Byte[] { 0x65, 0x4C, 0x8B, 0x04, 0x25 }, true); // mov r8, gs:[?? ?? ?? ??]
				hookOffset1 += 0x9;

				/*
					mov r8, [r8 + 0x8 * rax]
					cmp byte ptr [r8+0x600], 0
					je 0xF
				*/
				var bytes1 = new System.Byte[]
				{
					0x4D, 0x8B, 0x04, 0xC0,
					0x41, 0x80, 0xB8, 0x00, 0x06, 0x00, 0x00, 0x00,
					0x74, 0x0F
				};

				NetScriptFramework.Memory.WriteBytes(address + hookOffset1, bytes1, true);
				hookOffset1 += bytes1.Length;

				var hookOffset2 = hookOffset1 + hookLength;
				var bytes2 = new System.Byte[] { 0xEB, 0x0D }; // jmp 0xD

				NetScriptFramework.Memory.WriteBytes(address + hookOffset2, bytes2, true);
				hookOffset2 += bytes2.Length;

				// RCX: Subject
				// RDX: Argument1
				// R9: Result
				_getIsCreatureTypeEvent =
					new NetScriptFramework.EventHook<Events.GetIsCreatureTypeEventArguments>
					(
						NetScriptFramework.EventHookFlags.None,
						"GetIsCreatureType",
						new NetScriptFramework.EventHookParameters<Events.GetIsCreatureTypeEventArguments>
						(
							address: address + hookOffset1,
							pattern: "",
							replaceLength: hookLength,
							includeLength: 0,
							argFunc: cpuRegisters =>
							{
								return new Events.GetIsCreatureTypeEventArguments(cpuRegisters.CX, cpuRegisters.DX.ToInt32());
							},
							afterFunc: (cpuRegisters, arguments) =>
							{
								// Set result
								NetScriptFramework.Memory.WriteDouble(cpuRegisters.R9, arguments.Result);

								// Print to console
								ConsoleLog.Print(ConsoleLog.Instance, arguments.Text, System.BitConverter.ToInt64(System.BitConverter.GetBytes(arguments.Result), 0));
							}
						),
						new NetScriptFramework.EventHookParameters<Events.GetIsCreatureTypeEventArguments>
						(
							address: address + hookOffset2,
							pattern: "",
							replaceLength: 0x44 - hookOffset2,
							includeLength: 0,
							argFunc: cpuRegisters =>
							{
								return new Events.GetIsCreatureTypeEventArguments(cpuRegisters.CX, cpuRegisters.DX.ToInt32());
							},
							afterFunc: (cpuRegisters, arguments) =>
							{
								// Set result
								NetScriptFramework.Memory.WriteDouble(cpuRegisters.R9, arguments.Result);
							}
						)
					);
			}



			readonly static private NetScriptFramework.Event<Events.GetIsCreatureTypeEventArguments> _getIsCreatureTypeEvent;



			static public void Register(NetScriptFramework.Event<Events.GetIsCreatureTypeEventArguments>.EventHandler eventHandler, System.Int32 priority = 0, System.Int32 count = 0, NetScriptFramework.EventRegistrationFlags eventRegistrationFlags = NetScriptFramework.EventRegistrationFlags.Distinct)
			{
				_getIsCreatureTypeEvent.Register(eventHandler, priority, count, eventRegistrationFlags);
			}
		}

		static public class PlayHarvestSoundEvent
		{
			static PlayHarvestSoundEvent()
			{
				_playHarvestSound =
					new NetScriptFramework.EventHook<Events.PlayHarvestSoundEventArguments>
					(
						NetScriptFramework.EventHookFlags.None,
						"PlayHarvestSound",
						new NetScriptFramework.EventHookParameters<Events.PlayHarvestSoundEventArguments>
						(
							address: VIDS.Events.Harvest + 0x258,
							pattern: "E8 ?? ?? ?? ??",
							replaceLength: 5,
							includeLength: 5,
							argFunc: cpuRegisters => new Events.PlayHarvestSoundEventArguments(cpuRegisters.CX),
							afterFunc: (cpuRegisters, arguments) => { if (arguments.Skip) { cpuRegisters.Skip(); } }
						),
						new NetScriptFramework.EventHookParameters<Events.PlayHarvestSoundEventArguments>
						(
							address: VIDS.Events.Harvest + 0x3C9,
							pattern: "E8 ?? ?? ?? ??",
							replaceLength: 5,
							includeLength: 5,
							argFunc: cpuRegisters => new Events.PlayHarvestSoundEventArguments(cpuRegisters.CX),
							afterFunc: (cpuRegisters, arguments) => { if (arguments.Skip) { cpuRegisters.Skip(); } }
						)
					);
			}



			readonly static private NetScriptFramework.Event<Events.PlayHarvestSoundEventArguments> _playHarvestSound;



			static public void Register(NetScriptFramework.Event<Events.PlayHarvestSoundEventArguments>.EventHandler eventHandler, System.Int32 priority = 0, System.Int32 count = 0, NetScriptFramework.EventRegistrationFlags eventRegistrationFlags = NetScriptFramework.EventRegistrationFlags.Distinct)
			{
				_playHarvestSound.Register(eventHandler, priority, count, eventRegistrationFlags);
			}
		}

		static public class ShowHarvestNotificationEvent
		{
			static ShowHarvestNotificationEvent()
			{
				_showHarvestNotification =
					new NetScriptFramework.EventHook<Events.ShowHarvestNotificationEventArguments>
					(
						NetScriptFramework.EventHookFlags.None,
						"ShowHarvestNotification",
						new NetScriptFramework.EventHookParameters<Events.ShowHarvestNotificationEventArguments>
						(
							address: VIDS.Events.Harvest + 0x250,
							pattern: "E8 ?? ?? ?? ??",
							replaceLength: 5,
							includeLength: 5,
							argFunc: cpuRegisters => new Events.ShowHarvestNotificationEventArguments(cpuRegisters.CX),
							afterFunc: (cpuRegisters, arguments) => { if (arguments.Skip) { cpuRegisters.Skip(); } }
						),
						new NetScriptFramework.EventHookParameters<Events.ShowHarvestNotificationEventArguments>
						(
							address: VIDS.Events.Harvest + 0x3C1,
							pattern: "E8 ?? ?? ?? ??",
							replaceLength: 5,
							includeLength: 5,
							argFunc: cpuRegisters => new Events.ShowHarvestNotificationEventArguments(cpuRegisters.CX),
							afterFunc: (cpuRegisters, arguments) => { if (arguments.Skip) { cpuRegisters.Skip(); } }
						)
					);
			}



			readonly static private NetScriptFramework.Event<Events.ShowHarvestNotificationEventArguments> _showHarvestNotification;



			static public void Register(NetScriptFramework.Event<Events.ShowHarvestNotificationEventArguments>.EventHandler eventHandler, System.Int32 priority = 0, System.Int32 count = 0, NetScriptFramework.EventRegistrationFlags eventRegistrationFlags = NetScriptFramework.EventRegistrationFlags.Distinct)
			{
				_showHarvestNotification.Register(eventHandler, priority, count, eventRegistrationFlags);
			}
		}
	}
}
