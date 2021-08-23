namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x10)]
	unsafe public struct NiRefObject
	{
		[System.Runtime.InteropServices.FieldOffset(0x8)] volatile public System.Int32 ReferenceCount;



		// Virtual
		static public void Delete(NiRefObject* referenceObject)
		{
			var delete = Memory.ReadVirtualFunction<Eggstensions.Delegates.Types.NiRefObject.Delete>(*(System.IntPtr*)referenceObject, 0x1);

			delete(referenceObject);
		}
	}
}
