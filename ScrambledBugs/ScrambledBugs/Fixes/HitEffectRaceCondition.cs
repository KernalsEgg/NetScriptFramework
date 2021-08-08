using Eggstensions;



namespace ScrambledBugs.Fixes
{
	internal class HitEffectRaceCondition
	{
		static HitEffectRaceCondition()
		{
			// ECX: activeEffect->Flags
			
			var assembly = new UnmanagedArray<System.Byte>();

			assembly.Add(new System.Byte[1] { 0x52 });									// push rdx
			assembly.Add(new System.Byte[2] { 0x8B, 0xD1 });							// mov edx, ecx
			assembly.Add(new System.Byte[3] { 0xC1, 0xE9, 0x12 });						// shr ecx, 12 (ActiveEffectFlags.Dispelled)
			assembly.Add(new System.Byte[3] { 0xF6, 0xC1, 0x01 });						// test cl, 01
			assembly.Add(new System.Byte[2] { 0x75, (2 + 3 + 3 + 2) + (2 + 3 + 3) });	// jne 12

			assembly.Add(new System.Byte[2] { 0x8B, 0xCA });							// mov ecx, edx
			assembly.Add(new System.Byte[3] { 0xC1, 0xE9, 0x05 });						// shr ecx, 5 (ActiveEffectFlags.ApplyingVisualEffects)
			assembly.Add(new System.Byte[3] { 0xF6, 0xC1, 0x01 });						// test cl, 01
			assembly.Add(new System.Byte[2] { 0x75, 2 + 3 + 3 });						// jne 08

			assembly.Add(new System.Byte[2] { 0x8B, 0xCA });							// mov ecx, edx
			assembly.Add(new System.Byte[3] { 0xC1, 0xE9, 0x06 });						// shr ecx, 06 (ActiveEffectFlags.ApplyingSoundEffects)
			assembly.Add(new System.Byte[3] { 0xF6, 0xC1, 0x01 });						// test cl, 01

			assembly.Add(new System.Byte[1] { 0x5A });									// pop rdx
			assembly.Add(new System.Byte[1] { 0xC3 });                                  // ret

			ScrambledBugs.Plugin.Trampoline.WriteRelativeCallBranch
			(
				ScrambledBugs.Offsets.Fixes.HitEffectRaceCondition.ShouldUpdate,
				assembly
			);
			Memory.SafeFill<System.Byte>
			(
				ScrambledBugs.Offsets.Fixes.HitEffectRaceCondition.ShouldUpdate,
				Memory.Size<RelativeCall>.Unmanaged,
				3 + 3 - Memory.Size<RelativeCall>.Unmanaged,
				Assembly.Nop
			);
		}
	}
}
