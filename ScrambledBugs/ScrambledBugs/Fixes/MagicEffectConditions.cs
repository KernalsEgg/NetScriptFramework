using Eggstensions;



namespace ScrambledBugs.Fixes
{
	internal class MagicEffectConditions
	{
		static MagicEffectConditions()
		{
			// RDI: activeEffect
			// XMM1: activeEffect->ElapsedTime
			// XMM3: activeEffectConditionUpdateFrequency
			// XMM6: frameTime

			// ECX
			// EFLAGS
			// XMM0
			// XMM2
			
			// activeEffect != null

			var assembly = new UnmanagedArray<System.Byte>();

			assembly.Add(new System.Byte[3] { 0x0F, 0x57, 0xC0 });																						// xorps xmm0, xmm0
			assembly.Add(new System.Byte[3] { 0x0F, 0x2F, 0xC8 });																						// comiss xmm1, xmm0
			assembly.Add(new System.Byte[2] { 0x76, (8 + 3 + 2) + (5 + 4 + 4 + 3 + 2) + (4 + 8 + 5) });													// jna 30 (elapsedTime > 0.0F)

			assembly.Add(new System.Byte[8] { 0xF3, 0x0F, 0x10, 0x97, 0x8C, 0x00, 0x00, 0x00 });														// movss xmm2, [rdi+8C]
			assembly.Add(new System.Byte[3] { 0x0F, 0x2F, 0xD0 });																						// comiss xmm2, xmm0
			assembly.Add(new System.Byte[2] { 0x76, (5 + 4 + 4 + 3 + 2) + (4 + 8 + 5) });																// jna 23 (padding8C > 0.0F)

			assembly.Add(new System.Byte[5] { 0xB9, 0x01, 0x00, 0x00, 0x00 });																			// mov ecx, 00000001
			assembly.Add(new System.Byte[4] { 0xF3, 0x0F, 0x2A, 0xC1 });																				// cvtsi2ss xmm0, ecx
			assembly.Add(new System.Byte[4] { 0xF3, 0x0F, 0x5E, 0xC3 });																				// divss xmm0,xmm3
			assembly.Add(new System.Byte[3] { 0x0F, 0x2F, 0xC2 });																						// comiss xmm0, xmm2
			assembly.Add(new System.Byte[2] { 0x76, (4 + 8 + 5) });																						// jna 11 (activeEffectConditionUpdateInterval > padding8C)

			assembly.Add(new System.Byte[4] { 0xF3, 0x0F, 0x58, 0xD6 });																				// addss xmm2, xmm6
			assembly.Add(new System.Byte[8] { 0xF3, 0x0F, 0x11, 0x97, 0x8C, 0x00, 0x00, 0x00 });														// movss [rdi+8C], xmm2 (padding8C += frameTime)
			assembly.Add(new System.Byte[5] { 0xE9, 0x6C - ((3 + 3 + 2) + (8 + 3 + 2) + (5 + 4 + 4 + 3 + 2) + (4 + 8 + 5)) + 0x87, 0x00, 0x00, 0x00 });	// jmp BB (Skip)

			assembly.Add(new System.Byte[8] { 0xF3, 0x0F, 0x11, 0xB7, 0x8C, 0x00, 0x00, 0x00 });														// movss [rdi+8C], xmm6 (padding8C = frameTime)
			assembly.Add(new System.Byte[2] { 0xEB, 0x6C - ((3 + 3 + 2) + (8 + 3 + 2) + (5 + 4 + 4 + 3 + 2) + (4 + 8 + 5) + (8 + 2)) });				// jmp 2A (Update)

			Memory.SafeFill<System.Byte>(ScrambledBugs.Offsets.Fixes.MagicEffectConditions.UpdateConditions, 0x6C, Assembly.Nop);
			Memory.SafeWriteArray<System.Byte>(ScrambledBugs.Offsets.Fixes.MagicEffectConditions.UpdateConditions, assembly);
		}
	}
}
