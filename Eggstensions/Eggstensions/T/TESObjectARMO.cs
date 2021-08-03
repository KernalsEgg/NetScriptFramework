namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x228)]
	public struct TESObjectARMO // TESBoundObject, TESFullName
	{
		[System.Runtime.InteropServices.FieldOffset(0x0)] public TESBoundObject TESBoundObject;
		[System.Runtime.InteropServices.FieldOffset(0x30)] public TESFullName TESFullName;
	}
}
