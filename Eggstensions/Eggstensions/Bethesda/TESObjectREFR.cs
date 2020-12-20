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

		/// <param name = "reference">TESObjectREFR</param>
		/// <returns>BSExtraData, System.IntPtr.Zero</returns>
		static public System.IntPtr GetExtraData(System.IntPtr reference, ExtraDataTypes extraDataType)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("reference"); }

			return NetScriptFramework.Memory.InvokeCdecl(VIDS.ExtraDataList.GetExtraData, reference, (System.Byte)extraDataType);
		}

		/// <param name="reference">TESObjectREFR</param>
		/// <returns>ExtraDataList</returns>
		static public System.IntPtr GetExtraDataList(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("reference"); }

			return reference + 0x70;
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

		/// <summary>&lt;SkyrimSE.exe&gt; + 0x28E8D0 (VID19283)</summary>
		/// <param name = "reference">TESObjectREFR</param>
		static public (System.Single x, System.Single y, System.Single z) GetLookAtPosition(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("reference"); }

			using (var lookAtPosition = new NiPoint3())
			{
				VirtualObject.InvokeVTableThisCall(reference, 0x2D8, lookAtPosition.Address);

				return (lookAtPosition.X, lookAtPosition.Y, lookAtPosition.Z);
			}
		}

		/// <summary>&lt;SkyrimSE.exe&gt; + 0x2948D0 (VID19328)</summary>
		/// <param name = "reference">TESObjectREFR</param>
		static public (System.Single x, System.Single y, System.Single z) GetMaximumBounds(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("reference"); }

			using (var maximumBounds = new NiPoint3())
			{
				VirtualObject.InvokeVTableThisCall(reference, 0x3A0, maximumBounds.Address);

				return (maximumBounds.X, maximumBounds.Y, maximumBounds.Z);
			}
		}

		/// <summary>&lt;SkyrimSE.exe&gt; + 0x2947D0 (VID19327)</summary>
		/// <param name = "reference">TESObjectREFR</param>
		static public (System.Single x, System.Single y, System.Single z) GetMinimumBounds(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("reference"); }

			using (var minimumBounds = new NiPoint3())
			{
				VirtualObject.InvokeVTableThisCall(reference, 0x398, minimumBounds.Address);

				return (minimumBounds.X, minimumBounds.Y, minimumBounds.Z);
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

		/// <summary>&lt;SkyrimSE.exe&gt; + 0x994540 (VID55660)</summary>
		/// <param name = "reference">TESObjectREFR</param>
		static public System.Boolean IsActivationBlocked(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("reference"); }

			var extraData = TESObjectREFR.GetExtraData(reference, ExtraDataTypes.Flags);
			
			return extraData != System.IntPtr.Zero && ExtraFlags.IsActivationBlocked(extraData);
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

			return TESForm.HasFormFlags(reference, (System.UInt32)TESObjectREFR.RecordFlags.Harvested);
		}

		/// <param name="reference">TESObjectREFR</param>
		static public System.Boolean IsHit(System.IntPtr reference, (System.Single x, System.Single y, System.Single z) origin, (System.Single x, System.Single y, System.Single z) ray, CollisionLayers collisionLayer)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("reference"); }
			// origin
			// ray
			// collisionLayer

			var cell = TESObjectREFR.GetParentCell(reference);

			foreach (var hit in TESObjectCELL.RaycastAlong(cell, origin, ray, collisionLayer))
			{
				var niObject = Havok.GetNiObjectFromHavokObject(hit.HavokObject);

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

				return true;
			}

			return false;
		}

		/// <param name="reference">TESObjectREFR</param>
		/// <param name="target">TESObjectREFR</param>
		static public System.Boolean IsHit(System.IntPtr reference, System.IntPtr target, (System.Single x, System.Single y, System.Single z) from, (System.Single x, System.Single y, System.Single z) to, CollisionLayers collisionLayer)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("reference"); }
			if (target == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("target"); }
			// from
			// to
			// collisionLayer

			var cell = TESObjectREFR.GetParentCell(reference);

			foreach (var hit in TESObjectCELL.RaycastBetween(cell, from, to, collisionLayer))
			{
				var niObject = Havok.GetNiObjectFromHavokObject(hit.HavokObject);

				if (niObject != System.IntPtr.Zero)
				{
					var owner = NiAVObject.GetOwnerRecursive(niObject);

					if (owner != System.IntPtr.Zero)
					{
						if (owner == reference || owner == target)
						{
							continue;
						}
					}
				}

				return true;
			}

			return false;
		}

		/// <param name="reference">TESObjectREFR</param>
		static public System.Boolean IsOccluded(System.IntPtr reference, System.IntPtr target, (System.Single x, System.Single y, System.Single z) origin, CollisionLayers collisionLayer)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("reference"); }
			if (target == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("target"); }
			// origin
			// collisionLayer

			var targetPosition = TESObjectREFR.GetPosition(target);
			var targetMinimumBounds = TESObjectREFR.GetMinimumBounds(target);
			var targetMaximumBounds = TESObjectREFR.GetMaximumBounds(target);

			foreach (var fraction in GetFractions())
			{
				if (!TESObjectREFR.IsHit(reference, target, origin, (targetPosition.x, targetPosition.y, targetPosition.z + fraction * (targetMinimumBounds.z + targetMaximumBounds.z)), collisionLayer))
				{
					return false;
				}
			}

			return true;



			System.Collections.Generic.IEnumerable<System.Single> GetFractions()
			{
				yield return NetScriptFramework.Memory.ReadFloat(VIDS.TESObjectREFR.GetLineOfSightFraction1);
				yield return NetScriptFramework.Memory.ReadFloat(VIDS.TESObjectREFR.GetLineOfSightFraction2);
				yield return NetScriptFramework.Memory.ReadFloat(VIDS.TESObjectREFR.GetLineOfSightFraction3);
			}
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
