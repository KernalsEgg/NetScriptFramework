using Managed = Eggstensions.Math.Managed;
using Unmanaged = Eggstensions.Math.Unmanaged;



namespace Eggstensions.SkyrimSE
{
	public class NiPoint3 : Unmanaged.Vector3
	{
		override public System.Int32 Index(System.Int32 row, System.Int32 column)
		{
			return row + Rows * column;
		}



		public NiPoint3() : base() { }

		public NiPoint3(Managed.Vector3 vector3) : base(vector3) { }

		public NiPoint3(System.IntPtr address) : base(address) { }
	}
}
