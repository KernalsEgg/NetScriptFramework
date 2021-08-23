using Eggstensions;



namespace ScrambledBugs.Patches
{
	unsafe static internal class AccumulatingMagnitude
	{
		static public Eggstensions.Delegates.Types.Actor.GetMaximumWardPower GetMaximumWardPower { get; set; }



		static public void Patch()
		{
			Memory.SafeFill<System.Byte>(ScrambledBugs.Offsets.Patches.AccumulatingMagnitude.SetMaximumMagnitude, 8, Assembly.Nop);



			var constructorAssembly = new UnmanagedArray<System.Byte>();

			constructorAssembly.Add(new System.Byte[3] { 0x0F, 0x28, 0xD0 });																																							// movaps xmm2, xmm0
			constructorAssembly.Add(new System.Byte[5] { 0xF3, 0x0F, 0x10, 0x4F, 0x78 });																																				// movss xmm1, [rdi+78]
			constructorAssembly.Add(new System.Byte[6] { 0x8B, 0x8F, 0x90, 0x00, 0x00, 0x00 });																																			// mov ecx, [rdi+90]
			constructorAssembly.Add(Assembly.RelativeCall(ScrambledBugs.Offsets.Patches.AccumulatingMagnitude.SetRate, 3 + 5 + 6, Memory.ReadRelativeCall(ScrambledBugs.Offsets.Patches.AccumulatingMagnitude.SetRate, 3 + 8 + 6)));	// call
			
			constructorAssembly.Add(new System.Byte[8] { 0xF3, 0x0F, 0x11, 0x87, 0x9C, 0x00, 0x00, 0x00 });																																// movss [rdi+9C], xmm0

			Memory.SafeWriteArray<System.Byte>(ScrambledBugs.Offsets.Patches.AccumulatingMagnitude.SetRate, constructorAssembly);

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



			var visitAssembly = new UnmanagedArray<System.Byte>();

			visitAssembly.Add(new System.Byte[3] { 0x48, 0x8B, 0xCB });																														// mov rcx, rbx
			visitAssembly.Add(Assembly.RelativeCall(ScrambledBugs.Offsets.Patches.AccumulatingMagnitude.GetMaximumMagnitude, 3, Eggstensions.Offsets.ActiveEffect.GetCurrentMagnitude));	// call

			Memory.SafeWriteArray<System.Byte>(ScrambledBugs.Offsets.Patches.AccumulatingMagnitude.GetMaximumMagnitude, visitAssembly);

			/*
			AccumulatingValueModifierEffect* accumulatingValueModifierEffect;	// rbx
			System.Single maximumMagnitude;										// xmm0
			
			var maximumMagnitude = ActiveEffect.GetCurrentMagnitude(&accumulatingValueModifierEffect->ValueModifierEffect.ActiveEffect);
			*/



			var updateAssembly = new UnmanagedArray<System.Byte>();

			updateAssembly.Add(new System.Byte[8] { 0xF3, 0x0F, 0x10, 0xB3, 0x9C, 0x00, 0x00, 0x00 });	// movss xmm6, [rbx+9C]
			updateAssembly.Add(new System.Byte[4] { 0xF3, 0x0F, 0x59, 0xF7 });							// mulss xmm6, xmm7
			updateAssembly.Add(new System.Byte[3] { 0x0F, 0x28, 0xF8 });								// movaps xmm7,xmm0

			Memory.SafeWriteArray<System.Byte>(ScrambledBugs.Offsets.Patches.AccumulatingMagnitude.GetMaximumMagnitudeAndRate, updateAssembly);

			/*
			AccumulatingValueModifierEffect* accumulatingValueModifierEffect;	// rbx
			System.Single frameTime;											// xmm7
			System.Single maximumMagnitude;										// xmm0
			
			var rate = accumulatingValueModifierEffect->MaximumMagnitude * frameTime;
			var maximumMagnitude = ActiveEffect.GetCurrentMagnitude(&accumulatingValueModifierEffect->ValueModifierEffect.ActiveEffect);
			*/


			
			AccumulatingMagnitude.GetMaximumWardPower = (Actor* actor) =>
			{
				var findMaxMagnitudeVisitor						= new FindMaxMagnitudeVisitor();
				*(System.IntPtr*)&findMaxMagnitudeVisitor		= Eggstensions.Offsets.FindMaxMagnitudeVisitor.VirtualFunctionTable;
				findMaxMagnitudeVisitor.FinishedActiveEffect	= null;
				findMaxMagnitudeVisitor.MaximumMagnitude		= -1.0F;

				MagicTarget.VisitActiveEffects(&actor->MagicTarget, &findMaxMagnitudeVisitor);
				Actor.SetMaximumWardPower(actor, findMaxMagnitudeVisitor.MaximumMagnitude);

				return Actor.GetMaximumWardPower(actor);
			};

			ScrambledBugs.Plugin.Trampoline.WriteRelativeCall<Eggstensions.Delegates.Types.Actor.GetMaximumWardPower>
			(
				ScrambledBugs.Offsets.Patches.AccumulatingMagnitude.GetMaximumWardPower,
				AccumulatingMagnitude.GetMaximumWardPower
			);
		}
	}
}
