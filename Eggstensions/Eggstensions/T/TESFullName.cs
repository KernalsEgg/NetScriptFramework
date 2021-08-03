namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x10)]
	unsafe public struct TESFullName
	{
		// Virtual
		static public System.String GetFullName(TESFullName* fullName)
		{
			var getFullName = Memory.ReadVirtualFunction<Eggstensions.Delegates.Types.TESFullName.GetFullName>(*(System.IntPtr*)fullName, 0x5);

			return Memory.ReadString(getFullName(fullName));
		}
	}
}
