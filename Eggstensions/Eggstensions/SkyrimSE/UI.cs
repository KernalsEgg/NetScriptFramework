using static NetScriptFramework._IntPtrExtensions;



namespace Eggstensions.SkyrimSE
{
	/// <summary>NetScriptFramework.SkyrimSE.MenuManager</summary>
	static public class UI
	{
		/// <returns>UI</returns>
		static public System.IntPtr Instance
		{
			get
			{
				var instance = NetScriptFramework.Memory.ReadPointer(VIDS.UI.Instance);
				if (instance == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(instance)); }

				return instance;
			}
		}

		static public System.Boolean IsInMenuMode
		{
			get
			{
				return NetScriptFramework.Memory.InvokeCdecl(VIDS.UI.IsInMenuMode).ToBool();
			}
		}



		/// <param name="ui">UI</param>
		static public System.UInt32 GetPauseGameCount(System.IntPtr ui)
		{
			if (ui == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(ui)); }

			return NetScriptFramework.Memory.ReadUInt32(ui + 0x160);
		}

		static public void ShowMessageBox(System.String text)
		{
			if (System.String.IsNullOrWhiteSpace(text)) { throw new Eggceptions.ArgumentNullOrWhiteSpaceException(nameof(text)); }

			using (var bsFixedString = new BSFixedString(text))
			{
				NetScriptFramework.Memory.InvokeCdecl(VIDS.UI.ShowMessageBox, System.IntPtr.Zero, System.IntPtr.Zero, System.IntPtr.Zero, bsFixedString.Address);
			}
		}

		static public void ShowNotification(System.String text)
		{
			if (System.String.IsNullOrWhiteSpace(text)) { throw new Eggceptions.ArgumentNullOrWhiteSpaceException(nameof(text)); }

			using (var bsFixedString = new BSFixedString(text))
			{
				NetScriptFramework.Memory.InvokeCdecl(VIDS.UI.ShowNotification, System.IntPtr.Zero, System.IntPtr.Zero, System.IntPtr.Zero, bsFixedString.Address);
			}
		}
	}
}
