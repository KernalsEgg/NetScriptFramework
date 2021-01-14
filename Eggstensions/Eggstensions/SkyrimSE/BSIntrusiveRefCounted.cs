namespace Eggstensions.SkyrimSE
{
	static public class BSIntrusiveRefCounted
	{
		/// <param name="intrusiveRefCounted">BSIntrusiveRefCounted</param>
		static public System.Int32 DecrementReferenceCount(System.IntPtr intrusiveRefCounted)
		{
			if (intrusiveRefCounted == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(intrusiveRefCounted)); }

			return NetScriptFramework.Memory.InterlockedDecrement32(intrusiveRefCounted);
		}

		/// <param name="intrusiveRefCounted">BSIntrusiveRefCounted</param>
		static public System.UInt32 GetReferenceCount(System.IntPtr intrusiveRefCounted)
		{
			if (intrusiveRefCounted == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(intrusiveRefCounted)); }

			return NetScriptFramework.Memory.ReadUInt32(intrusiveRefCounted);
		}

		/// <param name="intrusiveRefCounted">BSIntrusiveRefCounted</param>
		static public System.Int32 IncrementReferenceCount(System.IntPtr intrusiveRefCounted)
		{
			if (intrusiveRefCounted == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(intrusiveRefCounted)); }

			return NetScriptFramework.Memory.InterlockedIncrement32(intrusiveRefCounted);
		}
	}
}
