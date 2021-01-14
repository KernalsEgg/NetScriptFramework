namespace Eggstensions.SkyrimSE
{
	static public class HorseCameraState
	{
		static public System.Single WeaponDrawnTargetOffsetX
		{
			get
			{
				return NetScriptFramework.Memory.ReadFloat(VIDS.HorseCameraState.WeaponDrawnTargetOffsetX);
			}
			set
			{
				NetScriptFramework.Memory.WriteFloat(VIDS.HorseCameraState.WeaponDrawnTargetOffsetX, value);
			}
		}

		static public System.Single WeaponDrawnTargetOffsetY
		{
			get
			{
				return NetScriptFramework.Memory.ReadFloat(VIDS.HorseCameraState.WeaponDrawnTargetOffsetY);
			}
			set
			{
				NetScriptFramework.Memory.WriteFloat(VIDS.HorseCameraState.WeaponDrawnTargetOffsetY, value);
			}
		}

		static public System.Single WeaponDrawnTargetOffsetZ
		{
			get
			{
				return NetScriptFramework.Memory.ReadFloat(VIDS.HorseCameraState.WeaponDrawnTargetOffsetZ);
			}
			set
			{
				NetScriptFramework.Memory.WriteFloat(VIDS.HorseCameraState.WeaponDrawnTargetOffsetZ, value);
			}
		}

		static public System.Single WeaponSheathedTargetOffsetX
		{
			get
			{
				return NetScriptFramework.Memory.ReadFloat(VIDS.HorseCameraState.WeaponSheathedTargetOffsetX);
			}
			set
			{
				NetScriptFramework.Memory.WriteFloat(VIDS.HorseCameraState.WeaponSheathedTargetOffsetX, value);
			}
		}

		static public System.Single WeaponSheathedTargetOffsetY
		{
			get
			{
				return NetScriptFramework.Memory.ReadFloat(VIDS.HorseCameraState.WeaponSheathedTargetOffsetY);
			}
			set
			{
				NetScriptFramework.Memory.WriteFloat(VIDS.HorseCameraState.WeaponSheathedTargetOffsetY, value);
			}
		}

		static public System.Single WeaponSheathedTargetOffsetZ
		{
			get
			{
				return NetScriptFramework.Memory.ReadFloat(VIDS.HorseCameraState.WeaponSheathedTargetOffsetZ);
			}
			set
			{
				NetScriptFramework.Memory.WriteFloat(VIDS.HorseCameraState.WeaponSheathedTargetOffsetZ, value);
			}
		}



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
