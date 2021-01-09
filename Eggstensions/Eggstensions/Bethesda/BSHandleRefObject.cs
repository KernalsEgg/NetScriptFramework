namespace Eggstensions.Bethesda
{
	static public class BSHandleRefObject
	{
		public enum Flags : System.UInt32
		{
			ValidHandle = 1u << 10
		}



		static public System.Boolean HasFlags(System.IntPtr bsHandleRefObject, BSHandleRefObject.Flags flags)
		{
			if (bsHandleRefObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bsHandleRefObject"); }

			return (NiRefObject.GetReferenceCount(bsHandleRefObject) & (System.UInt32)flags) == (System.UInt32)flags;
		}
		
		static public System.Boolean IsHandleValid(System.IntPtr bsHandleRefObject)
		{
			if (bsHandleRefObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bsHandleRefObject"); }

			return BSHandleRefObject.HasFlags(bsHandleRefObject, BSHandleRefObject.Flags.ValidHandle);
		}
	}
}
