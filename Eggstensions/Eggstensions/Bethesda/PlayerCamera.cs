namespace Eggstensions.Bethesda
{
	static public class PlayerCamera
	{
		/// <returns>PlayerCamera</returns>
		static public System.IntPtr Instance
		{
			get
			{
				var instance = NetScriptFramework.Memory.ReadPointer(VIDS.PlayerCamera.Instance);
				if (instance == System.IntPtr.Zero) { throw new Eggceptions.NullException("instance"); }

				return instance;
			}
		}



		/// <param name="playerCamera">PlayerCamera</param>
		static public TESObjectREFR.ReferenceFromHandle GetCameraTarget(System.IntPtr playerCamera)
		{
			if (playerCamera == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("playerCamera"); }

			return new TESObjectREFR.ReferenceFromHandle(playerCamera + 0x3C);
		}

		/// <summary>&lt;SkyrimSE.exe&gt; + 0x850260 (VID49975)</summary>
		/// <param name="playerCamera">PlayerCamera</param>
		/// <param name="thirdPersonState">ThirdPersonState</param>
		static public (System.Single x, System.Single y, System.Single z) GetOrigin(System.IntPtr playerCamera, System.IntPtr thirdPersonState)
		{
			if (playerCamera == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("playerCamera"); }
			if (thirdPersonState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("thirdPersonState"); }

			(System.Single x, System.Single y, System.Single z) origin;

			using (var cameraTarget = PlayerCamera.GetCameraTarget(playerCamera))
			{
				var rootNode = TESObjectREFR.GetRootNode(cameraTarget.Reference, false);

				if (rootNode != System.IntPtr.Zero)
				{
					var worldTransform = NiAVObject.GetWorldTransform(rootNode);

					origin =
					(
						NiTransform.GetPositionX(worldTransform),
						NiTransform.GetPositionY(worldTransform),
						NiTransform.GetPositionZ(worldTransform)
					);
				}
				else
				{
					origin =
					(
						TESObjectREFR.GetPositionX(cameraTarget.Reference),
						TESObjectREFR.GetPositionY(cameraTarget.Reference),
						TESObjectREFR.GetPositionZ(cameraTarget.Reference)
					);
				}

				if (ThirdPersonState.GetApplyOffsets(thirdPersonState))
				{
					origin.z += Actor.GetEyeLevel(cameraTarget.Reference);
				}
			}

			return origin;
		}

		/// <param name="playerCamera">PlayerCamera</param>
		/// <returns>(Units, Units, Units)</returns>
		static public (System.Single x, System.Single y, System.Single z) GetPosition(System.IntPtr playerCamera)
		{
			if (playerCamera == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("playerCamera"); }

			return
			(
				PlayerCamera.GetPositionX(playerCamera),
				PlayerCamera.GetPositionY(playerCamera),
				PlayerCamera.GetPositionZ(playerCamera)
			);
		}

		/// <param name="playerCamera">PlayerCamera</param>
		/// <returns>Units</returns>
		static public System.Single GetPositionX(System.IntPtr playerCamera)
		{
			if (playerCamera == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("playerCamera"); }

			return NetScriptFramework.Memory.ReadFloat(playerCamera + 0x144);
		}

		/// <param name="playerCamera">PlayerCamera</param>
		/// <returns>Units</returns>
		static public System.Single GetPositionY(System.IntPtr playerCamera)
		{
			if (playerCamera == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("playerCamera"); }

			return NetScriptFramework.Memory.ReadFloat(playerCamera + 0x148);
		}

		/// <param name="playerCamera">PlayerCamera</param>
		/// <returns>Units</returns>
		static public System.Single GetPositionZ(System.IntPtr playerCamera)
		{
			if (playerCamera == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("playerCamera"); }

			return NetScriptFramework.Memory.ReadFloat(playerCamera + 0x14C);
		}

		static public System.Boolean IsHorse(System.IntPtr playerCamera)
		{
			if (playerCamera == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("playerCamera"); }

			return TESCameraState.GetState(TESCamera.GetCurrentState(playerCamera)) == TESCameraStates.HorseCameraState;
		}
	}
}
