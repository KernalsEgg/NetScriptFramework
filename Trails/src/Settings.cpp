#include "Settings.h"



std::vector<Settings::Setting>& Settings::GetSingleton()
{
	static std::vector<Settings::Setting> singleton;

	return singleton;
}

std::vector<Settings::Setting> Settings::Deserialize(const json& a_jsonSettings)
{
	std::vector<Settings::Setting> settings;

	for (const auto& jsonSetting : a_jsonSettings)
	{
		Settings::Setting setting;

		setting.conditions = Settings::GetFormFromFile<RE::BGSConstructibleObject>(jsonSetting.at("conditions").at("formID").get<std::string>(), jsonSetting.at("conditions").at("fileName").get<std::string>());

		for (const auto& jsonFootstep : jsonSetting.at("footsteps"))
		{
			Settings::Footstep footstep;

			footstep.tags = jsonFootstep.at("tags").get<std::vector<std::string>>();

			for (const auto& jsonPlayImpactEffect : jsonFootstep.at("playImpactEffects"))
			{
				Settings::PlayImpactEffect playImpactEffect;

				Settings::DeserializePlayImpactEffect(jsonPlayImpactEffect, playImpactEffect);

				footstep.playImpactEffects.push_back(playImpactEffect);
			}

			setting.footsteps.push_back(footstep);
		}

		settings.push_back(setting);
	}

	return settings;
}

json Settings::Serialize(const std::vector<Settings::Setting>& a_settings)
{
	json jsonSettings;

	for (const auto& setting : a_settings)
	{
		json jsonSetting;

		jsonSetting["conditions"]["formID"] = Settings::FormToFormID(setting.conditions);
		jsonSetting["conditions"]["fileName"] = Settings::FormToFileName(setting.conditions);

		for (const auto& footstep : setting.footsteps)
		{
			json jsonFootstep;

			json jsonTags(footstep.tags);
			jsonFootstep["tags"] = jsonTags;

			for (const auto& playImpactEffect : footstep.playImpactEffects)
			{
				json jsonPlayImpactEffect;

				const auto& impactEffect = playImpactEffect.impactEffect;
				jsonPlayImpactEffect["impactEffect"]["formID"] = Settings::FormToFormID(impactEffect);
				jsonPlayImpactEffect["impactEffect"]["fileName"] = Settings::FormToFileName(impactEffect);

				const auto& rayCast = playImpactEffect.rayCast;
				jsonPlayImpactEffect["rayCast"]["origin"]["nodeName"] = rayCast.origin.nodeName;
				jsonPlayImpactEffect["rayCast"]["origin"]["offset"]["direction"]["x"] = rayCast.origin.offset.direction.x;
				jsonPlayImpactEffect["rayCast"]["origin"]["offset"]["direction"]["y"] = rayCast.origin.offset.direction.y;
				jsonPlayImpactEffect["rayCast"]["origin"]["offset"]["direction"]["z"] = rayCast.origin.offset.direction.z;
				jsonPlayImpactEffect["rayCast"]["origin"]["offset"]["magnitude"] = rayCast.origin.offset.magnitude;
				jsonPlayImpactEffect["rayCast"]["ray"]["direction"]["x"] = rayCast.ray.direction.x;
				jsonPlayImpactEffect["rayCast"]["ray"]["direction"]["y"] = rayCast.ray.direction.y;
				jsonPlayImpactEffect["rayCast"]["ray"]["direction"]["z"] = rayCast.ray.direction.z;
				jsonPlayImpactEffect["rayCast"]["ray"]["magnitude"] = rayCast.ray.magnitude;
				jsonPlayImpactEffect["rayCast"]["rotation"]["nodeName"] = rayCast.rotation.nodeName;
				jsonPlayImpactEffect["rayCast"]["rotation"]["x"] = rayCast.rotation.x;
				jsonPlayImpactEffect["rayCast"]["rotation"]["y"] = rayCast.rotation.y;
				jsonPlayImpactEffect["rayCast"]["rotation"]["z"] = rayCast.rotation.z;

				const auto& decal = playImpactEffect.decal;
				jsonPlayImpactEffect["decal"]["rotation"]["nodeName"] = decal.rotation.nodeName;
				jsonPlayImpactEffect["decal"]["rotation"]["x"] = decal.rotation.x;
				jsonPlayImpactEffect["decal"]["rotation"]["y"] = decal.rotation.y;
				jsonPlayImpactEffect["decal"]["rotation"]["z"] = decal.rotation.z;
				jsonPlayImpactEffect["decal"]["force"] = decal.force;

				jsonFootstep["playImpactEffects"].push_back(jsonPlayImpactEffect);
			}

			jsonSetting["footsteps"].push_back(jsonFootstep);
		}

		jsonSettings.push_back(jsonSetting);
	}

	return jsonSettings;
}

