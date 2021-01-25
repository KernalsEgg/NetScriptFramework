using System.Linq;



namespace Eggstensions.SkyrimSE
{
	static public class bhkWorldM
	{
		// VTable + 0x198: SkyrimSE.exe + 0xDA7580 (VID 76027)



		static bhkWorldM()
		{
			Scale =			NetScriptFramework.Memory.ReadFloat(VIDS.bhkWorldM.Scale);
			ScaleInverse =	NetScriptFramework.Memory.ReadFloat(VIDS.bhkWorldM.ScaleInverse);
		}



		static public System.Single Scale { get; }

		static public System.Single ScaleInverse { get; }



		/// <param name="havokWorld">bhkWorldM</param>
		/// <param name="references">TESObjectREFR[]</param>
		static public System.Boolean IsHitAlong(System.IntPtr havokWorld, (System.Single x, System.Single y, System.Single z) origin, (System.Single x, System.Single y, System.Single z) ray, BGSCollisionLayer.CollisionLayerTypes collisionLayerType, params System.IntPtr[] references)
		{
			if (havokWorld == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(havokWorld)); }
			// origin
			// ray
			// collisionLayerType
			// references

			foreach (var hit in bhkWorldM.RaycastAlong(havokWorld, origin, ray, collisionLayerType))
			{
				var niObject = Havok.GetNiObjectFromHavokObject(hit.HavokObject);

				if (niObject != System.IntPtr.Zero)
				{
					var owner = NiAVObject.GetOwner(niObject);

					if (owner != System.IntPtr.Zero)
					{
						if (references.Any(reference => reference == owner))
						{
							continue;
						}
					}
				}

				return true;
			}

			return false;
		}

		/// <param name="havokWorld">bhkWorldM</param>
		/// <param name="references">TESObjectREFR[]</param>
		static public System.Boolean IsHitBetween(System.IntPtr havokWorld, (System.Single x, System.Single y, System.Single z) from, (System.Single x, System.Single y, System.Single z) to, BGSCollisionLayer.CollisionLayerTypes collisionLayerType, params System.IntPtr[] references)
		{
			if (havokWorld == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(havokWorld)); }
			// from
			// to
			// collisionLayerType
			// references

			foreach (var hit in bhkWorldM.RaycastBetween(havokWorld, from, to, collisionLayerType))
			{
				var niObject = Havok.GetNiObjectFromHavokObject(hit.HavokObject);

				if (niObject != System.IntPtr.Zero)
				{
					var owner = NiAVObject.GetOwner(niObject);

					if (owner != System.IntPtr.Zero)
					{
						if (references.Any(reference => reference == owner))
						{
							continue;
						}
					}
				}

				return true;
			}

