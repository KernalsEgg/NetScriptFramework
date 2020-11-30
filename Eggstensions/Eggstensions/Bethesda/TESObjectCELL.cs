namespace Eggstensions.Bethesda
{
	public enum CellStates : System.Byte
	{
		Attached = 0x7
	}



	static public class TESObjectCELL
	{
		// 0x80: BSTSet<NiPointer<TESObjectREFR*>>



		/// <param name = "cell">TESObjectCELL</param>
		/// <returns>mutable BSSpinLock</returns>
		static public System.IntPtr GetCellLock(System.IntPtr cell)
		{
			if (cell == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("cell"); }

			return cell + 0x118;
		}

		/// <param name = "cell">TESObjectCELL</param>
		static public CellStates GetCellState(System.IntPtr cell)
		{
			if (cell == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("cell"); }

			return (CellStates)NetScriptFramework.Memory.ReadUInt8(cell + 0x44);
		}

		/// <summary>&lt;SkyrimSE.exe&gt; + 0x2654C0 (VID18536)</summary>
		/// <param name="cell">TESObjectCELL</param>
		/// <returns>bhkWorld</returns>
		static public System.IntPtr GetHavokWorld(System.IntPtr cell)
		{
			if (cell == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("cell"); }

			var functionAddress = NetScriptFramework.Main.GameInfo.GetAddressOf(18536);
			if (functionAddress == System.IntPtr.Zero) { throw new Eggceptions.NullException("functionAddress"); }

			var havokWorld = NetScriptFramework.Memory.InvokeCdecl(functionAddress, cell);
			if (havokWorld == System.IntPtr.Zero) { throw new Eggceptions.NullException("havokWorld"); }

			return havokWorld;
		}

		/// <param name = "cell">TESObjectCELL</param>
		/// <returns>System.Collections.Generic.HashSet&lt;TESObjectREFR&gt;</returns>
		static public System.Collections.Generic.HashSet<System.IntPtr> GetReferences(System.IntPtr cell)
		{
			if (cell == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("cell"); }

			var cellLock = TESObjectCELL.GetCellLock(cell);
			BSSpinLock.Lock(cellLock);

			try
			{
				var references = new System.Collections.Generic.HashSet<System.IntPtr>();

				foreach (var reference in new BSTSet(cell + 0x80))
				{
					references.Add(reference.value);
				}

				return references;
			}
			finally
			{
				BSSpinLock.Unlock(cellLock);
			}
		}

		/// <param name = "cell">TESObjectCELL</param>
		/// <returns>System.Collections.Generic.HashSet&lt;TESObjectREFR&gt;</returns>
		static public System.Collections.Generic.HashSet<System.IntPtr> GetReferences(System.IntPtr cell, FormTypes formType)
		{
			if (cell == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("cell"); }
			// formType

			var cellLock = TESObjectCELL.GetCellLock(cell);
			BSSpinLock.Lock(cellLock);

			try
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
			finally
			{
				BSSpinLock.Unlock(cellLock);
			}
		}

		/// <param name = "cell">TESObjectCELL</param>
		/// <returns>System.Collections.Generic.HashSet&lt;TESObjectREFR&gt;</returns>
		static public (System.Collections.Generic.HashSet<System.IntPtr> references1, System.Collections.Generic.HashSet<System.IntPtr> references2) GetReferences(System.IntPtr cell, FormTypes formType1, FormTypes formType2)
		{
			if (cell == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("cell"); }
			// formType1
			// formType2

			var cellLock = TESObjectCELL.GetCellLock(cell);
			BSSpinLock.Lock(cellLock);

			try
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
			finally
			{
				BSSpinLock.Unlock(cellLock);
			}
		}

		/// <param name = "cell">TESObjectCELL</param>
		static public System.Boolean IsAttached(System.IntPtr cell)
		{
			if (cell == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("cell"); }

			return GetCellState(cell) == CellStates.Attached;
		}

		/// <param name="cell">TESObjectCELL</param>
		static public System.Boolean IsHit(System.IntPtr cell, (System.Single x, System.Single y, System.Single z) origin, (System.Single x, System.Single y, System.Single z) ray, params CollisionLayers[] collisionLayers)
		{
			if (cell == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("cell"); }
			// origin
			// ray
			if (collisionLayers == null) { throw new Eggceptions.ArgumentNullException("collisionLayers"); }

			var hits = TESObjectCELL.Raycast(cell, origin, ray);

			foreach (var hit in hits)
			{
				var collisionLayer = Havok.GetCollisionLayer(hit.HavokObject);

				for (var i = 0; i < collisionLayers.Length; i++)
				{
					if (collisionLayer == collisionLayers[i])
					{
						return true;
					}
				}
			}

			return false;
		}

		/// <param name="cell">TESObjectCELL</param>
		static public System.Collections.Generic.List<RaycastHit> Raycast(System.IntPtr cell, (System.Single x, System.Single y, System.Single z) origin, (System.Single x, System.Single y, System.Single z) ray)
		{
			if (cell == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("cell"); }
			// origin
			// ray

			using (var allocation = NetScriptFramework.Memory.Allocate(0x110))
			{
				allocation.Zero();

				var havokWorldScale = Havok.HavokWorldScale;

				// hkpWorldRayCastInput
				NetScriptFramework.Memory.WriteFloat(allocation.Address, havokWorldScale * origin.x);
				NetScriptFramework.Memory.WriteFloat(allocation.Address + 0x4, havokWorldScale * origin.y);
				NetScriptFramework.Memory.WriteFloat(allocation.Address + 0x8, havokWorldScale * origin.z);

				NetScriptFramework.Memory.WriteFloat(allocation.Address + 0x90, havokWorldScale * ray.x);
				NetScriptFramework.Memory.WriteFloat(allocation.Address + 0x94, havokWorldScale * ray.y);
				NetScriptFramework.Memory.WriteFloat(allocation.Address + 0x98, havokWorldScale * ray.z);

				using (var collector = new hkpAllRayHitTempCollector())
				{
					NetScriptFramework.Memory.WritePointer(allocation.Address + 0xA8, collector.Address);

					var havokWorld = TESObjectCELL.GetHavokWorld(cell);
					VirtualObject.InvokeVTableThisCall(havokWorld, 0x198, allocation.Address); // <SkyrimSE.exe> + 0xDA7580 (VID76027)

					return hkpAllRayHitTempCollector.GetHits(collector.Address);
				}
			}
		}
	}
}
