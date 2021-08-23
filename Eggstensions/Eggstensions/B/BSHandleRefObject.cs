namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x10)]
	unsafe public struct BSHandleRefObject
	{
		[System.Runtime.InteropServices.FieldOffset(0x0)] public NiRefObject NiRefObject;



		// Member
		static public void DecrementReferenceCount(BSHandleRefObject* handleReferenceObject)
		{
			var referenceObject = &handleReferenceObject->NiRefObject;

			if (System.Threading.Interlocked.Decrement(ref referenceObject->ReferenceCount) == 0)
			{
				NiRefObject.Delete(referenceObject);
			}
		}

		static public void IncrementReferenceCount(BSHandleRefObject* handleReferenceObject)
		{
			System.Threading.Interlocked.Increment(ref handleReferenceObject->NiRefObject.ReferenceCount);
		}
	}
}
