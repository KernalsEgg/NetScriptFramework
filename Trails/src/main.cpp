#include "Events.h"



void MessagingInterfaceHandler(SKSE::MessagingInterface::Message* a_message)
{
	switch (a_message->type)
	{
		case SKSE::MessagingInterface::kDataLoaded:
		{
			Settings::Load();
			Events::SinkFootstepEventHandler();

			break;
		}
	}
}



extern "C" DLLEXPORT bool SKSEAPI SKSEPlugin_Query(const SKSE::QueryInterface* a_queryInterface, SKSE::PluginInfo* a_pluginInfo)
{
	auto path = SKSE::log::log_directory();

	if (!path)
	{
		return false;
	}

	*path /= "Trails.log"sv;

	auto sink = std::make_shared<spdlog::sinks::basic_file_sink_mt>(path->string(), true);
	auto logger = std::make_shared<spdlog::logger>("global log"s, std::move(sink));

	logger->set_level(spdlog::level::info);
	logger->flush_on(spdlog::level::info);

	spdlog::set_default_logger(std::move(logger));
	spdlog::set_pattern("[%H:%M:%S:%e] %g:%# (%^%l%$) %v"s);

	a_pluginInfo->infoVersion = SKSE::PluginInfo::kVersion;
	a_pluginInfo->name = "Trails";
	a_pluginInfo->version = Version::MAJOR;

	if (a_queryInterface->IsEditor())
	{
		SKSE::log::critical("Loaded in editor, marking as incompatible"sv);

		return false;
	}

	const auto version = a_queryInterface->RuntimeVersion();

	if (version < SKSE::RUNTIME_1_5_39)
	{
		SKSE::log::critical(FMT_STRING("Unsupported runtime version {}"), version.string());

		return false;
	}

	return true;
}

extern "C" DLLEXPORT bool SKSEAPI SKSEPlugin_Load(const SKSE::LoadInterface* a_loadInterface)
{
	SKSE::Init(a_loadInterface);

	if (!SKSE::GetMessagingInterface()->RegisterListener("SKSE", MessagingInterfaceHandler))
	{
		return false;
	}

	return true;
}
