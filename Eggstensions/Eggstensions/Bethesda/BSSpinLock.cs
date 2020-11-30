namespace Eggstensions.Bethesda
{
	/// <summary>NetScriptFramework.SkyrimSE.Mutex, BSAtomic</summary>
	static public class BSSpinLock
	{
		/// <summary>&lt;SkyrimSE.exe&gt; + 0x132BD0 (VID12210)</summary>
		/// <param name = "bsSpinLock">BSSpinLock</param>
		static public void Lock(System.IntPtr bsSpinLock, System.UInt32 pauseAttempts = 0)
		{
			if (bsSpinLock == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bsSpinLock"); }
			// pauseAttempts

			var functionAddress = NetScriptFramework.Main.GameInfo.GetAddressOf(12210);
			if (functionAddress == System.IntPtr.Zero) { throw new Eggceptions.NullException("functionAddress"); }

			NetScriptFramework.Memory.InvokeCdecl(functionAddress, bsSpinLock, pauseAttempts);
		}

		/// <param name="bsSpinLock">BSSpinLock</param>
		static public void Unlock(System.IntPtr bsSpinLock)
		{
			if (bsSpinLock == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bsSpinLock"); }

			var currentThread = NetScriptFramework.Memory.GetCurrentNativeThreadId();
			var lockedThread = NetScriptFramework.Memory.ReadInterlockedInt32(bsSpinLock);

			if (currentThread == lockedThread)
			{
				var lockedCount = NetScriptFramework.Memory.ReadInt32(bsSpinLock + 0x4);

				if (lockedCount == 1)
				{
					NetScriptFramework.Memory.WriteInterlockedInt32(bsSpinLock, 0);
					NetScriptFramework.Memory.WriteInterlockedInt32(bsSpinLock + 0x4, 0);
				}
				else
				{
					NetScriptFramework.Memory.InterlockedDecrement32(bsSpinLock + 0x4);
				}
			}
		}
	}
}
