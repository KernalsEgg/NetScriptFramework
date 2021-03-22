#include "BGSDecalManager.h"



void BGSDecalManager::ApplyDecal(RE::DECAL_CREATION_DATA& a_decalCreationData, bool a_forceDecal, RE::BGSDecalGroup* a_decalGroup)
{
	auto decalManager = RE::BGSDecalManager::GetSingleton();

	if (!decalManager)
	{
		return;
	}

	decalManager->unk14 = true;

	if (RE::INIPrefSettingCollection::GetSingleton()->GetSetting("bDecals:Decals")->GetBool())
	{
		auto avObject = a_decalCreationData.avObject;

		if (avObject)
		{
			auto node = avObject->AsNode();

			if (node)
			{
				RE::DECAL_APPLICATION_DATA decalApplicationData;

				decalApplicationData.decalCreationData = &a_decalCreationData;
				decalApplicationData.forceDecal = a_forceDecal || RE::INISettingCollection::GetSingleton()->GetSetting("bForceAllDecals:Decals")->GetBool();
				decalApplicationData.unk09 = a_decalCreationData.unkC0 != 0;
				decalApplicationData.decalCount = decalManager->decalCount;
				decalApplicationData.skinDecalCount = decalManager->skinDecalCount;
				decalApplicationData.skinDecalCountCurrentFrame = decalManager->skinDecalCountCurrentFrame;
				decalApplicationData.decalCountCurrentFrame = decalManager->decalCountCurrentFrame;
				decalApplicationData.unk1C = 0U;
				decalApplicationData.decalGroup = a_decalGroup;

				node->ApplyDecal(&decalApplicationData);
			}
		}
	}
}
