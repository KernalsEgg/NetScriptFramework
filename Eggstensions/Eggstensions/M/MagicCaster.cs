namespace Eggstensions
{
	public interface IMagicCaster : IVirtualObject
	{
	}

	public struct MagicCaster : IMagicCaster
	{
	}



	namespace ExtensionMethods
	{
		unsafe static public class IMagicCaster
		{
			// Virtual
			/// <summary>SkyrimSE.exe + 0x54C5F0 (VID 33626)</summary>
			/// <param name="noHitEffectArt">SkyrimSE.exe + 0x551980 (VID 33683)</param>
			/// <param name="effectiveness">SkyrimSE.exe + 0x540360 (VID 33320)</param>
			/// <param name="hostileEffectivenessOnly">SkyrimSE.exe + 0x53DEB0 (VID 33277)</param>
			/// <param name="magnitudeOverride">SkyrimSE.exe + 0x54C5F0 (VID 33626)</param>
			static public void Cast<TMagicCaster, TSpellItem, TActor1, TActor2>(this ref TMagicCaster magicCaster, TSpellItem* spell, System.Boolean noHitEffectArt, TActor1* target, System.Single effectiveness, System.Boolean hostileEffectivenessOnly, System.Single magnitudeOverride, TActor2* cause)
				where TMagicCaster : unmanaged, Eggstensions.IMagicCaster
				where TSpellItem : unmanaged, Eggstensions.ISpellItem
				where TActor1 : unmanaged, Eggstensions.IActor
				where TActor2 : unmanaged, Eggstensions.IActor
			{
				var cast = (delegate* unmanaged[Cdecl]<TMagicCaster*, TSpellItem*, System.Byte, TActor1*, System.Single, System.Byte, System.Single, TActor2*, void>)magicCaster.VirtualFunction(0x1);

				Cast(magicCaster.AsPointer(), spell, (System.Byte)(noHitEffectArt ? 1 : 0), target, effectiveness, (System.Byte)(hostileEffectivenessOnly ? 1 : 0), magnitudeOverride, cause);



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				void Cast(TMagicCaster* magicCaster, TSpellItem* spell, System.Byte noHitEffectArt, TActor1* target, System.Single effectiveness, System.Byte hostileEffectivenessOnly, System.Single magnitudeOverride, TActor2* cause)
				{
					cast(magicCaster, spell, noHitEffectArt, target, effectiveness, hostileEffectivenessOnly, magnitudeOverride, cause);
				}
			}
		}
	}
}
