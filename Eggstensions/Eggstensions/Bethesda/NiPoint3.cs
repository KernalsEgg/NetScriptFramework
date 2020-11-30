using Managed = Eggstensions.Math.Managed;
using Unmanaged = Eggstensions.Math.Unmanaged;



namespace Eggstensions.Bethesda
{
	public class NiPoint3 : Unmanaged.Vector3
	{
		override public System.Int32? Padding { get; } = 0x10;



		override public System.Int32 Index(System.Int32 row, System.Int32 column)
		{
			return row + Rows * column;
		}



		public NiPoint3() : base() { }

		public NiPoint3(Managed.Matrix matrix) : base(matrix) { }

		public NiPoint3(System.Single[,] elements) : base(elements) { }

		public NiPoint3(System.IntPtr address) : base(address) { }
	}
}
