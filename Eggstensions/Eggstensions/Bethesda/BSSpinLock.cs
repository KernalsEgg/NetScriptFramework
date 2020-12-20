namespace Eggstensions.Bethesda
{
	public class BSSpinLockGuard : TemporaryObject
	{
		public BSSpinLockGuard(System.IntPtr spinLock)
		{
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
		/// <param name = "bsSpinLock">BSSpinLock</param>
		static public void Lock(System.IntPtr bsSpinLock, System.UInt32 pauseAttempts = 0)
		{
			if (bsSpinLock == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bsSpinLock"); }
			// pauseAttempts

			NetScriptFramework.Memory.InvokeCdecl(VIDS.BSSpinLock.Lock, bsSpinLock, pauseAttempts);
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
