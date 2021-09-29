using Eggstensions;



namespace ScrambledBugs.Patches
{
	static internal class ReflectDamage
	{
		static public System.Boolean Patch()
		{
			if (!ScrambledBugs.Patterns.Patches.ReflectDamage.CompareReflectDamage)
			{
				return false;
			}
			
			Memory.SafeFill<System.Byte>(ScrambledBugs.Offsets.Patches.ReflectDamage.CompareReflectDamage, 2, Assembly.Nop);

			return true;
		}
	}
}
