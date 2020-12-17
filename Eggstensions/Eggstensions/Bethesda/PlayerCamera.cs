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

		static public System.Single GetPositionX(System.IntPtr playerCamera)
		{
			if (playerCamera == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("playerCamera"); }

			return NetScriptFramework.Memory.ReadFloat(playerCamera + 0x144);
		}

		static public System.Single GetPositionY(System.IntPtr playerCamera)
		{
			if (playerCamera == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("playerCamera"); }

			return NetScriptFramework.Memory.ReadFloat(playerCamera + 0x148);
		}

		static public System.Single GetPositionZ(System.IntPtr playerCamera)
		{
			if (playerCamera == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("playerCamera"); }

			return NetScriptFramework.Memory.ReadFloat(playerCamera + 0x14C);
		}
	}
}
