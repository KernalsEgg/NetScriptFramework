using Eggstensions;



namespace ScrambledBugs.Fixes
{
	static internal class HitEffectRaceCondition
	{
		static public void Fix()
		{
			var assembly = new UnmanagedArray<System.Byte>();

			assembly.Add(new System.Byte[1] { 0x52 });									// push rdx
			assembly.Add(new System.Byte[2] { 0x8B, 0xD0 });							// mov edx, eax
			assembly.Add(new System.Byte[3] { 0xC1, 0xEA, 0x07 });						// shr edx, 7 (ActiveEffectFlags.HasConditions)
			assembly.Add(new System.Byte[3] { 0xF6, 0xC2, 0x01 });						// test dl, 1
			assembly.Add(new System.Byte[2] { 0x75, (2 + 3 + 3 + 2) + (2 + 3 + 3) });	// jne 12

			assembly.Add(new System.Byte[2] { 0x8B, 0xD0 });							// mov edx, eax
			assembly.Add(new System.Byte[3] { 0xC1, 0xEA, 0x05 });						// shr edx, 5 (ActiveEffectFlags.ApplyingVisualEffects)
			assembly.Add(new System.Byte[3] { 0xF6, 0xC2, 0x01 });						// test dl, 1
			assembly.Add(new System.Byte[2] { 0x75, 2 + 3 + 3 });						// jne 8

			assembly.Add(new System.Byte[2] { 0x8B, 0xD0 });							// mov edx, eax
			assembly.Add(new System.Byte[3] { 0xC1, 0xEA, 0x06 });						// shr edx, 6 (ActiveEffectFlags.ApplyingSoundEffects)
			assembly.Add(new System.Byte[3] { 0xF6, 0xC2, 0x01 });						// test dl, 1

			assembly.Add(new System.Byte[1] { 0x5A });									// pop rdx
			assembly.Add(new System.Byte[1] { Assembly.Ret });							// ret

			ScrambledBugs.Plugin.Trampoline.WriteRelativeCallBranch(ScrambledBugs.Offsets.Fixes.HitEffectRaceCondition.ShouldUpdate, assembly);

			// eflags

			/*
			ActiveEffectFlags flags; // ecx
			
			return
				(flags & ActiveEffectFlags.Dispelled) == ActiveEffectFlags.Dispelled
				||
				(flags & ActiveEffectFlags.ApplyingVisualEffects) == ActiveEffectFlags.ApplyingVisualEffects
				||
				(flags & ActiveEffectFlags.ApplyingSoundEffects) == ActiveEffectFlags.ApplyingSoundEffects;
			*/
		}
	}
}
