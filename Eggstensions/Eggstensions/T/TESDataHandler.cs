namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0xDC0)]
	unsafe public struct TESDataHandler
	{
		// Static
		static public TESForm* GetForm(System.UInt32 formID)
		{
			return Eggstensions.Delegates.Instances.TESDataHandler.GetForm(formID);
		}
	}
}
