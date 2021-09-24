using Eggstensions.ExtensionMethods;



namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x8)]
	unsafe public struct BSFixedString : System.IDisposable
	{
		public BSFixedString(System.String text) : this()
		{
			BSFixedString.Initialize(this.AsPointer(), text);
		}



		[System.Runtime.InteropServices.FieldOffset(0x0)] public System.IntPtr Text;



		// Member
		public void Dispose()
		{
			BSFixedString.Release(this.AsPointer());
		}



		// Static
		static public BSFixedString* Initialize(BSFixedString* fixedString, System.String text)
		{
			var initialize = (delegate* unmanaged[Cdecl]<BSFixedString*, UnmanagedType.LPStr, BSFixedString*>)Eggstensions.Offsets.BSFixedString.Initialize;

			return Initialize(fixedString, new UnmanagedType.LPStr { Value = text });



			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			BSFixedString* Initialize(BSFixedString* fixedString, UnmanagedType.LPStr text)
			{
				return initialize(fixedString, text);
			}
		}

		static public void Release(BSFixedString* fixedString)
		{
			var release = (delegate* unmanaged[Cdecl]<BSFixedString*, void>)Eggstensions.Offsets.BSFixedString.Release;

			Release(fixedString);



			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			void Release(BSFixedString* fixedString)
			{
				release(fixedString);
			}
		}
	}
}
