namespace Eggstensions.Math.Library
{
	static public class Quaternion
	{
		// www.euclideanspace.com/maths/geometry/rotations/conversions/quaternionToMatrix
		/// <summary>SkyrimSE.exe + 0x1CFA50 (VID15612)</summary>
		static public System.Single[,] QuaternionToMatrix33(System.Single[,] quaternion)
		{
			if (quaternion == null) { throw new Eggceptions.ArgumentNullException(nameof(quaternion)); }

			var w = quaternion[0, 0];
			var x = quaternion[0, 1];
			var y = quaternion[0, 2];
			var z = quaternion[0, 3];

			var xw = x * w;
			var xx = x * x;
			var xy = x * y;
			var xz = x * z;

			var yw = y * w;
			var yy = y * y;
			var yz = y * z;

			var zw = z * w;
			var zz = z * z;

			return new System.Single[,]
			{
				{ 1 - 2 * (yy + zz), 2 * (xy + zw), 2 * (xz - yw) },
				{ 2 * (xy - zw), 1 - 2 * (xx + zz), 2 * (yz + xw) },
				{ 2 * (xz + yw), 2 * (yz - xw), 1 - 2 * (xx + yy) }
			};
		}
	}
}