			return false;
		}

		/// <param name="havokWorld">bhkWorldM</param>
		static public System.Collections.Generic.List<RaycastHit> RaycastAlong(System.IntPtr havokWorld, (System.Single x, System.Single y, System.Single z) origin, (System.Single x, System.Single y, System.Single z) ray)
		{
			if (havokWorld == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(havokWorld)); }
			// origin
			// ray

			using (var argumentsAllocation = NetScriptFramework.Memory.Allocate(0x110))
			using (var allRayHitTempCollector = new hkpAllRayHitTempCollector())
			{
				argumentsAllocation.Zero();

				var havokWorldScale = bhkWorldM.Scale;

				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address, havokWorldScale * origin.x);
				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address + 0x4, havokWorldScale * origin.y);
				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address + 0x8, havokWorldScale * origin.z);

				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address + 0x90, havokWorldScale * ray.x);
				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address + 0x94, havokWorldScale * ray.y);
				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address + 0x98, havokWorldScale * ray.z);

				NetScriptFramework.Memory.WritePointer(argumentsAllocation.Address + 0xA8, allRayHitTempCollector.Address);

				VirtualObject.InvokeVTableThisCall(havokWorld, 0x198, argumentsAllocation.Address);

				return hkpAllRayHitTempCollector.GetHits(allRayHitTempCollector.Address);
			}
		}

		/// <param name="havokWorld">bhkWorldM</param>
		static public System.Collections.Generic.List<RaycastHit> RaycastAlong(System.IntPtr havokWorld, (System.Single x, System.Single y, System.Single z) origin, (System.Single x, System.Single y, System.Single z) ray, BGSCollisionLayer.CollisionLayerTypes collisionLayerType)
		{
			if (havokWorld == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(havokWorld)); }
			// origin
			// ray
			// collisionLayerType

			using (var argumentsAllocation = NetScriptFramework.Memory.Allocate(0x110))
			using (var allRayHitTempCollector = new hkpAllRayHitTempCollector())
			{
				argumentsAllocation.Zero();

				var havokWorldScale = bhkWorldM.Scale;

				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address, havokWorldScale * origin.x);
				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address + 0x4, havokWorldScale * origin.y);
				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address + 0x8, havokWorldScale * origin.z);

				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address + 0x90, havokWorldScale * ray.x);
				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address + 0x94, havokWorldScale * ray.y);
				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address + 0x98, havokWorldScale * ray.z);

				NetScriptFramework.Memory.WriteUInt32(argumentsAllocation.Address + 0x24, (0xA << 0x10) | (System.UInt32)collisionLayerType);
				NetScriptFramework.Memory.WritePointer(argumentsAllocation.Address + 0xA8, allRayHitTempCollector.Address);

				VirtualObject.InvokeVTableThisCall(havokWorld, 0x198, argumentsAllocation.Address);

				return hkpAllRayHitTempCollector.GetHits(allRayHitTempCollector.Address);
			}
		}

		/// <param name="havokWorld">bhkWorldM</param>
		static public System.Collections.Generic.List<RaycastHit> RaycastBetween(System.IntPtr havokWorld, (System.Single x, System.Single y, System.Single z) from, (System.Single x, System.Single y, System.Single z) to)
		{
			if (havokWorld == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(havokWorld)); }
			// from
			// to

			using (var argumentsAllocation = NetScriptFramework.Memory.Allocate(0x110))
			using (var allRayHitTempCollector = new hkpAllRayHitTempCollector())
			{
				argumentsAllocation.Zero();

				var havokWorldScale = bhkWorldM.Scale;

				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address, havokWorldScale * from.x);
				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address + 0x4, havokWorldScale * from.y);
				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address + 0x8, havokWorldScale * from.z);

				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address + 0x10, havokWorldScale * to.x);
				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address + 0x14, havokWorldScale * to.y);
				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address + 0x18, havokWorldScale * to.z);

				NetScriptFramework.Memory.WritePointer(argumentsAllocation.Address + 0xA8, allRayHitTempCollector.Address);

				VirtualObject.InvokeVTableThisCall(havokWorld, 0x198, argumentsAllocation.Address);

				return hkpAllRayHitTempCollector.GetHits(allRayHitTempCollector.Address);
			}
		}

		/// <param name="havokWorld">bhkWorldM</param>
		static public System.Collections.Generic.List<RaycastHit> RaycastBetween(System.IntPtr havokWorld, (System.Single x, System.Single y, System.Single z) from, (System.Single x, System.Single y, System.Single z) to, BGSCollisionLayer.CollisionLayerTypes collisionLayerType)
		{
			if (havokWorld == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(havokWorld)); }
			// from
			// to
			// collisionLayerType

			using (var argumentsAllocation = NetScriptFramework.Memory.Allocate(0x110))
			using (var allRayHitTempCollector = new hkpAllRayHitTempCollector())
			{
				argumentsAllocation.Zero();

				var havokWorldScale = bhkWorldM.Scale;

				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address, havokWorldScale * from.x);
				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address + 0x4, havokWorldScale * from.y);
				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address + 0x8, havokWorldScale * from.z);

				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address + 0x10, havokWorldScale * to.x);
				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address + 0x14, havokWorldScale * to.y);
				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address + 0x18, havokWorldScale * to.z);

				NetScriptFramework.Memory.WriteUInt32(argumentsAllocation.Address + 0x24, (0xA << 0x10) | (System.UInt32)collisionLayerType);
				NetScriptFramework.Memory.WritePointer(argumentsAllocation.Address + 0xA8, allRayHitTempCollector.Address);

				VirtualObject.InvokeVTableThisCall(havokWorld, 0x198, argumentsAllocation.Address);

				return hkpAllRayHitTempCollector.GetHits(allRayHitTempCollector.Address);
			}
		}
	}
}
