namespace Eggstensions.SkyrimSE
{
	static public class TESObjectCELL
	{
		public enum States : System.Byte
		{
			Attached = 0x7
		}



		/// <param name = "cell">TESObjectCELL</param>
		static public BSSpinLockGuard GetCellLock(System.IntPtr cell)
		{
			if (cell == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(cell)); }

			return new BSSpinLockGuard(cell + 0x118);
		}

		/// <param name="cell">TESObjectCELL</param>
		/// <returns>bhkWorldM, System.IntPtr.Zero</returns>
		static public System.IntPtr GetHavokWorld(System.IntPtr cell)
		{
			if (cell == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(cell)); }

			return NetScriptFramework.Memory.InvokeCdecl(VIDS.TESObjectCELL.GetHavokWorld, cell);
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
		static public System.Collections.Generic.HashSet<System.IntPtr> GetReferences(System.IntPtr cell, TESForm.FormTypes formType)
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
		static public (System.Collections.Generic.HashSet<System.IntPtr> references1, System.Collections.Generic.HashSet<System.IntPtr> references2) GetReferences(System.IntPtr cell, TESForm.FormTypes formType1, TESForm.FormTypes formType2)
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

		/// <param name = "cell">TESObjectCELL</param>
		static public TESObjectCELL.States GetState(System.IntPtr cell)
		{
			if (cell == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(cell)); }

			return (TESObjectCELL.States)NetScriptFramework.Memory.ReadUInt8(cell + 0x44);
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
		static public System.Boolean HasState(System.IntPtr cell, TESObjectCELL.States state)
		{
			if (cell == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(cell)); }
			// state

			return TESObjectCELL.GetState(cell) == state;
		}

		/// <param name = "cell">TESObjectCELL</param>
		static public System.Boolean IsAttached(System.IntPtr cell)
		{
			if (cell == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(cell)); }

			return TESObjectCELL.HasState(cell, TESObjectCELL.States.Attached);
		}

		/// <param name="cell">TESObjectCELL</param>
		/// <param name="references">TESObjectREFR[]</param>
		static public System.Boolean IsHitAlong(System.IntPtr cell, (System.Single x, System.Single y, System.Single z) origin, (System.Single x, System.Single y, System.Single z) ray, BGSCollisionLayer.CollisionLayerTypes collisionLayerType, params System.IntPtr[] references)
		{
			if (cell == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(cell)); }
			// origin
			// ray
			// collisionLayerType
			// references

			var havokWorld = TESObjectCELL.GetHavokWorld(cell);
			if (havokWorld == System.IntPtr.Zero) { return false; }

			return bhkWorldM.IsHitAlong(havokWorld, origin, ray, collisionLayerType, references);
		}

		/// <param name="cell">TESObjectCELL</param>
		/// <param name="references">TESObjectREFR[]</param>
		static public System.Boolean IsHitBetween(System.IntPtr cell, (System.Single x, System.Single y, System.Single z) from, (System.Single x, System.Single y, System.Single z) to, BGSCollisionLayer.CollisionLayerTypes collisionLayerType, params System.IntPtr[] references)
		{
			if (cell == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(cell)); }
			// from
			// to
			// collisionLayerType
			// references

			var havokWorld = TESObjectCELL.GetHavokWorld(cell);
			if (havokWorld == System.IntPtr.Zero) { return false; }

			return bhkWorldM.IsHitBetween(havokWorld, from, to, collisionLayerType, references);
		}
	}
}
