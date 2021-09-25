namespace Eggstensions
{
	[System.Flags]
	public enum ActiveEffectFlags : System.UInt32
	{
		NoHitShader				= 1U << 1,
		NoHitEffectArt			= 1U << 2,
		NoInitialFlare			= 1U << 4,
		ApplyingVisualEffects	= 1U << 5,
		ApplyingSounds			= 1U << 6,
		HasConditions			= 1U << 7,
		Recover					= 1U << 9,
		DualCasting				= 1U << 12,
		Inactive				= 1U << 15,
		AppliedEffects			= 1U << 16,
		RemovedEffects			= 1U << 17,
		Dispelled				= 1U << 18,
		WornOff					= 1U << 31
	}



	public interface IActiveEffect : IVirtualObject
	{
	}

	public struct ActiveEffect : IActiveEffect
	{
	}



	namespace ExtensionMethods
	{
		unsafe static public class IActiveEffect
		{
			// Field
			static public BSPointerHandle Caster<TActiveEffect>(this ref TActiveEffect activeEffect)
				where TActiveEffect : unmanaged, Eggstensions.IActiveEffect
			{
				return *(BSPointerHandle*)activeEffect.AddByteOffset(0x34); // Actor
			}

			static public MagicItem* Spell<TActiveEffect>(this ref TActiveEffect activeEffect)
				where TActiveEffect : unmanaged, Eggstensions.IActiveEffect
			{
				return *(MagicItem**)activeEffect.AddByteOffset(0x40);
			}

			static public Effect* Effect<TActiveEffect>(this ref TActiveEffect activeEffect)
				where TActiveEffect : unmanaged, Eggstensions.IActiveEffect
			{
				return *(Effect**)activeEffect.AddByteOffset(0x48);
			}

			static public MagicTarget* MagicTarget<TActiveEffect>(this ref TActiveEffect activeEffect)
				where TActiveEffect : unmanaged, Eggstensions.IActiveEffect
			{
				return *(MagicTarget**)activeEffect.AddByteOffset(0x50);
			}

			static public System.Single ElapsedTime<TActiveEffect>(this ref TActiveEffect activeEffect)
				where TActiveEffect : unmanaged, Eggstensions.IActiveEffect
			{
				return *(System.Single*)activeEffect.AddByteOffset(0x70);
			}

			static public System.Single Duration<TActiveEffect>(this ref TActiveEffect activeEffect)
				where TActiveEffect : unmanaged, Eggstensions.IActiveEffect
			{
				return *(System.Single*)activeEffect.AddByteOffset(0x74);
			}

			static public void Duration<TActiveEffect>(this ref TActiveEffect activeEffect, System.Single duration)
				where TActiveEffect : unmanaged, Eggstensions.IActiveEffect
			{
				*(System.Single*)activeEffect.AddByteOffset(0x74) = duration;
			}

			static public System.Single Magnitude<TActiveEffect>(this ref TActiveEffect activeEffect)
				where TActiveEffect : unmanaged, Eggstensions.IActiveEffect
			{
				return *(System.Single*)activeEffect.AddByteOffset(0x78);
			}

			static public void Magnitude<TActiveEffect>(this ref TActiveEffect activeEffect, System.Single magnitude)
				where TActiveEffect : unmanaged, Eggstensions.IActiveEffect
			{
				*(System.Single*)activeEffect.AddByteOffset(0x78) = magnitude;
			}

			static public ActiveEffectFlags Flags<TActiveEffect>(this ref TActiveEffect activeEffect)
				where TActiveEffect : unmanaged, Eggstensions.IActiveEffect
			{
				return (ActiveEffectFlags)(*(System.UInt32*)activeEffect.AddByteOffset(0x7C));
			}

			static public CastingSource CastingSource<TActiveEffect>(this ref TActiveEffect activeEffect)
				where TActiveEffect : unmanaged, Eggstensions.IActiveEffect
			{
				return (CastingSource)(*(System.Int32*)activeEffect.AddByteOffset(0x88));
			}



			// Member
			static public void Dispel<TActiveEffect>(this ref TActiveEffect activeEffect, System.Boolean force)
				where TActiveEffect : unmanaged, Eggstensions.IActiveEffect
			{
				var dispel = (delegate* unmanaged[Cdecl]<TActiveEffect*, System.Byte, void>)Eggstensions.Offsets.ActiveEffect.Dispel;

				Dispel(activeEffect.AsPointer(), (System.Byte)(force ? 1 : 0));



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				void Dispel(TActiveEffect* activeEffect, System.Byte force)
				{
					dispel(activeEffect, force);
				}
			}

			static public System.Single GetCurrentMagnitude<TActiveEffect>(this ref TActiveEffect activeEffect)
				where TActiveEffect : unmanaged, Eggstensions.IActiveEffect
			{
				var getCurrentMagnitude = (delegate* unmanaged[Cdecl]<TActiveEffect*, System.Single>)Eggstensions.Offsets.ActiveEffect.GetCurrentMagnitude;

				return GetCurrentMagnitude(activeEffect.AsPointer());



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				System.Single GetCurrentMagnitude(TActiveEffect* activeEffect)
				{
					return getCurrentMagnitude(activeEffect);
				}
			}
		}
	}
}
