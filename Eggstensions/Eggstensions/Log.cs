namespace Eggstensions
{
	public class Log
	{
		static public System.IO.StreamWriter StreamWriter { get; } = new System.IO.StreamWriter(System.IO.Path.Combine(Main.ExecutingAssemblyDirectoryName, $"{Main.ExecutingAssemblyName}.log"), false) { AutoFlush = true };



		static public void WriteLine(System.String value)
		{
			StreamWriter.WriteLine($"[{System.DateTime.Now}] {value}");
		}
	}
}
