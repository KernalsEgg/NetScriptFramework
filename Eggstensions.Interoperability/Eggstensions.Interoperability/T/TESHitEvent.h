#pragma once

#include "NativeObject.h"



namespace Eggstensions
{
	namespace Interoperability
	{
		public enum class TESHitEventFlags : System::Byte
		{
			None = 0,
			PowerAttack = 1 << 0,
			SneakAttack = 1 << 1,
			BashAttack = 1 << 2,
			HitBlocked = 1 << 3
		};



		namespace Unmanaged
		{
			public struct TESHitEvent
			{
				System::IntPtr		target;		// 0
				System::IntPtr		cause;		// 8
				FormID				source;		// 10
				FormID				projectile;	// 14
				TESHitEventFlags	flags;		// 18
				System::Byte		pad19;		// 19
				System::UInt16		pad1A;		// 1A
				System::UInt32		pad1C;		// 1C
			};
			static_assert(offsetof(TESHitEvent, target)		== 0x0);
			static_assert(offsetof(TESHitEvent, cause)		== 0x8);
			static_assert(offsetof(TESHitEvent, source)		== 0x10);
			static_assert(offsetof(TESHitEvent, projectile)	== 0x14);
			static_assert(offsetof(TESHitEvent, flags)		== 0x18);
			static_assert(offsetof(TESHitEvent, pad19)		== 0x19);
			static_assert(offsetof(TESHitEvent, pad1A)		== 0x1A);
			static_assert(offsetof(TESHitEvent, pad1C)		== 0x1C);
			static_assert(sizeof(TESHitEvent) == 0x20);
		}

		namespace Managed
		{
			public ref class TESHitEvent : public UnownedNativeObject<Unmanaged::TESHitEvent>
			{
			public:
				TESHitEvent(Unmanaged::TESHitEvent* hitEvent)
					: UnownedNativeObject(hitEvent)
				{
				}

				property System::IntPtr Target
				{
					System::IntPtr get()
					{
						return NativeObject->target;
					}
				}

				property System::IntPtr Cause
				{
					System::IntPtr get()
					{
						return NativeObject->cause;
					}
				}

				property FormID Source
				{
					FormID get()
					{
						return NativeObject->source;
					}
				}

				property FormID Projectile
				{
					FormID get()
					{
						return NativeObject->projectile;
					}
				}

				property TESHitEventFlags Flags
				{
					TESHitEventFlags get()
					{
						return NativeObject->flags;
					}
				}
			};
		}
	}
}
