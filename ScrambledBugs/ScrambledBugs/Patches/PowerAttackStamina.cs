using Eggstensions;



namespace ScrambledBugs.Patches
{
	static internal class PowerAttackStamina
	{
		static public System.Byte[] CanPowerAttack(System.IntPtr getStaminaCost)
		{
			var assembly = new UnmanagedArray<System.Byte>();

			assembly.Add(new System.Byte[1] { 0x51 });											// push rcx
			assembly.Add(new System.Byte[4] { 0x48, 0x83, 0xEC, 0x20 });						// sub rsp, 20
			assembly.Add(Assembly.AbsoluteCall(getStaminaCost));								// call

			assembly.Add(new System.Byte[3] { 0x0F, 0x57, 0xC9 });								// xorps xmm1, xmm1
			assembly.Add(new System.Byte[3] { 0x0F, 0x2F, 0xC1 });								// comiss xmm0, xmm1
			assembly.Add(new System.Byte[2] { 0x76, (5 + 5 + 3 + 6 + 3) + (5 + 2) + (2 + 2) });	// jbe 21

			assembly.Add(new System.Byte[5] { 0xBA, 0x1A, 0x00, 0x00, 0x00 });					// mov edx, 1A
			assembly.Add(new System.Byte[5] { 0x48, 0x8B, 0x4C, 0x24, 0x20 });					// mov rcx, [rsp+20]
			assembly.Add(new System.Byte[3] { 0x48, 0x8B, 0x01 });								// mov rax, [rcx]
			assembly.Add(new System.Byte[6] { 0xF3, 0x0F, 0x11, 0x44, 0x24, 0x20 });			// movss [rsp+20], xmm0
			assembly.Add(new System.Byte[3] { 0xFF, 0x50, 0x08 });								// call [rax+8]

			assembly.Add(new System.Byte[5] { 0x0F, 0x2F, 0x44, 0x24, 0x20 });					// comiss xmm0, [rsp+20]
			assembly.Add(new System.Byte[2] { 0x73, 2 + 2 });									// jae 4

			assembly.Add(new System.Byte[2] { 0x31, 0xC0 });									// xor eax, eax
			assembly.Add(new System.Byte[2] { 0xEB, 0x05 });									// jmp 5

			assembly.Add(new System.Byte[5] { 0xB8, 0x01, 0x00, 0x00, 0x00 });					// mov eax, 1

			assembly.Add(new System.Byte[4] { 0x48, 0x83, 0xC4, 0x28 });						// add rsp, 28
			assembly.Add(new System.Byte[1] { Assembly.Ret });									// ret

			return assembly;
		}
		
		static public void Patch()
		{
			Memory.SafeFill<System.Byte>(ScrambledBugs.Offsets.Patches.PowerAttackStamina.HasStaminaActor, 2, Assembly.Nop);
			Memory.SafeFill<System.Byte>(ScrambledBugs.Offsets.Patches.PowerAttackStamina.HasStaminaPlayerCharacter, 2, Assembly.Nop);



			{
				var assembly = new UnmanagedArray<System.Byte>();

				assembly.Add(new System.Byte[2] { 0x84, 0xC0 });	// test al, al
				assembly.Add(new System.Byte[1] { Assembly.Nop });	// nop
				assembly.Add(new System.Byte[2] { 0x74, 0x6E });	// jz 6E

				Memory.SafeWriteArray<System.Byte>(ScrambledBugs.Offsets.Patches.PowerAttackStamina.HasStaminaCostActor, assembly);
			}
			{
				var assembly = new UnmanagedArray<System.Byte>();

				assembly.Add(new System.Byte[2] { 0x84, 0xC0 });	// test al, al
				assembly.Add(new System.Byte[1] { Assembly.Nop });	// nop
				assembly.Add(new System.Byte[2] { 0x75, 0x34 });	// jnz 34

				Memory.SafeWriteArray<System.Byte>(ScrambledBugs.Offsets.Patches.PowerAttackStamina.HasStaminaCostPlayerCharacter, assembly);
			}



			ScrambledBugs.Plugin.Trampoline.WriteRelativeCallBranch
			(
				ScrambledBugs.Offsets.Patches.PowerAttackStamina.GetStaminaCostActor,
				PowerAttackStamina.CanPowerAttack(Memory.ReadRelativeCall(ScrambledBugs.Offsets.Patches.PowerAttackStamina.GetStaminaCostActor))
			);

			ScrambledBugs.Plugin.Trampoline.WriteRelativeCallBranch
			(
				ScrambledBugs.Offsets.Patches.PowerAttackStamina.GetStaminaCostPlayerCharacter,
				PowerAttackStamina.CanPowerAttack(Memory.ReadRelativeCall(ScrambledBugs.Offsets.Patches.PowerAttackStamina.GetStaminaCostPlayerCharacter))
			);
			/*
			ActorValueOwner* actorValueOwner;	// rcx
			BGSAttackData* attackData;			// rdx
			
			var powerAttackStamina = ActorValueOwner.GetPowerAttackStamina(actorValueOwner, attackData);

			if (powerAttackStamina <= 0.0F)
			{
				return true;
			}

			var stamina = ActorValueOwner.GetActorValue(actorValueOwner, ActorValue.Stamina);

			if (stamina >= powerAttackStamina)
			{
				return true;
			}

			return false;
			*/
		}
	}
}
