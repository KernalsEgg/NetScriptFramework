﻿namespace Eggstensions
{
	// Implement List<System.Byte[]> interfaces? e.g. Add, Contains, IndexOf, Remove, RemoveAt
	public class Trampoline : System.IDisposable
	{
		public Trampoline(System.Diagnostics.ProcessModule processModule, System.Int32 size)
		{
			Address = Trampoline.Allocate(processModule, size);
			Size = size;
		}

		~Trampoline()
		{
			this.Dispose(false);
		}



		private System.Int32 position = 0;



		public System.IntPtr Address { get; }

		public System.Int32 Size { get; }



		public System.Int32 Position
		{
			get
			{
				return position;
			}
		}



		/// <summary>https://stackoverflow.com/a/54732489</summary>
		static public System.IntPtr Allocate(System.Diagnostics.ProcessModule processModule, System.Int32 size)
		{
			Memory.GetSystemInfo(out var systemInfo);

			var minimum = processModule.BaseAddress.ToInt64() > processModule.ModuleMemorySize - System.Int32.MinValue ? Math.Ceiling(processModule.BaseAddress + System.Int32.MinValue + processModule.ModuleMemorySize, systemInfo.AllocationGranularity) : System.IntPtr.Zero;
			var maximum = processModule.BaseAddress.ToInt64() < (System.Int64.MaxValue - System.Int32.MaxValue) ? Math.Floor(processModule.BaseAddress + System.Int32.MaxValue, systemInfo.AllocationGranularity) : new System.IntPtr(System.Int64.MaxValue);

			while (minimum.ToInt64() < maximum.ToInt64())
			{
				if (Memory.VirtualQuery(minimum, out var memoryBasicInformation, new System.IntPtr(Memory.Size<MemoryBasicInformation>.Unmanaged)) == System.IntPtr.Zero)
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



		virtual public void Dispose(System.Boolean disposing)
		{
			Memory.VirtualFree(Address, System.IntPtr.Zero, FreeTypes.MemRelease);
		}



		public void CaptureContext(System.IntPtr address, Eggstensions.Delegates.Types.Context.CaptureContext function, System.Byte[] before = null, System.Byte[] after = null)
		{
			var captureContext = Assembly.CaptureContext(function, before, after);
			var reservation = this.Reserve(Memory.Size<System.Byte>.Unmanaged * captureContext.Length);
			Memory.SafeWriteArray<System.Byte>(reservation, captureContext);
			Memory.WriteRelativeCall(address, reservation);
		}

		public void CaptureContext(System.IntPtr address, System.Int32 offset, Eggstensions.Delegates.Types.Context.CaptureContext function, System.Byte[] before = null, System.Byte[] after = null)
		{
			this.CaptureContext(address + offset, function, before, after);
		}

		public void Dispose()
		{
			this.Dispose(true);
			System.GC.SuppressFinalize(this);
		}

		public System.IntPtr Reserve(System.Int32 size)
		{
			return Address + (System.Threading.Interlocked.Add(ref this.position, size) - size);
		}

		public void WriteRelativeCall<T>(System.IntPtr address, T function)
			where T : System.Delegate
		{
			var reservation = this.Reserve(Memory.Size<AbsoluteJump>.Unmanaged);
			Memory.SafeWrite<AbsoluteJump>(reservation, Assembly.AbsoluteJump<T>(function));
			Memory.WriteRelativeCall(address, reservation);
		}

		public void WriteRelativeCall<T>(System.IntPtr address, System.Int32 offset, T function)
			where T : System.Delegate
		{
			this.WriteRelativeCall<T>(address + offset, function);
		}

		public void WriteRelativeCallBranch(System.IntPtr address, System.Byte[] assembly)
		{
			var reservation = this.Reserve(Memory.Size<System.Byte>.Unmanaged * assembly.Length);
			Memory.SafeWriteArray<System.Byte>(reservation, assembly);
			Memory.WriteRelativeCall(address, reservation);
		}

		public void WriteRelativeCallBranch(System.IntPtr address, System.Int32 offset, System.Byte[] assembly)
		{
			this.WriteRelativeCallBranch(address + offset, assembly);
		}

		public void WriteRelativeJump<T>(System.IntPtr address, T function)
			where T : System.Delegate
		{
			var reservation = this.Reserve(Memory.Size<AbsoluteJump>.Unmanaged);
			Memory.SafeWrite<AbsoluteJump>(reservation, Assembly.AbsoluteJump<T>(function));
			Memory.WriteRelativeJump(address, reservation);
		}

		public void WriteRelativeJump<T>(System.IntPtr address, System.Int32 offset, T function)
			where T : System.Delegate
		{
			this.WriteRelativeJump<T>(address + offset, function);
		}

		public void WriteRelativeJumpBranch(System.IntPtr address, System.Byte[] assembly)
		{
			var reservation = this.Reserve(Memory.Size<System.Byte>.Unmanaged * assembly.Length);
			Memory.SafeWriteArray<System.Byte>(reservation, assembly);
			Memory.WriteRelativeJump(address, reservation);
		}

		public void WriteRelativeJumpBranch(System.IntPtr address, System.Int32 offset, System.Byte[] assembly)
		{
			this.WriteRelativeJumpBranch(address + offset, assembly);
		}
	}
}