#pragma once

#include "NativeObject.h"



namespace Eggstensions
{
	namespace Interoperability
	{
		namespace Unmanaged
		{
			public class Memory
			{
			public:
				template<class Function, class... Arguments>
				static decltype(auto) Forward(Function function, Arguments&&... arguments)
				{
					return function(std::forward<Arguments>(arguments)...);
				}

				template<class Return, class... Arguments>
				static Return Invoke(void* functionAddress, Arguments... arguments)
				{
					const auto function = static_cast<decltype(std::addressof(Memory::Function<Return, Arguments...>))>(functionAddress);

					return Memory::Forward(function, arguments...);
				}

				static bool VirtualProtect(void* address, std::size_t size, std::uint32_t newProtect, std::uint32_t* oldProtect) noexcept
				{
					return static_cast<bool>(::VirtualProtect(static_cast<::LPVOID>(address), static_cast<::SIZE_T>(size), static_cast<::DWORD>(newProtect), reinterpret_cast<::PDWORD>(oldProtect)));
				}

			private:
				template<class Return, class... Arguments>
				static Return Function(Arguments... arguments)
				{
				}
			};
		}

		namespace Managed
		{
			template<class T>
			public ref class ValueType : public OwnedNativeObject<T>
			{
			public:
				ValueType(T value)
					: OwnedNativeObject(new T)
				{
					Value = value;
				}



				property T Value
				{
					T get()
					{
						return *NativeObject;
					}
					void set(T value)
					{
						*NativeObject = value;
					}
				}
			};

