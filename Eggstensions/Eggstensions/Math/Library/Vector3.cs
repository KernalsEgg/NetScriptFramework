namespace Eggstensions.Math.Library
{
	static public class Vector3
	{
		// www.euclideanspace.com/maths/geometry/rotations/conversions/angleToMatrix/index.htm
		// radians
		static public System.Single[,] AxisAngleToRotationMatrix(System.Single[,] axis, System.Single angle) // Matrix33
		{
			if (axis == null) { throw new Eggceptions.ArgumentNullException("axis"); }
			// angle
			if (!Matrix.IsVector3(axis)) { throw new Eggceptions.Math.Matrix.ArgumentMatrixDimensionsException("axis"); }
			if (!Vector.IsNormalized(axis)) { throw new Eggceptions.Math.Matrix.ArgumentUnnormalizedMatrixException("axis"); }

			var cos = (System.Single)System.Math.Cos(angle);
			var sin = (System.Single)System.Math.Sin(angle);

			var x = axis[0, 0];
			var y = axis[0, 1];
			var z = axis[0, 2];

			return new System.Single[,]
			{
				{ (1 - cos) * x * x + cos, (1 - cos) * x * y - z * sin, (1 - cos) * x * z + y * sin },
				{ (1 - cos) * x * y + z * sin, (1 - cos) * y * y + cos, (1 - cos) * y * z - x * sin },
				{ (1 - cos) * x * z - y * sin, (1 - cos) * y * z + x * sin, (1 - cos) * z * z + cos }
			};
		}

		// www.learnopencv.com/rotation-matrix-to-euler-angles/
		// Rx, Ry, Rz
		static public System.Single[,] EulerAnglesToRotationMatrix(System.Single[,] eulerAngles) // Matrix33
		{
			if (eulerAngles == null) { throw new Eggceptions.ArgumentNullException("eulerAngles"); }
			if (!Matrix.IsVector3(eulerAngles)) { throw new Eggceptions.Math.Matrix.ArgumentMatrixDimensionsException("eulerAngles"); }

			var identity = Matrix.Identity(3);
			var rotationX = Matrix33.RotateX(identity, eulerAngles[0, 0]);
			var rotationY = Matrix33.RotateY(identity, eulerAngles[0, 1]);
			var rotationZ = Matrix33.RotateZ(identity, eulerAngles[0, 2]);

			// rotationX * rotationY * rotationZ
			return Matrix.Multiply(Matrix.Multiply(rotationX, rotationY), rotationZ);
		}

		static public System.Single[,] RotationMatrixBetween(System.Single[,] left, System.Single[,] right) // Matrix33
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException("left"); }
			if (right == null) { throw new Eggceptions.ArgumentNullException("right"); }
			if (!Matrix.IsVector3(left)) { throw new Eggceptions.Math.Matrix.ArgumentMatrixDimensionsException("left"); }
			if (!Matrix.IsVector3(right)) { throw new Eggceptions.Math.Matrix.ArgumentMatrixDimensionsException("right"); }

			return Vector3.AxisAngleToRotationMatrix(Vector.CrossProduct(left, right), Vector.AngleBetween(left, right));
		}
	}
}
