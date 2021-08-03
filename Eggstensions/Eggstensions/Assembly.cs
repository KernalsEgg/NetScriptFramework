namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 0x1, Size = 0x10)]
	public struct AbsoluteCall
	{
		public System.Byte Call;		// 0x0
		public System.Byte ModRm;		// 0x1
		public System.Int32 Relative32;	// 0x2
		public System.Byte Jump;		// 0x6
		public System.SByte Relative8;	// 0x7
		public System.Int64 Relative64;	// 0x8
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 0x1, Size = 0xE)]
	public struct AbsoluteJump
	{
		public System.Byte Jump;		// 0x0
		public System.Byte ModRm;		// 0x1
		public System.Int32 Relative32;	// 0x2
		public System.Int64 Relative64;	// 0x6
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 0x1, Size = 0x5)]
	public struct RelativeCall
	{
		public System.Byte Call;		// 0x0
		public System.Int32 Relative32;	// 0x1
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 0x1, Size = 0x5)]
	public struct RelativeJump
	{
		public System.Byte Jump;		// 0x0
		public System.Int32 Relative32;	// 0x1
	}

	static public class Assembly
	{
		static public System.Byte Int3 { get; }	= 0xCC;
		static public System.Byte Nop { get; }	= 0x90;
		static public System.Byte Ret { get; }	= 0xC3;



		static public AbsoluteCall AbsoluteCall(System.IntPtr function)
		{
			return new AbsoluteCall()
			{
				Call		= 0xFF,
				ModRm		= 0x15,
				Relative32	= 0x2,
				Jump		= 0xEB,
				Relative8	= 0x8,
				Relative64	= function.ToInt64()
			};
		}

		static public AbsoluteCall AbsoluteCall<T>(T function)
			where T : System.Delegate
		{
			return Assembly.AbsoluteCall(System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<T>(function));
		}

		static public AbsoluteJump AbsoluteJump(System.IntPtr function)
		{
			return new AbsoluteJump()
			{
				Jump		= 0xFF,
				ModRm		= 0x25,
				Relative32	= 0x0,
				Relative64	= function.ToInt64()
			};
		}

		static public AbsoluteJump AbsoluteJump<T>(T function)
			where T : System.Delegate
		{
			return Assembly.AbsoluteJump(System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<T>(function));
		}

		// EFLAGS
		// RAX
		// RCX, RDX, R8, R9
		// R10:R11
		// XMM0:XMM3
		// XMM4:XMM5

		static public System.Byte[] CaptureContext(System.IntPtr function, System.Byte[] before = null, System.Byte[] after = null)
		{
			var assembly = new UnmanagedArray<System.Byte>();

			if (before != null)
			{
				assembly.Add(before);
			}

			assembly.Add(new System.Byte[1] { 0x54 });															// push rsp
			assembly.Add(new System.Byte[2] { 0x41, 0x53 });													// push r11
			assembly.Add(new System.Byte[1] { 0x9C });															// pushfq

			assembly.Add(new System.Byte[3] { 0x4C, 0x8B, 0xDC });												// mov r11, rsp
			assembly.Add(new System.Byte[4] { 0x48, 0x83, 0xE4, 0xF0 });										// and rsp, -10
			assembly.Add(new System.Byte[3] { 0x4C, 0x39, 0xDC });												// cmp rsp, r11

			assembly.Add(new System.Byte[1] { 0x55 });															// push rbp
			assembly.Add(new System.Byte[2] { 0x41, 0x52 });													// push r10

			assembly.Add(new System.Byte[2] { 0x74, 3 + 5 + 4 + 5 + 4 + 5 + 4 + 5 });							// je 23
			{
				assembly.Add(new System.Byte[3] { 0x4D, 0x8B, 0x13 });											// mov r10, [r11] (flags)
				assembly.Add(new System.Byte[5] { 0x4C, 0x89, 0x54, 0x24, 0x10 });								// mov [rsp+10], r10
				assembly.Add(new System.Byte[4] { 0x4D, 0x8B, 0x53, 0x08 });									// mov r10, [r11+8] (r11)
				assembly.Add(new System.Byte[5] { 0x4C, 0x89, 0x54, 0x24, 0x18 });								// mov [rsp+18], r10
				assembly.Add(new System.Byte[4] { 0x4D, 0x8B, 0x53, 0x10 });									// mov r10, [r11+10] (rsp)
				assembly.Add(new System.Byte[5] { 0x4C, 0x89, 0x54, 0x24, 0x20 });								// mov [rsp+20], r10
				assembly.Add(new System.Byte[4] { 0x4D, 0x8B, 0x53, 0x18 });									// mov r10, [r11+18] (rip)
				assembly.Add(new System.Byte[5] { 0x4C, 0x89, 0x54, 0x24, 0x28 });								// mov [rsp+28], r10
			}
			
			assembly.Add(new System.Byte[5] { 0x83, 0x44, 0x24, 0x20, 0x08 });									// add [rsp+20], 8
			assembly.Add(new System.Byte[5] { 0x48, 0x8B, 0x6C, 0x24, 0x20 });									// mov rbp, [rsp+20] (rsp)

			assembly.Add(new System.Byte[2] { 0x41, 0x57 });													// push r15
			assembly.Add(new System.Byte[2] { 0x41, 0x56 });													// push r14
			assembly.Add(new System.Byte[2] { 0x41, 0x55 });													// push r13
			assembly.Add(new System.Byte[2] { 0x41, 0x54 });													// push r12
			assembly.Add(new System.Byte[2] { 0x41, 0x51 });													// push r9
			assembly.Add(new System.Byte[2] { 0x41, 0x50 });													// push r8
			assembly.Add(new System.Byte[1] { 0x57 });															// push rdi
			assembly.Add(new System.Byte[1] { 0x56 });															// push rsi
			assembly.Add(new System.Byte[1] { 0x52 });															// push rdx
			assembly.Add(new System.Byte[1] { 0x51 });															// push rcx
			assembly.Add(new System.Byte[1] { 0x53 });															// push rbx
			assembly.Add(new System.Byte[1] { 0x50 });															// push rax

			assembly.Add(new System.Byte[7] { 0x48, 0x81, 0xEC, 0x20, 0x01, 0x00, 0x00 });						// sub rsp, 120
			assembly.Add(new System.Byte[10] { 0x66, 0x44, 0x0F, 0x7F, 0xBC, 0x24, 0x10, 0x01, 0x00, 0x00 });	// movdqa [rsp+110], xmm15
			assembly.Add(new System.Byte[10] { 0x66, 0x44, 0x0F, 0x7F, 0xB4, 0x24, 0x00, 0x01, 0x00, 0x00 });	// movdqa [rsp+100], xmm14
			assembly.Add(new System.Byte[10] { 0x66, 0x44, 0x0F, 0x7F, 0xAC, 0x24, 0xF0, 0x00, 0x00, 0x00 });	// movdqa [rsp+F0], xmm13
			assembly.Add(new System.Byte[10] { 0x66, 0x44, 0x0F, 0x7F, 0xA4, 0x24, 0xE0, 0x00, 0x00, 0x00 });	// movdqa [rsp+E0], xmm12
			assembly.Add(new System.Byte[10] { 0x66, 0x44, 0x0F, 0x7F, 0x9C, 0x24, 0xD0, 0x00, 0x00, 0x00 });	// movdqa [rsp+D0], xmm11
			assembly.Add(new System.Byte[10] { 0x66, 0x44, 0x0F, 0x7F, 0x94, 0x24, 0xC0, 0x00, 0x00, 0x00 });	// movdqa [rsp+C0], xmm10
			assembly.Add(new System.Byte[10] { 0x66, 0x44, 0x0F, 0x7F, 0x8C, 0x24, 0xB0, 0x00, 0x00, 0x00 });	// movdqa [rsp+B0], xmm9
			assembly.Add(new System.Byte[10] { 0x66, 0x44, 0x0F, 0x7F, 0x84, 0x24, 0xA0, 0x00, 0x00, 0x00 });	// movdqa [rsp+A0], xmm8
			assembly.Add(new System.Byte[9] { 0x66, 0x0F, 0x7F, 0xBC, 0x24, 0x90, 0x00, 0x00, 0x00 });			// movdqa [rsp+90], xmm7
			assembly.Add(new System.Byte[9] { 0x66, 0x0F, 0x7F, 0xB4, 0x24, 0x80, 0x00, 0x00, 0x00 });			// movdqa [rsp+80], xmm6
			assembly.Add(new System.Byte[6] { 0x66, 0x0F, 0x7F, 0x6C, 0x24, 0x70 });							// movdqa [rsp+70], xmm5
			assembly.Add(new System.Byte[6] { 0x66, 0x0F, 0x7F, 0x64, 0x24, 0x60 });							// movdqa [rsp+60], xmm4
			assembly.Add(new System.Byte[6] { 0x66, 0x0F, 0x7F, 0x5C, 0x24, 0x50 });							// movdqa [rsp+50], xmm3
			assembly.Add(new System.Byte[6] { 0x66, 0x0F, 0x7F, 0x54, 0x24, 0x40 });							// movdqa [rsp+40], xmm2
			assembly.Add(new System.Byte[6] { 0x66, 0x0F, 0x7F, 0x4C, 0x24, 0x30 });							// movdqa [rsp+30], xmm1
			assembly.Add(new System.Byte[6] { 0x66, 0x0F, 0x7F, 0x44, 0x24, 0x20 });							// movdqa [rsp+20], xmm0

			assembly.Add(new System.Byte[5] { 0x48, 0x8D, 0x4C, 0x24, 0x20 });									// lea rcx, [rsp+20]
			assembly.Add(Assembly.AbsoluteCall(function));

			assembly.Add(new System.Byte[6] { 0x66, 0x0F, 0x6F, 0x44, 0x24, 0x20 });							// movdqa xmm0, [rsp+20]
			assembly.Add(new System.Byte[6] { 0x66, 0x0F, 0x6F, 0x4C, 0x24, 0x30 });							// movdqa xmm1, [rsp+30]
			assembly.Add(new System.Byte[6] { 0x66, 0x0F, 0x6F, 0x54, 0x24, 0x40 });							// movdqa xmm2, [rsp+40]
			assembly.Add(new System.Byte[6] { 0x66, 0x0F, 0x6F, 0x5C, 0x24, 0x50 });							// movdqa xmm3, [rsp+50]
			assembly.Add(new System.Byte[6] { 0x66, 0x0F, 0x6F, 0x64, 0x24, 0x60 });							// movdqa xmm4, [rsp+60]
			assembly.Add(new System.Byte[6] { 0x66, 0x0F, 0x6F, 0x6C, 0x24, 0x70 });							// movdqa xmm5, [rsp+70]
			assembly.Add(new System.Byte[9] { 0x66, 0x0F, 0x6F, 0xB4, 0x24, 0x80, 0x00, 0x00, 0x00 });			// movdqa xmm6, [rsp+80]
			assembly.Add(new System.Byte[9] { 0x66, 0x0F, 0x6F, 0xBC, 0x24, 0x90, 0x00, 0x00, 0x00 });			// movdqa xmm7, [rsp+90]
			assembly.Add(new System.Byte[10] { 0x66, 0x44, 0x0F, 0x6F, 0x84, 0x24, 0xA0, 0x00, 0x00, 0x00 });	// movdqa xmm8, [rsp+A0]
			assembly.Add(new System.Byte[10] { 0x66, 0x44, 0x0F, 0x6F, 0x8C, 0x24, 0xB0, 0x00, 0x00, 0x00 });	// movdqa xmm9, [rsp+B0]
			assembly.Add(new System.Byte[10] { 0x66, 0x44, 0x0F, 0x6F, 0x94, 0x24, 0xC0, 0x00, 0x00, 0x00 });	// movdqa xmm10, [rsp+C0]
			assembly.Add(new System.Byte[10] { 0x66, 0x44, 0x0F, 0x6F, 0x9C, 0x24, 0xD0, 0x00, 0x00, 0x00 });	// movdqa xmm11, [rsp+D0]
			assembly.Add(new System.Byte[10] { 0x66, 0x44, 0x0F, 0x6F, 0xA4, 0x24, 0xE0, 0x00, 0x00, 0x00 });	// movdqa xmm12, [rsp+E0]
			assembly.Add(new System.Byte[10] { 0x66, 0x44, 0x0F, 0x6F, 0xAC, 0x24, 0xF0, 0x00, 0x00, 0x00 });	// movdqa xmm13, [rsp+F0]
			assembly.Add(new System.Byte[10] { 0x66, 0x44, 0x0F, 0x6F, 0xB4, 0x24, 0x00, 0x01, 0x00, 0x00 });	// movdqa xmm14, [rsp+100]
			assembly.Add(new System.Byte[10] { 0x66, 0x44, 0x0F, 0x6F, 0xBC, 0x24, 0x10, 0x01, 0x00, 0x00 });	// movdqa xmm15, [rsp+110]
			assembly.Add(new System.Byte[7] { 0x48, 0x81, 0xC4, 0x20, 0x01, 0x00, 0x00 });						// add rsp, 120

			assembly.Add(new System.Byte[1] { 0x58 });															// pop rax
			assembly.Add(new System.Byte[1] { 0x5B });															// pop rbx
			assembly.Add(new System.Byte[1] { 0x59 });															// pop rcx
			assembly.Add(new System.Byte[1] { 0x5A });															// pop rdx
			assembly.Add(new System.Byte[1] { 0x5E });															// pop rsi
			assembly.Add(new System.Byte[1] { 0x5F });															// pop rdi
			assembly.Add(new System.Byte[2] { 0x41, 0x58 });													// pop r8
			assembly.Add(new System.Byte[2] { 0x41, 0x59 });													// pop r9
			assembly.Add(new System.Byte[2] { 0x41, 0x5C });													// pop r12
			assembly.Add(new System.Byte[2] { 0x41, 0x5D });													// pop r13
			assembly.Add(new System.Byte[2] { 0x41, 0x5E });													// pop r14
			assembly.Add(new System.Byte[2] { 0x41, 0x5F });													// pop r15

			assembly.Add(new System.Byte[5] { 0x83, 0x6C, 0x24, 0x20, 0x08 });									// sub [rsp+20], 8
			assembly.Add(new System.Byte[5] { 0x4C, 0x8B, 0x5C, 0x24, 0x20 });									// mov r11, [rsp+20] (rsp)
			assembly.Add(new System.Byte[5] { 0x4C, 0x8B, 0x54, 0x24, 0x28 });									// mov r10, [rsp+28] (rip)
			assembly.Add(new System.Byte[3] { 0x4D, 0x89, 0x13 });												// mov [r11], r10
			
			assembly.Add(new System.Byte[2] { 0x41, 0x5A });													// pop r10
			assembly.Add(new System.Byte[1] { 0x5D });															// pop rbp
			assembly.Add(new System.Byte[1] { 0x9D });															// popfq
			assembly.Add(new System.Byte[2] { 0x41, 0x5B });													// pop r11
			assembly.Add(new System.Byte[1] { 0x5C });															// pop rsp

			if (after != null)
			{
				assembly.Add(after);
			}

			assembly.Add(new System.Byte[1] { 0xC3 });															// ret

			return assembly;
		}

		static public System.Byte[] CaptureContext(Eggstensions.Delegates.Types.Context.CaptureContext function, System.Byte[] before = null, System.Byte[] after = null)
		{
			return Assembly.CaptureContext(System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<Eggstensions.Delegates.Types.Context.CaptureContext>(function), before, after);
		}

		static public RelativeCall RelativeCall(System.IntPtr address, System.IntPtr function)
		{
			return new RelativeCall()
			{
				Call		= 0xE8,
				Relative32	= (System.Int32)(function.ToInt64() - (address.ToInt64() + Memory.Size<RelativeCall>.Unmanaged))
			};
		}

		static public RelativeCall RelativeCall(System.IntPtr address, System.Int32 offset, System.IntPtr function)
		{
			return Assembly.RelativeCall(address + offset, function);
		}

		static public RelativeCall RelativeCall<T>(System.IntPtr address, T function)
			where T : System.Delegate
		{
			return Assembly.RelativeCall(address, System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<T>(function));
		}

		static public RelativeCall RelativeCall<T>(System.IntPtr address, System.Int32 offset, T function)
			where T : System.Delegate
		{
			return Assembly.RelativeCall<T>(address + offset, function);
		}

		static public RelativeJump RelativeJump(System.IntPtr address, System.IntPtr function)
		{
			return new RelativeJump()
			{
				Jump		= 0xE9,
				Relative32	= (System.Int32)(function.ToInt64() - (address.ToInt64() + Memory.Size<RelativeJump>.Unmanaged))
			};
		}

		static public RelativeJump RelativeJump(System.IntPtr address, System.Int32 offset, System.IntPtr function)
		{
			return Assembly.RelativeJump(address + offset, function);
		}

		static public RelativeJump RelativeJump<T>(System.IntPtr address, T function)
			where T : System.Delegate
		{
			return Assembly.RelativeJump(address, System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<T>(function));
		}

		static public RelativeJump RelativeJump<T>(System.IntPtr address, System.Int32 offset, T function)
			where T : System.Delegate
		{
			return Assembly.RelativeJump<T>(address + offset, function);
		}
	}
}
