namespace Eggstensions.Bethesda
{
	/// <summary>PROCESS_TYPE</summary>
	public enum AIProcessLevels : System.Byte
	{
		High =			0x0,
		MiddleHigh =	0x1,
		MiddleLow =		0x2,
		Low =			0x3,
		None =			0xFF
	}
	
	/// <summary>RESET_3D_FLAGS</summary>
	public enum Update3DModelFlags : System.Byte
	{
		None =			0,
		Model =			1 << 0x0,
		Skin =			1 << 0x1,
		Head =			1 << 0x2,
		Face =			1 << 0x3,
		Scale =			1 << 0x4,
		Skeleton =		1 << 0x5,
		InitDefault =	1 << 0x6,
		SkyCellSkin =	1 << 0x7
	}



	static public class AIProcess
	{
		/// <param name="process">AIProcess</param>
		static public void AddUpdate3DModelFlags(System.IntPtr process, Update3DModelFlags update3DModelFlags)
		{
			if (process == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("process"); }
			// update3DModelFlags

			if (AIProcess.HasMiddleHighProcessData(process))
			{
				AIProcess.SetUpdate3DModelFlags(process, update3DModelFlags | AIProcess.GetUpdate3DModelFlags(process));
			}
		}

		/// <param name = "process">AIProcess</param>
		/// <returns>MiddleLowProcessData, System.IntPtr.Zero</returns>
		static public System.IntPtr GetMiddleLowProcessData(System.IntPtr process)
		{
			if (process == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("process"); }

			return NetScriptFramework.Memory.ReadPointer(process);
		}

		/// <param name = "process">AIProcess</param>
		/// <returns>MiddleHighProcessData, System.IntPtr.Zero</returns>
		static public System.IntPtr GetMiddleHighProcessData(System.IntPtr process)
		{
			if (process == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("process"); }

			return NetScriptFramework.Memory.ReadPointer(process + 0x8);
		}

		/// <param name = "process">AIProcess</param>
		/// <returns>HighProcessData, System.IntPtr.Zero</returns>
		static public System.IntPtr GetHighProcessData(System.IntPtr process)
		{
			if (process == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("process"); }

			return NetScriptFramework.Memory.ReadPointer(process + 0x10);
		}

		/// <param name="process">AIProcess</param>
		static public AIProcessLevels GetProcessLevel(System.IntPtr process)
		{
			if (process == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("process"); }

			return (AIProcessLevels)(NetScriptFramework.Memory.ReadUInt8(process + 0x137));
		}

		/// <summary>&lt;SkyrimSE.exe&gt; + 0x67E430 (VID38870)</summary>
		/// <param name = "process">AIProcess</param>
		static public Update3DModelFlags GetUpdate3DModelFlags(System.IntPtr process)
		{
			if (process == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("process"); }

			if (AIProcess.HasMiddleHighProcessData(process))
			{
				return (Update3DModelFlags)NetScriptFramework.Memory.ReadUInt8(process + 0x311);
			}

			return Update3DModelFlags.None;
		}

		/// <summary>&lt;SkyrimSE.exe&gt; + 0x67E410 (VID38869)</summary>
		/// <param name = "process">AIProcess</param>
		static public System.Boolean HasUpdate3DModelFlags(System.IntPtr process, Update3DModelFlags update3DModelFlags)
		{
			if (process == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("process"); }
			// update3DModelFlags

			if (AIProcess.HasMiddleHighProcessData(process))
			{
				return (AIProcess.GetUpdate3DModelFlags(process) & update3DModelFlags) == update3DModelFlags;
			}

			return false;
		}

		/// <summary>&lt;SkyrimSE.exe&gt; + 0x67E3B0 (VID38867)</summary>
		/// <param name = "process">AIProcess</param>
		static public void SetUpdate3DModelFlags(System.IntPtr process, Update3DModelFlags update3DModelFlags)
		{
			if (process == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("process"); }
			// update3DModelFlags

			if (AIProcess.HasMiddleHighProcessData(process))
			{
				NetScriptFramework.Memory.WriteUInt8(process + 0x311, (System.Byte)update3DModelFlags);
			}
		}

		/// <param name = "process">AIProcess</param>
		static public System.Boolean HasMiddleHighProcessData(System.IntPtr process)
		{
			if (process == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("process"); }

			return AIProcess.GetHighProcessData(process) != System.IntPtr.Zero;
		}

		/// <param name = "process">AIProcess</param>
		static public void RemoveUpdate3DModelFlags(System.IntPtr process, Update3DModelFlags update3DModelFlags)
		{
			if (process == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("process"); }
			// update3DModelFlags

			if (AIProcess.HasMiddleHighProcessData(process))
			{
				AIProcess.SetUpdate3DModelFlags(process, update3DModelFlags & ~AIProcess.GetUpdate3DModelFlags(process));
			}
		}
	}
}
