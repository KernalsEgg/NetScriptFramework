﻿using Eggstensions;



namespace ScrambledBugs.Patches
{
	static internal class ReflectDamage
	{
		static public void Patch()
		{
			Memory.SafeFill<System.Byte>(ScrambledBugs.Offsets.Patches.ReflectDamage.CompareReflectDamage, 2, Assembly.Nop);
		}
	}
}
