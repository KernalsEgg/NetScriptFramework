namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x150)]
	public struct TESActorBase // TESBoundObject, TESFullName
	{
		[System.Runtime.InteropServices.FieldOffset(0x0)] public TESBoundObject TESBoundObject;
		[System.Runtime.InteropServices.FieldOffset(0xD8)] public TESFullName TESFullName;
	}
}
