namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x8)]
	unsafe public struct NiPointer : System.IDisposable
	{
		public NiPointer(Actor* actor) : this(&actor->TESObjectREFR)
		{
		}

		public NiPointer(Projectile* projectile) : this(&projectile->TESObjectREFR)
		{
		}

		public NiPointer(TESObjectREFR* reference) : this()
		{
			Reference = reference;
			Attach();
		}



		[System.Runtime.InteropServices.FieldOffset(0x0)] public Actor* Actor;
		[System.Runtime.InteropServices.FieldOffset(0x0)] public Projectile* Projectile;
		[System.Runtime.InteropServices.FieldOffset(0x0)] public TESObjectREFR* Reference;



		public void Attach()
		{
			if (Reference != null)
			{
				BSHandleRefObject.IncrementReferenceCount(&Reference->BSHandleRefObject);
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
				BSHandleRefObject.DecrementReferenceCount(&Reference->BSHandleRefObject);
			}
		}
	}
}
