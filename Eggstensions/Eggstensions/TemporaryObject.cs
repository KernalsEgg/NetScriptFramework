namespace Eggstensions
{
	/// <summary>NetScriptFramework.TemporaryObject</summary>
	abstract public class TemporaryObject : System.IDisposable
	{
		private System.Boolean _hasBeenDisposed = false;

		private System.Int32 _pinned = 0;



		~TemporaryObject()
		{
			Dispose(false);
		}



		public void Pin()
		{
			System.Threading.Interlocked.Increment(ref _pinned);
		}

		public void Unpin()
		{
			System.Threading.Interlocked.Decrement(ref _pinned);
		}



		public void Dispose()
		{
			Dispose(true);
			System.GC.SuppressFinalize(this);
		}

		private void Dispose(System.Boolean disposing)
		{
			// disposing

			if (!_hasBeenDisposed)
			{
				if (_pinned == 0)
				{
					Free();
				}

				_hasBeenDisposed = true;
			}
		}

		abstract protected void Free();
	}
}
