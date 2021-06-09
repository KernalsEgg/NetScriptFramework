using Eggstensions;



namespace ScrambledBugs.Patches
{
	internal class AttachHitEffectArt
	{
		public AttachHitEffectArt()
		{
			Memory.SafeWriteArray<System.Byte>(Offsets.Patches.AttachHitEffectArt.AddNoHitEffectArtFlag, new System.Byte[2 + 2] { 0x24, 0xF8, Memory.Nop, Memory.Nop }); // 1 << 2 (NoHitEffectArt), 1 << 4 (NoInitialFlare)

			Memory.SafeWriteArray<System.Byte>(Offsets.Patches.AttachHitEffectArt.AttachToPlayer, new System.Byte[2] { Memory.Nop, Memory.Nop });
			Memory.SafeWriteArray<System.Byte>(Offsets.Patches.AttachHitEffectArt.AttachOnPerspectiveChange, new System.Byte[2] { Memory.Nop, Memory.Nop });

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address			= Offsets.Patches.AttachHitEffectArt.Attach + 0x2B,
				Pattern			= "48 3B 05 ?? ?? ?? ??" + "75 55",
				ReplaceLength	= 7 + 2, // 9
				IncludeLength	= 0,
				After			= registers =>
				{
					// target		!= System.IntPtr.Zero
					// hitEffectArt	!= System.IntPtr.Zero
					// controller	!= System.IntPtr.Zero

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
