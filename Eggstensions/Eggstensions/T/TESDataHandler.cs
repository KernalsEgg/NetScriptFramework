namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0xDC0)]
	unsafe public struct TESDataHandler
	{
		// Static
		static public TESForm* GetForm(System.UInt32 formId)
		{
			var getForm = (delegate* unmanaged[Cdecl]<System.UInt32, TESForm*>)Eggstensions.Offsets.TESDataHandler.GetForm;

			return GetForm(formId);



			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			TESForm* GetForm(System.UInt32 formId)
			{
				return getForm(formId);
			}
		}
	}
}
