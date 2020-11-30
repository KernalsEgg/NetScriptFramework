namespace Eggstensions
{
	static public class VirtualObject
	{
		/// <summary>NetScriptFramework.SkyrimSE.InvokeVTableThisCall</summary>
		/// <param name = "virtualObject">VirtualObject</param>
		static public System.IntPtr InvokeVTableThisCall(System.IntPtr virtualObject, System.Int32 offset, params NetScriptFramework.InvokeArgument[] arguments)
		{
			if (virtualObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("virtualObject"); }
			// offset
			// arguments

			var virtualTable = NetScriptFramework.Memory.ReadPointer(virtualObject);
			if (virtualTable == System.IntPtr.Zero) { throw new Eggceptions.NullException("virtualTable"); }

			var functionAddress = NetScriptFramework.Memory.ReadPointer(virtualTable + offset);
			if (functionAddress == System.IntPtr.Zero) { throw new Eggceptions.NullException("functionAddress"); }

			return NetScriptFramework.Memory.InvokeThisCall(virtualObject, functionAddress, arguments);
		}
	}
}
