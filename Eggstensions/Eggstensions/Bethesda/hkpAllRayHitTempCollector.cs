namespace Eggstensions.Bethesda
{
	public class RaycastHit
	{
		/// <summary>The fraction along the ray travelled at which the havok object was hit.</summary>
		public System.Single Fraction { get; }

		/// <summary>The havok object hit by the ray.</summary>
		public System.IntPtr HavokObject { get; }

		/// <summary>The normal of the rays collision with the havok object.</summary>
		public (System.Single x, System.Single y, System.Single z) Normal { get; }



		public RaycastHit(System.IntPtr havokObject, System.Single fraction, (System.Single x, System.Single y, System.Single z) normal)
		{
			HavokObject = havokObject;
			Fraction = fraction;
			Normal = normal;
		}
	}



	public class hkpAllRayHitTempCollector : TemporaryObject
	{
		private NetScriptFramework.MemoryAllocation _allocation;



		public System.IntPtr Address
		{
			get
			{
				return _allocation.Address;
			}
		}



		public hkpAllRayHitTempCollector()
		{
			_allocation = hkpAllRayHitTempCollector.Constructor();
			_allocation.Pin();
		}

		override protected void Free()
		{
			hkpAllRayHitTempCollector.Destructor(_allocation.Address);
			_allocation.Unpin();
			_allocation.Dispose();
		}



		static public NetScriptFramework.MemoryAllocation Constructor() // Instance
		{
			var allocation = NetScriptFramework.Memory.Allocate(0x320); // dtor (VTable + 0x8)
			allocation.Zero();
			NetScriptFramework.Memory.InvokeCdecl(VIDS.hkpAllRayHitTempCollector.Constructor, allocation.Address);

			return allocation;
		}

		/// <param name="collector">hkpAllRayHitTempCollector</param>
		static public void Destructor(System.IntPtr collector)
		{
			if (collector == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("collector"); }

			NetScriptFramework.Memory.InvokeCdecl(VIDS.hkpAllRayHitTempCollector.Destructor, collector);
		}

		/// <param name="collector">hkpAllRayHitTempCollector</param>
		static public System.IntPtr GetBegin(System.IntPtr collector)
		{
			if (collector == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("collector"); }

			var begin = NetScriptFramework.Memory.ReadPointer(collector + 0x10);
			if (begin == System.IntPtr.Zero) { throw new Eggceptions.NullException("begin"); }

			return begin;
		}

		/// <param name="collector">hkpAllRayHitTempCollector</param>
		static public System.UInt32 GetCount(System.IntPtr collector)
		{
			if (collector == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("collector"); }

			return NetScriptFramework.Memory.ReadUInt32(collector + 0x18);
		}

		/// <summary>hkpShapeRayCastCollectorOutput</summary>
		/// <param name="collector">hkpAllRayHitTempCollector</param>
		static public System.Collections.Generic.List<RaycastHit> GetHits(System.IntPtr collector)
		{
			if (collector == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("collector"); }

			var hits = new System.Collections.Generic.List<RaycastHit>();

			var count = hkpAllRayHitTempCollector.GetCount(collector);

			if (count > 0)
			{
				var begin = hkpAllRayHitTempCollector.GetBegin(collector);

				for (var i = 0; i < count; i++)
				{
					var hit = begin + 0x60 * i;

					var havokObject = NetScriptFramework.Memory.ReadPointer(hit + 0x50);
					if (havokObject == System.IntPtr.Zero) { throw new Eggceptions.NullException("havokObject"); }

					var fraction = NetScriptFramework.Memory.ReadFloat(hit + 0x10);
					var normal =
						(
							NetScriptFramework.Memory.ReadFloat(hit),
							NetScriptFramework.Memory.ReadFloat(hit + 0x4),
							NetScriptFramework.Memory.ReadFloat(hit + 0x8)
						);

					hits.Add(new RaycastHit(havokObject, fraction, normal));
				}
			}

			return hits;
		}
	}
}
