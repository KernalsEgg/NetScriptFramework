﻿namespace Eggstensions.SkyrimSE
{
	public enum TESCameraStates : System.UInt32
	{
		FirstPersonState =				0x0,
		AutoVanityState =				0x1,
		VATSCameraState =				0x2,
		FreeCameraState =				0x3,
		IronSightsState =				0x4,
		FurnitureCameraState =			0x5,
		PlayerCameraTransitionState =	0x6,
		TweenMenuCameraState =			0x7,
		ThirdPersonState1 =				0x8, // Furniture
		ThirdPersonState2 =				0x9, // Third-person
		HorseCameraState =				0xA,
		BleedoutCameraState =			0xB,
		DragonCameraState =				0xC
	}



	static public class TESCameraState
	{
		/// <param name="cameraState">TESCameraState</param>
		/// <returns>(Units, Units, Units)</returns>
		static public (System.Single x, System.Single y, System.Single z) GetPosition(System.IntPtr cameraState)
		{
			if (cameraState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(cameraState)); }

			using (var positionAllocation = NetScriptFramework.Memory.Allocate(0x10))
			{
				VirtualObject.InvokeVTableThisCall(cameraState, 0x28, positionAllocation.Address);

				return
				(
					NetScriptFramework.Memory.ReadFloat(positionAllocation.Address),
					NetScriptFramework.Memory.ReadFloat(positionAllocation.Address + 0x4),
					NetScriptFramework.Memory.ReadFloat(positionAllocation.Address + 0x8)
				);
			}
		}

		/// <param name="cameraState">TESCameraState</param>
		static public System.Single[,] GetRotationAsMatrix33(System.IntPtr cameraState)
		{
			if (cameraState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(cameraState)); }

			using (var rotationAllocation = NetScriptFramework.Memory.Allocate(0x10))
			{
				VirtualObject.InvokeVTableThisCall(cameraState, 0x20, rotationAllocation.Address);

				var quaternion = new System.Single[,]
				{
					{ NetScriptFramework.Memory.ReadFloat(rotationAllocation.Address), NetScriptFramework.Memory.ReadFloat(rotationAllocation.Address + 0x4), NetScriptFramework.Memory.ReadFloat(rotationAllocation.Address + 0x8), NetScriptFramework.Memory.ReadFloat(rotationAllocation.Address + 0xC) }
				};

				return Eggstensions.Math.Library.Quaternion.QuaternionToMatrix33(quaternion);
			}
		}

		/// <param name="cameraState">TESCameraState</param>
		static public (System.Single w, System.Single x, System.Single y, System.Single z) GetRotationAsQuaternion(System.IntPtr cameraState)
		{
			if (cameraState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(cameraState)); }

			using (var rotationAllocation = NetScriptFramework.Memory.Allocate(0x10))
			{
				VirtualObject.InvokeVTableThisCall(cameraState, 0x20, rotationAllocation.Address);

				return
				(
					NetScriptFramework.Memory.ReadFloat(rotationAllocation.Address),
					NetScriptFramework.Memory.ReadFloat(rotationAllocation.Address + 0x4),
					NetScriptFramework.Memory.ReadFloat(rotationAllocation.Address + 0x8),
					NetScriptFramework.Memory.ReadFloat(rotationAllocation.Address + 0xC)
				);
			}
		}

		/// <param name="cameraState">TESCameraState</param>
		static public TESCameraStates GetState(System.IntPtr cameraState)
		{
			if (cameraState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(cameraState)); }

			return (TESCameraStates)NetScriptFramework.Memory.ReadUInt32(cameraState + 0x18);
		}

		/// <param name="cameraState">TESCameraState</param>
		static public System.Boolean IsHorse(System.IntPtr cameraState)
		{
			if (cameraState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(cameraState)); }

			return TESCameraState.GetState(cameraState) == TESCameraStates.HorseCameraState;
		}
	}
}