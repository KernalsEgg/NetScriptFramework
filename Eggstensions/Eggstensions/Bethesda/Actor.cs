namespace Eggstensions.Bethesda
{
	static public class Actor
	{
		/// <param name = "actor">Actor</param>
		/// <returns>AIProcess</returns>
		static public System.IntPtr GetProcess(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("actor"); }

			var process = NetScriptFramework.Memory.ReadPointer(actor + 0xF0);
			if (process == System.IntPtr.Zero) { throw new Eggceptions.NullException("process"); }

			return process;
		}

		/// <summary>&lt;SkyrimSE.exe&gt; + 0x650DF0 (VID38404)</summary>
		/// <param name = "actor">Actor</param>
		/// <returns>MiddleHighProcessData</returns>
		static public System.IntPtr Update3DModel(System.IntPtr actor)
		{
			if (actor == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("actor"); }

			var functionAddress = NetScriptFramework.Main.GameInfo.GetAddressOf(38404);
			if (functionAddress == System.IntPtr.Zero) { throw new Eggceptions.NullException("functionAddress"); }

			var middleHighProcessData = NetScriptFramework.Memory.InvokeThisCall(Actor.GetProcess(actor), functionAddress, actor);
			if (middleHighProcessData == System.IntPtr.Zero) { throw new Eggceptions.NullException("middleHighProcessData"); }

			return middleHighProcessData;
		}
	}
}
