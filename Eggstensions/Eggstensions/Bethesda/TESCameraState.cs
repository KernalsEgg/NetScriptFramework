namespace Eggstensions.Bethesda
{
	public enum TESCameraStates : System.UInt32
	{
		FirstPersonState = 0x0,
		AutoVanityState = 0x1,
		VATSCameraState = 0x2,
		FreeCameraState = 0x3,
		IronSightsState = 0x4,
		FurnitureCameraState = 0x5,
		PlayerCameraTransitionState = 0x6,
		TweenMenuCameraState = 0x7,
		ThirdPersonState1 = 0x8,
		ThirdPersonState2 = 0x9,
		HorseCameraState = 0xA,
		BleedoutCameraState = 0xB,
		DragonCameraState = 0xC
	}



	class TESCameraState
	{
		/// <param name="tesCameraState">TESCameraState</param>
		static public (System.Single x, System.Single y, System.Single z) GetPosition(System.IntPtr tesCameraState)
		{
			if (tesCameraState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("tesCameraState"); }

			using (var position = new NiPoint3())
			{
				VirtualObject.InvokeVTableThisCall(tesCameraState, 0x28, position.Address);

				return (position.X, position.Y, position.Z);
			}
		}

		/// <param name="tesCameraState">TESCameraState</param>
		static public System.Single[,] GetRotationAsMatrix33(System.IntPtr tesCameraState)
		{
			if (tesCameraState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("tesCameraState"); }

			using (var rotation = new NiQuaternion())
			{
				VirtualObject.InvokeVTableThisCall(tesCameraState, 0x20, rotation.Address);

				return rotation.Elements.QuaternionToMatrix33().Elements;
			}
		}

		/// <param name="tesCameraState">TESCameraState</param>
		static public (System.Single w, System.Single x, System.Single y, System.Single z) GetRotationAsQuaternion(System.IntPtr tesCameraState)
		{
			if (tesCameraState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("tesCameraState"); }

			using (var rotation = new NiQuaternion())
			{
				VirtualObject.InvokeVTableThisCall(tesCameraState, 0x20, rotation.Address);

				return (rotation.W, rotation.X, rotation.Y, rotation.Z);
			}
		}

		/// <param name="tesCameraState">TESCameraState</param>
		static public TESCameraStates GetState(System.IntPtr tesCameraState)
		{
			if (tesCameraState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("tesCameraState"); }

			return (TESCameraStates)NetScriptFramework.Memory.ReadUInt32(tesCameraState + 0x18);
		}

		/// <param name="tesCameraState">TESCameraState</param>
		static public System.Boolean IsHorse(System.IntPtr tesCameraState)
		{
			if (tesCameraState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("tesCameraState"); }

			return TESCameraState.GetState(tesCameraState) == TESCameraStates.HorseCameraState;
		}
	}
}
