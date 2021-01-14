using Managed = Eggstensions.Math.Managed;
using Unmanaged = Eggstensions.Math.Unmanaged;



namespace Eggstensions.SkyrimSE
{
	public class NiQuaternion : Unmanaged.Quaternion
	{
		override public System.Int32 Index(System.Int32 row, System.Int32 column)
		{
			return row + Rows * column;
		}



		public NiQuaternion() : base() { }

		public NiQuaternion(Managed.Quaternion quaternion) : base(quaternion) { }

		public NiQuaternion(System.IntPtr address) : base(address) { }
	}
}
