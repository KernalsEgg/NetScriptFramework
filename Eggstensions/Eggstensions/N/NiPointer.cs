using Eggstensions.ExtensionMethods;



namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x8)]
	unsafe public struct NiPointer : System.IDisposable
	{
		public NiPointer(TESObjectREFR* reference) : this()
		{
			Reference = reference;
			Attach();
		}



		[System.Runtime.InteropServices.FieldOffset(0x0)] public TESObjectREFR* Reference;



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
