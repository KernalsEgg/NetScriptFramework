namespace Eggstensions.Bethesda
{
	static public class NiRefObject
	{
		/// <param name="niRefObject">NiRefObject</param>
		static public System.Boolean DecrementReferenceCount(System.IntPtr niRefObject)
		{
			if (niRefObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niRefObject"); }

			var referenceCount = NetScriptFramework.Memory.InterlockedDecrement32(niRefObject + 0x8) & 0x3FF;

			if (referenceCount == 0)
			{
				NiRefObject.Delete(niRefObject);

				return true;
			}

			return false;
		}

		static public void Delete(System.IntPtr niRefObject)
		{
			if (niRefObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niRefObject"); }

			VirtualObject.InvokeVTableThisCall(niRefObject, 0x8);
		}

		static public System.UInt32 GetReferenceCount(System.IntPtr niRefObject)
		{
			if (niRefObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niRefObject"); }

			return NetScriptFramework.Memory.ReadUInt32(niRefObject + 0x8);
		}

		/// <param name="niRefObject">NiRefObject</param>
		static public void IncrementReferenceCount(System.IntPtr niRefObject)
		{
			if (niRefObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niRefObject"); }

			NetScriptFramework.Memory.InterlockedIncrement32(niRefObject + 0x8);
		}
	}
}
