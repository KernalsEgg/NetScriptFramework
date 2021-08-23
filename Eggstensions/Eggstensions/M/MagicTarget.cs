namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x18)]
	unsafe public struct MagicTarget
	{
		// Member
		static public Actor* GetActor(MagicTarget* magicTarget)
		{
			return Eggstensions.Delegates.Instances.MagicTarget.GetActor(magicTarget);
		}

		static public void VisitActiveEffects(MagicTarget* magicTarget, void* visitor)
		{
			Eggstensions.Delegates.Instances.MagicTarget.VisitActiveEffects(magicTarget, visitor);
		}
	}
}
