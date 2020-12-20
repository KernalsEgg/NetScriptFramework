namespace Eggstensions.Bethesda
{
	public class BSReadLockGuard : TemporaryObject
	{
		public BSReadLockGuard(System.IntPtr readWriteLock)
		{
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
		public BSWriteLockGuard(System.IntPtr readWriteLock)
		{
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
