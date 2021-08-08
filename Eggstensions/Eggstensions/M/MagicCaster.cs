namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x48)]
	unsafe public struct MagicCaster
	{
		// Virtual
		/// <summary>SkyrimSE.exe + 0x54C5F0 (VID 33626)</summary>
		/// <param name="noHitEffectArt">SkyrimSE.exe + 0x551980 (VID 33683)</param>
		/// <param name="effectiveness">SkyrimSE.exe + 0x540360 (VID 33320)</param>
		/// <param name="hostileEffectivenessOnly">SkyrimSE.exe + 0x53DEB0 (VID 33277)</param>
		/// <param name="magnitudeOverride">SkyrimSE.exe + 0x54C5F0 (VID 33626)</param>
		static public void Cast(MagicCaster* magicCaster, SpellItem* spell, System.Boolean noHitEffectArt, Actor* target, System.Single effectiveness, System.Boolean hostileEffectivenessOnly, System.Single magnitudeOverride, Actor* cause)
		{
			var cast = Memory.ReadVirtualFunction<Eggstensions.Delegates.Types.MagicCaster.Cast>(*(System.IntPtr*)magicCaster, 0x1);

			cast(magicCaster, spell, (System.Byte)(noHitEffectArt ? 1 : 0), target, effectiveness, (System.Byte)(hostileEffectivenessOnly ? 1 : 0), magnitudeOverride, cause);
		}
	}
}
