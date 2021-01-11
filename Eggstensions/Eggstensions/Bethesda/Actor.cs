using static NetScriptFramework._IntPtrExtensions;



namespace Eggstensions.Bethesda
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
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("actor"); }

			return Actor.HasBoolFlags(actor, Actor.BoolFlags.CanDoFavor);
		}

		/// <param name="actor">Actor</param>
		/// <param name="spellItem">SpellItem</param>
		static public void CastSpellPerkEntryPoint(System.IntPtr actor, System.IntPtr spellItem)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("actor"); }
			if (spellItem == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("spellItem"); }

			NetScriptFramework.Memory.InvokeCdecl(VIDS.Actor.CastSpellPerkEntryPoint, actor, spellItem);
		}

		/// <param name="actor">Actor</param>
		static public System.UInt32 GetCollisionFilter(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("actor"); }

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
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("actor"); }

			return (Actor.BoolBits)NetScriptFramework.Memory.ReadUInt32(actor + 0xE0);
		}

		/// <param name="actor">Actor</param>
		static public Actor.BoolFlags GetBoolFlags(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("actor"); }

			return (Actor.BoolFlags)NetScriptFramework.Memory.ReadUInt32(actor + 0x1FC);
		}

		/// <param name="actor">Actor</param>
		static public System.Single GetEyeLevel(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("actor"); }

			return NetScriptFramework.Memory.InvokeCdeclF(VIDS.Actor.GetEyeLevel, actor);
		}
		
		/// <param name="actor">Actor</param>
		static public System.Single GetLastUpdate(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("actor"); }

			return NetScriptFramework.Memory.ReadFloat(actor + 0x258);
		}

		/// <param name = "actor">Actor</param>
		static public TESObjectREFR.ExistingReferenceFromHandle GetMount(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("actor"); }

			using (var mountAllocation = NetScriptFramework.Memory.Allocate(0x8))
			{
				mountAllocation.Zero();

				NetScriptFramework.Memory.InvokeCdecl(VIDS.Actor.GetMount, actor, mountAllocation.Address);

				return new TESObjectREFR.ExistingReferenceFromHandle(NetScriptFramework.Memory.ReadPointer(mountAllocation.Address));
			}
		}

		/// <param name = "actor">Actor</param>
		static public System.IntPtr GetMountInteraction(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("actor"); }

			using (var mountInteractionAllocation = NetScriptFramework.Memory.Allocate(0x8))
			{
				mountInteractionAllocation.Zero();

				NetScriptFramework.Memory.InvokeCdecl(VIDS.Actor.GetMountInteraction, actor, mountInteractionAllocation.Address);

				return NetScriptFramework.Memory.ReadPointer(mountInteractionAllocation.Address);
			}
		}

		static public TESObjectREFR.ExistingReferenceFromHandle GetMountOrRider(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("actor"); }

			if (Actor.IsMount(actor))
			{
				if (Actor.IsBeingRidden(actor))
				{
					return Actor.GetRider(actor);
				}
			}
			else
			{
				if (Actor.IsOnMount(actor))
				{
					return Actor.GetMount(actor);
				}
			}

			return null;
		}

		/// <param name = "actor">Actor</param>
		/// <returns>AIProcess</returns>
		static public System.IntPtr GetProcess(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("actor"); }

			var process = NetScriptFramework.Memory.ReadPointer(actor + 0xF0);
			if (process == System.IntPtr.Zero) { throw new Eggceptions.NullException("process"); }

			return process;
		}

		/// <param name="actor">Actor</param>
		static public System.IntPtr GetRace(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("actor"); }

			var race = NetScriptFramework.Memory.ReadPointer(actor + 0x1F0);
			if (race == System.IntPtr.Zero) { throw new Eggceptions.NullException("race"); }

			return race;
		}

		/// <param name = "actor">Actor</param>
		static public TESObjectREFR.ExistingReferenceFromHandle GetRider(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("actor"); }

			using (var riderAllocation = NetScriptFramework.Memory.Allocate(0x8))
			{
				riderAllocation.Zero();

				NetScriptFramework.Memory.InvokeCdecl(VIDS.Actor.GetRider, actor, riderAllocation.Address);

				return new TESObjectREFR.ExistingReferenceFromHandle(NetScriptFramework.Memory.ReadPointer(riderAllocation.Address));
			}
		}

		/// <param name="actor">Actor</param>
		static public System.Boolean HasBoolBits(System.IntPtr actor, Actor.BoolBits boolBits)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("actor"); }
			// boolBits

			return (Actor.GetBoolBits(actor) & boolBits) == boolBits;
		}

		/// <param name="actor">Actor</param>
		static public System.Boolean HasBoolFlags(System.IntPtr actor, Actor.BoolFlags boolFlags)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("actor"); }
			// boolFlags

			return (Actor.GetBoolFlags(actor) & boolFlags) == boolFlags;
		}

		/// <param name="actor">Actor</param>
		static public System.Boolean IsBeingRidden(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("actor"); }

			return NetScriptFramework.Memory.InvokeCdecl(VIDS.Actor.IsBeingRidden, actor).ToBool();
		}

		/// <param name="actor">Actor</param>
		static public System.Boolean IsBeingRiddenBy(System.IntPtr actor, System.IntPtr rider)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("actor"); }

			return NetScriptFramework.Memory.InvokeCdecl(VIDS.Actor.IsBeingRiddenBy, actor, rider).ToBool();
		}

		/// <param name="actor">Actor</param>
		static public System.Boolean IsFlying(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("actor"); }

			return TESRaceData.IsFlying(TESRace.GetData(Actor.GetRace(actor)));
		}

		/// <param name="actor">Actor</param>
		static public System.Boolean IsHitAlong(System.IntPtr actor, (System.Single x, System.Single y, System.Single z) origin, (System.Single x, System.Single y, System.Single z) ray, CollisionLayers collisionLayer)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("actor"); }
			// origin
			// ray
			// collisionLayer

			var cell = TESObjectREFR.GetParentCell(actor);

			using (var mountOrRider = Actor.GetMountOrRider(actor))
			{
				var mountOrRiderReference = mountOrRider != null ? mountOrRider.Reference : System.IntPtr.Zero;

				return TESObjectCELL.IsHitAlong(cell, origin, ray, collisionLayer, actor, mountOrRiderReference);
			}
		}

		/// <param name="actor">Actor</param>
		static public System.Boolean IsHostileToActor(System.IntPtr actor, System.IntPtr target)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("actor"); }
			if (target == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("target"); }

			return NetScriptFramework.Memory.InvokeCdecl(VIDS.Actor.IsHostileToActor, actor, target).ToBool();
		}

		/// <param name="actor">Actor</param>
		static public System.Boolean IsInHigh(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("actor"); }

			return AIProcess.IsInHigh(Actor.GetProcess(actor));
		}

		/// <param name="actor">Actor</param>
		static public System.Boolean IsMount(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("actor"); }

			return Actor.HasBoolFlags(actor, Actor.BoolFlags.IsMount);
		}

		/// <param name="actor">Actor</param>
		static public System.Boolean IsOnFlyingMount(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("actor"); }

			return NetScriptFramework.Memory.InvokeCdecl(VIDS.Actor.IsOnFlyingMount, actor).ToBool();
		}

		/// <param name="actor">Actor</param>
		static public System.Boolean IsOnMount(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("actor"); }

			return NetScriptFramework.Memory.InvokeCdecl(VIDS.Actor.IsOnMount, actor).ToBool();
		}

		/// <param name="actor">Actor</param>
		static public System.Boolean IsPlayerTeammate(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("actor"); }

			return Actor.HasBoolBits(actor, Actor.BoolBits.PlayerTeammate);
		}

		/// <param name="actor">Actor</param>
		/// <param name="target">TESObjectREFR</param>
		static public System.Boolean IsReferenceInViewshed(System.IntPtr actor, System.IntPtr target, (System.Single x, System.Single y, System.Single z) origin, CollisionLayers collisionLayer)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("actor"); }
			if (target == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("target"); }
			// origin
			// collisionLayer

			var fractions = new System.Single[] { 0.75f, 0.5f, 0.25f };
			var cell = TESObjectREFR.GetParentCell(actor);
			var targetPosition = TESObjectREFR.GetPosition(target);
			var targetMinimumBounds = TESObjectREFR.GetMinimumBounds(target);
			var targetMaximumBounds = TESObjectREFR.GetMaximumBounds(target);

			using (var mountOrRider = Actor.GetMountOrRider(actor))
			{
				var mountOrRiderReference = mountOrRider != null ? mountOrRider.Reference : System.IntPtr.Zero;
				
				foreach (var fraction in fractions)
				{
					if (!TESObjectCELL.IsHitBetween(cell, origin, (targetPosition.x, targetPosition.y, targetPosition.z + fraction * (targetMaximumBounds.z - targetMinimumBounds.z) + targetMinimumBounds.z), collisionLayer, actor, target, mountOrRiderReference))
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
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("actor"); }

			var middleHighProcessData = NetScriptFramework.Memory.InvokeThisCall(Actor.GetProcess(actor), VIDS.Actor.Update3DModel, actor);
			if (middleHighProcessData == System.IntPtr.Zero) { throw new Eggceptions.NullException("middleHighProcessData"); }

			return middleHighProcessData;
		}
	}
}
