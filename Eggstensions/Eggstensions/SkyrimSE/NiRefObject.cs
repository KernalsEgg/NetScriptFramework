namespace Eggstensions.SkyrimSE
{
	static public class NiRefObject
	{
		/// <param name="niRefObject">NiRefObject</param>
		static public System.Int32 DecrementReferenceCount(System.IntPtr niRefObject)
		{
			if (niRefObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(niRefObject)); }

			var referenceCount = NetScriptFramework.Memory.InterlockedDecrement32(niRefObject + 0x8) & 0x3FF;
			
			if (referenceCount == 0)
			{
				NiRefObject.Destructor(niRefObject);
			}

			return referenceCount;
		}

		/// <param name="niRefObject">NiRefObject</param>
		static public void Destructor(System.IntPtr niRefObject)
		{
			if (niRefObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(niRefObject)); }

			VirtualObject.InvokeVTableThisCall(niRefObject, 0x8);
		}

		/// <param name="niRefObject">NiRefObject</param>
		static public System.UInt32 GetReferenceCount(System.IntPtr niRefObject)
		{
			if (niRefObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(niRefObject)); }

			return NetScriptFramework.Memory.ReadUInt32(niRefObject + 0x8);
		}

		/// <param name="niRefObject">NiRefObject</param>
		static public System.Int32 IncrementReferenceCount(System.IntPtr niRefObject)
		{
			if (niRefObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(niRefObject)); }

			return NetScriptFramework.Memory.InterlockedIncrement32(niRefObject + 0x8);
		}
	}
}
