namespace Eggstensions.SkyrimSE
{
	static public class NiObject
	{
		/// <param name="niObject">NiObject</param>
		/// <returns>NiRTTI</returns>
		static public System.IntPtr GetNiRTTI(System.IntPtr niObject)
		{
			if (niObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(niObject)); }

			var niRTTI = VirtualObject.InvokeVTableThisCall(niObject, 0x10);
			if (niRTTI == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(niRTTI)); }

			return niRTTI;
		}
		
		/// <summary>SkyrimSE.exe + 0x1C4510 (VID15449)</summary>
		/// <param name = "niObject">NiObject</param>
		/// <param name = "niRTTI">NiRTTI</param>
		static public System.Boolean HasNiRTTI(System.IntPtr niObject, System.IntPtr niRTTI)
		{
			if (niObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(niObject)); }
			if (niRTTI == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(niRTTI)); }

			foreach (var currentNiRTTI in new NiRTTI(NiObject.GetNiRTTI(niObject)))
			{
				if (currentNiRTTI == niRTTI)
				{
					return true;
				}
			}

			return false;
		}
	}
}
