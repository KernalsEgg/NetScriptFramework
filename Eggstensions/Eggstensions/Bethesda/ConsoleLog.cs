namespace Eggstensions.Bethesda
{
	static public class ConsoleLog
	{
		/// <summary>&lt;SkyrimSE.exe&gt; + 0x2F000F0 (VID515064)</summary>
		/// <returns>ConsoleLog</returns>
		static public System.IntPtr Instance
		{
			get
			{
				var instancePointer = NetScriptFramework.Main.GameInfo.GetAddressOf(515064);
				if (instancePointer == System.IntPtr.Zero) { throw new Eggceptions.NullException("instancePointer"); }

				var instance = NetScriptFramework.Memory.ReadPointer(instancePointer);
				if (instance == System.IntPtr.Zero) { throw new Eggceptions.NullException("instance"); }

				return instance;
			}
		}



		/// <summary>&lt;SkyrimSE.exe&gt; + 0x85C290 (VID50179)</summary>
		static public void Print(System.IntPtr consoleLog, System.String text, System.Int64 argument)
		{
			if (System.String.IsNullOrWhiteSpace(text)) { throw new Eggceptions.ArgumentNullOrWhiteSpaceException(text); }

			using (var allocation = NetScriptFramework.Memory.AllocateString(text, false))
			{
				var functionAddress = NetScriptFramework.Main.GameInfo.GetAddressOf(50179);
				if (functionAddress == System.IntPtr.Zero) { throw new Eggceptions.NullException("functionAddress"); }

				NetScriptFramework.Memory.InvokeCdecl(functionAddress, consoleLog, allocation.Address, argument);
			}
		}
	}
}
