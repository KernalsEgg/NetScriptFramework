namespace Eggstensions.SkyrimSE
{
	static public class AIProcess
	{
		public enum Levels : System.Byte
		{
			High =			0x0,
			MiddleHigh =	0x1,
			MiddleLow =		0x2,
			Low =			0x3,
			None =			0xFF
		}

		public enum Update3DModelFlags : System.Byte
		{
			None =			0,
			Model =			1 << 0,
			Skin =			1 << 1,
			Head =			1 << 2,
			Face =			1 << 3,
			Scale =			1 << 4,
			Skeleton =		1 << 5,
			InitDefault =	1 << 6,
			SkyCellSkin =	1 << 7
		}



		/// <param name="aiProcess">AIProcess</param>
		static public void AddUpdate3DModelFlags(System.IntPtr aiProcess, AIProcess.Update3DModelFlags update3DModelFlags)
		{
			if (aiProcess == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(aiProcess)); }
			// update3DModelFlags

			if (AIProcess.HasMiddleHighProcessData(aiProcess))
			{
				AIProcess.SetUpdate3DModelFlags(aiProcess, update3DModelFlags | AIProcess.GetUpdate3DModelFlags(aiProcess));
			}
		}

		/// <param name = "aiProcess">AIProcess</param>
		/// <returns>MiddleLowProcessData, System.IntPtr.Zero</returns>
		static public System.IntPtr GetMiddleLowProcessData(System.IntPtr aiProcess)
		{
			if (aiProcess == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(aiProcess)); }

			return NetScriptFramework.Memory.ReadPointer(aiProcess);
		}

		/// <param name = "aiProcess">AIProcess</param>
		/// <returns>MiddleHighProcessData, System.IntPtr.Zero</returns>
		static public System.IntPtr GetMiddleHighProcessData(System.IntPtr aiProcess)
		{
			if (aiProcess == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(aiProcess)); }

			return NetScriptFramework.Memory.ReadPointer(aiProcess + 0x8);
		}

		/// <param name = "aiProcess">AIProcess</param>
		/// <returns>HighProcessData, System.IntPtr.Zero</returns>
		static public System.IntPtr GetHighProcessData(System.IntPtr aiProcess)
		{
			if (aiProcess == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(aiProcess)); }

			return NetScriptFramework.Memory.ReadPointer(aiProcess + 0x10);
		}

		/// <param name = "aiProcess">AIProcess</param>
		static public BSPointerHandle.ReferenceFromHandle GetOccupiedFurniture(System.IntPtr aiProcess)
		{
			if (aiProcess == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(aiProcess)); }

			var middleHighProcessData = AIProcess.GetMiddleHighProcessData(aiProcess);

			return MiddleHighProcessData.GetOccupiedFurniture(middleHighProcessData);
		}

		/// <param name = "aiProcess">AIProcess</param>
		static public System.UInt32 GetOccupiedFurnitureHandle(System.IntPtr aiProcess)
		{
			if (aiProcess == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(aiProcess)); }

			var middleHighProcessData = AIProcess.GetMiddleHighProcessData(aiProcess);

			return MiddleHighProcessData.GetOccupiedFurnitureHandle(middleHighProcessData);
		}

		/// <param name = "aiProcess">AIProcess</param>
		static public System.IntPtr GetOccupiedFurnitureHandleAddress(System.IntPtr aiProcess)
		{
			if (aiProcess == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(aiProcess)); }

			var middleHighProcessData = AIProcess.GetMiddleHighProcessData(aiProcess);

			return MiddleHighProcessData.GetOccupiedFurnitureHandleAddress(middleHighProcessData);
		}

		/// <param name="aiProcess">AIProcess</param>
		static public AIProcess.Levels GetProcessLevel(System.IntPtr aiProcess)
		{
			if (aiProcess == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(aiProcess)); }

			return (AIProcess.Levels)(NetScriptFramework.Memory.ReadUInt8(aiProcess + 0x137));
		}

		/// <param name = "aiProcess">AIProcess</param>
		static public AIProcess.Update3DModelFlags GetUpdate3DModelFlags(System.IntPtr aiProcess)
		{
			if (aiProcess == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(aiProcess)); }

			if (AIProcess.HasMiddleHighProcessData(aiProcess))
			{
				return (AIProcess.Update3DModelFlags)NetScriptFramework.Memory.ReadUInt8(aiProcess + 0x311);
			}

			return AIProcess.Update3DModelFlags.None;
		}

		/// <param name = "aiProcess">AIProcess</param>
		static public System.Boolean HasUpdate3DModelFlags(System.IntPtr aiProcess, AIProcess.Update3DModelFlags update3DModelFlags)
		{
			if (aiProcess == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(aiProcess)); }
			// update3DModelFlags

			if (AIProcess.HasMiddleHighProcessData(aiProcess))
			{
				return (AIProcess.GetUpdate3DModelFlags(aiProcess) & update3DModelFlags) == update3DModelFlags;
			}

			return false;
		}

		/// <param name="aiProcess">AIProcess</param>
		static public System.Boolean IsInHigh(System.IntPtr aiProcess)
		{
			if (aiProcess == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(aiProcess)); }

			return AIProcess.GetProcessLevel(aiProcess) == AIProcess.Levels.High;
		}

		/// <param name = "aiProcess">AIProcess</param>
		static public void SetUpdate3DModelFlags(System.IntPtr aiProcess, AIProcess.Update3DModelFlags update3DModelFlags)
		{
			if (aiProcess == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(aiProcess)); }
			// update3DModelFlags

			if (AIProcess.HasMiddleHighProcessData(aiProcess))
			{
				NetScriptFramework.Memory.WriteUInt8(aiProcess + 0x311, (System.Byte)update3DModelFlags);
			}
		}

		/// <param name = "aiProcess">AIProcess</param>
		static public System.Boolean HasMiddleHighProcessData(System.IntPtr aiProcess)
		{
			if (aiProcess == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(aiProcess)); }

			return AIProcess.GetMiddleHighProcessData(aiProcess) != System.IntPtr.Zero;
		}

		/// <param name = "aiProcess">AIProcess</param>
		static public void RemoveUpdate3DModelFlags(System.IntPtr aiProcess, AIProcess.Update3DModelFlags update3DModelFlags)
		{
			if (aiProcess == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(aiProcess)); }
			// update3DModelFlags

			if (AIProcess.HasMiddleHighProcessData(aiProcess))
			{
				AIProcess.SetUpdate3DModelFlags(aiProcess, update3DModelFlags & ~AIProcess.GetUpdate3DModelFlags(aiProcess));
			}
		}
	}
}
