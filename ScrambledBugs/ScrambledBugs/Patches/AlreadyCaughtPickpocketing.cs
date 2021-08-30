using Eggstensions;



namespace ScrambledBugs.Patches
{
	static internal class AlreadyCaughtPickpocketing
	{
		static public void Patch()
		{
			Memory.SafeFill<System.Byte>(ScrambledBugs.Offsets.Patches.AlreadyCaughtPickpocketing.IsAttackingOnSight, 2, Assembly.Nop);
			Memory.SafeWriteNullableArray<System.Byte>(ScrambledBugs.Offsets.Patches.AlreadyCaughtPickpocketing.IsNotKnockedDown, new System.Byte?[2] { 0xEB, null });
		}
	}
}
