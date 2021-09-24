using Eggstensions;



namespace ScrambledBugs.Patches
{
	static internal class AttachHitEffectArt
	{
		static public void Patch()
		{
			Memory.SafeFill<System.Byte>(ScrambledBugs.Offsets.Patches.AttachHitEffectArt.IsPlayerUpdatePosition, 2, Assembly.Nop);
			Memory.SafeFill<System.Byte>(ScrambledBugs.Offsets.Patches.AttachHitEffectArt.IsPerspectiveChange, 2, Assembly.Nop);



			{
				var assembly = new UnmanagedArray<System.Byte>();

				assembly.Add(new System.Byte[2] { 0x24, 0xF8 });	// and al, F8 (1 << 2 (NoHitEffectArt), 1 << 4 (NoInitialFlare))
				assembly.Add(new System.Byte[1] { Assembly.Nop });	// nop
				assembly.Add(new System.Byte[1] { Assembly.Nop });	// nop

				Memory.SafeWrite<System.Byte>(ScrambledBugs.Offsets.Patches.AttachHitEffectArt.AddNoHitEffectArtFlag, assembly);
			}



			{
				var assembly = new UnmanagedArray<System.Byte>();

				assembly.Add(new System.Byte[2] { 0x41, 0x54 });							// push r12
				assembly.Add(new System.Byte[2] { 0x41, 0x55 });							// push r13
				assembly.Add(new System.Byte[4] { 0x48, 0x83, 0xEC, 0x28 });				// sub rsp, 28
				assembly.Add(new System.Byte[4] { 0x48, 0x8B, 0x4E, 0x30 });				// mov rcx, [rsi+30] (modelReferenceEffect->Controller)
				assembly.Add(new System.Byte[3] { 0x48, 0x8B, 0x01 });						// mov rax, [rcx]
				assembly.Add(new System.Byte[3] { 0xFF, 0x50, 0x78 });						// call [rax+78] (ReferenceEffectController.GetAttachRoot(controller))
				assembly.Add(new System.Byte[3] { 0x48, 0x85, 0xC0 });						// test rax, rax (attachRoot)
				assembly.Add(new System.Byte[2] { 0x75, 3 + 3 + 6 });						// jnz C (attachRoot == null)

				assembly.Add(new System.Byte[3] { 0x48, 0x8B, 0xCB });						// mov rcx, rbx (actor)
				assembly.Add(new System.Byte[3] { 0x48, 0x8B, 0x01 });						// mov rax, [rcx]
				assembly.Add(new System.Byte[6] { 0xFF, 0x90, 0x68, 0x04, 0x00, 0x00 });	// call [rax+468] (TESObjectREFR.GetCurrent3D(actor))

				assembly.Add(new System.Byte[3] { 0x45, 0x31, 0xE4 });						// xor r12d, r12d (attachRootNode)
				assembly.Add(new System.Byte[3] { 0x48, 0x85, 0xC0 });						// test rax, rax
				assembly.Add(new System.Byte[2] { 0x74, (3 + 3 + 3 + 3 + 3 + 3 + 2) + 4 });	// jz 18 (attachRoot != null)

				assembly.Add(new System.Byte[3] { 0x4C, 0x8B, 0xE8 });						// mov r13, rax
				assembly.Add(new System.Byte[3] { 0x48, 0x8B, 0xC8 });						// mov rcx, rax
				assembly.Add(new System.Byte[3] { 0x48, 0x8B, 0x01 });						// mov rax, [rcx]
				assembly.Add(new System.Byte[3] { 0xFF, 0x50, 0x18 });						// call [rax+18] (NiObject.AsNode(attachRoot))
				assembly.Add(new System.Byte[3] { 0x4C, 0x8B, 0xE0 });						// mov r12, rax
				assembly.Add(new System.Byte[3] { 0x4D, 0x85, 0xE4 });						// test r12, r12
				assembly.Add(new System.Byte[2] { 0x75, 4 });								// jnz 4 (attachRootNode == null)

				assembly.Add(new System.Byte[4] { 0x4D, 0x8B, 0x65, 0x30 });				// mov r12, [r13+30] (attachRoot->Parent)

				assembly.Add(new System.Byte[4] { 0x4C, 0x3B, 0x66, 0x70 });				// cmp r12, [rsi+70]
				assembly.Add(new System.Byte[3] { 0x0F, 0x95, 0xC0 });						// setne al (attachRootNode != modelReferenceEffect->HitEffectArtData.AttachRoot)
				assembly.Add(new System.Byte[4] { 0x48, 0x83, 0xC4, 0x28 });				// add rsp, 28
				assembly.Add(new System.Byte[2] { 0x41, 0x5D });							// pop r13
				assembly.Add(new System.Byte[2] { 0x41, 0x5C });							// pop r12
				assembly.Add(new System.Byte[1] { Assembly.Ret });							// ret

				Trampoline.WriteRelativeCallBranch(ScrambledBugs.Offsets.Patches.AttachHitEffectArt.IsPlayerAttach, assembly);
			}
			{
				var assembly = new UnmanagedArray<System.Byte>();

				assembly.Add(new System.Byte[2] { 0x84, 0xC0 }); // test al, al
				assembly.Add(new System.Byte[2] { 0x74, 0x55 }); // jz 55

				Memory.SafeWrite<System.Byte>(ScrambledBugs.Offsets.Patches.AttachHitEffectArt.IsPlayerAttach, System.Runtime.CompilerServices.Unsafe.SizeOf<RelativeCall>(), assembly);
			}
			// Volatile registers

			// actor							!= null
			// modelReferenceEffect				!= null
			// modelReferenceEffect->Controller	!= null

			/*
			ModelReferenceEffect* modelReferenceEffect;	// rsi
			Actor* actor;								// rbx

			ReferenceEffectController* controller	= modelReferenceEffect->Controller();
			NiAVObject* attachRoot					= controller->GetAttachRoot();

			if (attachRoot == null)
			{
				attachRoot = actor->GetCurrent3D();
			}

			NiNode* attachRootNode = null;

			if (attachRoot != null)
			{
				attachRootNode = attachRoot->AsNode();

				if (attachRootNode == null)
				{
					attachRootNode = attachRoot->Parent();
				}
			}

			return attachRootNode != modelReferenceEffect->HitEffectArtData()->AttachRoot();
			*/
		}
	}
}
