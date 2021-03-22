#pragma once

#include <nlohmann/json.hpp>

using json = nlohmann::json;



class Settings
{
public:
	struct PlayImpactEffect
	{
		struct Vector
		{
			RE::NiPoint3 direction;
			float		 magnitude;
		};

		struct Position
		{
			std::string						   nodeName;
			Settings::PlayImpactEffect::Vector offset;
		};

		struct Rotation
		{
			std::string nodeName;
			bool		x;
			bool		y;
			bool		z;
		};

		struct RayCast
		{
			Settings::PlayImpactEffect::Position origin{ "", { { 0.0F, 0.0F, 1.0F }, 32.0F } };
			Settings::PlayImpactEffect::Vector	 ray{ { 0.0F, 0.0F, -1.0F }, 96.0F };
			Settings::PlayImpactEffect::Rotation rotation{ "", false, false, false };
		};

		struct Decal
		{
			Settings::PlayImpactEffect::Rotation rotation{ "", false, false, true };
			bool								 force{ false };
		};

		RE::BGSImpactDataSet*				impactEffect{ nullptr };
		Settings::PlayImpactEffect::RayCast rayCast;
		Settings::PlayImpactEffect::Decal	decal;
	};

	struct Footstep
	{
		std::vector<std::string>				tags;
		std::vector<Settings::PlayImpactEffect> playImpactEffects;
	};

	struct Setting
	{
		RE::BGSConstructibleObject*		conditions;
		std::vector<Settings::Footstep> footsteps;
	};

	static std::vector<Settings::Setting>& GetSingleton();

	static std::vector<Settings::Setting> Deserialize(const json& a_jsonSettings);
	static json							  Serialize(const std::vector<Settings::Setting>& a_settings);
	static void							  Load();

private:
	static void DeserializeDecal(const json& a_jsonDecal, Settings::PlayImpactEffect::Decal& a_decal);
	static void DeserializePlayImpactEffect(const json& a_jsonPlayImpactEffect, Settings::PlayImpactEffect& a_playImpactEffect);
	static void DeserializePosition(const json& a_jsonPosition, Settings::PlayImpactEffect::Position& a_position);
	static void DeserializeRayCast(const json& a_jsonRayCast, Settings::PlayImpactEffect::RayCast& a_rayCast);
	static void DeserializeRotation(const json& a_jsonRotation, Settings::PlayImpactEffect::Rotation& a_rotation);
	static void DeserializeVector(const json& a_jsonVector, Settings::PlayImpactEffect::Vector& a_vector);

	static std::string FormToFormID(RE::TESForm* a_form);
	static std::string FormToFileName(RE::TESForm* a_form);

	template <class T>
	static T* GetFormFromFile(std::string a_formID, std::string a_fileName);
};



template <class T>
T* Settings::GetFormFromFile(std::string a_formID, std::string a_fileName)
{
	try
	{
		auto form = RE::TESDataHandler::GetSingleton()->LookupForm<T>(std::stoul(a_formID, nullptr, 16), a_fileName);

		if (!form)
		{
			SKSE::log::warn("formID: {}, fileName: {}", a_formID, a_fileName);

			return nullptr;
		}

		return form;
	}
	catch (const std::exception& exception)
	{
		SKSE::log::error("formID: {}, fileName: {}", a_formID, a_fileName);

		throw;
	}
}
