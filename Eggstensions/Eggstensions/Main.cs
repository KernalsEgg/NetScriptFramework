[module: System.Runtime.CompilerServices.SkipLocalsInit]

/*
C# 9.0 function pointers offer better performance and simpler implementation compared to the functions available in the System.Runtime.InteropServices.Marshal class.
However, there are situations where they can cause crashes, which need to be accounted for. Namely, they are:
1. The JIT Compiler can optimise a function to send a non-blittable type instead of a blittable type as an argument. For example, a System.Boolean instead of a System.Byte.
2. If function pointer fields or properties are called and are otherwise only initialized inline using for example the Memory.ReadRelativeCall function.
These crashes are prevented in the following ways:
1. Only call function pointers in functions with blittable type arguments and the [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)] attribute.
2. Always initialize function pointer fields and properties in functions.
*/



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