void Settings::Load()
{
	if (std::filesystem::exists("Data\\SKSE\\Plugins\\Trails"s))
	{
		for (const auto& directoryEntry : std::filesystem::directory_iterator("Data\\SKSE\\Plugins\\Trails"s))
		{
			auto path = directoryEntry.path();

			if (_stricmp(path.extension().string().c_str(), ".json") != 0)
			{
				continue;
			}

			auto fileName = path.filename();

			try
			{
				SKSE::log::info("Loading {}...", fileName.string());

				auto  localSettings = Settings::Deserialize(json::parse(std::ifstream(path), nullptr, true, true));
				auto& globalSettings = Settings::GetSingleton();
				globalSettings.insert(globalSettings.end(), localSettings.begin(), localSettings.end());

				SKSE::log::info("{} loaded.", fileName.string());
			}
			catch (const std::exception& exception)
			{
				SKSE::log::error("{} aborted: {}", fileName.string(), exception.what());
			}
		}

		auto& settings = Settings::GetSingleton();

		if (settings.size() != 0)
		{
			SKSE::log::info("\n{}", Settings::Serialize(settings).dump(4));
		}
	}
}



void Settings::DeserializeDecal(const json& a_jsonDecal, Settings::PlayImpactEffect::Decal& a_decal)
{
	if (a_jsonDecal.contains("rotation"))
	{
		Settings::DeserializeRotation(a_jsonDecal.at("rotation"), a_decal.rotation);
	}

	if (a_jsonDecal.contains("force"))
	{
		a_decal.force = a_jsonDecal.at("force").get<bool>();
	}
}

void Settings::DeserializePlayImpactEffect(const json& a_jsonPlayImpactEffect, Settings::PlayImpactEffect& a_playImpactEffect)
{
	const auto& jsonImpactEffect = a_jsonPlayImpactEffect.at("impactEffect");
	auto&		impactEffect = a_playImpactEffect.impactEffect;

	impactEffect = Settings::GetFormFromFile<RE::BGSImpactDataSet>(jsonImpactEffect.at("formID").get<std::string>(), jsonImpactEffect.at("fileName").get<std::string>());

	if (a_jsonPlayImpactEffect.contains("rayCast"))
	{
		Settings::DeserializeRayCast(a_jsonPlayImpactEffect.at("rayCast"), a_playImpactEffect.rayCast);
	}

	if (a_jsonPlayImpactEffect.contains("decal"))
	{
		Settings::DeserializeDecal(a_jsonPlayImpactEffect.at("decal"), a_playImpactEffect.decal);
	}
}

void Settings::DeserializePosition(const json& a_jsonPosition, Settings::PlayImpactEffect::Position& a_position)
{
	if (a_jsonPosition.contains("nodeName"))
	{
		a_position.nodeName = a_jsonPosition.at("nodeName").get<std::string>();
	}

	if (a_jsonPosition.contains("offset"))
	{
		Settings::DeserializeVector(a_jsonPosition.at("offset"), a_position.offset);
	}
}

void Settings::DeserializeRayCast(const json& a_jsonRayCast, Settings::PlayImpactEffect::RayCast& a_rayCast)
{
	if (a_jsonRayCast.contains("origin"))
	{
		Settings::DeserializePosition(a_jsonRayCast.at("origin"), a_rayCast.origin);
	}

	if (a_jsonRayCast.contains("ray"))
	{
		Settings::DeserializeVector(a_jsonRayCast.at("ray"), a_rayCast.ray);
	}

	if (a_jsonRayCast.contains("rotation"))
	{
		Settings::DeserializeRotation(a_jsonRayCast.at("rotation"), a_rayCast.rotation);
	}
}

void Settings::DeserializeRotation(const json& a_jsonRotation, Settings::PlayImpactEffect::Rotation& a_rotation)
{
	if (a_jsonRotation.contains("nodeName"))
	{
		a_rotation.nodeName = a_jsonRotation.at("nodeName").get<std::string>();
	}

	if (a_jsonRotation.contains("x"))
	{
		a_rotation.x = a_jsonRotation.at("x").get<bool>();
	}

	if (a_jsonRotation.contains("y"))
	{
		a_rotation.y = a_jsonRotation.at("y").get<bool>();
	}

	if (a_jsonRotation.contains("z"))
	{
		a_rotation.z = a_jsonRotation.at("z").get<bool>();
	}
}

void Settings::DeserializeVector(const json& a_jsonVector, Settings::PlayImpactEffect::Vector& a_vector)
{
	if (a_jsonVector.contains("direction"))
	{
		const auto& jsonDirection = a_jsonVector.at("direction");
		auto&		direction = a_vector.direction;

		if (jsonDirection.contains("x"))
		{
			direction.x = jsonDirection.at("x").get<float>();
		}

		if (jsonDirection.contains("y"))
		{
			direction.y = jsonDirection.at("y").get<float>();
		}

		if (jsonDirection.contains("z"))
		{
			direction.z = jsonDirection.at("z").get<float>();
		}
	}

	if (a_jsonVector.contains("magnitude"))
	{
		a_vector.magnitude = a_jsonVector.at("magnitude").get<float>();
	}
}

std::string Settings::FormToFormID(RE::TESForm* a_form)
{
	if (!a_form)
	{
		return {};
	}

	auto file = a_form->GetFile(0);

	if (!file)
	{
		return {};
	}

	RE::FormID fileIndex = (file->compileIndex << 24) + (file->smallFileCompileIndex << 12);

	std::stringstream formID;
	formID << "0x" << std::uppercase << std::hex << (a_form->formID & ~fileIndex);

	return formID.str();
}

std::string Settings::FormToFileName(RE::TESForm* a_form)
{
	if (!a_form)
	{
		return {};
	}

	auto file = a_form->GetFile(0);

	if (!file)
	{
		return {};
	}

	return file->fileName;
}
