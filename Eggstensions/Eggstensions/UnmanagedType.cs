namespace Eggstensions
{
	namespace UnmanagedType
	{
		public struct LPStr
		{
			[System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPStr)]
			public System.String Value;
		}

		public struct LPWStr
		{
			[System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)]
			public System.String Value;
		}
	}
}
