using static NetScriptFramework._IntPtrExtensions;



namespace Eggstensions.SkyrimSE
{
	static public class NiBound
	{
		/// <param name="niBound">NiBound</param>
		/// <returns>(Units, Units, Units)</returns>
		static public (System.Single x, System.Single y, System.Single z) GetCenter(System.IntPtr niBound)
		{
			if (niBound == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(niBound)); }

			return
			(
				NiBound.GetCenterX(niBound),
				NiBound.GetCenterY(niBound),
				NiBound.GetCenterZ(niBound)
			);
		}

		/// <param name="niBound">NiBound</param>
		/// <returns>Units</returns>
		static public System.Single GetCenterX(System.IntPtr niBound)
		{
			if (niBound == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(niBound)); }

			return NetScriptFramework.Memory.ReadFloat(niBound);
		}

		/// <param name="niBound">NiBound</param>
		/// <returns>Units</returns>
		static public System.Single GetCenterY(System.IntPtr niBound)
		{
			if (niBound == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(niBound)); }

			return NetScriptFramework.Memory.ReadFloat(niBound + 0x4);
		}

		/// <param name="niBound">NiBound</param>
		/// <returns>Units</returns>
		static public System.Single GetCenterZ(System.IntPtr niBound)
		{
			if (niBound == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(niBound)); }

			return NetScriptFramework.Memory.ReadFloat(niBound + 0x8);
		}

		/// <param name="niBound">NiBound</param>
		/// <returns>Units</returns>
		static public System.Single GetRadius(System.IntPtr niBound)
		{
			if (niBound == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(niBound)); }

			return NetScriptFramework.Memory.ReadFloat(niBound + 0xC);
		}

		static public System.Boolean IsInFieldOfView(System.IntPtr niBound, System.IntPtr niCamera)
		{
			if (niBound == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(niBound)); }
			if (niCamera == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(niCamera)); }

			return NetScriptFramework.Memory.InvokeCdecl(VIDS.NiBound.IsInFieldOfView, niBound, niCamera).ToBool();
		}
	}
}
