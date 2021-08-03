namespace Eggstensions
{
	namespace BSAttachTechniques
	{
		[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x20)]
		unsafe public struct AttachTechniqueInput
		{
			[System.Runtime.InteropServices.FieldOffset(0x8)] public NiNode* AttachRoot;
			[System.Runtime.InteropServices.FieldOffset(0x10)] public NiNode* EffectRoot;
		}
	}
}