			public ref class Memory
			{
			public:
				static property System::Byte Int3
				{
					System::Byte get()
					{
						return 0xCC;
					}
				}

				static property System::Byte Nop
				{
					System::Byte get()
					{
						return 0x90;
					}
				}

				static property System::Byte Ret
				{
					System::Byte get()
					{
						return 0xC3;
					}
				}
				
				
				
				template<class T>
				static ValueType<T>^ Initialize(T value)
				{
					return gcnew ValueType<T>(value);
				}

				static ValueType<System::Boolean>^ InitializeBoolean()
				{
					return Memory::InitializeBoolean(false);
				}

				static ValueType<System::Boolean>^ InitializeBoolean(System::Boolean value)
				{
					return Memory::Initialize<System::Boolean>(value);
				}

				static ValueType<System::Byte>^ InitializeByte()
				{
					return Memory::InitializeByte(0U);
				}

				static ValueType<System::Byte>^ InitializeByte(System::Byte value)
				{
					return Memory::Initialize<System::Byte>(value);
				}

				static ValueType<System::Double>^ InitializeDouble()
				{
					return Memory::InitializeDouble(0.0);
				}

				static ValueType<System::Double>^ InitializeDouble(System::Double value)
				{
					return Memory::Initialize<System::Double>(value);
				}

				static ValueType<System::Int16>^ InitializeInt16()
				{
					return Memory::InitializeInt16(0);
				}

				static ValueType<System::Int16>^ InitializeInt16(System::Int16 value)
				{
					return Memory::Initialize<System::Int16>(value);
				}

				static ValueType<System::Int32>^ InitializeInt32()
				{
					return Memory::InitializeInt32(0);
				}

				static ValueType<System::Int32>^ InitializeInt32(System::Int32 value)
				{
					return Memory::Initialize<System::Int32>(value);
				}

				static ValueType<System::Int64>^ InitializeInt64()
				{
					return Memory::InitializeInt64(0L);
				}

				static ValueType<System::Int64>^ InitializeInt64(System::Int64 value)
				{
					return Memory::Initialize<System::Int64>(value);
				}

				static ValueType<System::IntPtr>^ InitializeIntPtr()
				{
					return Memory::InitializeIntPtr(System::IntPtr::Zero);
				}

				static ValueType<System::IntPtr>^ InitializeIntPtr(System::IntPtr value)
				{
					return Memory::Initialize<System::IntPtr>(value);
				}

				static ValueType<System::SByte>^ InitializeSByte()
				{
					return Memory::InitializeSByte(0);
				}

				static ValueType<System::SByte>^ InitializeSByte(System::SByte value)
				{
					return Memory::Initialize<System::SByte>(value);
				}

				static ValueType<System::Single>^ InitializeSingle()
				{
					return Memory::InitializeSingle(0.0F);
				}

				static ValueType<System::Single>^ InitializeSingle(System::Single value)
				{
					return Memory::Initialize<System::Single>(value);
				}

				static ValueType<System::UInt16>^ InitializeUInt16()
				{
					return Memory::InitializeUInt16(0U);
				}

				static ValueType<System::UInt16>^ InitializeUInt16(System::UInt16 value)
				{
					return Memory::Initialize<System::UInt16>(value);
				}

				static ValueType<System::UInt32>^ InitializeUInt32()
				{
					return Memory::InitializeUInt32(0U);
				}

				static ValueType<System::UInt32>^ InitializeUInt32(System::UInt32 value)
				{
					return Memory::Initialize<System::UInt32>(value);
				}

				static ValueType<System::UInt64>^ InitializeUInt64()
				{
					return Memory::InitializeUInt64(0UL);
				}

				static ValueType<System::UInt64>^ InitializeUInt64(System::UInt64 value)
				{
					return Memory::Initialize<System::UInt64>(value);
				}

				template<class T>
				static T Read(System::IntPtr address)
				{
					auto result = static_cast<T*>(address.ToPointer());

					return *result;
				}

				static System::Boolean ReadBoolean(System::IntPtr address)
				{
					return Memory::Read<System::Boolean>(address);
				}

				static System::Boolean ReadBoolean(System::IntPtr address, System::Int32 offset)
				{
					return Memory::ReadBoolean(address + offset);
				}

				static System::Byte ReadByte(System::IntPtr address)
				{
					return Memory::Read<System::Byte>(address);
				}

				static System::Byte ReadByte(System::IntPtr address, System::Int32 offset)
				{
					return Memory::ReadByte(address + offset);
				}

				static System::Double ReadDouble(System::IntPtr address)
				{
					return Memory::Read<System::Double>(address);
				}

				static System::Double ReadDouble(System::IntPtr address, System::Int32 offset)
				{
					return Memory::ReadDouble(address + offset);
				}

				static System::Int16 ReadInt16(System::IntPtr address)
				{
					return Memory::Read<System::Int16>(address);
				}

				static System::Int16 ReadInt16(System::IntPtr address, System::Int32 offset)
				{
					return Memory::ReadInt16(address + offset);
				}

				static System::Int32 ReadInt32(System::IntPtr address)
				{
					return Memory::Read<System::Int32>(address);
				}

				static System::Int32 ReadInt32(System::IntPtr address, System::Int32 offset)
				{
					return Memory::ReadInt32(address + offset);
				}

				static System::Int64 ReadInt64(System::IntPtr address)
				{
					return Memory::Read<System::Int64>(address);
				}

				static System::Int64 ReadInt64(System::IntPtr address, System::Int32 offset)
				{
					return Memory::ReadInt64(address + offset);
				}

				static System::IntPtr ReadIntPtr(System::IntPtr address)
				{
					return Memory::Read<System::IntPtr>(address);
				}

				static System::IntPtr ReadIntPtr(System::IntPtr address, System::Int32 offset)
				{
					return Memory::ReadIntPtr(address + offset);
				}

				static System::SByte ReadSByte(System::IntPtr address)
				{
					return Memory::Read<System::SByte>(address);
				}

				static System::SByte ReadSByte(System::IntPtr address, System::Int32 offset)
				{
					return Memory::ReadSByte(address + offset);
				}

				static System::Single ReadSingle(System::IntPtr address)
				{
					return Memory::Read<System::Single>(address);
				}

				static System::Single ReadSingle(System::IntPtr address, System::Int32 offset)
				{
					return Memory::ReadSingle(address + offset);
				}

				static System::UInt16 ReadUInt16(System::IntPtr address)
				{
					return Memory::Read<System::UInt16>(address);
				}

				static System::UInt16 ReadUInt16(System::IntPtr address, System::Int32 offset)
				{
					return Memory::ReadUInt16(address + offset);
				}

				static System::UInt32 ReadUInt32(System::IntPtr address)
				{
					return Memory::Read<System::UInt32>(address);
				}

				static System::UInt32 ReadUInt32(System::IntPtr address, System::Int32 offset)
				{
					return Memory::ReadUInt32(address + offset);
				}

				static System::UInt64 ReadUInt64(System::IntPtr address)
				{
					return Memory::Read<System::UInt64>(address);
				}

				static System::UInt64 ReadUInt64(System::IntPtr address, System::Int32 offset)
				{
					return Memory::ReadUInt64(address + offset);
				}

				template<class T>
				static void SafeWriteArray(System::IntPtr address, array<T>^ value)
				{
					System::UInt32 oldProtect{ 0 };
					System::Int32 size{ System::Runtime::InteropServices::Marshal::SizeOf<T>() * value->Length };

					if (Unmanaged::Memory::VirtualProtect(address.ToPointer(), size, PAGE_EXECUTE_READWRITE, std::addressof(oldProtect)) != 0)
					{
						try
						{
							System::Runtime::InteropServices::Marshal::Copy(value, 0, address, value->Length);
						}
						finally
						{
							Unmanaged::Memory::VirtualProtect(address.ToPointer(), size, oldProtect, std::addressof(oldProtect));
						}
					}
				}

				static void SafeWriteByteArray(System::IntPtr address, array<System::Byte>^ value)
				{
					Memory::SafeWriteArray<System::Byte>(address, value);
				}

				static void SafeWriteDoubleArray(System::IntPtr address, array<System::Double>^ value)
				{
					Memory::SafeWriteArray<System::Double>(address, value);
				}

				static void SafeWriteInt16Array(System::IntPtr address, array<System::Int16>^ value)
				{
					Memory::SafeWriteArray<System::Int16>(address, value);
				}

				static void SafeWriteInt32Array(System::IntPtr address, array<System::Int32>^ value)
				{
					Memory::SafeWriteArray<System::Int32>(address, value);
				}

				static void SafeWriteInt64Array(System::IntPtr address, array<System::Int64>^ value)
				{
					Memory::SafeWriteArray<System::Int64>(address, value);
				}

				static void SafeWriteIntPtrArray(System::IntPtr address, array<System::IntPtr>^ value)
				{
					Memory::SafeWriteArray<System::IntPtr>(address, value);
				}

				static void SafeWriteNopArray(System::IntPtr address, System::Int32 length)
				{
					auto bytes = gcnew array<System::Byte>(length);

					for (auto index = 0; index < length; index++)
					{
						bytes[index] = Memory::Nop;
					}

					Memory::SafeWriteArray<System::Byte>(address, bytes);
				}

				static void SafeWriteSingleArray(System::IntPtr address, array<System::Single>^ value)
				{
					Memory::SafeWriteArray<System::Single>(address, value);
				}

				template<class T>
				static void Write(System::IntPtr address, T value)
				{
					auto pointer = static_cast<T*>(address.ToPointer());

					*pointer = value;
				}

				static void WriteBoolean(System::IntPtr address, System::Boolean value)
				{
					Memory::Write<System::Boolean>(address, value);
				}

				static void WriteBoolean(System::IntPtr address, System::Int32 offset, System::Boolean value)
				{
					Memory::WriteBoolean(address + offset, value);
				}

				static void WriteByte(System::IntPtr address, System::Byte value)
				{
					Memory::Write<System::Byte>(address, value);
				}

				static void WriteByte(System::IntPtr address, System::Int32 offset, System::Byte value)
				{
					Memory::WriteByte(address + offset, value);
				}

				static void WriteDouble(System::IntPtr address, System::Double value)
				{
					Memory::Write<System::Double>(address, value);
				}

				static void WriteDouble(System::IntPtr address, System::Int32 offset, System::Double value)
				{
					Memory::WriteDouble(address + offset, value);
				}

				static void WriteInt16(System::IntPtr address, System::Int16 value)
				{
					Memory::Write<System::Int16>(address, value);
				}

				static void WriteInt16(System::IntPtr address, System::Int32 offset, System::Int16 value)
				{
					Memory::WriteInt16(address + offset, value);
				}

				static void WriteInt32(System::IntPtr address, System::Int32 value)
				{
					Memory::Write<System::Int32>(address, value);
				}

				static void WriteInt32(System::IntPtr address, System::Int32 offset, System::Int32 value)
				{
					Memory::WriteInt32(address + offset, value);
				}

				static void WriteInt64(System::IntPtr address, System::Int64 value)
				{
					Memory::Write<System::Int64>(address, value);
				}

				static void WriteInt64(System::IntPtr address, System::Int32 offset, System::Int64 value)
				{
					Memory::WriteInt64(address + offset, value);
				}

				static void WriteIntPtr(System::IntPtr address, System::IntPtr value)
				{
					Memory::Write<System::IntPtr>(address, value);
				}

				static void WriteIntPtr(System::IntPtr address, System::Int32 offset, System::IntPtr value)
				{
					Memory::WriteIntPtr(address + offset, value);
				}

				static void WriteSByte(System::IntPtr address, System::SByte value)
				{
					Memory::Write<System::SByte>(address, value);
				}

				static void WriteSByte(System::IntPtr address, System::Int32 offset, System::SByte value)
				{
					Memory::WriteSByte(address + offset, value);
				}

				static void WriteSingle(System::IntPtr address, System::Single value)
				{
					Memory::Write<System::Single>(address, value);
				}

				static void WriteSingle(System::IntPtr address, System::Int32 offset, System::Single value)
				{
					Memory::WriteSingle(address + offset, value);
				}

				static void WriteUInt16(System::IntPtr address, System::UInt16 value)
				{
					Memory::Write<System::UInt16>(address, value);
				}

				static void WriteUInt16(System::IntPtr address, System::Int32 offset, System::UInt16 value)
				{
					Memory::WriteUInt16(address + offset, value);
				}

				static void WriteUInt32(System::IntPtr address, System::UInt32 value)
				{
					Memory::Write<System::UInt32>(address, value);
				}

				static void WriteUInt32(System::IntPtr address, System::Int32 offset, System::UInt32 value)
				{
					Memory::WriteUInt32(address + offset, value);
				}

				static void WriteUInt64(System::IntPtr address, System::UInt64 value)
				{
					Memory::Write<System::UInt64>(address, value);
				}

				static void WriteUInt64(System::IntPtr address, System::Int32 offset, System::UInt64 value)
				{
					Memory::WriteUInt64(address + offset, value);
				}
			};
		}
	}
}
