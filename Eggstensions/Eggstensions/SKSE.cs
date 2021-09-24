namespace Eggstensions
{
	namespace SKSE
	{
		[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x18)]
		public struct PluginInfo
		{
			[System.Runtime.InteropServices.FieldOffset(0x0)] public System.UInt32 InfoVersion;
			[System.Runtime.InteropServices.FieldOffset(0x8)] public System.IntPtr Name;
			[System.Runtime.InteropServices.FieldOffset(0x10)] public System.UInt32 Version;
		}

		unsafe public struct SKSEInterface
		{
			public System.UInt32 SKSEVersion;
			public System.UInt32 RuntimeVersion;
			public System.UInt32 EditorVersion;
			public System.UInt32 IsEditor;
			public delegate* unmanaged[Cdecl]<System.UInt32, void*> QueryInterface;
			public delegate* unmanaged[Cdecl]<System.UInt32> GetPluginHandle;
			public delegate* unmanaged[Cdecl]<System.UInt32> GetReleaseIndex;
			public delegate* unmanaged[Cdecl]<UnmanagedType.LPStr, SKSE.PluginInfo*> GetPluginInfo;
		}
	}
}
