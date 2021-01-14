namespace Eggstensions.SkyrimSE
{
	static public class NiFrustum
	{
		/// <param name="niFrustum">NiFrustum</param>
		static public System.Single GetBottom(System.IntPtr niFrustum)
		{
			if (niFrustum == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(niFrustum)); }

			return NetScriptFramework.Memory.ReadFloat(niFrustum + 0xC);
		}

		/// <param name="niFrustum">NiFrustum</param>
		static public System.Single GetFar(System.IntPtr niFrustum)
		{
			if (niFrustum == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(niFrustum)); }

			return NetScriptFramework.Memory.ReadFloat(niFrustum + 0x14);
		}

		/// <param name="niFrustum">NiFrustum</param>
		static public System.Single GetLeft(System.IntPtr niFrustum)
		{
			if (niFrustum == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(niFrustum)); }

			return NetScriptFramework.Memory.ReadFloat(niFrustum);
		}

		/// <param name="niFrustum">NiFrustum</param>
		static public System.Single GetNear(System.IntPtr niFrustum)
		{
			if (niFrustum == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(niFrustum)); }

			return NetScriptFramework.Memory.ReadFloat(niFrustum + 0x10);
		}

		/// <param name="niFrustum">NiFrustum</param>
		static public System.Boolean GetOrthogonalProjection(System.IntPtr niFrustum)
		{
			if (niFrustum == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(niFrustum)); }

			return NetScriptFramework.Memory.ReadUInt8(niFrustum + 0x18) != 0;
		}

		/// <param name="niFrustum">NiFrustum</param>
		static public System.Single GetRight(System.IntPtr niFrustum)
		{
			if (niFrustum == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(niFrustum)); }

			return NetScriptFramework.Memory.ReadFloat(niFrustum + 0x4);
		}

		/// <param name="niFrustum">NiFrustum</param>
		static public System.Single GetTop(System.IntPtr niFrustum)
		{
			if (niFrustum == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(niFrustum)); }

			return NetScriptFramework.Memory.ReadFloat(niFrustum + 0x8);
		}

		/// <param name="niFrustum">NiFrustum</param>
		static public void SetBottom(System.IntPtr niFrustum, System.Single bottom)
		{
			if (niFrustum == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(niFrustum)); }
			// bottom

			NetScriptFramework.Memory.WriteFloat(niFrustum + 0xC, bottom);
		}

		/// <param name="niFrustum">NiFrustum</param>
		static public void SetFar(System.IntPtr niFrustum, System.Single far)
		{
			if (niFrustum == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(niFrustum)); }
			// far

			NetScriptFramework.Memory.WriteFloat(niFrustum + 0x14, far);
		}

		/// <param name="niFrustum">NiFrustum</param>
		static public void SetLeft(System.IntPtr niFrustum, System.Single left)
		{
			if (niFrustum == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(niFrustum)); }
			// left

			NetScriptFramework.Memory.WriteFloat(niFrustum, left);
		}

		/// <param name="niFrustum">NiFrustum</param>
		static public void SetNear(System.IntPtr niFrustum, System.Single near)
		{
			if (niFrustum == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(niFrustum)); }
			// near

			NetScriptFramework.Memory.WriteFloat(niFrustum + 0x10, near);
		}

		/// <param name="niFrustum">NiFrustum</param>
		static public void SetRight(System.IntPtr niFrustum, System.Single right)
		{
			if (niFrustum == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(niFrustum)); }
			// right

			NetScriptFramework.Memory.WriteFloat(niFrustum + 0x4, right);
		}

		/// <param name="niFrustum">NiFrustum</param>
		static public void SetTop(System.IntPtr niFrustum, System.Single top)
		{
			if (niFrustum == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(niFrustum)); }
			// top

			NetScriptFramework.Memory.WriteFloat(niFrustum + 0x8, top);
		}
	}
}
