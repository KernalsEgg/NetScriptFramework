#pragma once

#pragma warning(disable : 4100) // unreferenced formal parameter

#include "BGSImpactManager.h"



namespace Events
{
	void SinkFootstepEventHandler();



	class BGSFootstepEventHandler : public RE::BSTEventSink<RE::BGSFootstepEvent>
	{
	public:
		static BGSFootstepEventHandler*	 GetSingleton();
		virtual RE::BSEventNotifyControl ProcessEvent(const RE::BGSFootstepEvent* a_footstepEvent, RE::BSTEventSource<RE::BGSFootstepEvent>* a_footstepEventSource) override;

	private:
		BGSFootstepEventHandler() = default;
		BGSFootstepEventHandler(const BGSFootstepEventHandler&) = delete;
		BGSFootstepEventHandler(BGSFootstepEventHandler&&) = delete;
		virtual ~BGSFootstepEventHandler() = default;

		BGSFootstepEventHandler& operator=(const BGSFootstepEventHandler&) = delete;
		BGSFootstepEventHandler& operator=(BGSFootstepEventHandler&&) = delete;
	};
}
