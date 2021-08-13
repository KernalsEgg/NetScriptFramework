namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x128)]
	unsafe public struct TESAmmo
	{
		[System.Runtime.InteropServices.FieldOffset(0x0)] public TESBoundObject TESBoundObject;



		// Virtual
		static public System.Boolean IsPlayable(TESAmmo* ammo)
		{
			var isPlayable = Memory.ReadVirtualFunction<Eggstensions.Delegates.Types.TESAmmo.IsPlayable>(*(System.IntPtr*)ammo, 0x19);

			return isPlayable(ammo) != 0;
		}
	}
}
