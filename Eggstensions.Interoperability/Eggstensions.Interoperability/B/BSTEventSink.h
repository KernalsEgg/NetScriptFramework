#pragma once

#include "NativeObject.h"



namespace Eggstensions
{
	namespace Interoperability
	{
		public enum class BSEventNotifyControl : System::Int32
		{
			Continue = 0,
			Stop = 1
		};



		namespace Unmanaged
		{
			template<class ManagedEvent, class UnmanagedEvent>
			public class BSTEventSink
			{
			public:
				BSTEventSink(System::Func<ManagedEvent^, System::IntPtr, BSEventNotifyControl>^ processEvent)
					: _processEvent(processEvent)
				{
				}

				virtual ~BSTEventSink() = default;

				virtual BSEventNotifyControl ProcessEvent(UnmanagedEvent* event, System::IntPtr eventSource)
				{
					auto processEvent = (System::Func<ManagedEvent^, System::IntPtr, BSEventNotifyControl>^)_processEvent;

					return processEvent ? processEvent(gcnew ManagedEvent(event), eventSource) : BSEventNotifyControl::Continue;
				}

			private:
				msclr::gcroot<System::Func<ManagedEvent^, System::IntPtr, BSEventNotifyControl>^> _processEvent;
			};
		}

		namespace Managed
		{
			template<class ManagedEvent, class UnmanagedEvent>
			public ref class BSTEventSink : public OwnedNativeObject<Unmanaged::BSTEventSink<ManagedEvent, UnmanagedEvent>>
			{
			public:
				BSTEventSink(System::Func<ManagedEvent^, System::IntPtr, BSEventNotifyControl>^ processEvent)
					: OwnedNativeObject(new Unmanaged::BSTEventSink<ManagedEvent, UnmanagedEvent>(processEvent))
				{
				}
			};
		}
	}
}
