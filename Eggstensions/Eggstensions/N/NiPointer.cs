using Eggstensions.ExtensionMethods;



namespace Eggstensions
{
	// LayoutKind.Explicit does not support generic types
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Size = 0x8)]
	unsafe public struct NiPointer<T> : System.IDisposable
		where T : unmanaged, ITESObjectREFR
	{
		public NiPointer(T* reference) : this()
		{
			Reference = reference;
			Attach();
		}



		public T* Reference;



		// Member
		public void Attach()
		{
			if (Reference != null)
			{
				Reference->BSHandleRefObject()->IncrementReferenceCount();
			}
		}

		public void Dispose()
		{
			Detach();
		}

		public void Detach()
		{
			if (Reference != null)
			{
				Reference->BSHandleRefObject()->DecrementReferenceCount();
			}
		}
	}
}
