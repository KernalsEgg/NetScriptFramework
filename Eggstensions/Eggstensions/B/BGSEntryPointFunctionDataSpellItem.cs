namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x10)]
	unsafe public struct BGSEntryPointFunctionDataSpellItem
	{
		[System.Runtime.InteropServices.FieldOffset(0x0)] public BGSEntryPointFunctionData BGSEntryPointFunctionData;
		[System.Runtime.InteropServices.FieldOffset(0x8)] public SpellItem* Spell;
	}
}
