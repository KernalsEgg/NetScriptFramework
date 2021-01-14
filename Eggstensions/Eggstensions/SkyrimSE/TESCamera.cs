namespace Eggstensions.SkyrimSE
{
	static public class TESCamera
	{
		/// <param name="camera">TESCamera</param>
		/// <returns>NiNode</returns>
		static public System.IntPtr GetCameraRoot(System.IntPtr camera)
		{
			if (camera == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(camera)); }

			var cameraRoot = NiPointer.GetValue(camera + 0x20);
			if (cameraRoot == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(cameraRoot)); }

			return cameraRoot;
		}

		/// <param name="camera">TESCamera</param>
		/// <returns>TESCameraState</returns>
		static public System.IntPtr GetCurrentState(System.IntPtr camera)
		{
			if (camera == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(camera)); }

			var currentState = BSTSmartPointer.GetValue(camera + 0x28);
			if (currentState == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(currentState)); }

			return currentState;
		}
	}
}
