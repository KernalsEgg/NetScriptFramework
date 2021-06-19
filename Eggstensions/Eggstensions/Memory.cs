namespace Eggstensions
{
	[System.Flags]
	public enum MemoryProtectionFlags : System.UInt32
	{
		None					= 0U,
		PageNoAccess			= 1U << 0,
		PageReadOnly			= 1U << 1,
		PageReadWrite			= 1U << 2,
		PageWriteCopy			= 1U << 3,
		PageExecute				= 1U << 4,
		PageExecuteRead			= 1U << 5,
		PageExecuteReadWrite	= 1U << 6,
		PageExecuteWriteCopy	= 1U << 7,
		PageGuard				= 1U << 8,
		PageNoCache				= 1U << 9,
		PageWriteCombine		= 1U << 10
	}



	static public class Memory
	{
		[System.Runtime.InteropServices.DllImport("Kernel32.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
		static public extern System.Byte VirtualProtect(System.IntPtr address, System.Int32 size, MemoryProtectionFlags newMemoryProtectionFlags, out MemoryProtectionFlags oldMemoryProtectionFlags);



		static public System.Byte Int3 { get; }	= 0xCC;
		static public System.Byte Nop { get; }	= 0x90;
		static public System.Byte Ret { get; }	= 0xC3;



		unsafe static public T Read<T>(System.IntPtr address)
			where T : unmanaged
		{
			return *(T*)address.ToPointer();
		}

		static public T Read<T>(System.IntPtr address, System.Int32 offset)
			where T : unmanaged
		{
			return Memory.Read<T>(address + offset);
		}

		static public T[] ReadArray<T>(System.IntPtr address, System.Int32 length)
			where T : unmanaged
		{
			var array = new T[length];
			var size = Memory<T>.Size;

			for (System.Int32 index = 0; index < length; index++)
			{
				array[index] = Memory.Read<T>(address, size * index);
			}

			return array;
		}

		static public T[] ReadArray<T>(System.IntPtr address, System.Int32 offset, System.Int32 length)
			where T : unmanaged
		{
			return Memory.ReadArray<T>(address + offset, length);
		}

		static public System.String ReadString(System.IntPtr address)
		{
			return System.Runtime.InteropServices.Marshal.PtrToStringAnsi(address);
		}

		static public System.String ReadString(System.IntPtr address, System.Int32 offset)
		{
			return Memory.ReadString(address + offset);
		}

		static public void SafeWrite<T>(System.IntPtr address, T value)
			where T : unmanaged
		{
			var size = Memory<T>.Size;

			if (Memory.VirtualProtect(address, size, MemoryProtectionFlags.PageExecuteReadWrite, out var oldMemoryProtectionFlags) != 0)
			{
				try
				{
					Memory.Write<T>(address, value);
				}
				finally
				{
					Memory.VirtualProtect(address, size, oldMemoryProtectionFlags, out oldMemoryProtectionFlags);
				}
			}
		}

		static public void SafeWrite<T>(System.IntPtr address, System.Int32 offset, T value)
			where T : unmanaged
		{
			Memory.SafeWrite<T>(address + offset, value);
		}

		static public void SafeWriteArray<T>(System.IntPtr address, params T[] value)
			where T : unmanaged
		{
			var size = Memory<T>.Size;
			var length = value.Length;

			if (Memory.VirtualProtect(address, size * length, MemoryProtectionFlags.PageExecuteReadWrite, out var oldMemoryProtectionFlags) != 0)
			{
				try
				{
					Memory.WriteArray<T>(address, value);
				}
				finally
				{
					Memory.VirtualProtect(address, size * length, oldMemoryProtectionFlags, out oldMemoryProtectionFlags);
				}
			}
		}

		static public void SafeWriteArray<T>(System.IntPtr address, System.Int32 offset, params T[] value)
			where T : unmanaged
		{
			Memory.SafeWriteArray<T>(address + offset, value);
		}

		unsafe static public void Write<T>(System.IntPtr address, T value)
			where T : unmanaged
		{
			*(T*)address.ToPointer() = value;
		}

		static public void Write<T>(System.IntPtr address, System.Int32 offset, T value)
			where T : unmanaged
		{
			Memory.Write<T>(address + offset, value);
		}

		static public void WriteArray<T>(System.IntPtr address, params T[] value)
			where T : unmanaged
		{
			var size = Memory<T>.Size;
			var length = value.Length;

			for (System.Int32 index = 0; index < length; index++)
			{
				Memory.Write<T>(address, size * index, value[index]);
			}
		}

		static public void WriteArray<T>(System.IntPtr address, System.Int32 offset, params T[] value)
			where T : unmanaged
		{
			Memory.WriteArray<T>(address + offset, value);
		}

		static public T WriteVirtualFunction<T>(System.IntPtr address, System.Int32 index, T newVirtualFunction)
			where T : System.Delegate
		{
			var virtualFunctionAddress = address + index * Memory<System.IntPtr>.Size;
			var oldVirtualFunction = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<T>(Memory.Read<System.IntPtr>(virtualFunctionAddress));
			Memory.SafeWrite<System.IntPtr>(virtualFunctionAddress, System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(newVirtualFunction));

			return oldVirtualFunction;
		}
	}

	static public class Memory<T>
		where T : unmanaged
	{
		static public System.Int32 Size { get; } = System.Runtime.InteropServices.Marshal.SizeOf<T>();
	}
}
