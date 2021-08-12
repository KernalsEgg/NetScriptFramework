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



	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Size = 0x30)]
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



		public System.IntPtr BaseAddress;			// 0x0
		public System.IntPtr AllocationBase;		// 0x8
		public System.UInt32 AllocationProtect;		// 0x10
		public System.UInt16 PartitionId;			// 0x14
		public System.IntPtr RegionSize;			// 0x18
		public MemoryBasicInformation.States State;	// 0x20
		public System.UInt32 Protect;				// 0x24
		public MemoryBasicInformation.Types Type;	// 0x28
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Size = 0x30)]
	public struct SystemInfo
	{
		public System.UInt16 ProcessorArchitecture;		// 0x0
		public System.UInt16 Reserved;					// 0x2
		public System.UInt32 PageSize;					// 0x4
		public System.IntPtr MinimumApplicationAddress;	// 0x8
		public System.IntPtr MaximumApplicationAddress;	// 0x10
		public System.IntPtr ActiveProcessorMask;		// 0x18 (System.UInt32*)
		public System.UInt32 NumberOfProcessors;		// 0x20
		public System.UInt32 ProcessorType;				// 0x24
		public System.UInt32 AllocationGranularity;		// 0x28
		public System.UInt16 ProcessorLevel;			// 0x2C
		public System.UInt16 ProcessorRevision;			// 0x2E
	}



	static public class Memory
	{
		static public class Size<T>
			where T : unmanaged
		{
			unsafe static public System.Int32 Managed { get; }	= sizeof(T);
			static public System.Int32 Unmanaged { get; }		= System.Runtime.InteropServices.Marshal.SizeOf<T>();
		}



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

		static public System.Boolean CompareArray<T>(System.IntPtr address, T[] values)
			where T : unmanaged, System.IEquatable<T>
		{
			var length	= values.Length;
			var size	= Memory.Size<T>.Unmanaged;

			for (var index = 0; index < length; index++)
			{
				if (!Memory.Compare<T>(address, size * index, values[index]))
				{
					return false;
				}
			}

			return true;
		}

		static public System.Boolean CompareArray<T>(System.IntPtr address, System.Int32 offset, T[] values)
			where T : unmanaged, System.IEquatable<T>
		{
			return Memory.CompareArray<T>(address + offset, values);
		}

		static public System.Boolean CompareNullableArray<T>(System.IntPtr address, T?[] values)
			where T : unmanaged, System.IEquatable<T>
		{
			var length	= values.Length;
			var size	= Memory.Size<T>.Unmanaged;

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

		static public System.Boolean CompareNullableArray<T>(System.IntPtr address, System.Int32 offset, T?[] values)
			where T : unmanaged, System.IEquatable<T>
		{
			return Memory.CompareNullableArray<T>(address + offset, values);
		}

		unsafe static public TTo ConvertTo<TFrom, TTo>(TFrom value)
			where TFrom : unmanaged
			where TTo : unmanaged
		{
			return *(TTo*)&value;
		}

		unsafe static public TTo[] ConvertToArray<TFrom, TTo>(TFrom value)
			where TFrom : unmanaged
			where TTo : unmanaged
		{
			var length	= Memory.Size<TFrom>.Unmanaged / Memory.Size<TTo>.Unmanaged;
			var array	= new TTo[length];
			var pointer	= (TTo*)&value;

			for (var index = 0; index < length; index++)
			{
				array[index] = pointer[index];
			}

			return array;
		}

		unsafe static public TTo[] ConvertArrayToArray<TFrom, TTo>(TFrom[] values)
			where TFrom : unmanaged
			where TTo : unmanaged
		{
			var length	= (Memory.Size<TFrom>.Unmanaged * values.Length) / Memory.Size<TTo>.Unmanaged;
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
			var size = Memory.Size<T>.Unmanaged;
			
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

		static public System.Diagnostics.ProcessModule GetProcessModule(System.String name)
		{
			foreach (System.Diagnostics.ProcessModule processModule in System.Diagnostics.Process.GetCurrentProcess().Modules)
			{
				if (name.Equals(processModule.ModuleName, System.StringComparison.OrdinalIgnoreCase))
				{
					return processModule;
				}
			}

			return null;
		}

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
			var array	= new T[length];
			var size	= Memory.Size<T>.Unmanaged;

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

		static public T ReadRelativeCall<T>(System.IntPtr address)
			where T : System.Delegate
		{
			return System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<T>(address + Memory.Read<RelativeCall>(address).Relative32 + Memory.Size<RelativeCall>.Unmanaged);
		}

		static public T ReadRelativeCall<T>(System.IntPtr address, System.Int32 offset)
			where T : System.Delegate
		{
			return Memory.ReadRelativeCall<T>(address + offset);
		}

		static public T ReadRelativeJump<T>(System.IntPtr address)
			where T : System.Delegate
		{
			return System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<T>(address + Memory.Read<RelativeJump>(address).Relative32 + Memory.Size<RelativeJump>.Unmanaged);
		}

		static public T ReadRelativeJump<T>(System.IntPtr address, System.Int32 offset)
			where T : System.Delegate
		{
			return Memory.ReadRelativeJump<T>(address + offset);
		}

		static public System.String ReadString(System.IntPtr address)
		{
			return System.Runtime.InteropServices.Marshal.PtrToStringAnsi(address);
		}

		static public System.String ReadString(System.IntPtr address, System.Int32 offset)
		{
			return Memory.ReadString(address + offset);
		}

		static public T ReadVirtualFunction<T>(System.IntPtr address, System.Int32 index)
			where T : System.Delegate
		{
			return System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<T>(Memory.Read<System.IntPtr>(address, Memory.Size<System.IntPtr>.Unmanaged * index));
		}

		static public void SafeFill<T>(System.IntPtr address, System.Int32 count, T value)
			where T : unmanaged
		{
			var size = new System.IntPtr(Memory.Size<T>.Unmanaged * count);

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
			var size = new System.IntPtr(Memory.Size<T>.Unmanaged);

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

		static public void SafeWriteArray<T>(System.IntPtr address, T[] values)
			where T : unmanaged
		{
			var size = new System.IntPtr(Memory.Size<T>.Unmanaged * values.Length);

			if (Memory.VirtualProtect(address, size, MemoryProtectionConstants.PageExecuteReadWrite, out var oldProtect) != 0)
			{
				try
				{
					Memory.WriteArray<T>(address, values);
				}
				finally
				{
					Memory.VirtualProtect(address, size, oldProtect, out oldProtect);
				}
			}
		}

		static public void SafeWriteArray<T>(System.IntPtr address, System.Int32 offset, T[] values)
			where T : unmanaged
		{
			Memory.SafeWriteArray<T>(address + offset, values);
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

		static public void WriteArray<T>(System.IntPtr address, T[] values)
			where T : unmanaged
		{
			var length	= values.Length;
			var size	= Memory.Size<T>.Unmanaged;

			for (var index = 0; index < length; index++)
			{
				Memory.Write<T>(address, size * index, values[index]);
			}
		}

		static public void WriteArray<T>(System.IntPtr address, System.Int32 offset, T[] values)
			where T : unmanaged
		{
			Memory.WriteArray<T>(address + offset, values);
		}

		static public void WriteRelativeCall(System.IntPtr address, System.IntPtr function)
		{
			Memory.SafeWrite<RelativeCall>(address, Assembly.RelativeCall(address, function));
		}

		static public void WriteRelativeCall(System.IntPtr address, System.Int32 offset, System.IntPtr function)
		{
			Memory.WriteRelativeCall(address + offset, function);
		}

		static public void WriteRelativeCall<T>(System.IntPtr address, T function)
			where T : System.Delegate
		{
			Memory.WriteRelativeCall(address, System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<T>(function));
		}

		static public void WriteRelativeCall<T>(System.IntPtr address, System.Int32 offset, T function)
			where T : System.Delegate
		{
			Memory.WriteRelativeCall<T>(address + offset, function);
		}

		static public void WriteRelativeJump(System.IntPtr address, System.IntPtr function)
		{
			Memory.SafeWrite<RelativeJump>(address, Assembly.RelativeJump(address, function));
		}

		static public void WriteRelativeJump(System.IntPtr address, System.Int32 offset, System.IntPtr function)
		{
			Memory.WriteRelativeJump(address + offset, function);
		}

		static public void WriteRelativeJump<T>(System.IntPtr address, T function)
			where T : System.Delegate
		{
			Memory.WriteRelativeJump(address, System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<T>(function));
		}

		static public void WriteRelativeJump<T>(System.IntPtr address, System.Int32 offset, T function)
			where T : System.Delegate
		{
			Memory.WriteRelativeJump<T>(address + offset, function);
		}

		static public void WriteVirtualFunction(System.IntPtr address, System.Int32 index, System.IntPtr virtualFunction)
		{
			Memory.SafeWrite<System.IntPtr>(address, Memory.Size<System.IntPtr>.Unmanaged * index, virtualFunction);
		}

		static public void WriteVirtualFunction<T>(System.IntPtr address, System.Int32 index, T virtualFunction)
			where T : System.Delegate
		{
			Memory.WriteVirtualFunction(address, index, System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<T>(virtualFunction));
		}
	}
}
