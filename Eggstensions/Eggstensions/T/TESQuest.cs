namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x268)]
	public struct TESQuest // TESForm, TESFullName
	{
		[System.Runtime.InteropServices.FieldOffset(0x0)] public TESForm TESForm;
		[System.Runtime.InteropServices.FieldOffset(0x28)] public TESFullName TESFullName;
	}
}
