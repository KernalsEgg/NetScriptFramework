#include "Events.h"



namespace Events
{
	void SinkFootstepEventHandler()
	{
		RE::BGSFootstepManager::GetSingleton()->AddEventSink(BGSFootstepEventHandler::GetSingleton());
	}



	BGSFootstepEventHandler* BGSFootstepEventHandler::GetSingleton()
	{
		static BGSFootstepEventHandler singleton;

		return &singleton;
	}

	RE::BSEventNotifyControl BGSFootstepEventHandler::ProcessEvent(const RE::BGSFootstepEvent* a_footstepEvent, RE::BSTEventSource<RE::BGSFootstepEvent>* a_footstepEventSource)
	{
		if (!a_footstepEvent)
		{
			return RE::BSEventNotifyControl::kContinue;
		}

		auto a_actorHandle = a_footstepEvent->actor;
		auto a_tag = std::string(a_footstepEvent->tag.c_str());

		SKSE::GetTaskInterface()->AddTask
		([a_actorHandle, a_tag]()
		{
			auto actorPointer = a_actorHandle.get();

			if (!actorPointer)
			{
				return;
			}

			auto actor = actorPointer.get();

			if (!actor)
			{
				return;
			}

			for (const auto& setting : Settings::GetSingleton())
			{
				auto conditions = setting.conditions;

				if (!conditions)
				{
					continue;
				}

				if (conditions->conditions.IsTrue(actor, nullptr))
				{
					for (const auto& footstep : setting.footsteps)
					{
						for (const auto& tag : footstep.tags)
						{
							if (_stricmp(tag.c_str(), a_tag.c_str()) == 0)
							{
								for (const auto& playImpactEffect : footstep.playImpactEffects)
								{
									auto played = BGSImpactManager::PlayImpactEffect(actor, playImpactEffect);
									
									auto& impactEffect = playImpactEffect.impactEffect;
									auto& rayCast = playImpactEffect.rayCast;
									auto& decal = playImpactEffect.decal;

									SKSE::log::info
									(
										"tag: {}, played: {}, actor: {} (0x{:016X}, 0x{:08X}), impactEffect: (0x{:016X}, 0x{:08X}), "
										"rayCast.origin.nodeName: \"{}\", rayCast.origin.offset.direction: ({}, {}, {}), rayCast.origin.offset.magnitude: {}, "
										"rayCast.ray.direction: ({}, {}, {}), rayCast.ray.magnitude: {}, "
										"rayCast.rotation: \"{}\" ({}, {}, {}), "
										"decal.rotation: \"{}\" ({}, {}, {}), "
										"decal.force: {}",
										tag, played, actor->GetName(), reinterpret_cast<std::uintptr_t>(actor), actor->GetFormID(), reinterpret_cast<std::uintptr_t>(impactEffect), impactEffect->GetFormID(),
										rayCast.origin.nodeName, rayCast.origin.offset.direction.x, rayCast.origin.offset.direction.y, rayCast.origin.offset.direction.z, rayCast.origin.offset.magnitude,
										rayCast.ray.direction.x, rayCast.ray.direction.y, rayCast.ray.direction.z, rayCast.ray.magnitude,
										rayCast.rotation.nodeName, rayCast.rotation.x, rayCast.rotation.y, rayCast.rotation.z,
										decal.rotation.nodeName, decal.rotation.x, decal.rotation.y, decal.rotation.z,
										decal.force
									);
								}
							}
						}
					}
				}
			}
		});

		return RE::BSEventNotifyControl::kContinue;
	}
}
