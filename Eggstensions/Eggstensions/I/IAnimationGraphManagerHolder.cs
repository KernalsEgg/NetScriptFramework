namespace Eggstensions
{
	public interface IIAnimationGraphManagerHolder : IVirtualObject
	{
	}

	public struct IAnimationGraphManagerHolder : IIAnimationGraphManagerHolder
	{
	}



	namespace ExtensionMethods
	{
		unsafe static public class IIAnimationGraphManagerHolder
		{
			// Virtual
			static public System.Boolean GetAnimationVariableFloat<TIAnimationGraphManagerHolder>(this ref TIAnimationGraphManagerHolder animationGraphManagerHolder, BSFixedString* variableName, System.Single* value)
				where TIAnimationGraphManagerHolder : unmanaged, Eggstensions.IIAnimationGraphManagerHolder
			{
				var getAnimationVariableFloat = (delegate* unmanaged[Cdecl]<TIAnimationGraphManagerHolder*, BSFixedString*, System.Single*, System.Byte>)animationGraphManagerHolder.VirtualFunction(0x10);

				return GetAnimationVariableFloat(animationGraphManagerHolder.AsPointer(), variableName, value) != 0;



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				System.Byte GetAnimationVariableFloat(TIAnimationGraphManagerHolder* animationGraphManagerHolder, BSFixedString* variableName, System.Single* value)
				{
					return getAnimationVariableFloat(animationGraphManagerHolder, variableName, value);
				}
			}

			static public System.Boolean GetAnimationVariableInt<TIAnimationGraphManagerHolder>(this ref TIAnimationGraphManagerHolder animationGraphManagerHolder, BSFixedString* variableName, System.Int32* value)
				where TIAnimationGraphManagerHolder : unmanaged, Eggstensions.IIAnimationGraphManagerHolder
			{
				var getAnimationVariableInt = (delegate* unmanaged[Cdecl]<TIAnimationGraphManagerHolder*, BSFixedString*, System.Int32*, System.Byte>)animationGraphManagerHolder.VirtualFunction(0x11);

				return GetAnimationVariableInt(animationGraphManagerHolder.AsPointer(), variableName, value) != 0;



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				System.Byte GetAnimationVariableInt(TIAnimationGraphManagerHolder* animationGraphManagerHolder, BSFixedString* variableName, System.Int32* value)
				{
					return getAnimationVariableInt(animationGraphManagerHolder, variableName, value);
				}
			}

			static public System.Boolean GetAnimationVariableBool<TIAnimationGraphManagerHolder>(this ref TIAnimationGraphManagerHolder animationGraphManagerHolder, BSFixedString* variableName, System.Byte* value)
				where TIAnimationGraphManagerHolder : unmanaged, Eggstensions.IIAnimationGraphManagerHolder
			{
				var getAnimationVariableBool = (delegate* unmanaged[Cdecl]<TIAnimationGraphManagerHolder*, BSFixedString*, System.Byte*, System.Byte>)animationGraphManagerHolder.VirtualFunction(0x12);

				return GetAnimationVariableBool(animationGraphManagerHolder.AsPointer(), variableName, value) != 0;



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				System.Byte GetAnimationVariableBool(TIAnimationGraphManagerHolder* animationGraphManagerHolder, BSFixedString* variableName, System.Byte* value)
				{
					return getAnimationVariableBool(animationGraphManagerHolder, variableName, value);
				}
			}
		}
	}
}
