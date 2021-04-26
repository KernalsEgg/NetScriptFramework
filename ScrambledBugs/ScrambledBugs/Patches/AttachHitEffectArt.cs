namespace ScrambledBugs.Patches
{
	internal class AttachHitEffectArt
	{
		static protected class Offsets
		{
			static Offsets()
			{
				Offsets.Attach								= NetScriptFramework.Main.GameInfo.GetAddressOf(33872);
				Offsets.RemoveAttachHitEffectArtFlag		= NetScriptFramework.Main.GameInfo.GetAddressOf(37804, 0x6F, 0, "24 F9" + "0C 01"); // 4
				Offsets.UpdatePositionOfPlayer				= NetScriptFramework.Main.GameInfo.GetAddressOf(33862, 0x7C, 0, "75 3B"); // 2
				Offsets.UpdatePositionOnPerspectiveChange	= NetScriptFramework.Main.GameInfo.GetAddressOf(33862, 0x9A, 0, "74 08"); // 2
			}



			/// <summary> SkyrimSE.exe + 0x558F20 </summary>
			static internal System.IntPtr Attach { get; }

			/// <summary> SkyrimSE.exe + 0x6314F0 </summary>
			static internal System.IntPtr RemoveAttachHitEffectArtFlag { get; }

			/// <summary> SkyrimSE.exe + 0x558220 </summary>
			static internal System.IntPtr UpdatePositionOfPlayer { get; }

			/// <summary> SkyrimSE.exe + 0x558220 </summary>
			static internal System.IntPtr UpdatePositionOnPerspectiveChange { get; }
		}



		static protected class ModelReferenceEffect
		{
			static internal System.IntPtr GetCurrentAttachRoot(System.IntPtr modelReferenceEffect)
			{
				return NetScriptFramework.Memory.ReadPointer(modelReferenceEffect + 0x70);
			}
		}

		static protected class NiAVObject
		{
			static internal System.IntPtr GetParent(System.IntPtr niAVObject)
			{
				return NetScriptFramework.Memory.ReadPointer(niAVObject + 0x30);
			}
		}

		static protected class NiObject
		{
			static internal System.IntPtr AsNode(System.IntPtr niObject)
			{
				var virtualFunctionTable = NetScriptFramework.Memory.ReadPointer(niObject);
				var asNode = NetScriptFramework.Memory.ReadPointer(virtualFunctionTable + 0x18);

				return NetScriptFramework.Memory.InvokeThisCall(niObject, asNode);
			}
		}

		static protected class ReferenceEffect
		{
			static internal System.IntPtr GetController(System.IntPtr referenceEffect)
			{
				return NetScriptFramework.Memory.ReadPointer(referenceEffect + 0x30);
			}
		}

		static protected class ReferenceEffectController
		{
			static internal System.IntPtr GetAttachRoot(System.IntPtr referenceEffectController)
			{
				var virtualFunctionTable = NetScriptFramework.Memory.ReadPointer(referenceEffectController);
				var getAttachRoot = NetScriptFramework.Memory.ReadPointer(virtualFunctionTable + 0x78);

				return NetScriptFramework.Memory.InvokeThisCall(referenceEffectController, getAttachRoot);
			}
		}

		static protected class TESObjectREFR
		{
			static internal System.IntPtr GetCurrent3D(System.IntPtr reference)
			{
				var virtualFunctionTable = NetScriptFramework.Memory.ReadPointer(reference);
				var getCurrent3D = NetScriptFramework.Memory.ReadPointer(virtualFunctionTable + 0x468);

				return NetScriptFramework.Memory.InvokeThisCall(reference, getCurrent3D);
			}
		}



		internal AttachHitEffectArt()
		{
			NetScriptFramework.Memory.WriteBytes(AttachHitEffectArt.Offsets.RemoveAttachHitEffectArtFlag, new System.Byte[] { 0x24, 0xF8, 0x90, 0x90 }, true);

			NetScriptFramework.Memory.WriteNop(AttachHitEffectArt.Offsets.UpdatePositionOfPlayer, 2);
			NetScriptFramework.Memory.WriteNop(AttachHitEffectArt.Offsets.UpdatePositionOnPerspectiveChange, 2);

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = AttachHitEffectArt.Offsets.Attach + 0x2B,
				Pattern = "48 3B 05 ?? ?? ?? ??" + "75 55",
				ReplaceLength = 7 + 2,
				IncludeLength = 0,
				After = cpuRegisters =>
				{
					// target != System.IntPtr.Zero, formType == 0x3E
					// modelReferenceEffect != System.IntPtr.Zero
					// controller != System.IntPtr.Zero
					
					var target = cpuRegisters.BX;

					if (target != System.IntPtr.Zero)
					{
						var modelReferenceEffect = cpuRegisters.SI;

						if (modelReferenceEffect != System.IntPtr.Zero)
						{
							var controller = AttachHitEffectArt.ReferenceEffect.GetController(modelReferenceEffect);

							if (controller != System.IntPtr.Zero)
							{
								var attachRoot = AttachHitEffectArt.ReferenceEffectController.GetAttachRoot(controller);

								if (attachRoot == System.IntPtr.Zero)
								{
									attachRoot = AttachHitEffectArt.TESObjectREFR.GetCurrent3D(target);
								}

								if (attachRoot != System.IntPtr.Zero)
								{
									var attachRootNode = AttachHitEffectArt.NiObject.AsNode(attachRoot);

									attachRoot = (attachRootNode != System.IntPtr.Zero) ? attachRootNode : AttachHitEffectArt.NiAVObject.GetParent(attachRoot);
								}

								if (attachRoot != AttachHitEffectArt.ModelReferenceEffect.GetCurrentAttachRoot(modelReferenceEffect))
								{
									return; // Attach
								}
							}
						}
					}

					cpuRegisters.IP += 0x55; // Skip
				},
			});
		}
	}
}
