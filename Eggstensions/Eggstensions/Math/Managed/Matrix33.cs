namespace Eggstensions.Math.Managed
{
	public class Matrix33 : Matrix
	{
		#region New methods
		/// <summary>The adjugate of this Matrix33.</summary>
		new public Matrix33 Adjugate()
		{
			return new Matrix33(Library.Matrix.Adjugate(Elements));
		}

		/// <summary>The identity Matrix33.</summary>
		public Matrix33 Identity()
		{
			return new Matrix33(Library.Matrix.Identity(Rows)); // Rows == Columns
		}

		/// <summary>The inverse of this Matrix33.</summary>
		new public Matrix33 Invert()
		{
			return new Matrix33(Library.Matrix.Invert(Elements));
		}

		/// <summary>The transpose of this Matrix33.</summary>
		new public Matrix33 Transpose()
		{
			return new Matrix33(Library.Matrix.Transpose(Elements));
		}

		/// <summary>The zero Matrix33.</summary>
		public Matrix33 Zero()
		{
			return new Matrix33(Library.Matrix.Zero(Rows, Columns));
		}
		#endregion



		public Matrix33(System.Single[,] elements)
			: base(elements)
		{
			if (Rows != 3) { throw new Eggceptions.Math.Matrix.ArgumentMatrixDimensionsException("elements"); }
			if (Columns != 3) { throw new Eggceptions.Math.Matrix.ArgumentMatrixDimensionsException("elements"); }
		}



		#region Methods
		/// <summary>The interpolated Matrix33 at the specified ratio between this Matrix33 and another Matrix33.</summary>
		public Matrix33 Interpolate(Matrix33 other, System.Single ratio)
		{
			if (other == null) { throw new Eggceptions.ArgumentNullException("other"); }
			// ratio

			return new Matrix33(Library.Matrix33.Interpolate(Elements, other.Elements, ratio));
		}

		/// <summary>Rotate this Matrix33 about the x-axis.</summary>
		/// <param name="angle">Radians</param>
		public Matrix33 RotateX(System.Single angle)
		{
			// angle

			return new Matrix33(Library.Matrix33.RotateX(Elements, angle));
		}

		/// <summary>Rotate this Matrix33 about the y-axis.</summary>
		/// <param name="angle">Radians</param>
		public Matrix33 RotateY(System.Single angle)
		{
			// angle

			return new Matrix33(Library.Matrix33.RotateY(Elements, angle));
		}

		/// <summary>Rotate this Matrix33 about the z-axis.</summary>
		/// <param name="angle">Radians</param>
		public Matrix33 RotateZ(System.Single angle)
		{
			// angle

			return new Matrix33(Library.Matrix33.RotateZ(Elements, angle));
		}

		/// <summary>Convert this Matrix33 rotation matrix to axis-angle representation.</summary>
		/// <returns>Vector3 axis, Radians angle</returns>
		public (Vector3 axis, System.Single angle) RotationMatrixToAxisAngle()
		{
			(var axis, var angle) = Library.Matrix33.RotationMatrixToAxisAngle(Elements);

			return (new Vector3(axis), angle);
		}

		/// <summary>Convert this Matrix33 rotation matrix to Euler angle representation (Rx, Ry, Rz).</summary>
		public Vector3 RotationMatrixToEulerAngles()
		{
			return new Vector3(Library.Matrix33.RotationMatrixToEulerAngles(Elements));
		}
		#endregion



		#region Operator overloading
		// Matrix33 + Matrix33
		static public Matrix33 operator +(Matrix33 left, Matrix33 right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException("left"); }
			if (right == null) { throw new Eggceptions.ArgumentNullException("right"); }

			return new Matrix33(Library.Matrix.Add(left.Elements, right.Elements));
		}

		// Matrix33 + System.Single
		static public Matrix33 operator +(Matrix33 matrix33, System.Single scalar)
		{
			if (matrix33 == null) { throw new Eggceptions.ArgumentNullException("matrix33"); }
			// scalar

			return new Matrix33(Library.Matrix.Add(matrix33.Elements, scalar));
		}

		// System.Single + Matrix33
		static public Matrix33 operator +(System.Single scalar, Matrix33 matrix33)
		{
			// scalar
			if (matrix33 == null) { throw new Eggceptions.ArgumentNullException("matrix33"); }

			return new Matrix33(Library.Matrix.Add(matrix33.Elements, scalar));
		}

		// Matrix33 + System.Single[,]
		static public Matrix33 operator +(Matrix33 left, System.Single[,] right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException("left"); }
			if (right == null) { throw new Eggceptions.ArgumentNullException("right"); }

			return new Matrix33(Library.Matrix.Add(left.Elements, right));
		}

		// System.Single[,] + Matrix33
		static public Matrix33 operator +(System.Single[,] left, Matrix33 right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException("left"); }
			if (right == null) { throw new Eggceptions.ArgumentNullException("right"); }

			return new Matrix33(Library.Matrix.Add(left, right.Elements));
		}

		// -Matrix33
		static public Matrix33 operator -(Matrix33 matrix33)
		{
			if (matrix33 == null) { throw new Eggceptions.ArgumentNullException("matrix33"); }

			return new Matrix33(Library.Matrix.Negate(matrix33.Elements));
		}

		// Matrix33 - Matrix33
		static public Matrix33 operator -(Matrix33 left, Matrix33 right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException("left"); }
			if (right == null) { throw new Eggceptions.ArgumentNullException("right"); }

			return new Matrix33(Library.Matrix.Subtract(left.Elements, right.Elements));
		}

		// Matrix33 - System.Single
		static public Matrix33 operator -(Matrix33 matrix33, System.Single scalar)
		{
			if (matrix33 == null) { throw new Eggceptions.ArgumentNullException("matrix33"); }
			// scalar

			return new Matrix33(Library.Matrix.Subtract(matrix33.Elements, scalar));
		}

		// System.Single - Matrix33
		static public Matrix33 operator -(System.Single scalar, Matrix33 matrix33)
		{
			// scalar
			if (matrix33 == null) { throw new Eggceptions.ArgumentNullException("matrix33"); }

			return new Matrix33(Library.Matrix.Subtract(scalar, matrix33.Elements));
		}

		// Matrix33 - System.Single[,]
		static public Matrix33 operator -(Matrix33 left, System.Single[,] right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException("left"); }
			if (right == null) { throw new Eggceptions.ArgumentNullException("right"); }

			return new Matrix33(Library.Matrix.Subtract(left.Elements, right));
		}

		// System.Single[,] - Matrix33
		static public Matrix33 operator -(System.Single[,] left, Matrix33 right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException("left"); }
			if (right == null) { throw new Eggceptions.ArgumentNullException("right"); }

			return new Matrix33(Library.Matrix.Subtract(left, right.Elements));
		}

		// Matrix33 * Matrix33
		static public Matrix33 operator *(Matrix33 left, Matrix33 right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException("left"); }
			if (right == null) { throw new Eggceptions.ArgumentNullException("right"); }

			return new Matrix33(Library.Matrix.Multiply(left.Elements, right.Elements));
		}

		// Matrix33 * System.Single
		static public Matrix33 operator *(Matrix33 matrix33, System.Single scalar)
		{
			if (matrix33 == null) { throw new Eggceptions.ArgumentNullException("matrix33"); }
			// scalar

			return new Matrix33(Library.Matrix.Multiply(matrix33.Elements, scalar));
		}

		// System.Single * Matrix33
		static public Matrix33 operator *(System.Single scalar, Matrix33 matrix33)
		{
			// scalar
			if (matrix33 == null) { throw new Eggceptions.ArgumentNullException("matrix33"); }

			return new Matrix33(Library.Matrix.Multiply(matrix33.Elements, scalar));
		}

		// Matrix33 * System.Single[,]

		// System.Single[,] * Matrix33
		#endregion
	}
}
