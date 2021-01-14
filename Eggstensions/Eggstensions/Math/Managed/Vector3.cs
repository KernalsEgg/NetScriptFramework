namespace Eggstensions.Math.Managed
{
	public class Vector3 : Vector
	{
		#region New methods
		/// <summary>The cross product of this Vector and other Vector's.</summary>
		public Vector3 CrossProduct(Vector3 other)
		{
			if (other == null) { throw new Eggceptions.ArgumentNullException(nameof(other)); }
			
			return new Vector3(Library.Vector.CrossProduct(Elements, other.Elements));
		}

		/// <summary>The normalization of this Vector.</summary>
		new public Vector3 Normalize()
		{
			return new Vector3(Library.Vector.Normalize(Elements));
		}

		/// <summary>The zero Vector3.</summary>
		public Vector3 Zero()
		{
			return new Vector3(Library.Matrix.Zero(Rows, Columns));
		}
		#endregion



		public Vector3(System.Single[,] elements)
			: base(elements)
		{
			if (Columns != 3) { throw new Eggceptions.Math.Matrix.ArgumentMatrixDimensionsException(nameof(elements)); }
		}



		#region Properties
		/// <summary>The x-coordinate of this Vector3.</summary>
		public System.Single X
		{
			get
			{
				return this[0, 0];
			}
			set
			{
				this[0, 0] = value;
			}
		}

		/// <summary>The y-coordinate of this Vector3.</summary>
		public System.Single Y
		{
			get
			{
				return this[0, 1];
			}
			set
			{
				this[0, 1] = value;
			}
		}

		/// <summary>The z-coordinate of this Vector3.</summary>
		public System.Single Z
		{
			get
			{
				return this[0, 2];
			}
			set
			{
				this[0, 2] = value;
			}
		}
		#endregion



		#region Methods
		/// <summary>Convert this Vector3 from axis-angle representation to a rotation matrix.</summary>
		/// <param name="angle">Radians</param>
		public Matrix33 AxisAngleToRotationMatrix(System.Single angle)
		{
			// angle

			return new Matrix33(Library.Vector3.AxisAngleToRotationMatrix(Elements, angle));
		}

		/// <summary>Convert this Vector3 from Euler angle representation to a rotation matrix.</summary>
		public Matrix33 EulerAnglesToRotationMatrix()
		{
			return new Matrix33(Library.Vector3.EulerAnglesToRotationMatrix(Elements));
		}

		/// <summary>Rotate this Vector3 about the x-axis.</summary>
		/// <param name="angle">Radians</param>
		public Vector3 RotateX(System.Single angle)
		{
			// angle

			return new Vector3(Library.Matrix33.RotateX(Elements, angle));
		}

		/// <summary>Rotate this Vector3 about the y-axis.</summary>
		/// <param name="angle">Radians</param>
		public Vector3 RotateY(System.Single angle)
		{
			// angle

			return new Vector3(Library.Matrix33.RotateY(Elements, angle));
		}

		/// <summary>Rotate this Vector3 about the z-axis.</summary>
		/// <param name="angle">Radians</param>
		public Vector3 RotateZ(System.Single angle)
		{
			// angle

			return new Vector3(Library.Matrix33.RotateZ(Elements, angle));
		}

		/// <summary>The rotation matrix necessary to rotate this Vector3 onto another Vector3.</summary>
		public Matrix33 RotationMatrixBetween(Vector3 other)
		{
			if (other == null) { throw new Eggceptions.ArgumentNullException(nameof(other)); }

			return new Matrix33(Library.Vector3.RotationMatrixBetween(Elements, other.Elements));
		}
		#endregion



		#region Operator overloading
		// Vector3 + Vector3
		static public Vector3 operator +(Vector3 left, Vector3 right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException(nameof(left)); }
			if (right == null) { throw new Eggceptions.ArgumentNullException(nameof(right)); }

			return new Vector3(Library.Matrix.Add(left.Elements, right.Elements));
		}

		// Vector3 + System.Single
		static public Vector3 operator +(Vector3 vector3, System.Single scalar)
		{
			if (vector3 == null) { throw new Eggceptions.ArgumentNullException(nameof(vector3)); }
			// scalar

			return new Vector3(Library.Matrix.Add(vector3.Elements, scalar));
		}

		// System.Single + Vector3
		static public Vector3 operator +(System.Single scalar, Vector3 vector3)
		{
			// scalar
			if (vector3 == null) { throw new Eggceptions.ArgumentNullException(nameof(vector3)); }

			return new Vector3(Library.Matrix.Add(vector3.Elements, scalar));
		}

		// Vector3 + System.Single[,]
		static public Vector3 operator +(Vector3 left, System.Single[,] right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException(nameof(left)); }
			if (right == null) { throw new Eggceptions.ArgumentNullException(nameof(right)); }

			return new Vector3(Library.Matrix.Add(left.Elements, right));
		}

		// System.Single[,] + Vector3
		static public Vector3 operator +(System.Single[,] left, Vector3 right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException(nameof(left)); }
			if (right == null) { throw new Eggceptions.ArgumentNullException(nameof(right)); }

			return new Vector3(Library.Matrix.Add(left, right.Elements));
		}

		// -Vector3
		static public Vector3 operator -(Vector3 vector3)
		{
			if (vector3 == null) { throw new Eggceptions.ArgumentNullException(nameof(vector3)); }

			return new Vector3(Library.Matrix.Negate(vector3.Elements));
		}

		// Vector3 - Vector3
		static public Vector3 operator -(Vector3 left, Vector3 right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException(nameof(left)); }
			if (right == null) { throw new Eggceptions.ArgumentNullException(nameof(right)); }

			return new Vector3(Library.Matrix.Subtract(left.Elements, right.Elements));
		}

		// Vector3 - System.Single
		static public Vector3 operator -(Vector3 vector3, System.Single scalar)
		{
			if (vector3 == null) { throw new Eggceptions.ArgumentNullException(nameof(vector3)); }
			// scalar

			return new Vector3(Library.Matrix.Subtract(vector3.Elements, scalar));
		}

		// System.Single - Vector3
		static public Vector3 operator -(System.Single scalar, Vector3 vector3)
		{
			// scalar
			if (vector3 == null) { throw new Eggceptions.ArgumentNullException(nameof(vector3)); }

			return new Vector3(Library.Matrix.Subtract(scalar, vector3.Elements));
		}

		// Vector3 - System.Single[,]
		static public Vector3 operator -(Vector3 left, System.Single[,] right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException(nameof(left)); }
			if (right == null) { throw new Eggceptions.ArgumentNullException(nameof(right)); }

			return new Vector3(Library.Matrix.Subtract(left.Elements, right));
		}

		// System.Single[,] - Vector3
		static public Vector3 operator -(System.Single[,] left, Vector3 right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException(nameof(left)); }
			if (right == null) { throw new Eggceptions.ArgumentNullException(nameof(right)); }

			return new Vector3(Library.Matrix.Subtract(left, right.Elements));
		}

		// Vector3 * Vector3

		// Vector3 * Matrix33
		static public Vector3 operator *(Vector3 left, Matrix33 right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException(nameof(left)); }
			if (right == null) { throw new Eggceptions.ArgumentNullException(nameof(right)); }

			return new Vector3(Library.Matrix.Multiply(left.Elements, right.Elements));
		}

		// Vector3 * System.Single
		static public Vector3 operator *(Vector3 vector3, System.Single scalar)
		{
			if (vector3 == null) { throw new Eggceptions.ArgumentNullException(nameof(vector3)); }
			// scalar

			return new Vector3(Library.Matrix.Multiply(vector3.Elements, scalar));
		}

		// System.Single * Vector3
		static public Vector3 operator *(System.Single scalar, Vector3 vector3)
		{
			// scalar
			if (vector3 == null) { throw new Eggceptions.ArgumentNullException(nameof(vector3)); }

			return new Vector3(Library.Matrix.Multiply(vector3.Elements, scalar));
		}

		// Vector3 * System.Single[,]

		// System.Single[,] * Vector3
		#endregion
	}
}
