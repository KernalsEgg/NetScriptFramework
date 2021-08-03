namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x8)]
	unsafe public struct ReferenceEffectController
	{
		// Virtual
		static public NiAVObject* GetAttachRoot(ReferenceEffectController* referenceEffectController)
		{
			var getAttachRoot = Memory.ReadVirtualFunction<Eggstensions.Delegates.Types.ReferenceEffectController.GetAttachRoot>(*(System.IntPtr*)referenceEffectController, 0xF);

			return getAttachRoot(referenceEffectController);
		}
	}
}
