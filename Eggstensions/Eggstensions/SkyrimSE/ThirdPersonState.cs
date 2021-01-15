namespace Eggstensions.SkyrimSE
{
	static public class ThirdPersonState
	{
		/// <param name="thirdPersonState">ThirdPersonState</param>
		static public System.Boolean GetApplyOffsets(System.IntPtr thirdPersonState)
		{
			if (thirdPersonState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(thirdPersonState)); }

			return NetScriptFramework.Memory.ReadUInt8(thirdPersonState + 0xE1) != 0;
		}

		/// <summary>SkyrimSE.exe + 0x84F8A0 (VID49967)</summary>
		/// <param name="thirdPersonState">ThirdPersonState</param>
		static public (System.Single x, System.Single y, System.Single z) GetCurrentOffset(System.IntPtr thirdPersonState, System.Boolean zoom)
		{
			if (thirdPersonState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(thirdPersonState)); }
			// zoom

			ThirdPersonState.UpdateRotation(thirdPersonState);
			var rotation = TESCameraState.GetRotationAsMatrix33(thirdPersonState);

			var targetOffsetX = ThirdPersonState.GetTargetOffsetX(thirdPersonState);
			var targetOffsetZ = ThirdPersonState.GetTargetOffsetZ(thirdPersonState);

			if (zoom)
			{
				var targetOffsetY = ThirdPersonState.GetTargetOffsetY(thirdPersonState);

				return
				(
					rotation[0, 0] * targetOffsetX + rotation[1, 0] * targetOffsetY + rotation[2, 0] * targetOffsetZ,
					rotation[0, 1] * targetOffsetX + rotation[1, 1] * targetOffsetY + rotation[2, 1] * targetOffsetZ,
					rotation[0, 2] * targetOffsetX + rotation[1, 2] * targetOffsetY + rotation[2, 2] * targetOffsetZ
				);
			}
			else
			{
				return
				(
					rotation[0, 0] * targetOffsetX + rotation[2, 0] * targetOffsetZ,
					rotation[0, 1] * targetOffsetX + rotation[2, 1] * targetOffsetZ,
					rotation[0, 2] * targetOffsetX + rotation[2, 2] * targetOffsetZ
				);
			}
		}

		/// <param name="thirdPersonState">ThirdPersonState</param>
		static public (System.Single x, System.Single y) GetFreeRotation(System.IntPtr thirdPersonState)
		{
			if (thirdPersonState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(thirdPersonState)); }

			return
			(
				ThirdPersonState.GetFreeRotationX(thirdPersonState),
				ThirdPersonState.GetFreeRotationY(thirdPersonState)
			);
		}

		/// <param name="thirdPersonState">ThirdPersonState</param>
		static public System.Single GetFreeRotationX(System.IntPtr thirdPersonState)
		{
			if (thirdPersonState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(thirdPersonState)); }

			return NetScriptFramework.Memory.ReadFloat(thirdPersonState + 0xD4);
		}

		/// <param name="thirdPersonState">ThirdPersonState</param>
		static public System.Single GetFreeRotationY(System.IntPtr thirdPersonState)
		{
			if (thirdPersonState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(thirdPersonState)); }

			return NetScriptFramework.Memory.ReadFloat(thirdPersonState + 0xD8);
		}

		/// <param name="thirdPersonState">ThirdPersonState</param>
		static public (System.Single x, System.Single y, System.Single z) GetTargetOffsets(System.IntPtr thirdPersonState)
		{
			if (thirdPersonState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(thirdPersonState)); }

			return
			(
				ThirdPersonState.GetTargetOffsetX(thirdPersonState),
				ThirdPersonState.GetTargetOffsetY(thirdPersonState),
				ThirdPersonState.GetTargetOffsetZ(thirdPersonState)
			);
		}
		
		/// <param name="thirdPersonState">ThirdPersonState</param>
		static public System.Single GetTargetOffsetX(System.IntPtr thirdPersonState)
		{
			if (thirdPersonState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(thirdPersonState)); }

			return NetScriptFramework.Memory.ReadFloat(thirdPersonState + 0x5C);
		}

		/// <param name="thirdPersonState">ThirdPersonState</param>
		static public System.Single GetTargetOffsetY(System.IntPtr thirdPersonState)
		{
			if (thirdPersonState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(thirdPersonState)); }

			return NetScriptFramework.Memory.ReadFloat(thirdPersonState + 0x60);
		}

		/// <param name="thirdPersonState">ThirdPersonState</param>
		static public System.Single GetTargetOffsetZ(System.IntPtr thirdPersonState)
		{
			if (thirdPersonState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(thirdPersonState)); }

			return NetScriptFramework.Memory.ReadFloat(thirdPersonState + 0x64);
		}

		/// <param name="thirdPersonState">ThirdPersonState</param>
		static public void GetFreeRotations(System.IntPtr thirdPersonState, (System.Single x, System.Single y) freeRotations)
		{
			if (thirdPersonState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(thirdPersonState)); }

			ThirdPersonState.SetFreeRotationX(thirdPersonState, freeRotations.x);
			ThirdPersonState.SetFreeRotationY(thirdPersonState, freeRotations.y);
		}

		/// <param name="thirdPersonState">ThirdPersonState</param>
		static public void SetFreeRotationX(System.IntPtr thirdPersonState, System.Single freeRotationX)
		{
			if (thirdPersonState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(thirdPersonState)); }
			// freeRotationX

			NetScriptFramework.Memory.WriteFloat(thirdPersonState + 0xD4, freeRotationX);
		}

		/// <param name="thirdPersonState">ThirdPersonState</param>
		static public void SetFreeRotationY(System.IntPtr thirdPersonState, System.Single freeRotationY)
		{
			if (thirdPersonState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(thirdPersonState)); }
			// freeRotationY

			NetScriptFramework.Memory.WriteFloat(thirdPersonState + 0xD8, freeRotationY);
		}

		/// <param name="thirdPersonState">ThirdPersonState</param>
		static public void SetTargetOffsets(System.IntPtr thirdPersonState, (System.Single x, System.Single y, System.Single z) targetOffsets)
		{
			if (thirdPersonState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(thirdPersonState)); }
			// targetOffsets

			ThirdPersonState.SetTargetOffsetX(thirdPersonState, targetOffsets.x);
			ThirdPersonState.SetTargetOffsetY(thirdPersonState, targetOffsets.y);
			ThirdPersonState.SetTargetOffsetZ(thirdPersonState, targetOffsets.z);
		}

		/// <param name="thirdPersonState">ThirdPersonState</param>
		static public void SetTargetOffsetX(System.IntPtr thirdPersonState, System.Single targetOffsetX)
		{
			if (thirdPersonState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(thirdPersonState)); }
			// targetOffsetX

			NetScriptFramework.Memory.WriteFloat(thirdPersonState + 0x5C, targetOffsetX);
		}

		/// <param name="thirdPersonState">ThirdPersonState</param>
		static public void SetTargetOffsetY(System.IntPtr thirdPersonState, System.Single targetOffsetY)
		{
			if (thirdPersonState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(thirdPersonState)); }
			// targetOffsetY

			NetScriptFramework.Memory.WriteFloat(thirdPersonState + 0x60, targetOffsetY);
		}

		/// <param name="thirdPersonState">ThirdPersonState</param>
		static public void SetTargetOffsetZ(System.IntPtr thirdPersonState, System.Single targetOffsetZ)
		{
			if (thirdPersonState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(thirdPersonState)); }
			// targetOffsetZ

			NetScriptFramework.Memory.WriteFloat(thirdPersonState + 0x64, targetOffsetZ);
		}

		/// <param name="thirdPersonState">ThirdPersonState</param>
		static public void UpdateRotation(System.IntPtr thirdPersonState)
		{
			if (thirdPersonState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(thirdPersonState)); }

			VirtualObject.InvokeVTableThisCall(thirdPersonState, 0x70);
		}
	}
}
