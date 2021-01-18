using static NetScriptFramework._IntPtrExtensions;



namespace Eggstensions.SkyrimSE
{
	/// <summary>NetScriptFramework.SkyrimSE.MenuManager</summary>
	static public class UI
	{
		public enum Flags : System.UInt32
		{
			None =					0,
			PauseGame =				1u << 0,
			Modal =					1u << 4, // Pause other menus when in focus
			DisablePauseMenu =		1u << 7,
			EnableSaving =			1u << 11,
			Inventory =				1u << 13,
			ShowCursor =			1u << 14, // Show cursor when in focus
			CustomRendering =		1u << 15,
			Application =			1u << 17
		}



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



		/// <summary>UI.Flags.Application</summary>
		/// <param name="ui">UI</param>
		static public System.UInt32 GetApplicationCount(System.IntPtr ui)
		{
			if (ui == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(ui)); }

			return NetScriptFramework.Memory.ReadUInt32(ui + 0x178);
		}

		/// <summary>UI.Flags.CustomRendering</summary>
		/// <param name="ui">UI</param>
		static public System.UInt32 GetCustomRenderingCount(System.IntPtr ui)
		{
			if (ui == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(ui)); }

			return NetScriptFramework.Memory.ReadUInt32(ui + 0x174);
		}

		/// <summary>UI.Flags.DisablePauseMenu</summary>
		/// <param name="ui">UI</param>
		static public System.UInt32 GetDisablePauseMenuCount(System.IntPtr ui)
		{
			if (ui == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(ui)); }

			return NetScriptFramework.Memory.ReadUInt32(ui + 0x168);
		}

		/// <summary>UI.Flags.EnableSaving</summary>
		/// <param name="ui">UI</param>
		static public System.UInt32 GetEnableSavingCount(System.IntPtr ui)
		{
			if (ui == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(ui)); }

			return NetScriptFramework.Memory.ReadUInt32(ui + 0x16C);
		}

		/// <summary>UI.Flags.PauseGame</summary>
		/// <param name="ui">UI</param>
		static public System.UInt32 GetPauseGameCount(System.IntPtr ui)
		{
			if (ui == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(ui)); }

			return NetScriptFramework.Memory.ReadUInt32(ui + 0x160);
		}

		/// <summary>UI.Flags.Inventory</summary>
		/// <param name="ui">UI</param>
		static public System.UInt32 GetInventoryCount(System.IntPtr ui)
		{
			if (ui == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(ui)); }

			return NetScriptFramework.Memory.ReadUInt32(ui + 0x164);
		}

		/// <summary>UI.Flags.Modal</summary>
		/// <param name="ui">UI</param>
		static public System.Boolean GetModal(System.IntPtr ui)
		{
			if (ui == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(ui)); }

			return NetScriptFramework.Memory.ReadUInt8(ui + 0x17C) != 0;
		}

		/// <summary>UI.Flags.ShowCursor</summary>
		/// <param name="ui">UI</param>
		static public System.UInt32 GetShowCursorCount(System.IntPtr ui)
		{
			if (ui == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(ui)); }

			return NetScriptFramework.Memory.ReadUInt32(ui + 0x170);
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
