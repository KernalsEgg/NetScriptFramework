using Eggstensions;
using Eggstensions.Interoperability.Managed; // Memory



namespace ScrambledBugs.Patches
{
	namespace Offsets
	{
		static internal class AttachHitEffectArt
		{
			/// <summary> SkyrimSE.exe + 0x6314F0 </summary>
			static public System.IntPtr AddNoHitEffectArtFlag { get; }				= NetScriptFramework.Main.GameInfo.GetAddressOf(37804, 0x6F, 0, "24 F9" + "0C 01"); // 2 + 2

			/// <summary> SkyrimSE.exe + 0x558F20 </summary>
			static public System.IntPtr Attach { get; }								= NetScriptFramework.Main.GameInfo.GetAddressOf(33872);

			/// <summary> SkyrimSE.exe + 0x558220 </summary>
			static public System.IntPtr UpdatePositionOfPlayer { get; }				= NetScriptFramework.Main.GameInfo.GetAddressOf(33862, 0x7C, 0, "75 3B"); // 2

			/// <summary> SkyrimSE.exe + 0x558220 </summary>
			static public System.IntPtr UpdatePositionOnPerspectiveChange { get; }	= NetScriptFramework.Main.GameInfo.GetAddressOf(33862, 0x9A, 0, "74 08"); // 2
		}
	}
	
	
	
	internal class AttachHitEffectArt
	{
		public AttachHitEffectArt()
		{
			Memory.SafeWriteByteArray(Offsets.AttachHitEffectArt.AddNoHitEffectArtFlag, new System.Byte[] { 0x24, 0xF8, Memory.Nop, Memory.Nop }); // 1 << 2 (NoHitEffectArt), 1 << 4 (NoInitialFlare)

			Memory.SafeWriteNopArray(Offsets.AttachHitEffectArt.UpdatePositionOfPlayer, 2);
			Memory.SafeWriteNopArray(Offsets.AttachHitEffectArt.UpdatePositionOnPerspectiveChange, 2);

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = Offsets.AttachHitEffectArt.Attach + 0x2B,
				Pattern = "48 3B 05 ?? ?? ?? ??" + "75 55",
				ReplaceLength = 7 + 2, // 9
				IncludeLength = 0,
				After = registers =>
				{
					// target != System.IntPtr.Zero
					// hitEffectArt != System.IntPtr.Zero
					// controller != System.IntPtr.Zero

					Actor target = registers.BX;

					if (target)
					{
						ModelReferenceEffect hitEffectArt = registers.SI;

						if (hitEffectArt)
						{
							var controller = hitEffectArt.Controller;

							if (controller)
							{
								var attachRoot = controller.GetAttachRoot();

								if (!attachRoot)
								{
									attachRoot = target.GetCurrent3D();
								}

								NiNode attachRootNode = System.IntPtr.Zero;

								if (attachRoot)
								{
									attachRootNode = attachRoot.AsNode();

									if (!attachRootNode)
									{
										attachRootNode = attachRoot.GetParent();
									}
								}

								if (attachRootNode != hitEffectArt.HitEffectArtData.AttachRoot)
								{
									return; // Attach
								}
							}
						}
					}

					registers.IP += 0x55; // Skip
				}
			});
		}
	}
}
