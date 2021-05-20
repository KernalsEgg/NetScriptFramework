#pragma once

#include "Offsets.h"



namespace Eggstensions
{
	namespace Interoperability
	{
		namespace Events
		{
			public ref class AddActorValueEventSinks
			{
			public:
				static AddActorValueEventSinks()
				{
					auto hookParameters = gcnew NetScriptFramework::HookParameters();
					hookParameters->Address = Offsets::Events::AddActorValueEventSinks + 0xF;
					hookParameters->Pattern = "48 83 C4 28" + "C3";
					hookParameters->ReplaceLength = 4 + 1; // 5
					hookParameters->IncludeLength = 4 + 1; // 5
					hookParameters->Before = gcnew System::Action<NetScriptFramework::CPURegisters^>(&AddActorValueEventSinks::Before);

					NetScriptFramework::Memory::WriteHook(hookParameters);
				}



				static event System::EventHandler<System::EventArgs^>^ Handler;

			private:
				static System::Object^ _lock = gcnew System::Object();



				static void Before(NetScriptFramework::CPURegisters^ registers)
				{
					AddActorValueEventSinks::Raise(System::EventArgs::Empty);
				}

				static void Raise(System::EventArgs^ eventArguments)
				{
					msclr::lock lock(_lock);
					AddActorValueEventSinks::Handler(nullptr, eventArguments);
				}
			};
			
			public ref class AddHitEventSink
			{
			public:
				static AddHitEventSink()
				{
					auto hookParameters = gcnew NetScriptFramework::HookParameters();
					hookParameters->Address = Offsets::Events::AddScriptEventSinks + 0x25E;
					hookParameters->Pattern = "E8 ?? ?? ?? ??";
					hookParameters->ReplaceLength = 5;
					hookParameters->IncludeLength = 5;
					hookParameters->After = gcnew System::Action<NetScriptFramework::CPURegisters^>(&AddHitEventSink::After);

					NetScriptFramework::Memory::WriteHook(hookParameters);
				}



				static event System::EventHandler<System::EventArgs^>^ Handler;

			private:
				static System::Object^ _lock = gcnew System::Object();


				
				static void After(NetScriptFramework::CPURegisters^ registers)
				{
					AddHitEventSink::Raise(System::EventArgs::Empty);
				}

				static void Raise(System::EventArgs^ eventArguments)
				{
					msclr::lock lock(_lock);
					AddHitEventSink::Handler(nullptr, eventArguments);
				}
			};
		}
	}
}
