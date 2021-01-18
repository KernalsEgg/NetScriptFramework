using static NetScriptFramework._IntPtrExtensions;



namespace Eggstensions.SkyrimSE
{
	static public class Actor
	{
		public enum BoolBits : System.UInt32
		{
			PlayerTeammate = 1u << 26
		}

		public enum BoolFlags : System.UInt32
		{
			IsMount =		1u << 1,
			CanDoFavor =	1u << 7
		}



		/// <param name="actor">Actor</param>
		static public System.Boolean CanDoFavor(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(actor)); }

			return Actor.HasBoolFlags(actor, Actor.BoolFlags.CanDoFavor);
		}

		/// <param name="actor">Actor</param>
		/// <param name="spellItem">SpellItem</param>
		static public void CastSpellPerkEntryPoint(System.IntPtr actor, System.IntPtr spellItem)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(actor)); }
			if (spellItem == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(spellItem)); }

			NetScriptFramework.Memory.InvokeCdecl(VIDS.Actor.CastSpellPerkEntryPoint, actor, spellItem);
		}

		/// <param name="actor">Actor</param>
		/// <returns>ActorState</returns>
		static public System.IntPtr GetActorState(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(actor)); }

			return actor + 0xB8;
		}

		/// <param name="actor">Actor</param>
		static public System.UInt32 GetCollisionFilter(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(actor)); }

			using (var collisionFilterAllocation = NetScriptFramework.Memory.Allocate(0x8))
			{
				collisionFilterAllocation.Zero();

				NetScriptFramework.Memory.InvokeCdecl(VIDS.Actor.GetCollisionFilter, actor, collisionFilterAllocation.Address);

				return NetScriptFramework.Memory.ReadUInt32(collisionFilterAllocation.Address);
			}
		}

		/// <param name="actor">Actor</param>
		static public Actor.BoolBits GetBoolBits(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(actor)); }

			return (Actor.BoolBits)NetScriptFramework.Memory.ReadUInt32(actor + 0xE0);
		}

		/// <param name="actor">Actor</param>
		static public Actor.BoolFlags GetBoolFlags(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(actor)); }

			return (Actor.BoolFlags)NetScriptFramework.Memory.ReadUInt32(actor + 0x1FC);
		}

		/// <param name="actor">Actor</param>
		static public System.Single GetEyeLevel(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(actor)); }

			return NetScriptFramework.Memory.InvokeCdeclF(VIDS.Actor.GetEyeLevel, actor);
		}
		
		/// <param name="actor">Actor</param>
		static public System.Single GetLastUpdate(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(actor)); }

			return NetScriptFramework.Memory.ReadFloat(actor + 0x258);
		}

		/// <param name = "actor">Actor</param>
		static public BSPointerHandle.ExistingReferenceFromHandle GetMount(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(actor)); }

			using (var mountAllocation = NetScriptFramework.Memory.Allocate(0x8))
			{
				mountAllocation.Zero();

				NetScriptFramework.Memory.InvokeCdecl(VIDS.Actor.GetMount, actor, mountAllocation.Address);

				return new BSPointerHandle.ExistingReferenceFromHandle(NetScriptFramework.Memory.ReadPointer(mountAllocation.Address));
			}
		}

		/// <param name = "actor">Actor</param>
		static public MountInteraction GetMountInteraction(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(actor)); }

			using (var mountInteractionAllocation = NetScriptFramework.Memory.Allocate(0x8))
			{
				mountInteractionAllocation.Zero();

				NetScriptFramework.Memory.InvokeCdecl(VIDS.Actor.GetMountInteraction, actor, mountInteractionAllocation.Address);

				return new MountInteraction(NetScriptFramework.Memory.ReadPointer(mountInteractionAllocation.Address));
			}
		}

		/// <param name = "actor">Actor</param>
		static public BSPointerHandle.ReferenceFromHandle GetOccupiedFurniture(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(actor)); }

			var aiProcess = Actor.GetProcess(actor);

			return AIProcess.GetOccupiedFurniture(aiProcess);
		}

		/// <param name = "actor">Actor</param>
		static public System.UInt32 GetOccupiedFurnitureHandle(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(actor)); }

			var aiProcess = Actor.GetProcess(actor);

			return AIProcess.GetOccupiedFurnitureHandle(aiProcess);
		}

		/// <param name = "actor">Actor</param>
		static public System.IntPtr GetOccupiedFurnitureHandleAddress(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(actor)); }

			var aiProcess = Actor.GetProcess(actor);

			return AIProcess.GetOccupiedFurnitureHandleAddress(aiProcess);
		}

		/// <param name = "actor">Actor</param>
		/// <returns>AIProcess</returns>
		static public System.IntPtr GetProcess(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(actor)); }

			var aiProcess = NetScriptFramework.Memory.ReadPointer(actor + 0xF0);
			if (aiProcess == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(aiProcess)); }

			return aiProcess;
		}

		/// <param name="actor">Actor</param>
		static public System.IntPtr GetRace(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(actor)); }

			var race = NetScriptFramework.Memory.ReadPointer(actor + 0x1F0);
			if (race == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(race)); }

			return race;
		}

		/// <param name = "actor">Actor</param>
		static public BSPointerHandle.ExistingReferenceFromHandle GetRider(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(actor)); }

			using (var riderAllocation = NetScriptFramework.Memory.Allocate(0x8))
			{
				riderAllocation.Zero();

				NetScriptFramework.Memory.InvokeCdecl(VIDS.Actor.GetRider, actor, riderAllocation.Address);

				return new BSPointerHandle.ExistingReferenceFromHandle(NetScriptFramework.Memory.ReadPointer(riderAllocation.Address));
			}
		}

		/// <param name="actor">Actor</param>
		static public BSPointerHandle.ReferenceFromHandle GetVehicle(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(actor)); }

			return new BSPointerHandle.ReferenceFromHandle(actor + 0x1E8);
		}

		/// <param name="actor">Actor</param>
		static public System.UInt32 GetVehicleHandle(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(actor)); }

			return NetScriptFramework.Memory.ReadUInt32(actor + 0x1E8);
		}

		/// <param name="actor">Actor</param>
		static public System.IntPtr GetVehicleHandleAddress(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(actor)); }

			return actor + 0x1E8;
		}

		/// <param name="actor">Actor</param>
		static public System.Boolean HasBoolBits(System.IntPtr actor, Actor.BoolBits boolBits)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(actor)); }
			// boolBits

			return (Actor.GetBoolBits(actor) & boolBits) == boolBits;
		}

		/// <param name="actor">Actor</param>
		static public System.Boolean HasBoolFlags(System.IntPtr actor, Actor.BoolFlags boolFlags)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(actor)); }
			// boolFlags

			return (Actor.GetBoolFlags(actor) & boolFlags) == boolFlags;
		}

		/// <param name="actor">Actor</param>
		static public System.Boolean IsBeingRidden(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(actor)); }

			return NetScriptFramework.Memory.InvokeCdecl(VIDS.Actor.IsBeingRidden, actor).ToBool();
		}

		/// <param name="actor">Actor</param>
		static public System.Boolean IsBeingRiddenBy(System.IntPtr actor, System.IntPtr rider)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(actor)); }

			return NetScriptFramework.Memory.InvokeCdecl(VIDS.Actor.IsBeingRiddenBy, actor, rider).ToBool();
		}

		/// <param name="actor">Actor</param>
		static public System.Boolean IsFlying(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(actor)); }

			return TESRaceData.IsFlying(TESRace.GetData(Actor.GetRace(actor)));
		}

		/// <param name="actor">Actor</param>
		static public System.Boolean IsHitAlong(System.IntPtr actor, (System.Single x, System.Single y, System.Single z) origin, (System.Single x, System.Single y, System.Single z) ray, BGSCollisionLayer.CollisionLayerTypes collisionLayerType)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(actor)); }
			// origin
			// ray
			// collisionLayerType

			var parentCell = TESObjectREFR.GetParentCell(actor);
			if (parentCell == System.IntPtr.Zero) { return false; }

			using (var mountInteraction = Actor.GetMountInteraction(actor))
			{
				var mountInteractionAddress = mountInteraction.Address;

				if (mountInteractionAddress != System.IntPtr.Zero)
				{
					using (var mount = MountInteraction.GetMount(mountInteractionAddress))
					using (var rider = MountInteraction.GetRider(mountInteractionAddress))
					{
						return IsHitAlong(mount.Reference, rider.Reference);
					}
				}
			}

			return IsHitAlong(actor);



			System.Boolean IsHitAlong(params System.IntPtr[] references)
			{
				return TESObjectCELL.IsHitAlong(parentCell, origin, ray, collisionLayerType, references);
			}
		}

		/// <param name="actor">Actor</param>
		static public System.Boolean IsHostileToActor(System.IntPtr actor, System.IntPtr target)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(actor)); }
			if (target == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(target)); }

			return NetScriptFramework.Memory.InvokeCdecl(VIDS.Actor.IsHostileToActor, actor, target).ToBool();
		}

		/// <param name="actor">Actor</param>
		static public System.Boolean IsInHigh(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(actor)); }

			return AIProcess.IsInHigh(Actor.GetProcess(actor));
		}

		/// <param name="actor">Actor</param>
		static public System.Boolean IsMount(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(actor)); }

			return Actor.HasBoolFlags(actor, Actor.BoolFlags.IsMount);
		}

		/// <param name="actor">Actor</param>
		static public System.Boolean IsOnFlyingMount(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(actor)); }

			return NetScriptFramework.Memory.InvokeCdecl(VIDS.Actor.IsOnFlyingMount, actor).ToBool();
		}

		/// <param name="actor">Actor</param>
		static public System.Boolean IsOnMount(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(actor)); }

			return NetScriptFramework.Memory.InvokeCdecl(VIDS.Actor.IsOnMount, actor).ToBool();
		}

		/// <param name="actor">Actor</param>
		static public System.Boolean IsPlayerTeammate(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(actor)); }

			return Actor.HasBoolBits(actor, Actor.BoolBits.PlayerTeammate);
		}

		/// <param name="actor">Actor</param>
		/// <param name="target">TESObjectREFR</param>
		static public System.Boolean IsReferenceInViewshed(System.IntPtr actor, System.IntPtr target, (System.Single x, System.Single y, System.Single z) origin, BGSCollisionLayer.CollisionLayerTypes collisionLayerType)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(actor)); }
			if (target == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(target)); }
			// origin
			// collisionLayerType

			var parentCell = TESObjectREFR.GetParentCell(actor);
			if (parentCell == System.IntPtr.Zero) { return false; }

			var fractions = new System.Single[] { 0.75f, 0.5f, 0.25f };
			var targetPosition = TESObjectREFR.GetPosition(target);
			var targetMinimumBounds = TESObjectREFR.GetMinimumBounds(target);
			var targetMaximumBounds = TESObjectREFR.GetMaximumBounds(target);

			using (var mountInteraction = Actor.GetMountInteraction(actor))
			{
				var mountInteractionAddress = mountInteraction.Address;

				if (mountInteractionAddress != System.IntPtr.Zero)
				{
					using (var mount = MountInteraction.GetMount(mountInteractionAddress))
					using (var rider = MountInteraction.GetRider(mountInteractionAddress))
					{
						return IsReferenceInViewshed(mount.Reference, rider.Reference, target);
					}
				}
			}

			return IsReferenceInViewshed(actor, target);

			
			
			System.Boolean IsReferenceInViewshed(params System.IntPtr[] references)
			{
				foreach (var fraction in fractions)
				{
					if (!TESObjectCELL.IsHitBetween(parentCell, origin, (targetPosition.x, targetPosition.y, targetPosition.z + fraction * (targetMaximumBounds.z - targetMinimumBounds.z) + targetMinimumBounds.z), collisionLayerType, references))
					{
						return true;
					}
				}

				return false;
			}
		}

		/// <param name = "actor">Actor</param>
		/// <returns>MiddleHighProcessData</returns>
		static public System.IntPtr Update3DModel(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(actor)); }

			var middleHighProcessData = NetScriptFramework.Memory.InvokeThisCall(Actor.GetProcess(actor), VIDS.Actor.Update3DModel, actor);
			if (middleHighProcessData == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(middleHighProcessData)); }

			return middleHighProcessData;
		}
	}
}
