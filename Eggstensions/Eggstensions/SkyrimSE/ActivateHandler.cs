namespace Eggstensions.SkyrimSE
{
	static public class ActivateHandler
	{
		/// <param name="activateHandler">ActivateHandler</param>
		static public System.Boolean IsActivateControlsDisabled(System.IntPtr activateHandler)
		{
			if (activateHandler == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(activateHandler)); }

			return NetScriptFramework.Memory.ReadUInt8(activateHandler + 0x1B) != 0;
		}
	}
}
