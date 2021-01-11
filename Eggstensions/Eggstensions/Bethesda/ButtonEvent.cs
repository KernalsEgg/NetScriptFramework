namespace Eggstensions.Bethesda
{
	static public class ButtonEvent
	{
		/// <param name="buttonEvent">ButtonEvent</param>
		static public System.Single GetHeldDuration(System.IntPtr buttonEvent)
		{
			if (buttonEvent == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("buttonEvent"); }

			return NetScriptFramework.Memory.ReadFloat(buttonEvent + 0x2C);
		}

		/// <param name="buttonEvent">ButtonEvent</param>
		static public System.Single GetValue(System.IntPtr buttonEvent)
		{
			if (buttonEvent == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("buttonEvent"); }

			return NetScriptFramework.Memory.ReadFloat(buttonEvent + 0x28);
		}

		/// <param name="buttonEvent">ButtonEvent</param>
		static public System.Boolean IsHeld(System.IntPtr buttonEvent)
		{
			if (buttonEvent == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("buttonEvent"); }

			return
				(ButtonEvent.GetValue(buttonEvent) > 0.0f) &&
				(ButtonEvent.GetHeldDuration(buttonEvent) >= 0.0f);
		}

		/// <param name="buttonEvent">ButtonEvent</param>
		static public System.Boolean IsPressed(System.IntPtr buttonEvent)
		{
			if (buttonEvent == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("buttonEvent"); }

			return
				(ButtonEvent.GetValue(buttonEvent) > 0.0f) &&
				(ButtonEvent.GetHeldDuration(buttonEvent) == 0.0f);
		}

		/// <param name="buttonEvent">ButtonEvent</param>
		static public System.Boolean IsReleased(System.IntPtr buttonEvent)
		{
			if (buttonEvent == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("buttonEvent"); }

			return
				(ButtonEvent.GetValue(buttonEvent) == 0.0f) &&
				(ButtonEvent.GetHeldDuration(buttonEvent) >= 0.0f);
		}
	}
}
