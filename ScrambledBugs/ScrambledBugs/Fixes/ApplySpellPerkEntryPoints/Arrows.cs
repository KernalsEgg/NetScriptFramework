using Eggstensions;



namespace ScrambledBugs.Fixes.ApplySpellPerkEntryPoints
{
	static internal class Arrows
	{
		static public void Fix()
		{
			var position = ScrambledBugs.Plugin.Trampoline.Reserve((7 + 4 + 4 + 2) + Memory.Size<AbsoluteJump>.Unmanaged + 1);

			ScrambledBugs.Plugin.Trampoline.Write += (System.Object sender, System.EventArgs arguments) =>
			{
				if (sender is Trampoline trampoline)
				{
					var assembly = new UnmanagedArray<System.Byte>();

					assembly.Add(new System.Byte[7] { 0x44, 0x8B, 0x97, 0xCC, 0x01, 0x00, 0x00 });																			// mov r10d, [rdi+1CC]
					assembly.Add(new System.Byte[4] { 0x41, 0xC1, 0xEA, 0x08 });																							// shr r10d, 8 (ProjectileFlags.Is3DLoaded)
					assembly.Add(new System.Byte[4] { 0x41, 0xF6, 0xC2, 0x01 });																							// test r10b, 1
					assembly.Add(new System.Byte[2] { 0x74, (System.Byte)Memory.Size<AbsoluteJump>.Unmanaged });															// je 0E
					
					assembly.Add(Assembly.AbsoluteJump(Memory.ReadRelativeCall(ScrambledBugs.Offsets.Fixes.ApplySpellPerkEntryPoints.Arrows.ApplyCombatHitSpellArrow)));	// call
					
					assembly.Add(new System.Byte[1] { 0xC3 });																												// ret
					
					Memory.SafeWriteArray<System.Byte>(trampoline.Address + position, assembly);
					Memory.WriteRelativeCall(ScrambledBugs.Offsets.Fixes.ApplySpellPerkEntryPoints.Arrows.ApplyCombatHitSpellArrow, trampoline.Address + position);

					// arrowProjectile != null

					/*
					ArrowProjectile* arrowProjectile; // rdi

					if ((arrowProjectile->MissileProjectile.Projectile.Flags & ProjectileFlags.Is3DLoaded) == ProjectileFlags.Is3DLoaded)
					{
						goto Function;
					}

					return;
					*/
				}
			};
		}
	}
}
