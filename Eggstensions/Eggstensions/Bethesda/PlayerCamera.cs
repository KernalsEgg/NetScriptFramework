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
		/// <returns>Handle</returns>
		static public System.IntPtr GetCameraTarget(System.IntPtr playerCamera)
		{
			if (playerCamera == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("playerCamera"); }

			return playerCamera + 0x3C;
		}

		/// <summary>&lt;SkyrimSE.exe&gt; + 0x850260 (VID49975)</summary>
		/// <param name="playerCamera">PlayerCamera</param>
		/// <param name="thirdPersonState">ThirdPersonState</param>
		static public (System.Single x, System.Single y, System.Single z) GetOrigin(System.IntPtr playerCamera, System.IntPtr thirdPersonState)
		{
			if (playerCamera == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("playerCamera"); }
			if (thirdPersonState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("thirdPersonState"); }

			using (var cameraTarget = new TESObjectREFR.ReferenceFromHandle(PlayerCamera.GetCameraTarget(playerCamera)))
			{
				var rootNode = TESObjectREFR.GetRootNode(cameraTarget.Reference, false);

				if (rootNode != System.IntPtr.Zero)
				{
					var worldTransform = NiAVObject.GetWorldTransform(rootNode);

					return
					(
						NiTransform.GetPositionX(worldTransform),
						NiTransform.GetPositionY(worldTransform),
						ThirdPersonState.GetApplyOffsets(thirdPersonState)
							?
							NiTransform.GetPositionZ(worldTransform) + Actor.GetEyeLevel(cameraTarget.Reference)
							:
							NiTransform.GetPositionZ(worldTransform)
					);
				}
				else
				{
					return
					(
						TESObjectREFR.GetPositionX(cameraTarget.Reference),
						TESObjectREFR.GetPositionY(cameraTarget.Reference),
						ThirdPersonState.GetApplyOffsets(thirdPersonState)
							?
							TESObjectREFR.GetPositionZ(cameraTarget.Reference) + Actor.GetEyeLevel(cameraTarget.Reference)
							:
							TESObjectREFR.GetPositionZ(cameraTarget.Reference)
					);
				}
			}
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
