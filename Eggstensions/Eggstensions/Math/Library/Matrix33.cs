namespace Eggstensions.Math.Library
{
	static public class Matrix33
	{
		// www.stackoverflow.com/questions/3093455/3d-geometry-how-to-interpolate-a-matrix
		static public System.Single[,] Interpolate(System.Single[,] left, System.Single[,] right, System.Single ratio)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException("left"); }
			if (right == null) { throw new Eggceptions.ArgumentNullException("right"); }
			if (ratio < 0 || ratio > 1) { throw new Eggceptions.ArgumentOutOfRangeException("ratio"); }
			if (!Matrix.IsMatrix33(left)) { throw new Eggceptions.Math.Matrix.ArgumentMatrixDimensionsException("left"); }
			if (!Matrix.IsMatrix33(right)) { throw new Eggceptions.Math.Matrix.ArgumentMatrixDimensionsException("right"); }

			var transpose = Matrix.Transpose(left);
			(var axis, var angle) = Matrix33.RotationMatrixToAxisAngle(Matrix.Multiply(right, transpose)); // rotationMatrix = delta
			var rotationMatrix = Vector3.AxisAngleToRotationMatrix(axis, angle * ratio);

			return Matrix.Multiply(rotationMatrix, left);
		}

		// radians
		static public System.Single[,] RotateX(System.Single[,] matrix, System.Single angle)
		{
			if (matrix == null) { throw new Eggceptions.ArgumentNullException("matrix"); }
			// angle

			var cos = (System.Single)System.Math.Cos(angle);
			var sin = (System.Single)System.Math.Sin(angle);

			var rotationX = new System.Single[,]
			{
				{ 1, 0, 0 },
				{ 0, cos, sin },
				{ 0, -sin, cos }
			};

			return Matrix.Multiply(matrix, rotationX);
		}

		// radians
		static public System.Single[,] RotateY(System.Single[,] matrix, System.Single angle)
		{
			if (matrix == null) { throw new Eggceptions.ArgumentNullException("matrix"); }
			// angle

			var cos = (System.Single)System.Math.Cos(angle);
			var sin = (System.Single)System.Math.Sin(angle);

			var rotationY = new System.Single[,]
			{
				{ cos, 0, sin },
				{ 0, 1, 0 },
				{ -sin, 0, cos }
			};

			return Matrix.Multiply(matrix, rotationY);
		}

		// radians
		static public System.Single[,] RotateZ(System.Single[,] matrix, System.Single angle)
		{
			if (matrix == null) { throw new Eggceptions.ArgumentNullException("matrix"); }
			// angle

			var cos = (System.Single)System.Math.Cos(angle);
			var sin = (System.Single)System.Math.Sin(angle);

			var rotationZ = new System.Single[,]
			{
				{ cos, sin, 0 },
				{ -sin, cos, 0 },
				{ 0, 0, 1 }
			};

			return Matrix.Multiply(matrix, rotationZ);
		}

		// www.euclideanspace.com/maths/geometry/rotations/conversions/matrixToAngle/index.htm
		// radians
		static public (System.Single[,] axis, System.Single angle) RotationMatrixToAxisAngle(System.Single[,] rotationMatrix) // Vector3
		{
			if (rotationMatrix == null) { throw new Eggceptions.ArgumentNullException("rotationMatrix"); }
			if (!Matrix.IsMatrix33(rotationMatrix)) { throw new Eggceptions.Math.Matrix.ArgumentMatrixDimensionsException("rotationMatrix"); }
			if (!Matrix.IsRotationMatrix(rotationMatrix)) { throw new Eggceptions.Math.Matrix.ArgumentTransformationMatrixException("rotationMatrix"); }

			if (Matrix.IsSymmetric(rotationMatrix, false))
			{
				if (Matrix.IsIdentity(rotationMatrix))
				{
					var angle = 0.0f;
					var axis = new System.Single[,] { { 1, 0, 0 } }; // Arbitrary normalized axis

					return (axis, angle);
				}

				{
					var angle = (System.Single)System.Math.PI;

					/*
					{
						{ 2 * x * x - 1, 2 * x * y, 2 * x * z },
						{ 2 * x * y, 2 * y * y - 1, 2 * y * z },
						{ 2 * x * z, 2 * y * z, 2 * z * z - 1 }
					};
					*/

					var xx = (rotationMatrix[0, 0] + 1) / 2;
					var yy = (rotationMatrix[1, 1] + 1) / 2;
					var zz = (rotationMatrix[2, 2] + 1) / 2;

					var xy = (rotationMatrix[0, 1] + rotationMatrix[1, 0]) / 4;
					var xz = (rotationMatrix[0, 2] + rotationMatrix[2, 0]) / 4;
					var yz = (rotationMatrix[1, 2] + rotationMatrix[2, 1]) / 4;

					if ((xx > yy) && (xx > zz)) // x
					{
						if (xx == 0)
						{
							var axis = new System.Single[,] { { 0, (System.Single)System.Math.Cos((System.Single)System.Math.PI / 4), (System.Single)System.Math.Cos((System.Single)System.Math.PI / 4) } };

							return (axis, angle);
						}
						else
						{
							var x = (System.Single)System.Math.Sqrt(xx);
							var axis = new System.Single[,] { { x, xy / x, xz / x } };

							return (axis, angle);
						}
					}
					else if ((yy > xx) && (yy > zz)) // y
					{
						if (yy == 0)
						{
							var axis = new System.Single[,] { { (System.Single)System.Math.Cos((System.Single)System.Math.PI / 4), 0, (System.Single)System.Math.Cos((System.Single)System.Math.PI / 4) } };

							return (axis, angle);
						}
						else
						{
							var y = (System.Single)System.Math.Sqrt(yy);
							var axis = new System.Single[,] { { xy / y, y, yz / y } };

							return (axis, angle);
						}
					}
					else // z
					{
						if (zz == 0)
						{
							var axis = new System.Single[,] { { (System.Single)System.Math.Cos((System.Single)System.Math.PI / 4), (System.Single)System.Math.Cos((System.Single)System.Math.PI / 4), 0 } };

							return (axis, angle);
						}
						else
						{
							var z = (System.Single)System.Math.Sqrt(zz);
							var axis = new System.Single[,] { { xz / z, yz / z, z } };

							return (axis, angle);
						}
					}
				}
			}
			else
			{
				var angle = (System.Single)System.Math.Acos((rotationMatrix[0, 0] + rotationMatrix[1, 1] + rotationMatrix[2, 2] - 1) / 2);
				var axis = Vector.Normalize(new System.Single[,] { { rotationMatrix[2, 1] - rotationMatrix[1, 2], rotationMatrix[0, 2] - rotationMatrix[2, 0], rotationMatrix[1, 0] - rotationMatrix[0, 1] } });

				return (axis, angle);
			}
		}

		// www.geometrictools.com/Documentation/EulerAngles.pdf
		// Rx, Ry, Rz
		// radians
		static public System.Single[,] RotationMatrixToEulerAngles(System.Single[,] rotationMatrix) // Vector3
		{
			if (rotationMatrix == null) { throw new Eggceptions.ArgumentNullException("rotationMatrix"); }
			if (!Matrix.IsMatrix33(rotationMatrix)) { throw new Eggceptions.Math.Matrix.ArgumentMatrixDimensionsException("rotationMatrix"); }
			if (!Matrix.IsRotationMatrix(rotationMatrix)) { throw new Eggceptions.Math.Matrix.ArgumentTransformationMatrixException("rotationMatrix"); }

			if (rotationMatrix[0, 2] < 1)
			{
				if (rotationMatrix[0, 2] > -1) // r02 < 1 && r02 > -1
				{
					// { { Atan2(-r12, r22), Asin(r02), Atan2(-r01, r00) } }
					return new System.Single[,] { { (System.Single)System.Math.Atan2(-rotationMatrix[1, 2], rotationMatrix[2, 2]), (System.Single)System.Math.Asin(rotationMatrix[0, 2]), (System.Single)System.Math.Atan2(-rotationMatrix[0, 1], rotationMatrix[0, 0]) } };
				}
				else // r02 == -1
				{
					// { { -Atan2(r10, r11), -PI/2, 0 } }
					return new System.Single[,] { { -(System.Single)System.Math.Atan2(rotationMatrix[1, 0], rotationMatrix[1, 1]), -((System.Single)System.Math.PI / 2), 0 } };
				}
			}
			else // r02 == 1
			{
				// { { Atan2(r10, r11), PI/2, 0 } }
				return new System.Single[,] { { (System.Single)System.Math.Atan2(rotationMatrix[1, 0], rotationMatrix[1, 1]), (System.Single)System.Math.PI / 2, 0 } };
			}
		}
	}
}
