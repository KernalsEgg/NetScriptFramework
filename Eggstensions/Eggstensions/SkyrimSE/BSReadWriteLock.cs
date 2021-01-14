namespace Eggstensions.SkyrimSE
{
	public class BSReadLockGuard : TemporaryObject
	{
		/// <param name="readWriteLock">BSReadWriteLock</param>
		public BSReadLockGuard(System.IntPtr readWriteLock)
		{
			if (readWriteLock == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(readWriteLock)); }
			
			Address = readWriteLock;
			BSReadWriteLock.LockForRead(readWriteLock);
		}

		override protected void Free()
		{
			BSReadWriteLock.UnlockForRead(Address);
		}



		public System.IntPtr Address { get; }
	}

	public class BSWriteLockGuard : TemporaryObject
	{
		/// <param name="readWriteLock">BSReadWriteLock</param>
		public BSWriteLockGuard(System.IntPtr readWriteLock)
		{
			if (readWriteLock == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(readWriteLock)); }

			Address = readWriteLock;
			BSReadWriteLock.LockForWrite(readWriteLock);
		}

		override protected void Free()
		{
			BSReadWriteLock.UnlockForWrite(Address);
		}



		public System.IntPtr Address { get; }
	}



	static public class BSReadWriteLock
	{
		/// <param name="readWriteLock">BSReadWriteLock</param>
		static public void LockForRead(System.IntPtr readWriteLock)
		{
			if (readWriteLock == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(readWriteLock)); }

			NetScriptFramework.Memory.InvokeCdecl(VIDS.BSReadWriteLock.LockForRead);
		}

		/// <param name="readWriteLock">BSReadWriteLock</param>
		static public void LockForWrite(System.IntPtr readWriteLock)
		{
			if (readWriteLock == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(readWriteLock)); }

			NetScriptFramework.Memory.InvokeCdecl(VIDS.BSReadWriteLock.LockForWrite);
		}

		/// <param name="readWriteLock">BSReadWriteLock</param>
		static public void UnlockForRead(System.IntPtr readWriteLock)
		{
			if (readWriteLock == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(readWriteLock)); }

			NetScriptFramework.Memory.InvokeCdecl(VIDS.BSReadWriteLock.UnlockForRead);
		}

		/// <param name="readWriteLock">BSReadWriteLock</param>
		static public void UnlockForWrite(System.IntPtr readWriteLock)
		{
			if (readWriteLock == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(readWriteLock)); }

			NetScriptFramework.Memory.InvokeCdecl(VIDS.BSReadWriteLock.UnlockForWrite);
		}
	}
}
