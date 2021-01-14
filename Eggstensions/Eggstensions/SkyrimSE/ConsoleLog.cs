namespace Eggstensions.SkyrimSE
{
	static public class ConsoleLog
	{
		/// <returns>ConsoleLog</returns>
		static public System.IntPtr Instance
		{
			get
			{
				var instance = NetScriptFramework.Memory.ReadPointer(VIDS.ConsoleLog.Instance);
				if (instance == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(instance)); }

				return instance;
			}
		}



		static public void Print(System.IntPtr consoleLog, System.String text, System.Int64 argument)
		{
			if (System.String.IsNullOrWhiteSpace(text)) { throw new Eggceptions.ArgumentNullOrWhiteSpaceException(nameof(text)); }

			using (var textAllocation = NetScriptFramework.Memory.AllocateString(text, false))
			{
				NetScriptFramework.Memory.InvokeCdecl(VIDS.ConsoleLog.Print, consoleLog, textAllocation.Address, argument);
			}
		}
	}
}
