using Eggstensions;



namespace ScrambledBugs.Patches
{
	unsafe static internal class AccumulatingMagnitude
	{
		static public void Patch()
		{
			Memory.SafeFill<System.Byte>(ScrambledBugs.Offsets.Patches.AccumulatingMagnitude.SetMaximumMagnitude, 8, Assembly.Nop);



			{
				var assembly = new UnmanagedArray<System.Byte>();

				assembly.Add(new System.Byte[3] { 0x0F, 0x28, 0xD0 });																																							// movaps xmm2, xmm0
				assembly.Add(new System.Byte[5] { 0xF3, 0x0F, 0x10, 0x4F, 0x78 });																																				// movss xmm1, [rdi+78]
				assembly.Add(new System.Byte[6] { 0x8B, 0x8F, 0x90, 0x00, 0x00, 0x00 });																																		// mov ecx, [rdi+90]
				assembly.Add(Assembly.RelativeCall(ScrambledBugs.Offsets.Patches.AccumulatingMagnitude.SetRate, 3 + 5 + 6, Memory.ReadRelativeCall(ScrambledBugs.Offsets.Patches.AccumulatingMagnitude.SetRate, 3 + 8 + 6)));	// call
			
				assembly.Add(new System.Byte[8] { 0xF3, 0x0F, 0x11, 0x87, 0x9C, 0x00, 0x00, 0x00 });																															// movss [rdi+9C], xmm0

				Memory.SafeWriteArray<System.Byte>(ScrambledBugs.Offsets.Patches.AccumulatingMagnitude.SetRate, assembly);
			}
			/*
			AccumulatingValueModifierEffect* accumulatingValueModifierEffect;	// rdi
			System.Single magicSkill;											// xmm0
			
			accumulatingValueModifierEffect->MaximumMagnitude = AccumulatingValueModifierEffect.GetRate
			(
				accumulatingValueModifierEffect->ValueModifierEffect.ActorValue,
				accumulatingValueModifierEffect->ValueModifierEffect.ActiveEffect.Magnitude,
				magicSkill
			);
			*/



			{
				var assembly = new UnmanagedArray<System.Byte>();

				assembly.Add(new System.Byte[3] { 0x48, 0x8B, 0xCB });																													// mov rcx, rbx
				assembly.Add(Assembly.RelativeCall(ScrambledBugs.Offsets.Patches.AccumulatingMagnitude.GetMaximumMagnitude, 3, Eggstensions.Offsets.ActiveEffect.GetCurrentMagnitude));	// call

				Memory.SafeWriteArray<System.Byte>(ScrambledBugs.Offsets.Patches.AccumulatingMagnitude.GetMaximumMagnitude, assembly);
			}
			/*
			AccumulatingValueModifierEffect* accumulatingValueModifierEffect;	// rbx
			System.Single maximumMagnitude;										// xmm0
			
			var maximumMagnitude = ActiveEffect.GetCurrentMagnitude(&accumulatingValueModifierEffect->ValueModifierEffect.ActiveEffect);
			*/



			{
				var assembly = new UnmanagedArray<System.Byte>();

				assembly.Add(new System.Byte[8] { 0xF3, 0x0F, 0x10, 0xB3, 0x9C, 0x00, 0x00, 0x00 });	// movss xmm6, [rbx+9C]
				assembly.Add(new System.Byte[4] { 0xF3, 0x0F, 0x59, 0xF7 });							// mulss xmm6, xmm7
				assembly.Add(new System.Byte[3] { 0x0F, 0x28, 0xF8 });									// movaps xmm7,xmm0

				Memory.SafeWriteArray<System.Byte>(ScrambledBugs.Offsets.Patches.AccumulatingMagnitude.GetMaximumMagnitudeAndRate, assembly);
			}
			/*
			AccumulatingValueModifierEffect* accumulatingValueModifierEffect;	// rbx
			System.Single frameTime;											// xmm7
			System.Single maximumMagnitude;										// xmm0
			
			var rate = accumulatingValueModifierEffect->MaximumMagnitude * frameTime;
			var maximumMagnitude = ActiveEffect.GetCurrentMagnitude(&accumulatingValueModifierEffect->ValueModifierEffect.ActiveEffect);
			*/



			{
				var assembly = new UnmanagedArray<System.Byte>();

				assembly.Add(new System.Byte[1] { 0x51 });																								// push rcx
				assembly.Add(new System.Byte[4] { 0x48, 0x83, 0xEC, 0x40 });																			// sub rsp, 40
				assembly.Add(new System.Byte[2] { 0x48, 0xB8 }); assembly.Add(Eggstensions.Offsets.FindMaxMagnitudeVisitor.VirtualFunctionTable);		// mov rax
				assembly.Add(new System.Byte[5] { 0x48, 0x89, 0x44, 0x24, 0x20 });																		// mov [rsp+20], rax
				assembly.Add(new System.Byte[2] { 0x31, 0xC0 });																						// xor eax, eax
				assembly.Add(new System.Byte[5] { 0x48, 0x89, 0x44, 0x24, 0x28 });																		// mov [rsp+28], rax
				assembly.Add(new System.Byte[5] { 0xB8, 0xFF, 0xFF, 0xFF, 0xFF });																		// mov eax, -1
				assembly.Add(new System.Byte[4] { 0xF3, 0x0F, 0x2A, 0xC0 });																			// cvtsi2ss xmm0, eax
				assembly.Add(new System.Byte[6] { 0xF3, 0x0F, 0x11, 0x44, 0x24, 0x30 });																// movss [rsp+30], xmm0
				assembly.Add(new System.Byte[5] { 0x48, 0x8D, 0x54, 0x24, 0x20 });																		// lea rdx, [rsp+20]
				assembly.Add(new System.Byte[7] { 0x48, 0x81, 0xC1, 0x98, 0x00, 0x00, 0x00 });															// add rcx, 98
				assembly.Add(Assembly.AbsoluteCall(Eggstensions.Offsets.MagicTarget.VisitActiveEffects));												// call
				
				assembly.Add(new System.Byte[6] { 0xF3, 0x0F, 0x10, 0x4C, 0x24, 0x30 });																// movss xmm1, [rsp+30]
				assembly.Add(new System.Byte[5] { 0x48, 0x8B, 0x4C, 0x24, 0x40 });																		// mov rcx, [rsp+40]
				assembly.Add(Assembly.AbsoluteCall(Eggstensions.Offsets.Actor.SetMaximumWardPower));													// call

				assembly.Add(new System.Byte[5] { 0x48, 0x8B, 0x4C, 0x24, 0x40 });																		// mov rcx, [rsp+40]
				assembly.Add(Assembly.AbsoluteCall(Memory.ReadRelativeCall(ScrambledBugs.Offsets.Patches.AccumulatingMagnitude.GetMaximumWardPower)));	// call

				assembly.Add(new System.Byte[4] { 0x48, 0x83, 0xC4, 0x48 });																			// add rsp, 48
				assembly.Add(new System.Byte[1] { Assembly.Ret });																						// ret

				ScrambledBugs.Plugin.Trampoline.WriteRelativeCallBranch(ScrambledBugs.Offsets.Patches.AccumulatingMagnitude.GetMaximumWardPower, assembly);
			}
			/*
			Actor* actor; // rcx
			
			var findMaxMagnitudeVisitor						= new FindMaxMagnitudeVisitor();
			*(System.IntPtr*)&findMaxMagnitudeVisitor		= Eggstensions.Offsets.FindMaxMagnitudeVisitor.VirtualFunctionTable;
			findMaxMagnitudeVisitor.FinishedActiveEffect	= null;
			findMaxMagnitudeVisitor.MaximumMagnitude		= -1.0F;

			MagicTarget.VisitActiveEffects(&actor->MagicTarget, &findMaxMagnitudeVisitor);
			Actor.SetMaximumWardPower(actor, findMaxMagnitudeVisitor.MaximumMagnitude);

			return Actor.GetMaximumWardPower(actor);
			*/
		}
	}
}
