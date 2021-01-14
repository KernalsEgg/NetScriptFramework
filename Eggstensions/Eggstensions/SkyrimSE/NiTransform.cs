namespace Eggstensions.SkyrimSE
{
	static public class NiTransform
	{
		/// <param name="niTransform">NiTransform</param>
		/// <returns>(Units, Units, Units)</returns>
		static public (System.Single x, System.Single y, System.Single z) GetPosition(System.IntPtr niTransform)
		{
			if (niTransform == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(niTransform)); }

			return
			(
				NiTransform.GetPositionX(niTransform),
				NiTransform.GetPositionY(niTransform),
				NiTransform.GetPositionZ(niTransform)
			);
		}
		
		/// <param name="niTransform"></param>
		/// <returns>Units</returns>
		static public System.Single GetPositionX(System.IntPtr niTransform)
		{
			if (niTransform == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(niTransform)); }

			return NetScriptFramework.Memory.ReadFloat(niTransform + 0x24);
		}

		/// <param name="niTransform">NiTransform</param>
		/// <returns>Units</returns>
		static public System.Single GetPositionY(System.IntPtr niTransform)
		{
			if (niTransform == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(niTransform)); }

			return NetScriptFramework.Memory.ReadFloat(niTransform + 0x28);
		}

		/// <param name="niTransform">NiTransform</param>
		/// <returns>Units</returns>
		static public System.Single GetPositionZ(System.IntPtr niTransform)
		{
			if (niTransform == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(niTransform)); }

			return NetScriptFramework.Memory.ReadFloat(niTransform + 0x2C);
		}

		/// <param name="niTransform">NiTransform</param>
		/// <returns>Radians</returns>
		static public System.Single[,] GetRotation(System.IntPtr niTransform)
		{
			if (niTransform == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(niTransform)); }

			return new System.Single[,]
			{
				{ NetScriptFramework.Memory.ReadFloat(niTransform), NetScriptFramework.Memory.ReadFloat(niTransform + 0xC), NetScriptFramework.Memory.ReadFloat(niTransform + 0x18) },
				{ NetScriptFramework.Memory.ReadFloat(niTransform + 0x4), NetScriptFramework.Memory.ReadFloat(niTransform + 0x10), NetScriptFramework.Memory.ReadFloat(niTransform + 0x1C) },
				{ NetScriptFramework.Memory.ReadFloat(niTransform + 0x8), NetScriptFramework.Memory.ReadFloat(niTransform + 0x14), NetScriptFramework.Memory.ReadFloat(niTransform + 0x20) }
			};
		}

		/// <param name="niTransform">NiTransform</param>
		static public System.Single GetScale(System.IntPtr niTransform)
		{
			if (niTransform == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(niTransform)); }

			return NetScriptFramework.Memory.ReadFloat(niTransform + 0x30);
		}
	}
}
