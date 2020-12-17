using static NetScriptFramework._IntPtrExtensions;



namespace Eggstensions.Bethesda
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

		sealed public class CastSpellPerkEntryPointEventArguments : NetScriptFramework.HookedEventArgs
		{
			public CastSpellPerkEntryPointEventArguments(System.IntPtr target, System.IntPtr spellItem)
			{
				Target = target;
				SpellItem = spellItem;
			}



			public System.Boolean Skip { get; set; } = false;

			/// <summary>SpellItem</summary>
			public System.IntPtr SpellItem { get; }

			/// <summary>Actor</summary>
			public System.IntPtr Target { get; }
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

		sealed public class SetSpellPerkEntryPointEventArguments : NetScriptFramework.HookedEventArgs
		{
			public SetSpellPerkEntryPointEventArguments(System.IntPtr result, System.IntPtr perkEntryPoint)
			{
				Result = result;
				PerkEntryPoint = perkEntryPoint;
			}



			public System.Boolean Skip { get; set; } = false;

			public System.IntPtr Result { get; }

			/// <summary>BGSEntryPointFunctionDataSpellItem</summary>
			public System.IntPtr PerkEntryPoint { get; }
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
							address: NetScriptFramework.Memory.ReadPointer(VIDS.TESFlora.VTable + 0x1B8),
							replaceLength: 7,
							includeLength: 7,
							pattern: "48 81 C1 C8 00 00 00",
							argFunc: cpuRegisters => new Events.ActivateFloraEventArguments(cpuRegisters.CX, cpuRegisters.DX, cpuRegisters.R8),
							afterFunc: null
						)
					);
			}



			static private NetScriptFramework.Event<Events.ActivateFloraEventArguments> _activateFloraEvent;



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
							address: NetScriptFramework.Memory.ReadPointer(VIDS.TESObjectTREE.VTable + 0x1B8),
							replaceLength: 5,
							includeLength: 5,
							pattern: "48 89 5C 24 08",
							argFunc: cpuRegisters => new Events.ActivateTreeEventArguments(cpuRegisters.CX, cpuRegisters.DX, cpuRegisters.R8),
							afterFunc: null
						)
					);
			}



			static private NetScriptFramework.Event<Events.ActivateTreeEventArguments> _activateTreeEvent;



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
							replaceLength: 6,
							includeLength: 6,
							pattern: "FF 90 A8010000",
							argFunc: cpuRegisters => new Events.AttachPrecipitationObjectEventArguments(cpuRegisters.CX, cpuRegisters.DX),
							afterFunc: null
						)
					);
			}



			static private NetScriptFramework.Event<Events.AttachPrecipitationObjectEventArguments> _attachPrecipitationObject;



			static public void Register(NetScriptFramework.Event<Events.AttachPrecipitationObjectEventArguments>.EventHandler eventHandler, System.Int32 priority = 0, System.Int32 count = 0, NetScriptFramework.EventRegistrationFlags eventRegistrationFlags = NetScriptFramework.EventRegistrationFlags.Distinct)
			{
				_attachPrecipitationObject.Register(eventHandler, priority, count, eventRegistrationFlags);
			}
		}

		static public class CastSpellPerkEntryPointEvent
		{
			static CastSpellPerkEntryPointEvent()
			{
				_castSpellPerkEntryPoint =
					new NetScriptFramework.EventHook<Events.CastSpellPerkEntryPointEventArguments>
					(
						NetScriptFramework.EventHookFlags.None,
						"CastSpellPerkEntryPoint",
						new NetScriptFramework.EventHookParameters<Events.CastSpellPerkEntryPointEventArguments>
						(
							address: VIDS.Events.ApplyBashingSpell + 0x429,
							replaceLength: 5,
							includeLength: 5,
							pattern: "E8",
							argFunc: cpuRegisters => new Events.CastSpellPerkEntryPointEventArguments(cpuRegisters.CX, cpuRegisters.DX),
							afterFunc: (cpuRegisters, arguments) => { if (arguments.Skip) { cpuRegisters.Skip(); } }
						),
						new NetScriptFramework.EventHookParameters<Events.CastSpellPerkEntryPointEventArguments>
						(
							address: VIDS.Events.ApplyCombatHitSpellMelee + 0x79,
							replaceLength: 5,
							includeLength: 5,
							pattern: "E8",
							argFunc: cpuRegisters => new Events.CastSpellPerkEntryPointEventArguments(cpuRegisters.CX, cpuRegisters.DX),
							afterFunc: (cpuRegisters, arguments) => { if (arguments.Skip) { cpuRegisters.Skip(); } }
						),
						new NetScriptFramework.EventHookParameters<Events.CastSpellPerkEntryPointEventArguments>
						(
							address: VIDS.Events.ApplyCombatHitSpellProjectile + 0x2A7,
							replaceLength: 5,
							includeLength: 5,
							pattern: "E8",
							argFunc: cpuRegisters => new Events.CastSpellPerkEntryPointEventArguments(cpuRegisters.CX, cpuRegisters.DX),
							afterFunc: (cpuRegisters, arguments) => { if (arguments.Skip) { cpuRegisters.Skip(); } }
						),
						new NetScriptFramework.EventHookParameters<Events.CastSpellPerkEntryPointEventArguments>
						(
							address: VIDS.Events.ApplyReanimateSpell + 0xD2,
							replaceLength: 5,
							includeLength: 5,
							pattern: "E8",
							argFunc: cpuRegisters => new Events.CastSpellPerkEntryPointEventArguments(cpuRegisters.CX, cpuRegisters.DX),
							afterFunc: (cpuRegisters, arguments) => { if (arguments.Skip) { cpuRegisters.Skip(); } }
						),
						new NetScriptFramework.EventHookParameters<Events.CastSpellPerkEntryPointEventArguments>
						(
							address: VIDS.Events.ApplySneakingSpell + 0xCE,
							replaceLength: 5,
							includeLength: 5,
							pattern: "E8",
							argFunc: cpuRegisters => new Events.CastSpellPerkEntryPointEventArguments(cpuRegisters.CX, cpuRegisters.DX),
							afterFunc: (cpuRegisters, arguments) => { if (arguments.Skip) { cpuRegisters.Skip(); } }
						),
						new NetScriptFramework.EventHookParameters<Events.CastSpellPerkEntryPointEventArguments>
						(
							address: VIDS.Events.ApplyWeaponSwingSpell + 0xC3,
							replaceLength: 5,
							includeLength: 5,
							pattern: "E8",
							argFunc: cpuRegisters => new Events.CastSpellPerkEntryPointEventArguments(cpuRegisters.CX, cpuRegisters.DX),
							afterFunc: (cpuRegisters, arguments) => { if (arguments.Skip) { cpuRegisters.Skip(); } }
						)
					);
			}



			static private NetScriptFramework.Event<Events.CastSpellPerkEntryPointEventArguments> _castSpellPerkEntryPoint;



			static public void Register(NetScriptFramework.Event<Events.CastSpellPerkEntryPointEventArguments>.EventHandler eventHandler, System.Int32 priority = 0, System.Int32 count = 0, NetScriptFramework.EventRegistrationFlags eventRegistrationFlags = NetScriptFramework.EventRegistrationFlags.Distinct)
			{
				_castSpellPerkEntryPoint.Register(eventHandler, priority, count, eventRegistrationFlags);
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
							replaceLength: 6,
							includeLength: 6,
							pattern: "FF 90 C0010000",
							argFunc: cpuRegisters => new Events.DetachPrecipitationObjectEventArguments(cpuRegisters.CX, cpuRegisters.DX),
							afterFunc: null
						),
						new NetScriptFramework.EventHookParameters<Events.DetachPrecipitationObjectEventArguments>
						(
							address: VIDS.Events.DetachPrecipitationObject1 + 0x32A,
							replaceLength: 6,
							includeLength: 6,
							pattern: "FF 90 C0010000",
							argFunc: cpuRegisters => new Events.DetachPrecipitationObjectEventArguments(cpuRegisters.CX, cpuRegisters.DX),
							afterFunc: null
						),
						new NetScriptFramework.EventHookParameters<Events.DetachPrecipitationObjectEventArguments>
						(
							address: VIDS.Events.DetachPrecipitationObject2 + 0x28,
							replaceLength: 6,
							includeLength: 6,
							pattern: "FF 90 C0010000",
							argFunc: cpuRegisters => new Events.DetachPrecipitationObjectEventArguments(cpuRegisters.CX, cpuRegisters.DX),
							afterFunc: null
						),
						new NetScriptFramework.EventHookParameters<Events.DetachPrecipitationObjectEventArguments>
						(
							address: VIDS.Events.DetachPrecipitationObject2 + 0x73,
							replaceLength: 6,
							includeLength: 6,
							pattern: "FF 90 C0010000",
							argFunc: cpuRegisters => new Events.DetachPrecipitationObjectEventArguments(cpuRegisters.CX, cpuRegisters.DX),
							afterFunc: null
						)
					);
			}



			static private NetScriptFramework.Event<Events.DetachPrecipitationObjectEventArguments> _detachPrecipitationObject;



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
				var offset = 0x4;

				if (!NetScriptFramework.Memory.VerifyBytes(address + offset, "8B 0D", false)) { throw new Eggceptions.FormatException("8B 0D"); }   // mov ecx, DWORD PTR [rip+0x0]
				NetScriptFramework.Memory.WriteBytes(address + offset, new System.Byte[] { 0x8B, 0x05 }, true);                                     // mov eax, DWORD PTR [rip+0x0]
				offset += 0x6;

				if (!NetScriptFramework.Memory.VerifyBytes(address + offset, "65 48 8B 04 25", false)) { throw new Eggceptions.FormatException("65 48 8B 04 25"); } // mov rax, QWORD PTR gs:0x0
				NetScriptFramework.Memory.WriteBytes(address + offset, new System.Byte[] { 0x65, 0x4C, 0x8B, 0x04, 0x25 }, true);                                   // mov r8, QWORD PTR gs:0x0
				offset += 0x9;

				/*
					mov r8, [r8 + 0x8 * rax]
					mov r8b, [r8 + 0x600]
				*/
				var bytes = new System.Byte[]
				{
					0x4D, 0x8B, 0x04, 0xC0,
					0x45, 0x8A, 0x80, 0x00, 0x06, 0x00, 0x00
				};

				if (!NetScriptFramework.Memory.VerifyBytes(address + offset, "BA 00060000", false)) { throw new Eggceptions.FormatException("BA 00060000"); } // mov edx, 0x600
				NetScriptFramework.Memory.WriteBytes(address + offset, bytes, true);
				offset += bytes.Length;

				_getIsCreatureTypeEvent =
					new NetScriptFramework.EventHook<Events.GetIsCreatureTypeEventArguments>
					(
						NetScriptFramework.EventHookFlags.None,
						"GetIsCreatureType",
						new NetScriptFramework.EventHookParameters<Events.GetIsCreatureTypeEventArguments>
						(
							address: address + offset,
							replaceLength: 0x44 - offset,
							includeLength: 0x0,
							pattern:
								"00" +
								"48 8B 04 C8",
							argFunc: cpuRegisters =>
							{
								// RCX: Subject			(argument 1)
								// RDX: Argument1		(argument 2)
								// R8B: PrintToConsole
								// R9: Result			(argument 4)
								return new Events.GetIsCreatureTypeEventArguments(cpuRegisters.CX, cpuRegisters.DX.ToInt32());
							},
							afterFunc: (cpuRegisters, arguments) =>
							{
								// Set result
								NetScriptFramework.Memory.WriteDouble(cpuRegisters.R9, arguments.Result);

								// Print to console
								if (cpuRegisters.R8.ToBool())
								{
									ConsoleLog.Print(ConsoleLog.Instance, arguments.Text, System.BitConverter.ToInt64(System.BitConverter.GetBytes(arguments.Result), 0));
								}
							}
						)
					);
			}



			static private NetScriptFramework.Event<Events.GetIsCreatureTypeEventArguments> _getIsCreatureTypeEvent;



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
							replaceLength: 5,
							includeLength: 5,
							pattern: "E8",
							argFunc: cpuRegisters => new Events.PlayHarvestSoundEventArguments(cpuRegisters.CX),
							afterFunc: (cpuRegisters, arguments) => { if (arguments.Skip) { cpuRegisters.Skip(); } }
						),
						new NetScriptFramework.EventHookParameters<Events.PlayHarvestSoundEventArguments>
						(
							address: VIDS.Events.Harvest + 0x3C9,
							replaceLength: 5,
							includeLength: 5,
							pattern: "E8",
							argFunc: cpuRegisters => new Events.PlayHarvestSoundEventArguments(cpuRegisters.CX),
							afterFunc: (cpuRegisters, arguments) => { if (arguments.Skip) { cpuRegisters.Skip(); } }
						)
					);
			}



			static private NetScriptFramework.Event<Events.PlayHarvestSoundEventArguments> _playHarvestSound;



			static public void Register(NetScriptFramework.Event<Events.PlayHarvestSoundEventArguments>.EventHandler eventHandler, System.Int32 priority = 0, System.Int32 count = 0, NetScriptFramework.EventRegistrationFlags eventRegistrationFlags = NetScriptFramework.EventRegistrationFlags.Distinct)
			{
				_playHarvestSound.Register(eventHandler, priority, count, eventRegistrationFlags);
			}
		}

		static public class SetSpellPerkEntryPointEvent
		{
			static SetSpellPerkEntryPointEvent()
			{
				_setSpellPerkEntryPoint =
					new NetScriptFramework.EventHook<Events.SetSpellPerkEntryPointEventArguments>
					(
						NetScriptFramework.EventHookFlags.None,
						"SetSpellPerkEntryPoint",
						new NetScriptFramework.EventHookParameters<Events.SetSpellPerkEntryPointEventArguments>
						(
							address: VIDS.Events.SetSpellPerkEntryPoint + 0x53,
							replaceLength: 7,
							includeLength: 7,
							pattern:
								"48 8B 43 08" +
								"48 89 01",
							argFunc: cpuRegisters => new Events.SetSpellPerkEntryPointEventArguments(cpuRegisters.CX, cpuRegisters.BX),
							afterFunc: (cpuRegisters, arguments) => { if (arguments.Skip) { cpuRegisters.Skip(); } }
						)
					);
			}



			static private NetScriptFramework.Event<Events.SetSpellPerkEntryPointEventArguments> _setSpellPerkEntryPoint;



			static public void Register(NetScriptFramework.Event<Events.SetSpellPerkEntryPointEventArguments>.EventHandler eventHandler, System.Int32 priority = 0, System.Int32 count = 0, NetScriptFramework.EventRegistrationFlags eventRegistrationFlags = NetScriptFramework.EventRegistrationFlags.Distinct)
			{
				_setSpellPerkEntryPoint.Register(eventHandler, priority, count, eventRegistrationFlags);
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
							replaceLength: 5,
							includeLength: 5,
							pattern: "E8",
							argFunc: cpuRegisters => new Events.ShowHarvestNotificationEventArguments(cpuRegisters.CX),
							afterFunc: (cpuRegisters, arguments) => { if (arguments.Skip) { cpuRegisters.Skip(); } }
						),
						new NetScriptFramework.EventHookParameters<Events.ShowHarvestNotificationEventArguments>
						(
							address: VIDS.Events.Harvest + 0x3C1,
							replaceLength: 5,
							includeLength: 5,
							pattern: "E8",
							argFunc: cpuRegisters => new Events.ShowHarvestNotificationEventArguments(cpuRegisters.CX),
							afterFunc: (cpuRegisters, arguments) => { if (arguments.Skip) { cpuRegisters.Skip(); } }
						)
					);
			}



			static private NetScriptFramework.Event<Events.ShowHarvestNotificationEventArguments> _showHarvestNotification;



			static public void Register(NetScriptFramework.Event<Events.ShowHarvestNotificationEventArguments>.EventHandler eventHandler, System.Int32 priority = 0, System.Int32 count = 0, NetScriptFramework.EventRegistrationFlags eventRegistrationFlags = NetScriptFramework.EventRegistrationFlags.Distinct)
			{
				_showHarvestNotification.Register(eventHandler, priority, count, eventRegistrationFlags);
			}
		}
	}
}
