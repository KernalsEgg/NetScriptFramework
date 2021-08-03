namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x220)]
	unsafe public struct TESObjectWEAP // TESBoundObject
	{
		[System.Runtime.InteropServices.FieldOffset(0x0)] public TESBoundObject TESBoundObject;



		static public TESObjectWEAP* Unarmed
		{
			get
			{
				return (TESObjectWEAP*)Memory.Read<System.IntPtr>(Eggstensions.Offsets.TESObjectWEAP.Unarmed).ToPointer();
			}
		}
	}
}
