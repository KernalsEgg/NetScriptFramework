namespace Eggstensions.SkyrimSE
{
	static public class BSHandleRefObject
	{
		public enum Flags : System.UInt32
		{
			ValidHandle = 1u << 10
		}



		/// <param name = "pointerHandle">BSHandleRefObject</param>
		static public System.IntPtr GetReferenceFromHandleRefObject(System.IntPtr handleRefObject)
		{
			if (handleRefObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(handleRefObject)); }

			return handleRefObject - 0x20;
		}

		/// <param name="handleRefObject">BSHandleRefObject</param>
		static public System.Boolean HasFlags(System.IntPtr handleRefObject, BSHandleRefObject.Flags flags)
		{
			if (handleRefObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(handleRefObject)); }

			return (NiRefObject.GetReferenceCount(handleRefObject) & (System.UInt32)flags) == (System.UInt32)flags;
		}

		/// <param name="handleRefObject">BSHandleRefObject</param>
		static public System.Boolean IsHandleValid(System.IntPtr handleRefObject)
		{
			if (handleRefObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(handleRefObject)); }

			return BSHandleRefObject.HasFlags(handleRefObject, BSHandleRefObject.Flags.ValidHandle);
		}
	}
}
