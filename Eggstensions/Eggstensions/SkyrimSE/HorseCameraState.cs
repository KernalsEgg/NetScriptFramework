namespace Eggstensions.SkyrimSE
{
	static public class HorseCameraState
	{
		/// <param name="horseCameraState">HorseCameraState</param>
		static public BSPointerHandle.ReferenceFromHandle GetHorse(System.IntPtr horseCameraState)
		{
			if (horseCameraState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(horseCameraState)); }

			return new BSPointerHandle.ReferenceFromHandle(horseCameraState + 0xE8);
		}

		/// <param name="horseCameraState">HorseCameraState</param>
		static public System.UInt32 GetHorseHandle(System.IntPtr horseCameraState)
		{
			if (horseCameraState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(horseCameraState)); }

			return NetScriptFramework.Memory.ReadUInt32(horseCameraState + 0xE8);
		}

		/// <param name="horseCameraState">HorseCameraState</param>
		static public System.IntPtr GetHorseHandleAddress(System.IntPtr horseCameraState)
		{
			if (horseCameraState == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(horseCameraState)); }

			return horseCameraState + 0xE8;
		}
	}
}
