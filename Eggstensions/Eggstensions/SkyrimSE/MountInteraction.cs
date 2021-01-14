namespace Eggstensions.SkyrimSE
{
	public class MountInteraction : TemporaryObject
	{
		public MountInteraction(System.IntPtr mountInteraction)
		{
			Address = mountInteraction;
		}

		override protected void Free()
		{
			if (Address != System.IntPtr.Zero)
			{
				MountInteraction.DecrementReferenceCount(Address);
			}
		}



		public System.IntPtr Address { get; }



		static public System.Int32 DecrementReferenceCount(System.IntPtr mountInteraction)
		{
			if (mountInteraction == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(mountInteraction)); }

			var referenceCount = BSIntrusiveRefCounted.DecrementReferenceCount(MountInteraction.GetIntrusiveRefCounted(mountInteraction));

			if (referenceCount == 0)
			{
				MountInteraction.Destructor(mountInteraction);
			}

			return referenceCount;
		}

		/// <param name="mountInteraction">MountInteraction</param>
		static public void Destructor(System.IntPtr mountInteraction)
		{
			if (mountInteraction == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(mountInteraction)); }

			VirtualObject.InvokeVTableThisCall(mountInteraction, 0x0);
		}

		/// <param name="mountInteraction">MountInteraction</param>
		/// <returns>BSIntrusiveRefCounted</returns>
		static public System.IntPtr GetIntrusiveRefCounted(System.IntPtr mountInteraction)
		{
			if (mountInteraction == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(mountInteraction)); }

			return mountInteraction + 0x8;
		}

		/// <param name="mountInteraction">MountInteraction</param>
		static public BSPointerHandle.ExistingReferenceFromHandle GetMount(System.IntPtr mountInteraction)
		{
			if (mountInteraction == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(mountInteraction)); }

			using (var mountAllocation = NetScriptFramework.Memory.Allocate(0x8))
			{
				mountAllocation.Zero();

				NetScriptFramework.Memory.InvokeCdecl(VIDS.MountInteraction.GetMount, mountInteraction, mountAllocation.Address);
				
				return new BSPointerHandle.ExistingReferenceFromHandle(NetScriptFramework.Memory.ReadPointer(mountAllocation.Address));
			}
		}

		/// <param name="mountInteraction">MountInteraction</param>
		static public BSPointerHandle.ExistingReferenceFromHandle GetRider(System.IntPtr mountInteraction)
		{
			if (mountInteraction == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(mountInteraction)); }

			using (var riderAllocation = NetScriptFramework.Memory.Allocate(0x8))
			{
				riderAllocation.Zero();

				NetScriptFramework.Memory.InvokeCdecl(VIDS.MountInteraction.GetRider, mountInteraction, riderAllocation.Address);

				return new BSPointerHandle.ExistingReferenceFromHandle(NetScriptFramework.Memory.ReadPointer(riderAllocation.Address));
			}
		}
	}
}
