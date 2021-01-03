namespace Eggstensions.Bethesda
{
	static public class CrosshairPickData
	{
		static public System.IntPtr Instance
		{
			get
			{
				var instance = NetScriptFramework.Memory.ReadPointer(VIDS.CrosshairPickData.Instance);
				if (instance == System.IntPtr.Zero) { throw new Eggceptions.NullException("instance"); }

				return instance;
			}
		}
	}
}
