namespace Eggstensions.Bethesda
{
	static public class ThirdPersonState
	{
		/// <param name="thirdPersonState">ThirdPersonState</param>
		static public System.Boolean GetApplyOffsets(System.IntPtr thirdPersonState)
		{
			if (thirdPersonState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("thirdPersonState"); }

			return NetScriptFramework.Memory.ReadUInt8(thirdPersonState + 0xE1) != 0;
		}

		/// <summary>&lt;SkyrimSE.exe&gt; + 0x84F8A0 (VID49967)</summary>
		/// <param name="thirdPersonState">ThirdPersonState</param>
		static public (System.Single x, System.Single y, System.Single z) GetCurrentOffset(System.IntPtr thirdPersonState, System.Boolean zoom)
		{
			if (thirdPersonState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("thirdPersonState"); }
			// zoom

			ThirdPersonState.UpdateRotation(thirdPersonState);
			var quaternion = TESCameraState.GetRotation(thirdPersonState);
			var matrix = Eggstensions.Math.Library.Quaternion.QuaternionToMatrix33(new System.Single[,] { { quaternion.w, quaternion.x, quaternion.y, quaternion.z } });

			var targetOffsetX = ThirdPersonState.GetTargetOffsetX(thirdPersonState);
			var targetOffsetZ = ThirdPersonState.GetTargetOffsetZ(thirdPersonState);

			if (zoom)
			{
				var targetOffsetY = ThirdPersonState.GetTargetOffsetY(thirdPersonState);

				return
					(
						matrix[0, 0] * targetOffsetX + matrix[1, 0] * targetOffsetY + matrix[2, 0] * targetOffsetZ,
						matrix[0, 1] * targetOffsetX + matrix[1, 1] * targetOffsetY + matrix[2, 1] * targetOffsetZ,
						matrix[0, 2] * targetOffsetX + matrix[1, 2] * targetOffsetY + matrix[2, 2] * targetOffsetZ
					);
			}
			else
			{
				return
					(
						matrix[0, 0] * targetOffsetX + matrix[2, 0] * targetOffsetZ,
						matrix[0, 1] * targetOffsetX + matrix[2, 1] * targetOffsetZ,
						matrix[0, 2] * targetOffsetX + matrix[2, 2] * targetOffsetZ
					);
			}
		}
		
		/// <param name="thirdPersonState">ThirdPersonState</param>
		static public (System.Single x, System.Single y, System.Single z) GetTargetOffsets(System.IntPtr thirdPersonState)
		{
			if (thirdPersonState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("thirdPersonState"); }

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
			if (thirdPersonState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("thirdPersonState"); }

			return NetScriptFramework.Memory.ReadFloat(thirdPersonState + 0x5C);
		}

		/// <param name="thirdPersonState">ThirdPersonState</param>
		static public System.Single GetTargetOffsetY(System.IntPtr thirdPersonState)
		{
			if (thirdPersonState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("thirdPersonState"); }

			return NetScriptFramework.Memory.ReadFloat(thirdPersonState + 0x60);
		}

		/// <param name="thirdPersonState">ThirdPersonState</param>
		static public System.Single GetTargetOffsetZ(System.IntPtr thirdPersonState)
		{
			if (thirdPersonState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("thirdPersonState"); }

			return NetScriptFramework.Memory.ReadFloat(thirdPersonState + 0x64);
		}

		/// <param name="thirdPersonState">ThirdPersonState</param>
		static public void SetTargetOffsets(System.IntPtr thirdPersonState, (System.Single x, System.Single y, System.Single z) targetOffsets)
		{
			if (thirdPersonState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("thirdPersonState"); }
			// targetOffsets

			ThirdPersonState.SetTargetOffsetX(thirdPersonState, targetOffsets.x);
			ThirdPersonState.SetTargetOffsetY(thirdPersonState, targetOffsets.y);
			ThirdPersonState.SetTargetOffsetZ(thirdPersonState, targetOffsets.z);
		}

		/// <param name="thirdPersonState">ThirdPersonState</param>
		static public void SetTargetOffsetX(System.IntPtr thirdPersonState, System.Single targetOffsetX)
		{
			if (thirdPersonState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("thirdPersonState"); }
			// targetOffsetX

			NetScriptFramework.Memory.WriteFloat(thirdPersonState + 0x5C, targetOffsetX);
		}

		/// <param name="thirdPersonState">ThirdPersonState</param>
		static public void SetTargetOffsetY(System.IntPtr thirdPersonState, System.Single targetOffsetY)
		{
			if (thirdPersonState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("thirdPersonState"); }
			// targetOffsetY

			NetScriptFramework.Memory.WriteFloat(thirdPersonState + 0x60, targetOffsetY);
		}

		/// <param name="thirdPersonState">ThirdPersonState</param>
		static public void SetTargetOffsetZ(System.IntPtr thirdPersonState, System.Single targetOffsetZ)
		{
			if (thirdPersonState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("thirdPersonState"); }
			// targetOffsetZ

			NetScriptFramework.Memory.WriteFloat(thirdPersonState + 0x64, targetOffsetZ);
		}

		/// <param name="thirdPersonState">ThirdPersonState</param>
		static public void UpdateRotation(System.IntPtr thirdPersonState)
		{
			if (thirdPersonState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("thirdPersonState"); }

			VirtualObject.InvokeVTableThisCall(thirdPersonState, 0x70);
		}
	}
}
