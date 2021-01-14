namespace Eggstensions.SkyrimSE
{
	public class BSSpinLockGuard : TemporaryObject
	{
		/// <param name="bsSpinLock">BSSpinLock</param>
		public BSSpinLockGuard(System.IntPtr spinLock)
		{
			if (spinLock == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(spinLock)); }

			Address = spinLock;
			BSSpinLock.Lock(spinLock);
		}

		override protected void Free()
		{
			BSSpinLock.Unlock(Address);
		}



		public System.IntPtr Address { get; }
	}


	
	/// <summary>NetScriptFramework.SkyrimSE.Mutex, BSAtomic</summary>
	static public class BSSpinLock
	{
		/// <param name = "spinLock">BSSpinLock</param>
		static public void Lock(System.IntPtr spinLock, System.UInt32 pauseAttempts = 0)
		{
			if (spinLock == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(spinLock)); }
			// pauseAttempts

			NetScriptFramework.Memory.InvokeCdecl(VIDS.BSSpinLock.Lock, spinLock, pauseAttempts);
		}

		/// <param name="spinLock">BSSpinLock</param>
		static public void Unlock(System.IntPtr spinLock)
		{
			if (spinLock == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(spinLock)); }

			var currentThread = NetScriptFramework.Memory.GetCurrentNativeThreadId();
			var lockedThread = NetScriptFramework.Memory.ReadInterlockedInt32(spinLock);

			if (currentThread == lockedThread)
			{
				var lockedCount = NetScriptFramework.Memory.ReadInt32(spinLock + 0x4);

				if (lockedCount == 1)
				{
					NetScriptFramework.Memory.WriteInterlockedInt32(spinLock, 0);
					NetScriptFramework.Memory.WriteInterlockedInt32(spinLock + 0x4, 0);
				}
				else
				{
					NetScriptFramework.Memory.InterlockedDecrement32(spinLock + 0x4);
				}
			}
		}
	}
}
