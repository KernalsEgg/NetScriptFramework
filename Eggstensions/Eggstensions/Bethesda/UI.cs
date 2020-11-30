namespace Eggstensions.Bethesda
{
	/// <summary>NetScriptFramework.SkyrimSE.Main</summary>
	static public class UI
	{
		/// <summary>&lt;SkyrimSE.exe&gt; + 0x1EBEB20 (VID514178)</summary>
		/// <returns>UI</returns>
		static public System.IntPtr Instance
		{
			get
			{
				var instancePointer = NetScriptFramework.Main.GameInfo.GetAddressOf(514178);
				if (instancePointer == System.IntPtr.Zero) { throw new Eggceptions.NullException("instancePointer"); }

				var instance = NetScriptFramework.Memory.ReadPointer(instancePointer);
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

		/// <summary>&lt;SkyrimSE.exe&gt; + 0x96DD60 (VID54737)</summary>
		static public void ShowMessageBox(System.String text)
		{
			if (System.String.IsNullOrWhiteSpace(text)) { throw new Eggceptions.ArgumentNullOrWhiteSpaceException(text); }

			using (var bsFixedString = new BSFixedString(text))
			{
				var functionAddress = NetScriptFramework.Main.GameInfo.GetAddressOf(54737);
				if (functionAddress == System.IntPtr.Zero) { throw new Eggceptions.NullException("functionAddress"); }

				NetScriptFramework.Memory.InvokeCdecl(functionAddress, System.IntPtr.Zero, System.IntPtr.Zero, System.IntPtr.Zero, bsFixedString.Address);
			}
		}

		/// <summary>&lt;SkyrimSE.exe&gt; + 0x96DDB0 (VID54738)</summary>
		static public void ShowNotification(System.String text)
		{
			if (System.String.IsNullOrWhiteSpace(text)) { throw new Eggceptions.ArgumentNullOrWhiteSpaceException(text); }

			using (var bsFixedString = new BSFixedString(text))
			{
				var functionAddress = NetScriptFramework.Main.GameInfo.GetAddressOf(54738);
				if (functionAddress == System.IntPtr.Zero) { throw new Eggceptions.NullException("functionAddress"); }

				NetScriptFramework.Memory.InvokeCdecl(functionAddress, System.IntPtr.Zero, System.IntPtr.Zero, System.IntPtr.Zero, bsFixedString.Address);
			}
		}
	}
}
