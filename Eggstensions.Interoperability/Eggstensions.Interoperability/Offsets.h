#pragma once



namespace Eggstensions
{
	namespace Interoperability
	{
		namespace Offsets
		{
			namespace Events
			{
				/// <summary>SkyrimSE.exe + 0x99CB0</summary>
				const System::IntPtr AddActorValueEventSinks = NetScriptFramework::Main::GameInfo->GetAddressOf(5998, 0, 0, nullptr);

				/// <summary>SkyrimSE.exe + 0x92C260</summary>
				const System::IntPtr AddScriptEventSinks = NetScriptFramework::Main::GameInfo->GetAddressOf(53216, 0, 0, nullptr);
			}
		}
	}
}
