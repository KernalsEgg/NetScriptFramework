namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x8)]
	unsafe public struct BSFixedString
	{
		[System.Runtime.InteropServices.FieldOffset(0x0)] public System.IntPtr Text;



		// Member
		static public BSFixedString* Initialize(BSFixedString* fixedString, System.String text)
		{
			return Eggstensions.Delegates.Instances.BSFixedString.Initialize(fixedString, text);
		}

		static public void Release(BSFixedString* fixedString)
		{
			Eggstensions.Delegates.Instances.BSFixedString.Release(fixedString);
		}
	}
}
