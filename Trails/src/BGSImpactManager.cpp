#include "BGSImpactManager.h"

#include "BGSDecalManager.h"



bool BGSImpactManager::PlayImpactEffect(RE::TESObjectREFR* a_subject, const Settings::PlayImpactEffect& a_playImpactEffect)
{
	if (!a_subject)
	{
		return false;
	}

	auto impactEffect = a_playImpactEffect.impactEffect;

	if (!impactEffect)
	{
		return false;
	}

	auto parentCell = a_subject->GetParentCell();

	if (!parentCell)
	{
		return false;
	}

	auto bhkWorld = parentCell->GetbhkWorld();

	if (!bhkWorld)
	{
		return false;
	}

	auto result = false;

	auto isApplyingDecal = RE::BGSDecalManager::IsApplyingDecal();
	RE::BGSDecalManager::SetApplyingDecal(true);

	const auto& rayCast = a_playImpactEffect.rayCast;

	const auto& originNodeName = rayCast.origin.nodeName;
	auto		originNode = !originNodeName.empty() ? a_subject->GetNodeByName(RE::BSFixedString(originNodeName.c_str())) : nullptr;
	auto		origin = originNode ? originNode->world.translate : a_subject->GetPosition();

	auto offset = rayCast.origin.offset.direction;
	auto ray = rayCast.ray.direction;

	const auto& rayCastRotationNodeName = rayCast.rotation.nodeName;
	auto		rayCastRotationNode = !rayCastRotationNodeName.empty() ? a_subject->GetNodeByName(RE::BSFixedString(rayCastRotationNodeName.c_str())) : nullptr;

	if (rayCastRotationNode)
	{
		auto rotation = rayCastRotationNode->world.rotate;

		offset = rotation * offset;
		ray = rotation * ray;
	}
	else if (rayCast.rotation.x || rayCast.rotation.y || rayCast.rotation.z)
	{
		RE::NiMatrix3 rotation;
		rotation.EulerAnglesToAxesZXY(rayCast.rotation.x ? a_subject->GetAngle().x : 0.0F, rayCast.rotation.y ? a_subject->GetAngle().y : 0.0F, rayCast.rotation.z ? a_subject->GetAngle().z : 0.0F);

		offset = rotation * offset;
		ray = rotation * ray;
	}

	offset.Unitize();
	offset *= rayCast.origin.offset.magnitude;
	origin += offset;

	ray.Unitize();
	ray *= rayCast.ray.magnitude;

	RE::hkpWorldRayCastInput worldRayCastInput;

	auto closestRayHitCollector = RE::hkpClosestRayHitCollector();
	worldRayCastInput.rayHitCollectorA8 = &closestRayHitCollector;

	auto bhkWorldScale = RE::bhkWorld::GetWorldScale();
	worldRayCastInput.from.quad = _mm_setr_ps(origin.x * bhkWorldScale, origin.y * bhkWorldScale, origin.z * bhkWorldScale, 0.0F);
	worldRayCastInput.ray.quad = _mm_setr_ps(ray.x * bhkWorldScale, ray.y * bhkWorldScale, ray.z * bhkWorldScale, 0.0F);

	auto actor = a_subject->As<RE::Actor>();

	if (actor)
	{
		auto characterController = actor->GetCharController();

		if (characterController)
		{
			characterController->GetCollisionFilterInfo(worldRayCastInput.filterInfo);
		}
	}
	else
	{
		auto rootNode = RE::NiPointer(a_subject->Get3D2());

		if (rootNode)
		{
			auto collisionObject = rootNode.get()->GetCollisionObject();

			if (collisionObject)
			{
				auto rigidBody = collisionObject->GetRigidBody();

				if (rigidBody)
				{
					auto referencedObject = RE::hkRefPtr(static_cast<RE::hkpWorldObject*>(rigidBody->referencedObject.get()));

					if (referencedObject)
					{
						worldRayCastInput.filterInfo = referencedObject->collidable.broadPhaseHandle.collisionFilterInfo;
					}
				}
			}
		}
	}

	if (bhkWorld->CastRay(worldRayCastInput))
	{
		auto& rayHit = closestRayHitCollector.rayHit;
		auto  rootCollidable = rayHit.rootCollidable;

		if (rootCollidable)
		{
			auto position = RE::NiPoint3(origin.x + rayHit.hitFraction * ray.x, origin.y + rayHit.hitFraction * ray.y, origin.z + rayHit.hitFraction * ray.z);
			auto normal = RE::NiPoint3(rayHit.normal.quad.m128_f32[0], rayHit.normal.quad.m128_f32[1], rayHit.normal.quad.m128_f32[2]);

			std::uint32_t				  materialID = 0U;
			RE::NiPointer<RE::NiAVObject> target3D = nullptr;

			auto terrain = (rootCollidable->broadPhaseHandle.collisionFilterInfo & RE::hkpCollidable::CollisionFilterInfo::kBelongsToMask) == RE::hkpCollidable::BelongsTo::kTerrain;

			if (terrain)
			{
				materialID = RE::TES::GetSingleton()->GetMaterialID(&position);

				if (rootCollidable->broadPhaseHandle.type == 1)
				{
					auto owner = rootCollidable->GetOwner<RE::hkpWorldObject>();

					if (owner)
					{
						auto userData = reinterpret_cast<RE::bhkRefObject*>(owner->userData);

						if (userData)
						{
							auto propertyValue = reinterpret_cast<RE::NiAVObject*>(static_cast<RE::hkpWorldObject*>(userData->referencedObject.get())->GetPropertyValue(0));

							if (propertyValue)
							{
								auto parent = propertyValue->parent;

								if (parent)
								{
									target3D = RE::NiPointer(parent);
								}
							}
						}
					}
				}
			}
			else
			{
				auto shape = rootCollidable->shape;

				if (shape)
				{
					auto userData = reinterpret_cast<RE::bhkShape*>(shape->userData);

					if (userData)
					{
						auto shapeKey = RE::HK_INVALID_SHAPE_KEY;
						auto shapeKeys = rayHit.shapeKeys;

						for (auto shapeKeyIndex = 0; shapeKeyIndex < RE::hkpShapeRayCastOutput::kMaxHierarchyDepth; ++shapeKeyIndex)
						{
							if (shapeKeys[shapeKeyIndex] == RE::HK_INVALID_SHAPE_KEY)
							{
								break;
							}

							shapeKey = shapeKeys[shapeKeyIndex];
						}

						materialID = userData->GetMaterialID(shapeKey);
					}
				}

				target3D = RE::NiPointer(rootCollidable->Get3D());
			}

			if (materialID)
			{
				auto materialType = RE::BGSMaterialType::GetMaterialType(materialID);

				if (materialType)
				{
					auto impactData = impactEffect->GetImpactData(materialType);

					if (impactData)
					{
						result = true;

						auto model = impactData->GetModel();
						parentCell->PlaceTempEffectParticle(0U, model, &normal, &position, 1.0F, 7U, nullptr);

						RE::IMPACT_SOUND_DATA impactSoundData;

						impactSoundData.impactData = impactData;
						impactSoundData.position = &position;
						impactSoundData.playSound1 = true;
						impactSoundData.playSound2 = true;

						RE::BGSImpactManager::GetSingleton()->PlaySound(impactSoundData);

						auto textureSet = impactData->decalTextureSet;

						if (textureSet)
						{
							auto target = RE::NiPointer(RE::TESObjectREFR::FindReferenceFor3D(target3D.get()));

							if (terrain || (target && RE::BGSDecalManager::ShouldApplyDecal(target.get())))
							{
								RE::DECAL_CREATION_DATA decalCreationData;

								decalCreationData.origin = position;
								decalCreationData.direction = normal;
								decalCreationData.avObject = target3D;
								decalCreationData.textureSet = textureSet;
								decalCreationData.textureSet2 = impactData->decalTextureSet2;

								auto& decalData = impactData->dData.data;

								std::random_device			   randomDevice;
								std::mt19937				   generator(randomDevice());
								std::uniform_real_distribution widthDistribution(decalData.decalMinWidth, decalData.decalMaxWidth);
								std::uniform_real_distribution heightDistribution(decalData.decalMinHeight, decalData.decalMaxHeight);

								decalCreationData.width = widthDistribution(generator);
								decalCreationData.height = heightDistribution(generator);
								decalCreationData.depth = decalData.depth;

								const auto& decal = a_playImpactEffect.decal;

								const auto& decalRotationNodeName = decal.rotation.nodeName;
								auto		decalRotationNode = !decalRotationNodeName.empty() ? a_subject->GetNodeByName(RE::BSFixedString(decalRotationNodeName.c_str())) : nullptr;

								if (decalRotationNode)
								{
									decalCreationData.emitterRotation = decalRotationNode->world.rotate;
								}
								else if (decal.rotation.x || decal.rotation.y || decal.rotation.z)
								{
									decalCreationData.emitterRotation.EulerAnglesToAxesZXY(decal.rotation.x ? a_subject->GetAngle().x : 0.0F, decal.rotation.y ? a_subject->GetAngle().y : 0.0F, decal.rotation.z ? a_subject->GetAngle().z : 0.0F);
								}

								if (!target.get())
								{
									decalCreationData.parentCell = RE::TES::GetSingleton()->GetCell(&position);
								}

								decalCreationData.parallaxScale = decalData.parallaxScale;
								decalCreationData.shininess = decalData.shininess;
								decalCreationData.angleThreshold = impactData->data.angleThreshold;
								decalCreationData.placementRadius = impactData->data.placementRadius;

								auto color = decalData.color;
								decalCreationData.color = RE::NiColor(color.red / 255.0F, color.green / 255.0F, color.blue / 255.0F);

								auto flags = decalData.flags;

								if ((flags & RE::DECAL_DATA_DATA::Flag::kNoSubtextures) != 0)
								{
									decalCreationData.subtextureIndex = -1;
								}
								else
								{
									std::uniform_int_distribution subtextureIndexDistribution(0, 3);

									decalCreationData.subtextureIndex = static_cast<std::uint8_t>(subtextureIndexDistribution(generator));
								}

								decalCreationData.parallax = (flags & RE::DECAL_DATA_DATA::Flag::kParallax) != 0;
								decalCreationData.alphaTesting = (flags & RE::DECAL_DATA_DATA::Flag::kAlphaTesting) != 0;
								decalCreationData.alphaBlending = (flags & RE::DECAL_DATA_DATA::Flag::kAlphaBlending) != 0;

								decalCreationData.parallaxPasses = decalData.parallaxPasses;

								BGSDecalManager::ApplyDecal(decalCreationData, decal.force, nullptr);
							}
						}
					}
				}
			}
		}
	}

	RE::BGSDecalManager::SetApplyingDecal(isApplyingDecal);

	return result;
}
