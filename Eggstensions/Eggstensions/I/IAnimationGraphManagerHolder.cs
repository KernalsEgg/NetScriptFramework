namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x8)]
	unsafe public struct IAnimationGraphManagerHolder
	{
		// Virtual
		static public System.Boolean GetAnimationVariableFloat(IAnimationGraphManagerHolder* animationGraphManagerHolder, BSFixedString* variableName, System.Single* variable)
		{
			var getAnimationVariableFloat = Memory.ReadVirtualFunction<Eggstensions.Delegates.Types.IAnimationGraphManagerHolder.GetAnimationVariableFloat>(*(System.IntPtr*)animationGraphManagerHolder, 0x10);

			return getAnimationVariableFloat(animationGraphManagerHolder, variableName, variable) != 0;
		}

		static public System.Boolean GetAnimationVariableInt(IAnimationGraphManagerHolder* animationGraphManagerHolder, BSFixedString* variableName, System.Int32* variable)
		{
			var getAnimationVariableInt = Memory.ReadVirtualFunction<Eggstensions.Delegates.Types.IAnimationGraphManagerHolder.GetAnimationVariableInt>(*(System.IntPtr*)animationGraphManagerHolder, 0x11);

			return getAnimationVariableInt(animationGraphManagerHolder, variableName, variable) != 0;
		}

		static public System.Boolean GetAnimationVariableBool(IAnimationGraphManagerHolder* animationGraphManagerHolder, BSFixedString* variableName, System.Byte* variable)
		{
			var getAnimationVariableBool = Memory.ReadVirtualFunction<Eggstensions.Delegates.Types.IAnimationGraphManagerHolder.GetAnimationVariableBool>(*(System.IntPtr*)animationGraphManagerHolder, 0x12);

			return getAnimationVariableBool(animationGraphManagerHolder, variableName, variable) != 0;
		}
	}
}
