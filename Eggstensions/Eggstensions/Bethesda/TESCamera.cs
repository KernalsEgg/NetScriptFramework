namespace Eggstensions.Bethesda
{
	static public class TESCamera
	{
		/// <param name="tesCamera">TESCamera</param>
		/// <returns>NiNode</returns>
		static public System.IntPtr GetCameraRoot(System.IntPtr tesCamera)
		{
			if (tesCamera == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("tesCamera"); }

			var cameraRoot = NiPointer.GetValue(tesCamera + 0x20);
			if (cameraRoot == System.IntPtr.Zero) { throw new Eggceptions.NullException("cameraRoot"); }

			return cameraRoot;
		}

		/// <param name="tesCamera">TESCamera</param>
		/// <returns>TESCameraState</returns>
		static public System.IntPtr GetCurrentState(System.IntPtr tesCamera)
		{
			if (tesCamera == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("tesCamera"); }

			var currentState = BSTSmartPointer.GetValue(tesCamera + 0x28);
			if (currentState == System.IntPtr.Zero) { throw new Eggceptions.NullException("currentState"); }

			return currentState;
		}
	}
}
