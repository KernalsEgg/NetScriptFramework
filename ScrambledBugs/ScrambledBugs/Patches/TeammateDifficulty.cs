﻿using Eggstensions;



namespace ScrambledBugs.Patches
{
	static internal class TeammateDifficulty
	{
		static public System.Boolean Patch()
		{
			if (!ScrambledBugs.Patterns.Patches.TeammateDifficulty.IsPlayer)
			{
				return false;
			}

			TeammateDifficulty.IsPlayerOrTeammate();

			return true;
		}



		static public void IsPlayerOrTeammate()
		{
			var assembly = new UnmanagedArray<System.Byte>();

			assembly.Add(Memory.ReadArray<System.Byte>(ScrambledBugs.Offsets.Patches.TeammateDifficulty.IsPlayer, System.Runtime.CompilerServices.Unsafe.SizeOf<RelativeCall>()));	// mov edx, 18
			assembly.Add(new System.Byte[2] { 0x74, 6 + 3 + 2 + 2 });																												// je B

			assembly.Add(new System.Byte[6] { 0x8B, 0x81, 0xE0, 0x00, 0x00, 0x00 });																								// mov eax, [rcx+E0]
			assembly.Add(new System.Byte[3] { 0xC1, 0xE8, 0x1A });																													// shr eax, 1A
			assembly.Add(new System.Byte[2] { 0xF6, 0xD0 });																														// not al
			assembly.Add(new System.Byte[2] { 0xA8, 0x01 });																														// test al, 1

			assembly.Add(new System.Byte[1] { Assembly.Ret });																														// ret

			Trampoline.WriteRelativeCallBranch(ScrambledBugs.Offsets.Patches.TeammateDifficulty.IsPlayer, assembly);

			// rax
			// eflags

			// actor != null

			/*
			Actor* actor; // rcx

			return
				(actor == player)
				||
				((actor->BoolBits() & ActorBoolBits.PlayerTeammate) == ActorBoolBits.PlayerTeammate);
			*/
		}
	}
}
