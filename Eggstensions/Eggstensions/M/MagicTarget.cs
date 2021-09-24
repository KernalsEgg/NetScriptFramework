namespace Eggstensions
{
	public interface IMagicTarget : IVirtualObject
	{
	}

	public struct MagicTarget : IMagicTarget
	{
	}



	namespace ExtensionMethods
	{
		unsafe static public class IMagicTarget
		{
			// Member
			static public Actor* GetActor<TMagicTarget>(this ref TMagicTarget magicTarget)
				where TMagicTarget : unmanaged, Eggstensions.IMagicTarget
			{
				var getActor = (delegate* unmanaged[Cdecl]<TMagicTarget*, Actor*>)Eggstensions.Offsets.MagicTarget.GetActor;

				return GetActor(magicTarget.AsPointer());



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				Actor* GetActor(TMagicTarget* magicTarget)
				{
					return getActor(magicTarget);
				}
			}

			static public void VisitActiveEffects<TMagicTarget>(this ref TMagicTarget magicTarget, void* visitor)
				where TMagicTarget : unmanaged, Eggstensions.IMagicTarget
			{
				var visitActiveEffects = (delegate* unmanaged[Cdecl]<TMagicTarget*, void*, void>)Eggstensions.Offsets.MagicTarget.VisitActiveEffects;

				VisitActiveEffects(magicTarget.AsPointer(), visitor);



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				void VisitActiveEffects(TMagicTarget* magicTarget, void* visitor)
				{
					visitActiveEffects(magicTarget, visitor);
				}
			}
		}
	}
}
