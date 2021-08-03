namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0xD8)]
	public struct ModelReferenceEffect // ReferenceEffect
	{
		[System.Runtime.InteropServices.FieldOffset(0x0)] public ReferenceEffect ReferenceEffect;
		[System.Runtime.InteropServices.FieldOffset(0x68)] public RefAttachTechniqueInput HitEffectArtData;
	}
}
