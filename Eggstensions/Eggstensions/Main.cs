[module: System.Runtime.CompilerServices.SkipLocalsInit]



namespace Eggstensions
{
	public class Main
	{
		static Main()
		{
			Main.ExecutingAssembly				= System.Reflection.Assembly.GetExecutingAssembly();
			Main.ExecutingAssemblyName			= Main.ExecutingAssembly.GetName().Name;
			Main.ExecutingAssemblyDirectoryName	= System.IO.Path.GetDirectoryName(Main.ExecutingAssembly.Location);

			Main.MainModule					= System.Diagnostics.Process.GetCurrentProcess().MainModule;
			Main.MainModuleName				= Main.MainModule.ModuleName;
			Main.MainModuleDirectoryName	= System.IO.Path.GetDirectoryName(Main.MainModule.FileName);

			Main.ProductVersion			= Main.MainModule.FileVersionInfo.ProductVersion;
			Main.ProductVersionMajor	= System.Int32.Parse(Main.ProductVersion.Split('.')[0]);
			Main.ProductVersionMinor	= System.Int32.Parse(Main.ProductVersion.Split('.')[1]);
			Main.ProductVersionBuild	= System.Int32.Parse(Main.ProductVersion.Split('.')[2]);
			Main.ProductVersionPrivate	= System.Int32.Parse(Main.ProductVersion.Split('.')[3]);
		}



		static public System.Diagnostics.ProcessModule MainModule { get; }
		static public System.Int32 ProductVersionMajor { get; }
		static public System.Int32 ProductVersionMinor { get; }
		static public System.Int32 ProductVersionBuild { get; }
		static public System.Int32 ProductVersionPrivate { get; }
		static public System.Reflection.Assembly ExecutingAssembly { get; }
		static public System.String ExecutingAssemblyDirectoryName { get; }
		static public System.String ExecutingAssemblyName { get; }
		static public System.String MainModuleDirectoryName { get; }
		static public System.String MainModuleName { get; }
		static public System.String ProductVersion { get; }
	}
}
