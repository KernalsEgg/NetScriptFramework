namespace Eggstensions.Bethesda
{
	public class BSReadLockGuard : TemporaryObject
	{
		public System.IntPtr Address { get; }



		public BSReadLockGuard(System.IntPtr spinLock)
		{
			Address = spinLock;
			BSReadWriteLock.LockForRead(Address);
		}

		override protected void Free()
		{
			BSReadWriteLock.UnlockForRead(Address);
		}
	}

	public class BSWriteLockGuard : TemporaryObject
	{
		public System.IntPtr Address { get; }



		public BSWriteLockGuard(System.IntPtr spinLock)
		{
			Address = spinLock;
			BSReadWriteLock.LockForWrite(Address);
		}

		override protected void Free()
		{
			BSReadWriteLock.UnlockForWrite(Address);
		}
	}



	static public class BSReadWriteLock
	{
		static public void LockForRead(System.IntPtr readWriteLock)
		{
			if (readWriteLock == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("readWriteLock"); }

			NetScriptFramework.Memory.InvokeCdecl(VIDS.BSReadWriteLock.LockForRead);
		}

		static public void LockForWrite(System.IntPtr readWriteLock)
		{
			if (readWriteLock == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("readWriteLock"); }

			NetScriptFramework.Memory.InvokeCdecl(VIDS.BSReadWriteLock.LockForWrite);
		}

		static public void UnlockForRead(System.IntPtr readWriteLock)
		{
			if (readWriteLock == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("readWriteLock"); }

			NetScriptFramework.Memory.InvokeCdecl(VIDS.BSReadWriteLock.UnlockForRead);
		}

		static public void UnlockForWrite(System.IntPtr readWriteLock)
		{
			if (readWriteLock == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("readWriteLock"); }

			NetScriptFramework.Memory.InvokeCdecl(VIDS.BSReadWriteLock.UnlockForWrite);
		}
	}
}
