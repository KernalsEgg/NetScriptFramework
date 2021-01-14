﻿using System.Linq;



namespace Eggstensions.SkyrimSE
{
	public enum CellStates : System.Byte
	{
		Attached = 0x7
	}



	static public class TESObjectCELL
	{
		/// <param name = "cell">TESObjectCELL</param>
		static public BSSpinLockGuard GetCellLock(System.IntPtr cell)
		{
			if (cell == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(cell)); }

			return new BSSpinLockGuard(cell + 0x118);
		}

		/// <param name = "cell">TESObjectCELL</param>
		static public CellStates GetCellState(System.IntPtr cell)
		{
			if (cell == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(cell)); }

			return (CellStates)NetScriptFramework.Memory.ReadUInt8(cell + 0x44);
		}

		/// <param name="cell">TESObjectCELL</param>
		/// <returns>bhkWorld</returns>
		static public System.IntPtr GetHavokWorld(System.IntPtr cell)
		{
			if (cell == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(cell)); }

			var havokWorld = NetScriptFramework.Memory.InvokeCdecl(VIDS.TESObjectCELL.GetHavokWorld, cell);
			if (havokWorld == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(havokWorld)); }

			return havokWorld;
		}

		/// <param name = "cell">TESObjectCELL</param>
		/// <returns>System.Collections.Generic.HashSet&lt;TESObjectREFR&gt;</returns>
		static public System.Collections.Generic.HashSet<System.IntPtr> GetReferences(System.IntPtr cell)
		{
			if (cell == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(cell)); }

			using (TESObjectCELL.GetCellLock(cell))
			{
				var references = new System.Collections.Generic.HashSet<System.IntPtr>();

				// BSTSet<NiPointer<TESObjectREFR>>
				foreach (var reference in new BSTSet(cell + 0x80))
				{
					references.Add(reference.value);
				}

				return references;
			}
		}

		/// <param name = "cell">TESObjectCELL</param>
		/// <returns>System.Collections.Generic.HashSet&lt;TESObjectREFR&gt;</returns>
		static public System.Collections.Generic.HashSet<System.IntPtr> GetReferences(System.IntPtr cell, FormTypes formType)
		{
			if (cell == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(cell)); }
			// formType

			using (TESObjectCELL.GetCellLock(cell))
			{
				var references = new System.Collections.Generic.HashSet<System.IntPtr>();

				foreach (var reference in new BSTSet(cell + 0x80))
				{
					if (TESForm.GetFormType(TESObjectREFR.GetBaseForm(reference.value)) == formType)
					{
						references.Add(reference.value);
					}
				}

				return references;
			}
		}

		/// <param name = "cell">TESObjectCELL</param>
		/// <returns>System.Collections.Generic.HashSet&lt;TESObjectREFR&gt;</returns>
		static public (System.Collections.Generic.HashSet<System.IntPtr> references1, System.Collections.Generic.HashSet<System.IntPtr> references2) GetReferences(System.IntPtr cell, FormTypes formType1, FormTypes formType2)
		{
			if (cell == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(cell)); }
			// formType1
			// formType2

			using (TESObjectCELL.GetCellLock(cell))
			{
				var references1 = new System.Collections.Generic.HashSet<System.IntPtr>();
				var references2 = new System.Collections.Generic.HashSet<System.IntPtr>();

				foreach (var reference in new BSTSet(cell + 0x80))
				{
					var formType = TESForm.GetFormType(TESObjectREFR.GetBaseForm(reference.value));

					if (formType == formType1)
					{
						references1.Add(reference.value);
					}
					else if (formType == formType2)
					{
						references2.Add(reference.value);
					}
				}

				return (references1, references2);
			}
		}

		/// <param name="cell">TESObjectCELL</param>
		/// <returns>TESWorldSpace</returns>
		static public System.IntPtr GetWorldSpace(System.IntPtr cell)
		{
			if (cell == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(cell)); }

			var worldSpace = NetScriptFramework.Memory.ReadPointer(cell + 0x120);
			if (worldSpace == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(worldSpace)); }

			return worldSpace;
		}

		/// <param name = "cell">TESObjectCELL</param>
		static public System.Boolean IsAttached(System.IntPtr cell)
		{
			if (cell == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(cell)); }

			return GetCellState(cell) == CellStates.Attached;
		}

		/// <param name="cell">TESObjectCELL</param>
		/// <param name="references">TESObjectREFR[]</param>
		static public System.Boolean IsHitAlong(System.IntPtr cell, (System.Single x, System.Single y, System.Single z) origin, (System.Single x, System.Single y, System.Single z) ray, CollisionLayers collisionLayer, params System.IntPtr[] references)
		{
			if (cell == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(cell)); }
			// origin
			// ray
			// collisionLayer
			// references

			foreach (var hit in TESObjectCELL.RaycastAlong(cell, origin, ray, collisionLayer))
			{
				var niObject = Havok.GetNiObjectFromHavokObject(hit.HavokObject);

				if (niObject != System.IntPtr.Zero)
				{
					var owner = NiAVObject.GetOwnerRecursive(niObject);

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

		/// <param name="cell">TESObjectCELL</param>
		/// <param name="references">TESObjectREFR[]</param>
		static public System.Boolean IsHitBetween(System.IntPtr cell, (System.Single x, System.Single y, System.Single z) from, (System.Single x, System.Single y, System.Single z) to, CollisionLayers collisionLayer, params System.IntPtr[] references)
		{
			if (cell == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(cell)); }
			// from
			// to
			// collisionLayer
			// references

			foreach (var hit in TESObjectCELL.RaycastBetween(cell, from, to, collisionLayer))
			{
				var niObject = Havok.GetNiObjectFromHavokObject(hit.HavokObject);

				if (niObject != System.IntPtr.Zero)
				{
					var owner = NiAVObject.GetOwnerRecursive(niObject);

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

		/// <param name="cell">TESObjectCELL</param>
		static public System.Collections.Generic.List<RaycastHit> RaycastAlong(System.IntPtr cell, (System.Single x, System.Single y, System.Single z) origin, (System.Single x, System.Single y, System.Single z) ray)
		{
			if (cell == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(cell)); }
			// origin
			// ray

			using (var argumentsAllocation = NetScriptFramework.Memory.Allocate(0x110))
			using (var allRayHitTempCollector = new hkpAllRayHitTempCollector())
			{
				argumentsAllocation.Zero();

				var havokWorld = TESObjectCELL.GetHavokWorld(cell);
				var havokWorldScale = Havok.HavokWorldScale;

				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address, havokWorldScale * origin.x);
				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address + 0x4, havokWorldScale * origin.y);
				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address + 0x8, havokWorldScale * origin.z);

				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address + 0x90, havokWorldScale * ray.x);
				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address + 0x94, havokWorldScale * ray.y);
				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address + 0x98, havokWorldScale * ray.z);

				NetScriptFramework.Memory.WritePointer(argumentsAllocation.Address + 0xA8, allRayHitTempCollector.Address);

				VirtualObject.InvokeVTableThisCall(havokWorld, 0x198, argumentsAllocation.Address); // SkyrimSE.exe + 0xDA7580 (VID76027)

				return hkpAllRayHitTempCollector.GetHits(allRayHitTempCollector.Address);
			}
		}

		/// <param name="cell">TESObjectCELL</param>
		static public System.Collections.Generic.List<RaycastHit> RaycastAlong(System.IntPtr cell, (System.Single x, System.Single y, System.Single z) origin, (System.Single x, System.Single y, System.Single z) ray, CollisionLayers collisionLayer)
		{
			if (cell == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(cell)); }
			// origin
			// ray

			using (var argumentsAllocation = NetScriptFramework.Memory.Allocate(0x110))
			using (var allRayHitTempCollector = new hkpAllRayHitTempCollector())
			{
				argumentsAllocation.Zero();

				var havokWorld = TESObjectCELL.GetHavokWorld(cell);
				var havokWorldScale = Havok.HavokWorldScale;

				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address, havokWorldScale * origin.x);
				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address + 0x4, havokWorldScale * origin.y);
				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address + 0x8, havokWorldScale * origin.z);

				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address + 0x90, havokWorldScale * ray.x);
				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address + 0x94, havokWorldScale * ray.y);
				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address + 0x98, havokWorldScale * ray.z);

				NetScriptFramework.Memory.WriteUInt32(argumentsAllocation.Address + 0x24, (0xA << 0x10) | (System.UInt32)collisionLayer);
				NetScriptFramework.Memory.WritePointer(argumentsAllocation.Address + 0xA8, allRayHitTempCollector.Address);

				VirtualObject.InvokeVTableThisCall(havokWorld, 0x198, argumentsAllocation.Address); // SkyrimSE.exe + 0xDA7580 (VID76027)

				return hkpAllRayHitTempCollector.GetHits(allRayHitTempCollector.Address);
			}
		}

		/// <param name="cell">TESObjectCELL</param>
		static public System.Collections.Generic.List<RaycastHit> RaycastBetween(System.IntPtr cell, (System.Single x, System.Single y, System.Single z) from, (System.Single x, System.Single y, System.Single z) to)
		{
			if (cell == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(cell)); }
			// from
			// to

			using (var argumentsAllocation = NetScriptFramework.Memory.Allocate(0x110))
			using (var allRayHitTempCollector = new hkpAllRayHitTempCollector())
			{
				argumentsAllocation.Zero();

				var havokWorld = TESObjectCELL.GetHavokWorld(cell);
				var havokWorldScale = Havok.HavokWorldScale;

				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address, havokWorldScale * from.x);
				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address + 0x4, havokWorldScale * from.y);
				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address + 0x8, havokWorldScale * from.z);

				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address + 0x10, havokWorldScale * to.x);
				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address + 0x14, havokWorldScale * to.y);
				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address + 0x18, havokWorldScale * to.z);

				NetScriptFramework.Memory.WritePointer(argumentsAllocation.Address + 0xA8, allRayHitTempCollector.Address);

				VirtualObject.InvokeVTableThisCall(havokWorld, 0x198, argumentsAllocation.Address); // SkyrimSE.exe + 0xDA7580 (VID76027)

				return hkpAllRayHitTempCollector.GetHits(allRayHitTempCollector.Address);
			}
		}

		/// <param name="cell">TESObjectCELL</param>
		static public System.Collections.Generic.List<RaycastHit> RaycastBetween(System.IntPtr cell, (System.Single x, System.Single y, System.Single z) from, (System.Single x, System.Single y, System.Single z) to, CollisionLayers collisionLayer)
		{
			if (cell == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(cell)); }
			// from
			// to

			using (var argumentsAllocation = NetScriptFramework.Memory.Allocate(0x110))
			using (var allRayHitTempCollector = new hkpAllRayHitTempCollector())
			{
				argumentsAllocation.Zero();

				var havokWorld = TESObjectCELL.GetHavokWorld(cell);
				var havokWorldScale = Havok.HavokWorldScale;

				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address, havokWorldScale * from.x);
				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address + 0x4, havokWorldScale * from.y);
				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address + 0x8, havokWorldScale * from.z);

				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address + 0x10, havokWorldScale * to.x);
				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address + 0x14, havokWorldScale * to.y);
				NetScriptFramework.Memory.WriteFloat(argumentsAllocation.Address + 0x18, havokWorldScale * to.z);

				NetScriptFramework.Memory.WriteUInt32(argumentsAllocation.Address + 0x24, (0xA << 0x10) | (System.UInt32)collisionLayer);
				NetScriptFramework.Memory.WritePointer(argumentsAllocation.Address + 0xA8, allRayHitTempCollector.Address);

				VirtualObject.InvokeVTableThisCall(havokWorld, 0x198, argumentsAllocation.Address); // SkyrimSE.exe + 0xDA7580 (VID76027)

				return hkpAllRayHitTempCollector.GetHits(allRayHitTempCollector.Address);
			}
		}
	}
}