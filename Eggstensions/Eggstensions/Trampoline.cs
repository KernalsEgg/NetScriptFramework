namespace Eggstensions
{
	unsafe static public class Trampoline
	{
		static private System.Int32 position = 0;



		static public event System.EventHandler Write;



		static public System.IntPtr Address { get; private set; }



		/// <summary>https://stackoverflow.com/a/54732489</summary>
		static public System.IntPtr Allocate(System.Diagnostics.ProcessModule processModule, System.Int32 size)
		{
			Memory.GetSystemInfo(out var systemInfo);

			var minimum = processModule.BaseAddress.ToInt64() > processModule.ModuleMemorySize - System.Int32.MinValue ? Math.Ceiling(processModule.BaseAddress + System.Int32.MinValue + processModule.ModuleMemorySize, systemInfo.AllocationGranularity) : System.IntPtr.Zero;
			var maximum = processModule.BaseAddress.ToInt64() < (System.Int64.MaxValue - System.Int32.MaxValue) ? Math.Floor(processModule.BaseAddress + System.Int32.MaxValue, systemInfo.AllocationGranularity) : new System.IntPtr(System.Int64.MaxValue);

			while (minimum.ToInt64() < maximum.ToInt64())
			{
				if (Memory.VirtualQuery(minimum, out var memoryBasicInformation, new System.IntPtr(System.Runtime.CompilerServices.Unsafe.SizeOf<MemoryBasicInformation>())) == System.IntPtr.Zero)
				{
					return System.IntPtr.Zero;
				}

				minimum = new System.IntPtr(memoryBasicInformation.BaseAddress.ToInt64() + memoryBasicInformation.RegionSize.ToInt64());

				if (memoryBasicInformation.State == MemoryBasicInformation.States.MemFree)
				{
					var baseAddress = Math.Ceiling(memoryBasicInformation.BaseAddress, systemInfo.AllocationGranularity);

					// If rounding has not changed regions and the region is at least the specified size
					if (baseAddress.ToInt64() < minimum.ToInt64() && (minimum.ToInt64() - baseAddress.ToInt64()) >= size)
					{
						var allocation = Memory.VirtualAlloc(baseAddress, new System.IntPtr(size), AllocationTypes.MemCommit | AllocationTypes.MemReserve, MemoryProtectionConstants.PageExecuteReadWrite);

						if (allocation != System.IntPtr.Zero)
						{
							return allocation;
						}
					}
				}
			}

			return System.IntPtr.Zero;
		}

		static public void CaptureContext(System.IntPtr address, delegate* unmanaged[Cdecl]<Context*, void> function, System.Byte[] before = null, System.Byte[] after = null)
		{
			var captureContext	= Assembly.CaptureContext(function, before, after);
			var position		= Trampoline.Reserve(System.Runtime.CompilerServices.Unsafe.SizeOf<System.Byte>() * captureContext.Length);

			Trampoline.Write += (System.Object sender, System.EventArgs arguments) =>
			{
				Memory.SafeWrite<System.Byte>(Trampoline.Address + position, captureContext);
				Memory.WriteRelativeCall(address, (Trampoline.Address + position).ToPointer());
			};
		}

		static public void CaptureContext(System.IntPtr address, System.Int32 offset, delegate* unmanaged[Cdecl]<Context*, void> function, System.Byte[] before = null, System.Byte[] after = null)
		{
			Trampoline.CaptureContext(address + offset, function, before, after);
		}

		static public void Commit()
		{
			if (Trampoline.position > 0)
			{
				Trampoline.Address = Trampoline.Allocate(Main.MainModule, Trampoline.position);

				if (Trampoline.Address == System.IntPtr.Zero)
				{
					try
					{
						throw new System.InsufficientMemoryException($"{nameof(Trampoline)}: Failed to allocate {Trampoline.position:X} bytes of memory.");
					}
					catch (System.InsufficientMemoryException insufficientMemoryException)
					{
						Log.Information($"{insufficientMemoryException}");

						throw;
					}
				}

				Trampoline.Write?.Invoke(null, System.EventArgs.Empty);
			}
		}

		static public void Free(System.IntPtr address)
		{
			Memory.VirtualFree(address, System.IntPtr.Zero, FreeTypes.MemRelease);
		}

		static public System.Int32 Reserve(System.Int32 size)
		{
			return System.Threading.Interlocked.Add(ref Trampoline.position, size) - size;
		}

		static public void WriteRelativeCall(System.IntPtr address, void* function)
		{
			var absoluteJump	= Assembly.AbsoluteJump(function);
			var position		= Trampoline.Reserve(System.Runtime.CompilerServices.Unsafe.SizeOf<AbsoluteJump>());

			Trampoline.Write += (System.Object sender, System.EventArgs arguments) =>
			{
				Memory.SafeWrite<AbsoluteJump>(Trampoline.Address + position, absoluteJump);
				Memory.WriteRelativeCall(address, (Trampoline.Address + position).ToPointer());
			};
		}

		static public void WriteRelativeCall(System.IntPtr address, System.Int32 offset, void* function)
		{
			Trampoline.WriteRelativeCall(address + offset, function);
		}

		static public void WriteRelativeCallBranch(System.IntPtr address, System.Byte[] assembly)
		{
			var position = Trampoline.Reserve(System.Runtime.CompilerServices.Unsafe.SizeOf<System.Byte>() * assembly.Length);

			Trampoline.Write += (System.Object sender, System.EventArgs arguments) =>
			{
				Memory.SafeWrite<System.Byte>(Trampoline.Address + position, assembly);
				Memory.WriteRelativeCall(address, (Trampoline.Address + position).ToPointer());
			};
		}

		static public void WriteRelativeCallBranch(System.IntPtr address, System.Int32 offset, System.Byte[] assembly)
		{
			Trampoline.WriteRelativeCallBranch(address + offset, assembly);
		}

		static public void WriteRelativeJump(System.IntPtr address, void* function)
		{
			var absoluteJump	= Assembly.AbsoluteJump(function);
			var position		= Trampoline.Reserve(System.Runtime.CompilerServices.Unsafe.SizeOf<AbsoluteJump>());

			Trampoline.Write += (System.Object sender, System.EventArgs arguments) =>
			{
				Memory.SafeWrite<AbsoluteJump>(Trampoline.Address + position, absoluteJump);
				Memory.WriteRelativeJump(address, (Trampoline.Address + position).ToPointer());
			};
		}

		static public void WriteRelativeJump(System.IntPtr address, System.Int32 offset, void* function)
		{
			Trampoline.WriteRelativeJump(address + offset, function);
		}

		static public void WriteRelativeJumpBranch(System.IntPtr address, System.Byte[] assembly)
		{
			var position = Trampoline.Reserve(System.Runtime.CompilerServices.Unsafe.SizeOf<System.Byte>() * assembly.Length);

			Trampoline.Write += (System.Object sender, System.EventArgs arguments) =>
			{
				Memory.SafeWrite<System.Byte>(Trampoline.Address + position, assembly);
				Memory.WriteRelativeJump(address, (Trampoline.Address + position).ToPointer());
			};
		}

		static public void WriteRelativeJumpBranch(System.IntPtr address, System.Int32 offset, System.Byte[] assembly)
		{
			Trampoline.WriteRelativeJumpBranch(address + offset, assembly);
		}
	}
}
