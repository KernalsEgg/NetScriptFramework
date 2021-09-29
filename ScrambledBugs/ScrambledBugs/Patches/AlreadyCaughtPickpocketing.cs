using Eggstensions;



namespace ScrambledBugs.Patches
{
	static internal class AlreadyCaughtPickpocketing
	{
		static public System.Boolean Patch()
		{
			if
			(
				!ScrambledBugs.Patterns.Patches.AlreadyCaughtPickpocketing.IsAttackingOnSight
				||
				!ScrambledBugs.Patterns.Patches.AlreadyCaughtPickpocketing.IsNotKnockedDown
			)
			{
				return false;
			}

			Memory.SafeFill<System.Byte>(ScrambledBugs.Offsets.Patches.AlreadyCaughtPickpocketing.IsAttackingOnSight, 2, Assembly.Nop);
			Memory.SafeWrite<System.Byte>(ScrambledBugs.Offsets.Patches.AlreadyCaughtPickpocketing.IsNotKnockedDown, new System.Byte?[2] { 0xEB, null });

			return true;
		}
	}
}
