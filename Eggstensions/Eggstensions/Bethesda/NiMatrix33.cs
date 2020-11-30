using Managed = Eggstensions.Math.Managed;
using Unmanaged = Eggstensions.Math.Unmanaged;



namespace Eggstensions.Bethesda
{
	public class NiMatrix33 : Eggstensions.Math.Unmanaged.Matrix33
	{
		override public System.Int32? Padding { get; } = 0x40;



		override public System.Int32 Index(System.Int32 row, System.Int32 column)
		{
			return row + Rows * column;
		}



		public NiMatrix33() : base() { }

		public NiMatrix33(Managed.Matrix matrix) : base(matrix) { }

		public NiMatrix33(System.Single[,] elements) : base(elements) { }

		public NiMatrix33(System.IntPtr address) : base(address) { }
	}
}
