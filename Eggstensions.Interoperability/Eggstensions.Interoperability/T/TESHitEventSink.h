#pragma once

#include "B\BSTEventSink.h"
#include "T\TESHitEvent.h"



namespace Eggstensions
{
	namespace Interoperability
	{
		namespace Managed
		{
			public ref class TESHitEventSink : public BSTEventSink<TESHitEvent, Unmanaged::TESHitEvent>
			{
			public:
				TESHitEventSink(System::Func<TESHitEvent^, System::IntPtr, BSEventNotifyControl>^ processEvent)
					: BSTEventSink(processEvent)
				{
				}
			};
		}
	}
}
