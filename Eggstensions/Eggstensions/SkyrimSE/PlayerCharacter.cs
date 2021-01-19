using static NetScriptFramework._IntPtrExtensions;



namespace Eggstensions.SkyrimSE
{
	static public class PlayerCharacter
	{
		/// <returns>PlayerCharacter</returns>
		static public System.IntPtr Instance
		{
			get
			{
				var instance = NetScriptFramework.Memory.ReadPointer(VIDS.PlayerCharacter.Instance);
				if (instance == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(instance)); }

				return instance;
			}
		}



		/// <param name="playerCharacter">PlayerCharacter</param>
		static public BSPointerHandle.ReferenceFromHandle GetActorBeingCommanded(System.IntPtr playerCharacter)
		{
			if (playerCharacter == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(playerCharacter)); }

			return new BSPointerHandle.ReferenceFromHandle(playerCharacter + 0x894);
		}

		/// <param name="playerCharacter">PlayerCharacter</param>
		static public System.UInt32 GetActorBeingCommandedHandle(System.IntPtr playerCharacter)
		{
			if (playerCharacter == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(playerCharacter)); }

			return NetScriptFramework.Memory.ReadUInt32(playerCharacter + 0x894);
		}

		/// <param name="playerCharacter">PlayerCharacter</param>
		static public System.IntPtr GetActorBeingCommandedHandleAddress(System.IntPtr playerCharacter)
		{
			if (playerCharacter == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(playerCharacter)); }

			return playerCharacter + 0x894;
		}

		/// <param name="playerCharacter">PlayerCharacter</param>
		static public BSPointerHandle.ReferenceFromHandle GetAutoAimActor(System.IntPtr playerCharacter)
		{
			if (playerCharacter == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(playerCharacter)); }

			return new BSPointerHandle.ReferenceFromHandle(playerCharacter + 0x9B8);
		}

		/// <param name="playerCharacter">PlayerCharacter</param>
		static public System.UInt32 GetAutoAimActorHandle(System.IntPtr playerCharacter)
		{
			if (playerCharacter == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(playerCharacter)); }

			return NetScriptFramework.Memory.ReadUInt32(playerCharacter + 0x9B8);
		}

		/// <param name="playerCharacter">PlayerCharacter</param>
		static public System.IntPtr GetAutoAimActorHandleAddress(System.IntPtr playerCharacter)
		{
			if (playerCharacter == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(playerCharacter)); }

			return playerCharacter + 0x9B8;
		}

		/// <summary>SkyrimSE.exe + 0x6CFEF0 (VID 40243)</summary>
		/// <param name="playerCharacter">PlayerCharacter</param>
		static public System.IntPtr GetTargetActor(System.IntPtr playerCharacter, System.Func<System.IntPtr, System.IntPtr, System.Boolean> condition)
		{
			if (playerCharacter == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(playerCharacter)); }
			if (condition == null) { throw new Eggceptions.ArgumentNullException(nameof(condition)); }

			var targetActor = System.IntPtr.Zero;

			var autoAimBasedOnDistance = SettingT.GameSettingCollection.AutoAimBasedOnDistance;
			var autoAimScreenPercentage = SettingT.GameSettingCollection.AutoAimScreenPercentage;
			var autoAimScreenPercentagePositive = 0.005f * autoAimScreenPercentage;
			var autoAimScreenPercentageNegative = -0.005f * autoAimScreenPercentage;

			var maximumDistanceBetween = SettingT.GameSettingCollection.AutoAimMaxDistance;
			var maximumTotalResultX = 1.0f;
			var maximumTotalResultY = 1.0f;

			var isOnMount = Actor.IsOnMount(playerCharacter);
			var worldRootCamera = SceneGraph.GetCamera(SceneGraph.WorldRootNode);

			foreach (var highActor in ProcessLists.GetHighActors(ProcessLists.Instance)) 
				using (highActor)
			{
				var highActorReference = highActor.Reference;
				if (highActorReference == System.IntPtr.Zero) { continue; }
				if (!Actor.IsInHigh(highActorReference)) { continue; }

				var distanceBetween = TESObjectREFR.GetDistanceBetween(highActorReference, playerCharacter);
				if (distanceBetween >= maximumDistanceBetween) { continue; }

				if (TESObjectREFR.IsDead(highActorReference, false)) { continue; }
				if (!condition(highActorReference, playerCharacter)) { continue; }
				if (isOnMount && Actor.IsBeingRiddenBy(highActorReference, playerCharacter)) { continue; }

				var rootNode = TESObjectREFR.GetRootNode(highActorReference);
				if (rootNode == System.IntPtr.Zero) { continue; }

				var worldBound = NiAVObject.GetWorldBound(rootNode);
				var center = NiBound.GetCenter(worldBound);

				var (x, _, _) = TESObjectREFR.GetMaximumBounds(highActorReference);
				var ((negativeResultX, _, _), (positiveResultX, _, _)) = NiCamera.IsInCenter(worldRootCamera, center, x, 0.00001f);
				var totalResultX = System.Math.Abs(negativeResultX + positiveResultX);

				var radius = NiBound.GetRadius(worldBound);
				var ((_, negativeResultY, _), (_, positiveResultY, _)) = NiCamera.IsInCenter(worldRootCamera, center, radius, 0.00001f);
				var totalResultY = System.Math.Abs(negativeResultY + positiveResultY);

				if
				(
					(autoAimBasedOnDistance || totalResultX < maximumTotalResultX || totalResultY < maximumTotalResultY)
					&& (negativeResultX != -1.0f || positiveResultX != 1.0f)
					&& (negativeResultX >= autoAimScreenPercentageNegative || positiveResultX >= autoAimScreenPercentageNegative)
					&& (negativeResultX <= autoAimScreenPercentagePositive || positiveResultX <= autoAimScreenPercentagePositive)
					&& (negativeResultY != -1.0f || positiveResultY != 1.0f)
					&& (negativeResultY >= autoAimScreenPercentageNegative || positiveResultY >= autoAimScreenPercentageNegative)
					&& (negativeResultY <= autoAimScreenPercentagePositive || positiveResultY <= autoAimScreenPercentagePositive)
				)
				{
					if (PlayerCharacter.HasLineOfSight(playerCharacter, highActorReference).lineOfSight)
					{
						targetActor = highActorReference;

						if (autoAimBasedOnDistance)
						{
							maximumDistanceBetween = distanceBetween;
						}
						else
						{
							maximumTotalResultX = totalResultX;
							maximumTotalResultY = totalResultY;
						}
					}
				}
			}

			return targetActor;
		}

		/// <param name="playerCharacter">PlayerCharacter</param>
		static public System.UInt32 GetTeammateCount(System.IntPtr playerCharacter)
		{
			if (playerCharacter == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(playerCharacter)); }

			return NetScriptFramework.Memory.ReadUInt32(playerCharacter + 0xA08);
		}

		/// <param name="playerCharacter">PlayerCharacter</param>
		static public System.IntPtr GetTargetHostile(System.IntPtr playerCharacter)
		{
			if (playerCharacter == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(playerCharacter)); }

			return PlayerCharacter.GetTargetActor(playerCharacter, Actor.IsHostileToActor);
		}

		/// <param name="playerCharacter">PlayerCharacter</param>
		static public System.IntPtr GetTargetTeammate(System.IntPtr playerCharacter)
		{
			if (playerCharacter == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(playerCharacter)); }

			if (PlayerCharacter.GetTeammateCount(playerCharacter) > 0)
			{
				return PlayerCharacter.GetTargetActor(playerCharacter, (actor, _) => Actor.IsPlayerTeammate(actor));
			}
			else
			{
				return System.IntPtr.Zero;
			}
		}

		/// <param name="playerCharacter">PlayerCharacter</param>
		/// <param name="target">TESObjectREFR</param>
		static public (System.Boolean fieldOfView, System.Boolean lineOfSight) HasLineOfSight(System.IntPtr playerCharacter, System.IntPtr target)
		{
			if (playerCharacter == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(playerCharacter)); }
			if (target == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(target)); }

			using (var fieldOfViewAllocation = NetScriptFramework.Memory.Allocate(0x8))
			{
				fieldOfViewAllocation.Zero();

				var lineOfSight = NetScriptFramework.Memory.InvokeCdecl(VIDS.PlayerCharacter.HasLineOfSight, playerCharacter, target, fieldOfViewAllocation.Address).ToBool();
				var fieldOfView = NetScriptFramework.Memory.ReadUInt8(fieldOfViewAllocation.Address) != 0;

				return (fieldOfView, lineOfSight);
			}
		}
	}
}
