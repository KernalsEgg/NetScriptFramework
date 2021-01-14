using static NetScriptFramework._IntPtrExtensions;



namespace Eggstensions.SkyrimSE
{
	static public class TESObjectREFR
	{
		public enum RecordFlags : System.UInt32
		{
			Disabled =	1u << 11,
			Harvested =	1u << 13 // TESFlora, TESObjectTREE
		}



		/// <param name="reference">TESObjectREFR</param>
		/// <param name="activator">TESObjectREFR</param>
		static public System.Boolean Activate(System.IntPtr reference, System.IntPtr activator, System.Boolean defaultProcessingOnly = false)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(reference)); }
			if (activator == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(activator)); }

			return NetScriptFramework.Memory.InvokeCdecl(VIDS.TESObjectREFR.Activate, reference, activator, 0, 0, 1, defaultProcessingOnly ? 1 : 0).ToBool();
		}

		/// <param name = "reference">TESObjectREFR</param>
		/// <returns>TESForm</returns>
		static public System.IntPtr GetBaseForm(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(reference)); }

			var baseForm = NetScriptFramework.Memory.ReadPointer(reference + 0x40);
			if (baseForm == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(baseForm)); }

			return baseForm;
		}

		/// <param name = "reference">TESObjectREFR</param>
		/// <returns>BSTSmartPointer&lt;BipedAnim&gt;, System.IntPtr.Zero</returns>
		static public System.IntPtr GetBiped(System.IntPtr reference, System.Boolean firstPerson)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(reference)); }

			var bipedPointer = VirtualObject.InvokeVTableThisCall(reference, 0x3F0, firstPerson);
			if (bipedPointer == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(bipedPointer)); }

			var biped = NetScriptFramework.Memory.ReadPointer(bipedPointer);
			if (biped == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(biped)); }

			return biped;
		}

		/// <param name = "reference">TESObjectREFR</param>
		/// <returns>BSTSmartPointer&lt;BipedAnim&gt;, System.IntPtr.Zero</returns>
		static public System.IntPtr GetCurrentBiped(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(reference)); }

			var currentBipedPointer = VirtualObject.InvokeVTableThisCall(reference, 0x400);
			if (currentBipedPointer == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(currentBipedPointer)); }

			var currentBiped = NetScriptFramework.Memory.ReadPointer(currentBipedPointer);
			if (currentBiped == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(currentBiped)); }

			return currentBiped;
		}

		/// <param name="reference">TESObjectREFR</param>
		/// <param name="target">TESObjectREFR</param>
		/// <returns>Units</returns>
		static public System.Single GetDistanceBetween(System.IntPtr reference, System.IntPtr target)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(reference)); }
			if (target == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(target)); }

			(var referenceX, var referenceY, var referenceZ) = TESObjectREFR.GetPosition(reference);
			(var targetX, var targetY, var targetZ) = TESObjectREFR.GetPosition(target);

			return (System.Single)System.Math.Sqrt(((targetX - referenceX) * (targetX - referenceX)) + ((targetY - referenceY) * (targetY - referenceY)) + ((targetZ - referenceZ) * (targetZ - referenceZ)));
		}

		/// <param name = "reference">TESObjectREFR</param>
		/// <returns>BSExtraData, System.IntPtr.Zero</returns>
		static public System.IntPtr GetExtraData(System.IntPtr reference, ExtraDataTypes extraDataType)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(reference)); }

			return NetScriptFramework.Memory.InvokeCdecl(VIDS.ExtraDataList.GetExtraData, reference, (System.Byte)extraDataType);
		}

		/// <param name="reference">TESObjectREFR</param>
		/// <returns>ExtraDataList</returns>
		static public System.IntPtr GetExtraDataList(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(reference)); }

			return reference + 0x70;
		}

		/// <param name="reference">TESObjectREFR</param>
		/// <returns>FormTypes</returns>
		static public FormTypes GetFormType(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(reference)); }

			return (FormTypes)VirtualObject.InvokeVTableThisCall(reference, 0xA8).ToUInt8();
		}

		/// <param name="reference">TESObjectREFR</param>
		/// <returns>BSHandleRefObject</returns>
		static public System.IntPtr GetHandleRefObject(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(reference)); }

			return reference + 0x20;
		}

		/// <summary>SkyrimSE.exe + 0x28E8D0 (VID19283)</summary>
		/// <param name = "reference">TESObjectREFR</param>
		static public (System.Single x, System.Single y, System.Single z) GetLookAtPosition(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(reference)); }

			using (var lookAtPositionAllocation = NetScriptFramework.Memory.Allocate(0x10))
			{
				VirtualObject.InvokeVTableThisCall(reference, 0x2D8, lookAtPositionAllocation.Address);

				return
				(
					NetScriptFramework.Memory.ReadFloat(lookAtPositionAllocation.Address),
					NetScriptFramework.Memory.ReadFloat(lookAtPositionAllocation.Address + 0x4),
					NetScriptFramework.Memory.ReadFloat(lookAtPositionAllocation.Address + 0x8)
				);
			}
		}

		/// <summary>SkyrimSE.exe + 0x2948D0 (VID19328)</summary>
		/// <param name = "reference">TESObjectREFR</param>
		static public (System.Single x, System.Single y, System.Single z) GetMaximumBounds(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(reference)); }

			using (var maximumBoundsAllocation = NetScriptFramework.Memory.Allocate(0x10))
			{
				VirtualObject.InvokeVTableThisCall(reference, 0x3A0, maximumBoundsAllocation.Address);

				return
				(
					NetScriptFramework.Memory.ReadFloat(maximumBoundsAllocation.Address),
					NetScriptFramework.Memory.ReadFloat(maximumBoundsAllocation.Address + 0x4),
					NetScriptFramework.Memory.ReadFloat(maximumBoundsAllocation.Address + 0x8)
				);
			}
		}

		/// <summary>SkyrimSE.exe + 0x2947D0 (VID19327)</summary>
		/// <param name = "reference">TESObjectREFR</param>
		static public (System.Single x, System.Single y, System.Single z) GetMinimumBounds(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(reference)); }

			using (var minimumBoundsAllocation = NetScriptFramework.Memory.Allocate(0x10))
			{
				VirtualObject.InvokeVTableThisCall(reference, 0x398, minimumBoundsAllocation.Address);

				return
				(
					NetScriptFramework.Memory.ReadFloat(minimumBoundsAllocation.Address),
					NetScriptFramework.Memory.ReadFloat(minimumBoundsAllocation.Address + 0x4),
					NetScriptFramework.Memory.ReadFloat(minimumBoundsAllocation.Address + 0x8)
				);
			}
		}

		/// <param name="reference">TESObjectREFR</param>
		static public System.IntPtr GetParentCell(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(reference)); }

			var parentCell = NetScriptFramework.Memory.ReadPointer(reference + 0x60);
			if (parentCell == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(parentCell)); }

			return parentCell;
		}

		/// <param name="reference">TESObjectREFR</param>
		/// <returns>(Units, Units, Units)</returns>
		static public (System.Single x, System.Single y, System.Single z) GetPosition(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(reference)); }

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
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(reference)); }

			return NetScriptFramework.Memory.ReadFloat(reference + 0x54);
		}

		/// <param name="reference">TESObjectREFR</param>
		/// <returns>Units</returns>
		static public System.Single GetPositionY(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(reference)); }

			return NetScriptFramework.Memory.ReadFloat(reference + 0x58);
		}

		/// <param name="reference">TESObjectREFR</param>
		/// <returns>Units</returns>
		static public System.Single GetPositionZ(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(reference)); }

			return NetScriptFramework.Memory.ReadFloat(reference + 0x5C);
		}

		/// <param name = "reference">TESObjectREFR</param>
		/// <returns>NiNode, System.IntPtr.Zero</returns>
		static public System.IntPtr GetRootNode(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(reference)); }

			return VirtualObject.InvokeVTableThisCall(reference, 0x380);
		}

		/// <param name = "reference">TESObjectREFR</param>
		/// <returns>NiNode, System.IntPtr.Zero</returns>
		static public System.IntPtr GetRootNode(System.IntPtr reference, System.Boolean firstPerson)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(reference)); }

			return VirtualObject.InvokeVTableThisCall(reference, 0x378, firstPerson);
		}

		/// <param name="reference">TESObjectREFR</param>
		/// <returns>(Radians, Radians, Radians)</returns>
		static public (System.Single x, System.Single y, System.Single z) GetRotation(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(reference)); }

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
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(reference)); }

			return NetScriptFramework.Memory.ReadFloat(reference + 0x48);
		}

		/// <param name="reference">TESObjectREFR</param>
		/// <returns>Radians</returns>
		static public System.Single GetRotationY(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(reference)); }

			return NetScriptFramework.Memory.ReadFloat(reference + 0x4C);
		}

		/// <param name="reference">TESObjectREFR</param>
		/// <returns>Radians</returns>
		static public System.Single GetRotationZ(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(reference)); }

			return NetScriptFramework.Memory.ReadFloat(reference + 0x50);
		}

		/// <summary>SkyrimSE.exe + 0x994540 (VID55660)</summary>
		/// <param name = "reference">TESObjectREFR</param>
		static public System.Boolean IsActivationBlocked(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(reference)); }

			var extraData = TESObjectREFR.GetExtraData(reference, ExtraDataTypes.Flags);
			
			return extraData != System.IntPtr.Zero && ExtraFlags.IsActivationBlocked(extraData);
		}

		/// <param name = "reference">TESObjectREFR</param>
		static public System.Boolean IsActor(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(reference)); }

			return TESForm.HasFormType(reference, FormTypes.Character);
		}
		
		/// <param name = "reference">TESObjectREFR</param>
		static public System.Boolean IsCrimeToActivate(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(reference)); }

			return NetScriptFramework.Memory.InvokeCdecl(VIDS.TESObjectREFR.IsCrimeToActivate, reference).ToBool();
		}

		/// <param name = "reference">TESObjectREFR</param>
		static public System.Boolean IsDead(System.IntPtr reference, System.Boolean notEssential)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(reference)); }

			return VirtualObject.InvokeVTableThisCall(reference, 0x4C8, notEssential).ToBool();
		}

		/// <param name="reference">TESObjectREFR</param>
		static public System.Boolean IsDisabled(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(reference)); }

			return TESForm.HasFormFlags(reference, (System.UInt32)TESObjectREFR.RecordFlags.Disabled);
		}

		/// <param name="reference">TESObjectREFR</param>
		static public System.Boolean IsHarvested(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(reference)); }

			return TESForm.HasFormFlags(reference, (System.UInt32)TESObjectREFR.RecordFlags.Harvested);
		}

		/// <param name="reference">TESObjectREFR</param>
		static public System.Boolean IsHitAlong(System.IntPtr reference, (System.Single x, System.Single y, System.Single z) origin, (System.Single x, System.Single y, System.Single z) ray, CollisionLayers collisionLayer)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(reference)); }
			// origin
			// ray
			// collisionLayer

			var cell = TESObjectREFR.GetParentCell(reference);

			return TESObjectCELL.IsHitAlong(cell, origin, ray, collisionLayer, reference);
		}

		/// <param name="reference">TESObjectREFR</param>
		/// <param name="target">TESObjectREFR</param>
		static public System.Boolean IsHitBetween(System.IntPtr reference, System.IntPtr target, (System.Single x, System.Single y, System.Single z) from, (System.Single x, System.Single y, System.Single z) to, CollisionLayers collisionLayer)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(reference)); }
			if (target == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(target)); }
			// from
			// to
			// collisionLayer

			var cell = TESObjectREFR.GetParentCell(reference);

			return TESObjectCELL.IsHitBetween(cell, from, to, collisionLayer, reference, target);
		}

		/*
		/// <param name="reference">TESObjectREFR</param>
		static public void SetHarvested(System.IntPtr reference, System.Boolean harvested)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(reference)); }
			// harvested

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
