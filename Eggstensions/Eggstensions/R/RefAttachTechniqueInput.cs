namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x48)]
	unsafe public struct RefAttachTechniqueInput
	{
		[System.Runtime.InteropServices.FieldOffset(0x0)] public BSAttachTechniques.AttachTechniqueInput AttachTechniqueInput;
		[System.Runtime.InteropServices.FieldOffset(0x28)] public TESRace* Race;
		[System.Runtime.InteropServices.FieldOffset(0x30)] public bhkWorld* HavokWorld;
		[System.Runtime.InteropServices.FieldOffset(0x40)] public BSFixedString NodeName;
	}
}
