using static NetScriptFramework._IntPtrExtensions;



namespace Eggstensions.Bethesda
{
	static public class TESObjectREFR
	{
		public enum RecordFlags : System.UInt32
		{
			Disabled = 1u << 11,
			Harvested = 1u << 13 // TESFlora, TESObjectTREE
		}



		/// <param name = "reference">TESObjectREFR</param>
		/// <param name = "activator">TESObjectREFR</param>
		static public System.Boolean Activate(System.IntPtr reference, System.IntPtr activator)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("reference"); }
			if (activator == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("activator"); }

			return VirtualObject.InvokeVTableThisCall(TESObjectREFR.GetBaseForm(reference), 0x1B8, reference, activator).ToBool();
		}

		/// <param name = "reference">TESObjectREFR</param>
		/// <returns>TESForm</returns>
		static public System.IntPtr GetBaseForm(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("reference"); }

			var baseForm = NetScriptFramework.Memory.ReadPointer(reference + 0x40);
			if (baseForm == System.IntPtr.Zero) { throw new Eggceptions.NullException("baseForm"); }

			return baseForm;
		}

		/// <param name = "reference">TESObjectREFR</param>
		/// <returns>BSTSmartPointer&lt;BipedAnim&gt;, System.IntPtr.Zero</returns>
		static public System.IntPtr GetBiped(System.IntPtr reference, System.Boolean firstPerson)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("reference"); }

			var bipedPointer = VirtualObject.InvokeVTableThisCall(reference, 0x3F0, firstPerson);
			if (bipedPointer == System.IntPtr.Zero) { throw new Eggceptions.NullException("bipedPointer"); }

			var biped = NetScriptFramework.Memory.ReadPointer(bipedPointer);
			if (biped == System.IntPtr.Zero) { throw new Eggceptions.NullException("biped"); }

			return biped;
		}

		/// <param name = "reference">TESObjectREFR</param>
		/// <returns>BSTSmartPointer&lt;BipedAnim&gt;, System.IntPtr.Zero</returns>
		static public System.IntPtr GetCurrentBiped(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("reference"); }

			var currentBipedPointer = VirtualObject.InvokeVTableThisCall(reference, 0x400);
			if (currentBipedPointer == System.IntPtr.Zero) { throw new Eggceptions.NullException("currentBipedPointer"); }

			var currentBiped = NetScriptFramework.Memory.ReadPointer(currentBipedPointer);
			if (currentBiped == System.IntPtr.Zero) { throw new Eggceptions.NullException("currentBiped"); }

			return currentBiped;
		}

		/// <param name="reference1">TESObjectREFR</param>
		/// <param name="reference2">TESObjectREFR</param>
		/// <returns>Units</returns>
		static public System.Single GetDistanceBetween(System.IntPtr reference1, System.IntPtr reference2)
		{
			if (reference1 == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("reference1"); }
			if (reference2 == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("reference2"); }

			(var x1, var y1, var z1) = TESObjectREFR.GetPosition(reference1);
			(var x2, var y2, var z2) = TESObjectREFR.GetPosition(reference2);

			return (System.Single)System.Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)) + ((z2 - z1) * (z2 - z1)));
		}

		/// <param name="reference">TESObjectREFR</param>
		/// <returns>FormTypes</returns>
		static public FormTypes GetFormType(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("reference"); }

			return (FormTypes)VirtualObject.InvokeVTableThisCall(reference, 0xA8).ToUInt8();
		}

		/// <param name = "reference">TESObjectREFR</param>
		/// <returns>ObjectRefHandle</returns>
		static public System.UInt32 GetHandleFromReference(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("reference"); }

			using (var allocation = NetScriptFramework.Memory.Allocate(0x10))
			{
				allocation.Zero();
				NetScriptFramework.Memory.InvokeCdecl(VIDS.TESObjectREFR.GetHandleFromReference, allocation.Address, reference);

				return NetScriptFramework.Memory.ReadUInt32(allocation.Address);
			}
		}

		/// <param name = "reference">TESObjectREFR</param>
		static public (System.Single x, System.Single y, System.Single z) GetLookAtPosition(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("reference"); }

			using (var lookAtPosition = new NiPoint3())
			{
				VirtualObject.InvokeVTableThisCall(reference, 0x2D8, lookAtPosition.Address);
				if (lookAtPosition.IsZero) { throw new Eggceptions.NullException("location"); }

				return (lookAtPosition.X, lookAtPosition.Y, lookAtPosition.Z);
			}
		}
		
		/// <param name = "reference">TESObjectREFR</param>
		/// <returns>NiNode</returns>
		static public System.IntPtr GetNiNode(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("reference"); }

			var niNode = VirtualObject.InvokeVTableThisCall(reference, 0x380);
			if (niNode == System.IntPtr.Zero) { throw new Eggceptions.NullException("niNode"); }

			return niNode;
		}

		/// <param name="reference">TESObjectREFR</param>
		static public System.IntPtr GetParentCell(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("reference"); }

			var parentCell = NetScriptFramework.Memory.ReadPointer(reference + 0x60);
			if (parentCell == System.IntPtr.Zero) { throw new Eggceptions.NullException("parentCell"); }

			return parentCell;
		}

		/// <param name="reference">TESObjectREFR</param>
		/// <returns>(Units, Units, Units)</returns>
		static public (System.Single x, System.Single y, System.Single z) GetPosition(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("reference"); }

			return
				(
					TESObjectREFR.GetPositionX(reference),
					TESObjectREFR.GetPositionY(reference),
					TESObjectREFR.GetPositionZ(reference)
				);
		}

		/// <param name="reference">TESObjectREFR</param>
		/// <returns>Units</returns>
		static public System.Single GetPositionX(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("reference"); }

			return NetScriptFramework.Memory.ReadFloat(reference + 0x54);
		}

		/// <param name="reference">TESObjectREFR</param>
		/// <returns>Units</returns>
		static public System.Single GetPositionY(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("reference"); }

			return NetScriptFramework.Memory.ReadFloat(reference + 0x58);
		}

		/// <param name="reference">TESObjectREFR</param>
		/// <returns>Units</returns>
		static public System.Single GetPositionZ(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("reference"); }

			return NetScriptFramework.Memory.ReadFloat(reference + 0x5C);
		}

		/// <param name = "handle">ObjectRefHandle</param>
		/// <returns>TESObjectREFR</returns>
		static public System.IntPtr GetReferenceFromHandle(System.UInt32 handle)
		{
			// handle

			using (var allocation = NetScriptFramework.Memory.Allocate(0x20))
			{
				allocation.Zero();
				NetScriptFramework.Memory.WriteUInt32(allocation.Address, handle);

				NetScriptFramework.Memory.InvokeCdecl(VIDS.TESObjectREFR.GetReferenceFromHandle, allocation.Address, allocation.Address + 0x10);
				var reference = NetScriptFramework.Memory.ReadPointer(allocation.Address + 0x10);
				if (reference == System.IntPtr.Zero) { throw new Eggceptions.NullException("reference"); }

				return reference;
			}
		}

		/// <param name="reference">TESObjectREFR</param>
		/// <returns>(Radians, Radians, Radians)</returns>
		static public (System.Single x, System.Single y, System.Single z) GetRotation(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("reference"); }

			return
				(
					TESObjectREFR.GetRotationX(reference),
					TESObjectREFR.GetRotationY(reference),
					TESObjectREFR.GetRotationZ(reference)
				);
		}

		/// <param name="reference">TESObjectREFR</param>
		/// <returns>Radians</returns>
		static public System.Single GetRotationX(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("reference"); }

			return NetScriptFramework.Memory.ReadFloat(reference + 0x48);
		}

		/// <param name="reference">TESObjectREFR</param>
		/// <returns>Radians</returns>
		static public System.Single GetRotationY(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("reference"); }

			return NetScriptFramework.Memory.ReadFloat(reference + 0x4C);
		}

		/// <param name="reference">TESObjectREFR</param>
		/// <returns>Radians</returns>
		static public System.Single GetRotationZ(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("reference"); }

			return NetScriptFramework.Memory.ReadFloat(reference + 0x50);
		}

		/// <param name="reference">TESObjectREFR</param>
		static public System.Boolean HasFormType(System.IntPtr reference, params FormTypes[] formTypes)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("reference"); }
			if (formTypes == null) { throw new Eggceptions.ArgumentNullException("formTypes"); }

			var formType = TESObjectREFR.GetFormType(reference);

			for (var i = 0; i < formTypes.Length; i++)
			{
				if (formTypes[i] == formType)
				{
					return true;
				}
			}

			return false;
		}

		/// <param name = "reference">TESObjectREFR</param>
		static public System.Boolean IsCrimeToActivate(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("reference"); }

			return NetScriptFramework.Memory.InvokeCdecl(VIDS.TESObjectREFR.IsCrimeToActivate, reference).ToBool();
		}

		/// <param name="reference">TESObjectREFR</param>
		static public System.Boolean IsDisabled(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("reference"); }

			return TESForm.HasFormFlags(reference, (System.UInt32)TESObjectREFR.RecordFlags.Disabled);
		}

		/// <param name="reference">TESObjectREFR</param>
		static public System.Boolean IsHarvested(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("reference"); }
			if (!TESForm.HasFormType(TESObjectREFR.GetBaseForm(reference), FormTypes.TESObjectTREE, FormTypes.TESFlora)) { throw new Eggceptions.Bethesda.ArgumentFormTypeException("reference"); }

			return TESForm.HasFormFlags(reference, (System.UInt32)TESObjectREFR.RecordFlags.Harvested);
		}

		/// <param name="cell">TESObjectCELL</param>
		static public System.Boolean IsHit(System.IntPtr reference, (System.Single x, System.Single y, System.Single z) origin, (System.Single x, System.Single y, System.Single z) ray, params CollisionLayers[] collisionLayers)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("reference"); }
			// origin
			// ray
			if (collisionLayers == null) { throw new Eggceptions.ArgumentNullException("collisionLayers"); }

			var cell = TESObjectREFR.GetParentCell(reference);
			var hits = TESObjectCELL.Raycast(cell, origin, ray);

			foreach (var hit in hits)
			{
				var havokObject = hit.HavokObject;
				var niObject = Havok.GetNiObjectFromHavokObject(havokObject);

				if (niObject != System.IntPtr.Zero)
				{
					var owner = NiAVObject.GetOwnerRecursive(niObject);

					if (owner != System.IntPtr.Zero)
					{
						if (owner == reference)
						{
							continue;
						}
					}
				}

				var collisionLayer = Havok.GetCollisionLayer(havokObject);

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

		/*
		/// <param name="reference">TESObjectREFR</param>
		static public void SetHarvested(System.IntPtr reference, System.Boolean harvested)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("reference"); }
			// harvested
			if (!TESForm.HasFormType(TESObjectREFR.GetBaseForm(reference), FormTypes.TESObjectTREE, FormTypes.TESFlora)) { throw new Eggceptions.Bethesda.ArgumentFormTypeException("reference"); }

			if (harvested)
			{
				TESForm.AddFormFlags(reference, (System.UInt32)TESObjectREFR.RecordFlags.Harvested);
			}
			else
			{
				TESForm.RemoveFormFlags(reference, (System.UInt32)TESObjectREFR.RecordFlags.Harvested);
			}

			// TaskInterface::UpdateHarvestModel(pProduceRef); // SKSE64
		}
		*/
	}
}
