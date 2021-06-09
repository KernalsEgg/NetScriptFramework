namespace Eggstensions
{
	public class MagicCaster : VirtualObject
	{
		public MagicCaster(System.IntPtr address) : base(address)
		{
		}



		/// <summary>SkyrimSE.exe + 0x54C5F0 (VID 33626)</summary>
		/// <param name="noHitEffectArt">SkyrimSE.exe + 0x551980 (VID 33683)</param>
		/// <param name="dualCastingMultiplier">SkyrimSE.exe + 0x540360 (VID 33320)</param>
		/// <param name="hostileDualCastingMultiplierOnly">SkyrimSE.exe + 0x53DEB0 (VID 33277)</param>
		/// <param name="magnitudeOverride">SkyrimSE.exe + 0x54C5F0 (VID 33626)</param>
		virtual public void Cast(SpellItem spell, System.Boolean noHitEffectArt, Actor target, System.Single dualCastingMultiplier, System.Boolean hostileDualCastingMultiplierOnly, System.Single magnitudeOverride, System.IntPtr unknownPointer)
		{
			var cast = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.MagicCaster.Cast>(this[0x1]);

			cast(this, spell, (System.Byte)(noHitEffectArt ? 1 : 0), target, dualCastingMultiplier, (System.Byte)(hostileDualCastingMultiplierOnly ? 1 : 0), magnitudeOverride, unknownPointer);
		}



		static public implicit operator MagicCaster(System.IntPtr address)
		{
			return new MagicCaster(address);
		}
	}
}
