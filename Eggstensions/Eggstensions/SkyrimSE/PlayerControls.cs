namespace Eggstensions.SkyrimSE
{
	static public class PlayerControlsData
	{
		static public (System.Single x, System.Single y) GetLookInput(System.IntPtr playerControlsData)
		{
			if (playerControlsData == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(playerControlsData)); }

			return
			(
				PlayerControlsData.GetLookInputX(playerControlsData),
				PlayerControlsData.GetLookInputY(playerControlsData)
			);
		}

		/// <param name="playerControlsData">PlayerControlsData</param>
		static public System.Single GetLookInputX(System.IntPtr playerControlsData)
		{
			if (playerControlsData == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(playerControlsData)); }

			return NetScriptFramework.Memory.ReadFloat(playerControlsData + 0x8);
		}

		/// <param name="playerControlsData">PlayerControlsData</param>
		static public System.Single GetLookInputY(System.IntPtr playerControlsData)
		{
			if (playerControlsData == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(playerControlsData)); }

			return NetScriptFramework.Memory.ReadFloat(playerControlsData + 0xC);
		}
	}
	
	static public class PlayerControls
	{
		/// <summary>PlayerControls</summary>
		static public System.IntPtr Instance
		{
			get
			{
				var instance = NetScriptFramework.Memory.ReadPointer(VIDS.PlayerControls.Instance);
				if (instance == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(instance)); }

				return instance;
			}
		}



		/// <param name="playerControls">PlayerControls</param>
		/// <returns>ActivateHandler</returns>
		static public System.IntPtr GetActivateHandler(System.IntPtr playerControls)
		{
			if (playerControls == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(playerControls)); }

			var activateHandler = NetScriptFramework.Memory.ReadPointer(playerControls + 0x1A0);
			if (activateHandler == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(activateHandler)); }

			return activateHandler;
		}

		/// <param name="playerControls">PlayerControls</param>
		/// <returns>AttackBlockHandler</returns>
		static public System.IntPtr GetAttackBlockHandler(System.IntPtr playerControls)
		{
			if (playerControls == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(playerControls)); }

			var attackBlockHandler = NetScriptFramework.Memory.ReadPointer(playerControls + 0x1B8);
			if (attackBlockHandler == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(attackBlockHandler)); }

			return attackBlockHandler;
		}

		/// <param name="playerControls">PlayerControls</param>
		/// <returns>AutoMoveHandler</returns>
		static public System.IntPtr GetAutoMoveHandler(System.IntPtr playerControls)
		{
			if (playerControls == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(playerControls)); }

			var autoMoveHandler = NetScriptFramework.Memory.ReadPointer(playerControls + 0x190);
			if (autoMoveHandler == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(autoMoveHandler)); }

			return autoMoveHandler;
		}

		/// <param name="playerControls">PlayerControls</param>
		/// <returns>JumpHandler</returns>
		static public System.IntPtr GetJumpHandler(System.IntPtr playerControls)
		{
			if (playerControls == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(playerControls)); }

			var jumpHandler = NetScriptFramework.Memory.ReadPointer(playerControls + 0x1A8);
			if (jumpHandler == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(jumpHandler)); }

			return jumpHandler;
		}

		/// <param name="playerControls">PlayerControls</param>
		/// <returns>LookHandler</returns>
		static public System.IntPtr GetLookHandler(System.IntPtr playerControls)
		{
			if (playerControls == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(playerControls)); }

			var lookHandler = NetScriptFramework.Memory.ReadPointer(playerControls + 0x178);
			if (lookHandler == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(lookHandler)); }

			return lookHandler;
		}

		/// <param name="playerControls">PlayerControls</param>
		/// <returns>MovementHandler</returns>
		static public System.IntPtr GetMovementHandler(System.IntPtr playerControls)
		{
			if (playerControls == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(playerControls)); }

			var movementHandler = NetScriptFramework.Memory.ReadPointer(playerControls + 0x170);
			if (movementHandler == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(movementHandler)); }

			return movementHandler;
		}

		static public System.IntPtr GetData(System.IntPtr playerControls)
		{
			if (playerControls == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(playerControls)); }

			return playerControls + 0x24;
		}

		/// <param name="playerControls">PlayerControls</param>
		/// <returns>ReadyWeaponHandler</returns>
		static public System.IntPtr GetReadyWeaponHandler(System.IntPtr playerControls)
		{
			if (playerControls == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(playerControls)); }

			var readyWeaponHandler = NetScriptFramework.Memory.ReadPointer(playerControls + 0x188);
			if (readyWeaponHandler == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(readyWeaponHandler)); }

			return readyWeaponHandler;
		}

		/// <param name="playerControls">PlayerControls</param>
		/// <returns>RunHandler</returns>
		static public System.IntPtr GetRunHandler(System.IntPtr playerControls)
		{
			if (playerControls == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(playerControls)); }

			var runHandler = NetScriptFramework.Memory.ReadPointer(playerControls + 0x1C0);
			if (runHandler == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(runHandler)); }

			return runHandler;
		}

		/// <param name="playerControls">PlayerControls</param>
		/// <returns>ShoutHandler</returns>
		static public System.IntPtr GetShoutHandler(System.IntPtr playerControls)
		{
			if (playerControls == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(playerControls)); }

			var shoutHandler = NetScriptFramework.Memory.ReadPointer(playerControls + 0x1B0);
			if (shoutHandler == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(shoutHandler)); }

			return shoutHandler;
		}

		/// <param name="playerControls">PlayerControls</param>
		/// <returns>SneakHandler</returns>
		static public System.IntPtr GetSneakHandler(System.IntPtr playerControls)
		{
			if (playerControls == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(playerControls)); }

			var sneakHandler = NetScriptFramework.Memory.ReadPointer(playerControls + 0x1C8);
			if (sneakHandler == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(sneakHandler)); }

			return sneakHandler;
		}

		/// <param name="playerControls">PlayerControls</param>
		/// <returns>SprintHandler</returns>
		static public System.IntPtr GetSprintHandler(System.IntPtr playerControls)
		{
			if (playerControls == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(playerControls)); }

			var sprintHandler = NetScriptFramework.Memory.ReadPointer(playerControls + 0x180);
			if (sprintHandler == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(sprintHandler)); }

			return sprintHandler;
		}

		/// <param name="playerControls">PlayerControls</param>
		/// <returns>TogglePOVHandler</returns>
		static public System.IntPtr GetTogglePOVHandler(System.IntPtr playerControls)
		{
			if (playerControls == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(playerControls)); }

			var togglePOVHandler = NetScriptFramework.Memory.ReadPointer(playerControls + 0x1D0);
			if (togglePOVHandler == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(togglePOVHandler)); }

			return togglePOVHandler;
		}

		/// <param name="playerControls">PlayerControls</param>
		/// <returns>ToggleRunHandler</returns>
		static public System.IntPtr GetToggleRunHandler(System.IntPtr playerControls)
		{
			if (playerControls == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(playerControls)); }

			var toggleRunHandler = NetScriptFramework.Memory.ReadPointer(playerControls + 0x198);
			if (toggleRunHandler == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(toggleRunHandler)); }

			return toggleRunHandler;
		}
	}
}
