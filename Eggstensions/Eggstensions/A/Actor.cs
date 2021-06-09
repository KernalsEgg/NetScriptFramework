namespace Eggstensions
{
	public enum ActorValue : System.Int32
	{
		SpeedMult = 30
	}



	public class Actor : TESObjectREFR
	{
		public Actor(System.IntPtr address) : base(address)
		{
		}



		virtual public MagicCaster GetMagicCaster(CastingSource castingSource)
		{
			var getMagicCaster = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.Actor.GetMagicCaster>(this[0x5C]);

			return getMagicCaster(this, (System.Int32)castingSource);
		}



		public System.Boolean AddSpell(SpellItem spell)
		{
			return Delegates.Instances.Actor.AddSpell(this, spell) != 0;
		}



		static public implicit operator Actor(System.IntPtr address)
		{
			return new Actor(address);
		}
	}
}
