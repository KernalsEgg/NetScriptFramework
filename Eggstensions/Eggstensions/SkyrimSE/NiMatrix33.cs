using Managed = Eggstensions.Math.Managed;
using Unmanaged = Eggstensions.Math.Unmanaged;



namespace Eggstensions.SkyrimSE
{
	public class NiMatrix33 : Unmanaged.Matrix33
	{
		override public System.Int32 Index(System.Int32 row, System.Int32 column)
		{
			return row + Rows * column;
		}



		public NiMatrix33() : base() { }

		public NiMatrix33(Managed.Matrix33 matrix33) : base(matrix33) { }

		public NiMatrix33(System.IntPtr address) : base(address) { }
	}
}
