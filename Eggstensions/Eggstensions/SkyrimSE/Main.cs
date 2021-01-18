namespace Eggstensions.SkyrimSE
{
	static public class Main
	{
		/// <returns>Main</returns>
		static public System.IntPtr Instance
		{
			get
			{
				var instance = NetScriptFramework.Memory.ReadPointer(VIDS.Main.Instance);
				if (instance == System.IntPtr.Zero) { throw new Eggceptions.NullException(nameof(instance)); }

				return instance;
			}
		}
	}
}
