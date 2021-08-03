namespace Eggstensions
{
	public enum ActorValue : System.Int32
	{
		SpeedMult = 30
	}



	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x2B0)]
	unsafe public struct Actor // TESObjectREFR
	{
		[System.Runtime.InteropServices.FieldOffset(0x0)] public TESObjectREFR TESObjectREFR;



		// Virtual
		static public MagicCaster* GetMagicCaster(Actor* actor, CastingSource castingSource)
		{
			var getMagicCaster = Memory.ReadVirtualFunction<Eggstensions.Delegates.Types.Actor.GetMagicCaster>(*(System.IntPtr*)actor, 0x5C);

			return getMagicCaster(actor, (System.Int32)castingSource);
		}



		// Member
		static public System.Boolean AddSpell(Actor* actor, SpellItem* spell)
		{
			return Eggstensions.Delegates.Instances.Actor.AddSpell(actor, spell) != 0;
		}
	}
}
