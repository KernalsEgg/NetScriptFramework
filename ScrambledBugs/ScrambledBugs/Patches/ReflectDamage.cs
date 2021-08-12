using Eggstensions;



namespace ScrambledBugs.Patches
{
	internal class ReflectDamage
	{
		static ReflectDamage()
		{
			Memory.SafeFill<System.Byte>(ScrambledBugs.Offsets.Patches.ReflectDamage.CompareReflectDamage, 2, Assembly.Nop);
		}
	}
}
