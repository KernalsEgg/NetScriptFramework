namespace Eggstensions.Bethesda
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
				if (instance == System.IntPtr.Zero) { throw new Eggceptions.NullException("instance"); }

				return instance;
			}
		}



		/// <param name="ui">UI</param>
		static public System.UInt32 GetPauseGameCount(System.IntPtr ui)
		{
			if (ui == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("ui"); }

			return NetScriptFramework.Memory.ReadUInt32(ui + 0x160);
		}

		static public void ShowMessageBox(System.String text)
		{
			if (System.String.IsNullOrWhiteSpace(text)) { throw new Eggceptions.ArgumentNullOrWhiteSpaceException(text); }

			using (var bsFixedString = new BSFixedString(text))
			{
				NetScriptFramework.Memory.InvokeCdecl(VIDS.UI.ShowMessageBox, System.IntPtr.Zero, System.IntPtr.Zero, System.IntPtr.Zero, bsFixedString.Address);
			}
		}

		static public void ShowNotification(System.String text)
		{
			if (System.String.IsNullOrWhiteSpace(text)) { throw new Eggceptions.ArgumentNullOrWhiteSpaceException(text); }

			using (var bsFixedString = new BSFixedString(text))
			{
				NetScriptFramework.Memory.InvokeCdecl(VIDS.UI.ShowNotification, System.IntPtr.Zero, System.IntPtr.Zero, System.IntPtr.Zero, bsFixedString.Address);
			}
		}
	}
}
