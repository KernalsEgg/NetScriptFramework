namespace Eggstensions.Bethesda
{
	static public class NiObject
	{
		/// <summary>&lt;SkyrimSE.exe&gt; + 0x1C4510 (VID15449)</summary>
		/// <param name = "niObject">NiObject</param>
		/// <param name = "niRTTI">NiRTTI</param>
		static public System.Boolean HasRTTI(System.IntPtr niObject, System.IntPtr niRTTI)
		{
			if (niObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niObject"); }
			if (niRTTI == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niRTTI"); }

			var currentNiRTTI = VirtualObject.InvokeVTableThisCall(niObject, 0x10);
			if (currentNiRTTI == System.IntPtr.Zero) { throw new Eggceptions.NullException("address"); }

			while (currentNiRTTI != niRTTI)
			{
				currentNiRTTI = NetScriptFramework.Memory.ReadPointer(currentNiRTTI + 0x8);

				if (currentNiRTTI == System.IntPtr.Zero)
				{
					return false;
				}
			}

			return true;
		}
	}
}
