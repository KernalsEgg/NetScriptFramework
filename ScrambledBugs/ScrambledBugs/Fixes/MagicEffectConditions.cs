using Eggstensions;



namespace ScrambledBugs.Fixes
{
	static internal class MagicEffectConditions
	{
		static public System.Boolean Fix()
		{
			if (!ScrambledBugs.Patterns.Fixes.MagicEffectConditions.UpdateConditions)
			{
				return false;
			}

			MagicEffectConditions.UpdateConditions();

			return true;
		}



		static public void UpdateConditions()
		{
			var assembly = new UnmanagedArray<System.Byte>();

			assembly.Add(new System.Byte[3] { 0x0F, 0x57, 0xC0 });																									// xorps xmm0, xmm0
			assembly.Add(new System.Byte[3] { 0x0F, 0x2F, 0xC8 });																									// comiss xmm1, xmm0
			assembly.Add(new System.Byte[2] { 0x77, 5 + 8 });																										// ja D (elapsedTime <= 0.0F)

			assembly.Add(new System.Byte[8] { 0xF3, 0x0F, 0x11, 0xB7, 0x8C, 0x00, 0x00, 0x00 });																	// movss [rdi+8C], xmm6 (padding8C = frameTime)
			assembly.Add(new System.Byte[5] { 0xE9, 0x6C - ((3 + 3 + 2) + (8 + 5)) + 0x87, 0x00, 0x00, 0x00 });														// jmp DE (Skip)

			assembly.Add(new System.Byte[8] { 0xF3, 0x0F, 0x10, 0x97, 0x8C, 0x00, 0x00, 0x00 });																	// movss xmm2, [rdi+8C]
			assembly.Add(new System.Byte[3] { 0x0F, 0x2F, 0xD0 });																									// comiss xmm2, xmm0
			assembly.Add(new System.Byte[2] { 0x76, (5 + 4 + 4 + 3 + 2) + (4 + 8 + 5) });																			// jna 23 (padding8C > 0.0F)

			assembly.Add(new System.Byte[5] { 0xB9, 0x01, 0x00, 0x00, 0x00 });																						// mov ecx, 1
			assembly.Add(new System.Byte[4] { 0xF3, 0x0F, 0x2A, 0xC1 });																							// cvtsi2ss xmm0, ecx
			assembly.Add(new System.Byte[4] { 0xF3, 0x0F, 0x5E, 0xC3 });																							// divss xmm0,xmm3
			assembly.Add(new System.Byte[3] { 0x0F, 0x2F, 0xC2 });																									// comiss xmm0, xmm2
			assembly.Add(new System.Byte[2] { 0x76, (4 + 8 + 5) });																									// jna 11 (activeEffectConditionUpdateInterval > padding8C)

			assembly.Add(new System.Byte[4] { 0xF3, 0x0F, 0x58, 0xD6 });																							// addss xmm2, xmm6
			assembly.Add(new System.Byte[8] { 0xF3, 0x0F, 0x11, 0x97, 0x8C, 0x00, 0x00, 0x00 });																	// movss [rdi+8C], xmm2 (padding8C += frameTime)
			assembly.Add(new System.Byte[5] { 0xE9, 0x6C - ((3 + 3 + 2) + (8 + 5) + (8 + 3 + 2) + (5 + 4 + 4 + 3 + 2) + (4 + 8 + 5)) + 0x87, 0x00, 0x00, 0x00 });	// jmp AE (Skip)

			assembly.Add(new System.Byte[8] { 0xF3, 0x0F, 0x11, 0xB7, 0x8C, 0x00, 0x00, 0x00 });																	// movss [rdi+8C], xmm6 (padding8C = frameTime)
			assembly.Add(new System.Byte[2] { 0xEB, 0x6C - ((3 + 3 + 2) + (8 + 5) + (8 + 3 + 2) + (5 + 4 + 4 + 3 + 2) + (4 + 8 + 5) + (8 + 2)) });					// jmp 1D (Update)

			Memory.SafeFill<System.Byte>(ScrambledBugs.Offsets.Fixes.MagicEffectConditions.UpdateConditions, 0x6C, Assembly.Nop);
			Memory.SafeWrite<System.Byte>(ScrambledBugs.Offsets.Fixes.MagicEffectConditions.UpdateConditions, assembly);

			// ecx
			// eflags
			// xmm0
			// xmm2

			// activeEffect != null

			/*
			ActiveEffect* activeEffect;							// rdi
			System.Single elapsedTime;							// xmm1
			System.Single activeEffectConditionUpdateFrequency;	// xmm3
			System.Single frameTime;							// xmm6

			if (elapsedTime <= 0.0F)
			{
				activeEffect->Padding8C(frameTime);

				goto Skip;
			}

			System.Single padding8C = activeEffect->Padding8C();

			if (padding8C > 0.0F)
			{
				System.Single activeEffectConditionUpdateInterval = 1.0F / activeEffectConditionUpdateFrequency;

				if (padding8C < activeEffectConditionUpdateInterval)
				{
					activeEffect->Padding8C(padding8C + frameTime);

					goto Skip;
				}
			}

			activeEffect->Padding8C(frameTime);

			goto Update;
			*/
		}
	}
}
