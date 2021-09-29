namespace Eggstensions
{
	public class Log
	{
		readonly static private System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(System.IO.Path.Combine(Main.ExecutingAssemblyDirectoryName, $"{Main.ExecutingAssemblyName}.log"), false) { AutoFlush = true };



		static public void Error(System.String value, [System.Runtime.CompilerServices.CallerFilePath] System.String filePath = "", [System.Runtime.CompilerServices.CallerLineNumber] System.Int32 lineNumber = 0)
		{
			streamWriter.WriteLine($"[{System.DateTime.Now}] {filePath}:line {lineNumber}: {value}");
		}

		static public void Information(System.String value)
		{
			streamWriter.WriteLine($"[{System.DateTime.Now}] {value}");
		}
	}
}
