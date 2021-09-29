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

		[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x18)]
		unsafe public struct SKSEInterface
		{
			[System.Runtime.InteropServices.FieldOffset(0x0)] public System.UInt32 SKSEVersion;
			[System.Runtime.InteropServices.FieldOffset(0x4)] public System.UInt32 RuntimeVersion;
			[System.Runtime.InteropServices.FieldOffset(0x8)] public System.UInt32 EditorVersion;
			[System.Runtime.InteropServices.FieldOffset(0xC)] public System.UInt32 IsEditor;
			[System.Runtime.InteropServices.FieldOffset(0x10)] public delegate* unmanaged[Cdecl]<System.UInt32, void*> QueryInterface;
			[System.Runtime.InteropServices.FieldOffset(0x18)] public delegate* unmanaged[Cdecl]<System.UInt32> GetPluginHandle;
			[System.Runtime.InteropServices.FieldOffset(0x20)] public delegate* unmanaged[Cdecl]<System.UInt32> GetReleaseIndex;
			[System.Runtime.InteropServices.FieldOffset(0x28)] public delegate* unmanaged[Cdecl]<UnmanagedType.LPStr, SKSE.PluginInfo*> GetPluginInfo;
		}
	}
}
