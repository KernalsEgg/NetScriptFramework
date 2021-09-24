namespace Eggstensions
{
	[System.Flags]
	public enum AllocationTypes : System.UInt32
	{
		MemCommit		= 1U << 12,
		MemReserve		= 1U << 13,
		MemReset		= 1U << 19,
		MemTopDown		= 1U << 20,
		MemWriteWatch	= 1U << 21,
		MemPhysical		= 1U << 22,
		MemResetUndo	= 1U << 24,
		MemLargePages	= 1U << 29
	}

	[System.Flags]
	public enum FreeTypes : System.UInt32
	{
		MemCoalescePlaceholders	= 1U << 0,
		MemPreservePlaceholder	= 1U << 1,
		MemDecommit				= 1U << 14,
		MemRelease				= 1U << 15
	}

	[System.Flags]
	public enum MemoryProtectionConstants : System.UInt32
	{
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
		PageWriteCombine		= 1U << 10,
		PageTargetsInvalid		= 1U << 30,
		PageTargetsNoUpdate		= 1U << 30
	}



	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x30)]
	public struct MemoryBasicInformation
	{
		[System.Flags]
		public enum States : System.UInt32
		{
			MemCommit	= 1U << 12,
			MemReserve	= 1U << 13,
			MemFree		= 1U << 16
		}

		[System.Flags]
		public enum Types : System.UInt32
		{
			MemPrivate	= 1U << 17,
			MemMapped	= 1U << 18,
			MemImage	= 1U << 24
		}



		[System.Runtime.InteropServices.FieldOffset(0x0)] public System.IntPtr BaseAddress;
		[System.Runtime.InteropServices.FieldOffset(0x8)] public System.IntPtr AllocationBase;
		[System.Runtime.InteropServices.FieldOffset(0x10)] public System.UInt32 AllocationProtect;
		[System.Runtime.InteropServices.FieldOffset(0x14)] public System.UInt16 PartitionId;
		[System.Runtime.InteropServices.FieldOffset(0x18)] public System.IntPtr RegionSize;
		[System.Runtime.InteropServices.FieldOffset(0x20)] public MemoryBasicInformation.States State;
		[System.Runtime.InteropServices.FieldOffset(0x24)] public System.UInt32 Protect;
		[System.Runtime.InteropServices.FieldOffset(0x28)] public MemoryBasicInformation.Types Type;
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x30)]
	public struct SystemInfo
	{
		[System.Runtime.InteropServices.FieldOffset(0x0)] public System.UInt16 ProcessorArchitecture;
		[System.Runtime.InteropServices.FieldOffset(0x2)] public System.UInt16 Reserved;
		[System.Runtime.InteropServices.FieldOffset(0x4)] public System.UInt32 PageSize;
		[System.Runtime.InteropServices.FieldOffset(0x8)] public System.IntPtr MinimumApplicationAddress;
		[System.Runtime.InteropServices.FieldOffset(0x10)] public System.IntPtr MaximumApplicationAddress;
		[System.Runtime.InteropServices.FieldOffset(0x18)] public System.IntPtr ActiveProcessorMask; // System.UInt32*
		[System.Runtime.InteropServices.FieldOffset(0x20)] public System.UInt32 NumberOfProcessors;
		[System.Runtime.InteropServices.FieldOffset(0x24)] public System.UInt32 ProcessorType;
		[System.Runtime.InteropServices.FieldOffset(0x28)] public System.UInt32 AllocationGranularity;
		[System.Runtime.InteropServices.FieldOffset(0x2C)] public System.UInt16 ProcessorLevel;
		[System.Runtime.InteropServices.FieldOffset(0x2E)] public System.UInt16 ProcessorRevision;
	}



	unsafe static public class Memory
	{
		[System.Runtime.InteropServices.DllImport("Kernel32.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError = true)]
		static public extern void GetSystemInfo(out SystemInfo systemInfo);

		[System.Runtime.InteropServices.DllImport("Msvcrt.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl, EntryPoint = "memcmp")]
		static public extern System.Int32 MemCmp(System.IntPtr buffer1, System.IntPtr buffer2, System.IntPtr count);

		[System.Runtime.InteropServices.DllImport("Msvcrt.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl, EntryPoint = "memset")]
		static public extern void MemSet(System.IntPtr destination, System.Int32 character, System.IntPtr count);

		[System.Runtime.InteropServices.DllImport("Kernel32.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError = true)]
		static public extern System.IntPtr VirtualAlloc(System.IntPtr address, System.IntPtr size, AllocationTypes allocationType, MemoryProtectionConstants protect);

		[System.Runtime.InteropServices.DllImport("Kernel32.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError = true)]
		static public extern System.Byte VirtualFree(System.IntPtr address, System.IntPtr size, FreeTypes freeType);

		[System.Runtime.InteropServices.DllImport("Kernel32.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError = true)]
		static public extern System.Byte VirtualProtect(System.IntPtr address, System.IntPtr size, MemoryProtectionConstants newProtect, out MemoryProtectionConstants oldProtect);

		[System.Runtime.InteropServices.DllImport("Kernel32.dll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError = true)]
		static public extern System.IntPtr VirtualQuery(System.IntPtr address, out MemoryBasicInformation buffer, System.IntPtr length);



		static public System.Boolean Compare<T>(System.IntPtr address, T value)
			where T : unmanaged, System.IEquatable<T>
		{
			return Memory.Read<T>(address).Equals(value);
		}

		static public System.Boolean Compare<T>(System.IntPtr address, System.Int32 offset, T value)
			where T : unmanaged, System.IEquatable<T>
		{
			return Memory.Compare<T>(address + offset, value);
		}

		static public System.Boolean Compare<T>(System.IntPtr address, T[] values)
			where T : unmanaged, System.IEquatable<T>
		{
			var length	= values.Length;
			var size	= System.Runtime.CompilerServices.Unsafe.SizeOf<T>();

			for (var index = 0; index < length; index++)
			{
				if (!Memory.Compare<T>(address, size * index, values[index]))
				{
					return false;
				}
			}

			return true;
		}

		static public System.Boolean Compare<T>(System.IntPtr address, System.Int32 offset, T[] values)
			where T : unmanaged, System.IEquatable<T>
		{
			return Memory.Compare<T>(address + offset, values);
		}

		static public System.Boolean Compare<T>(System.IntPtr address, T?[] values)
			where T : unmanaged, System.IEquatable<T>
		{
			var length	= values.Length;
			var size	= System.Runtime.CompilerServices.Unsafe.SizeOf<T>();

			for (var index = 0; index < length; index++)
			{
				var value = values[index];
				
				if (value.HasValue)
				{
					if (!Memory.Compare<T>(address, size * index, value.Value))
					{
						return false;
					}
				}
			}

			return true;
		}

		static public System.Boolean Compare<T>(System.IntPtr address, System.Int32 offset, T?[] values)
			where T : unmanaged, System.IEquatable<T>
		{
			return Memory.Compare<T>(address + offset, values);
		}

		static public TTo ConvertTo<TFrom, TTo>(TFrom value)
			where TFrom : unmanaged
			where TTo : unmanaged
		{
			return *(TTo*)&value;
		}

		static public TTo[] ConvertToArray<TFrom, TTo>(TFrom value)
			where TFrom : unmanaged
			where TTo : unmanaged
		{
			var length	= System.Runtime.CompilerServices.Unsafe.SizeOf<TFrom>() / System.Runtime.CompilerServices.Unsafe.SizeOf<TTo>();
			var array	= new TTo[length];
			var pointer	= (TTo*)&value;

			for (var index = 0; index < length; index++)
			{
				array[index] = pointer[index];
			}

			return array;
		}

		static public TTo[] ConvertToArray<TFrom, TTo>(TFrom[] values)
			where TFrom : unmanaged
			where TTo : unmanaged
		{
			var length	= (System.Runtime.CompilerServices.Unsafe.SizeOf<TFrom>() * values.Length) / System.Runtime.CompilerServices.Unsafe.SizeOf<TTo>();
			var array	= new TTo[length];

			fixed (TFrom* fromPointer = values)
			{
				var toPointer = (TTo*)fromPointer;

				for (var index = 0; index < length; index++)
				{
					array[index] = toPointer[index];
				}
			}

			return array;
		}

		static public void Fill<T>(System.IntPtr address, System.Int32 count, T value)
			where T : unmanaged
		{
			var size = System.Runtime.CompilerServices.Unsafe.SizeOf<T>();
			
			for (var index = 0; index < count; index++)
			{
				Memory.Write<T>(address, size * index, value);
			}
		}

		static public void Fill<T>(System.IntPtr address, System.Int32 offset, System.Int32 count, T value)
			where T : unmanaged
		{
			Memory.Fill<T>(address + offset, count, value);
		}

		static public System.Diagnostics.ProcessModule GetProcessModule(System.String moduleName)
		{
			foreach (System.Diagnostics.ProcessModule processModule in System.Diagnostics.Process.GetCurrentProcess().Modules)
			{
				if (moduleName.Equals(processModule.ModuleName, System.StringComparison.OrdinalIgnoreCase))
				{
					return processModule;
				}
			}

			return null;
		}

		static public T Read<T>(System.IntPtr address)
			where T : unmanaged
		{
			return *(T*)address;
		}

		static public T Read<T>(System.IntPtr address, System.Int32 offset)
			where T : unmanaged
		{
			return Memory.Read<T>(address + offset);
		}

		static public T[] ReadArray<T>(System.IntPtr address, System.Int32 length)
			where T : unmanaged
		{
			var array	= new T[length];
			var size	= System.Runtime.CompilerServices.Unsafe.SizeOf<T>();

			for (var index = 0; index < length; index++)
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

		static public ref T ReadReference<T>(System.IntPtr address)
			where T : unmanaged
		{
			return ref *(T*)address;
		}

		static public ref T ReadReference<T>(System.IntPtr address, System.Int32 offset)
			where T : unmanaged
		{
			return ref Memory.ReadReference<T>(address + offset);
		}

		static public void* ReadRelativeCall(System.IntPtr address)
		{
			return (address + Memory.Read<RelativeCall>(address).Relative32 + System.Runtime.CompilerServices.Unsafe.SizeOf<RelativeCall>()).ToPointer();
		}

		static public void* ReadRelativeCall(System.IntPtr address, System.Int32 offset)
		{
			return Memory.ReadRelativeCall(address + offset);
		}

		static public void* ReadRelativeJump(System.IntPtr address)
		{
			return (address + Memory.Read<RelativeJump>(address).Relative32 + System.Runtime.CompilerServices.Unsafe.SizeOf<RelativeJump>()).ToPointer();
		}

		static public void* ReadRelativeJump(System.IntPtr address, System.Int32 offset)
		{
			return Memory.ReadRelativeJump(address + offset);
		}

		static public System.String ReadString(System.IntPtr address)
		{
			return System.Runtime.InteropServices.Marshal.PtrToStringAnsi(address);
		}

		static public System.String ReadString(System.IntPtr address, System.Int32 offset)
		{
			return Memory.ReadString(address + offset);
		}

		static public void* ReadVirtualFunction(System.IntPtr address, System.Int32 index)
		{
			return ((System.IntPtr*)address)[index].ToPointer();
		}

		static public void SafeFill<T>(System.IntPtr address, System.Int32 count, T value)
			where T : unmanaged
		{
			var size = new System.IntPtr(System.Runtime.CompilerServices.Unsafe.SizeOf<T>() * count);

			if (Memory.VirtualProtect(address, size, MemoryProtectionConstants.PageExecuteReadWrite, out var oldProtect) != 0)
			{
				try
				{
					Memory.Fill<T>(address, count, value);
				}
				finally
				{
					Memory.VirtualProtect(address, size, oldProtect, out oldProtect);
				}
			}
		}

		static public void SafeFill<T>(System.IntPtr address, System.Int32 offset, System.Int32 count, T value)
			where T : unmanaged
		{
			Memory.SafeFill<T>(address + offset, count, value);
		}

		static public void SafeWrite<T>(System.IntPtr address, T value)
			where T : unmanaged
		{
			var size = new System.IntPtr(System.Runtime.CompilerServices.Unsafe.SizeOf<T>());

			if (Memory.VirtualProtect(address, size, MemoryProtectionConstants.PageExecuteReadWrite, out var oldProtect) != 0)
			{
				try
				{
					Memory.Write<T>(address, value);
				}
				finally
				{
					Memory.VirtualProtect(address, size, oldProtect, out oldProtect);
				}
			}
		}

		static public void SafeWrite<T>(System.IntPtr address, System.Int32 offset, T value)
			where T : unmanaged
		{
			Memory.SafeWrite<T>(address + offset, value);
		}

		static public void SafeWrite<T>(System.IntPtr address, T[] values)
			where T : unmanaged
		{
			var size = new System.IntPtr(System.Runtime.CompilerServices.Unsafe.SizeOf<T>() * values.Length);

			if (Memory.VirtualProtect(address, size, MemoryProtectionConstants.PageExecuteReadWrite, out var oldProtect) != 0)
			{
				try
				{
					Memory.Write<T>(address, values);
				}
				finally
				{
					Memory.VirtualProtect(address, size, oldProtect, out oldProtect);
				}
			}
		}

		static public void SafeWrite<T>(System.IntPtr address, System.Int32 offset, T[] values)
			where T : unmanaged
		{
			Memory.SafeWrite<T>(address + offset, values);
		}

		static public void SafeWrite<T>(System.IntPtr address, T?[] values)
			where T : unmanaged
		{
			var size = new System.IntPtr(System.Runtime.CompilerServices.Unsafe.SizeOf<T>() * values.Length);

			if (Memory.VirtualProtect(address, size, MemoryProtectionConstants.PageExecuteReadWrite, out var oldProtect) != 0)
			{
				try
				{
					Memory.Write<T>(address, values);
				}
				finally
				{
					Memory.VirtualProtect(address, size, oldProtect, out oldProtect);
				}
			}
		}

		static public void SafeWrite<T>(System.IntPtr address, System.Int32 offset, T?[] values)
			where T : unmanaged
		{
			Memory.SafeWrite<T>(address + offset, values);
		}

		static public void Write<T>(System.IntPtr address, T value)
			where T : unmanaged
		{
			*(T*)address = value;
		}

		static public void Write<T>(System.IntPtr address, System.Int32 offset, T value)
			where T : unmanaged
		{
			Memory.Write<T>(address + offset, value);
		}

		static public void Write<T>(System.IntPtr address, T? value)
			where T : unmanaged
		{
			if (value.HasValue)
			{
				Memory.Write<T>(address, value.Value);
			}
		}

		static public void Write<T>(System.IntPtr address, System.Int32 offset, T? value)
			where T : unmanaged
		{
			Memory.Write<T>(address + offset, value);
		}

		static public void Write<T>(System.IntPtr address, T[] values)
			where T : unmanaged
		{
			var length	= values.Length;
			var size	= System.Runtime.CompilerServices.Unsafe.SizeOf<T>();

			for (var index = 0; index < length; index++)
			{
				Memory.Write<T>(address, size * index, values[index]);
			}
		}

		static public void Write<T>(System.IntPtr address, System.Int32 offset, T[] values)
			where T : unmanaged
		{
			Memory.Write<T>(address + offset, values);
		}

		static public void Write<T>(System.IntPtr address, T?[] values)
			where T : unmanaged
		{
			var length	= values.Length;
			var size	= System.Runtime.CompilerServices.Unsafe.SizeOf<T>();

			for (var index = 0; index < length; index++)
			{
				Memory.Write<T>(address, size * index, values[index]);
			}
		}

		static public void Write<T>(System.IntPtr address, System.Int32 offset, T?[] values)
			where T : unmanaged
		{
			Memory.Write<T>(address + offset, values);
		}

		static public void WriteRelativeCall(System.IntPtr address, void* function)
		{
			Memory.SafeWrite<RelativeCall>(address, Assembly.RelativeCall(address, function));
		}

		static public void WriteRelativeCall(System.IntPtr address, System.Int32 offset, void* function)
		{
			Memory.WriteRelativeCall(address + offset, function);
		}

		static public void WriteRelativeJump(System.IntPtr address, void* function)
		{
			Memory.SafeWrite<RelativeJump>(address, Assembly.RelativeJump(address, function));
		}

		static public void WriteRelativeJump(System.IntPtr address, System.Int32 offset, void* function)
		{
			Memory.WriteRelativeJump(address + offset, function);
		}

		static public void WriteVirtualFunction(System.IntPtr address, System.Int32 index, void* virtualFunction)
		{
			Memory.SafeWrite<System.IntPtr>(address, System.Runtime.CompilerServices.Unsafe.SizeOf<System.IntPtr>() * index, new System.IntPtr(virtualFunction));
		}
	}
}
