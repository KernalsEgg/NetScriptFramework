using Eggstensions.ExtensionMethods;



namespace Eggstensions.Math.Managed
{
	public class Matrix
	{
		public Matrix(System.Single[,] elements)
		{
			if (elements == null) { throw new Eggceptions.ArgumentNullException(nameof(elements)); }

			Elements = elements;
		}



		public System.Single[,] Elements { get; }

		public System.Int32 Rows { get { return Elements.Rows(); } }

		public System.Int32 Columns { get { return Elements.Columns(); } }



		public System.Single this[System.Int32 row, System.Int32 column]
		{
			get
			{
				return Elements[row, column];
			}
			set
			{
				Elements[row, column] = value;
			}
		}



		#region Properties
		/// <summary>If this Matrix is an identity matrix.</summary>
		public System.Boolean IsIdentity
		{
			get
			{
				return Library.Matrix.IsIdentity(Elements);
			}
		}

		/// <summary>If this Matrix is invertible.</summary>
		public System.Boolean IsInvertible
		{
			get
			{
				return Library.Matrix.IsInvertible(Elements);
			}
		}

		/// <summary>If this Matrix is a 3x3 matrix.</summary>
		public System.Boolean IsMatrix33
		{
			get
			{
				return Library.Matrix.IsMatrix33(Elements);
			}
		}

		/// <summary>If this Matrix is a rotation matrix.</summary>
		public System.Boolean IsRotationMatrix
		{
			get
			{
				return Library.Matrix.IsRotationMatrix(Elements);
			}
		}

		/// <summary>If this Matrix is skew symmetric.</summary>
		public System.Boolean IsSkewSymmetric
		{
			get
			{
				return Library.Matrix.IsSymmetric(Elements, true);
			}
		}

		/// <summary>If this Matrix is square.</summary>
		public System.Boolean IsSquare
		{
			get
			{
				return Library.Matrix.IsSquare(Elements);
			}
		}

		/// <summary>If this Matrix is symmetric.</summary>
		public System.Boolean IsSymmetric
		{
			get
			{
				return Library.Matrix.IsSymmetric(Elements, false);
			}
		}

		/// <summary>If this Matrix is a vector.</summary>
		public System.Boolean IsVector
		{
			get
			{
				return Library.Matrix.IsVector(Elements);
			}
		}

		/// <summary>If this Matrix is a 1x3 vector.</summary>
		public System.Boolean IsVector3
		{
			get
			{
				return Library.Matrix.IsVector3(Elements);
			}
		}

		/// <summary>If this Matrix is a 1x7 vector.</summary>
		public System.Boolean IsVector7
		{
			get
			{
				return Library.Matrix.IsVector7(Elements);
			}
		}

		/// <summary>If this Matrix is a zero matrix.</summary>
		public System.Boolean IsZero
		{
			get
			{
				return Library.Matrix.IsZero(Elements);
			}
		}
		#endregion



		#region Methods
		/// <summary>The adjugate of this Matrix.</summary>
		public Matrix Adjugate()
		{
			return new Matrix(Library.Matrix.Adjugate(Elements));
		}

		/// <summary>If this Matrix and another Matrix can be multiplied.</summary>
		public (System.Boolean condition, (System.Int32 rows, System.Int32 columns)? dimensions) CanMultiply(Matrix other)
		{
			if (other == null) { throw new Eggceptions.ArgumentNullException(nameof(other)); }

			return Library.Matrix.CanMultiply(Elements, other.Elements);
		}

		/// <summary>The determinant of this Matrix.</summary>
		public System.Single Determinant()
		{
			return Library.Matrix.Determinant(Elements);
		}

		/// <summary>If this Matrix is equal to another Matrix.</summary>
		public System.Boolean Equals(Matrix other)
		{
			if (other == null) { throw new Eggceptions.ArgumentNullException(nameof(other)); }

			return Library.Matrix.Equals(Elements, other.Elements);
		}

		/// <summary>If this Matrix has the specified dimensions. To exclude a dimension set it to null.</summary>
		public System.Boolean HasDimensions(System.Int32? rows, System.Int32? columns)
		{
			// rows
			// columns

			return Library.Matrix.HasDimensions(Elements, rows, columns);
		}

		/// <summary>The identity Matrix with the specified dimensions.</summary>
		public Matrix Identity(System.Int32 dimensions)
		{
			return new Matrix(Library.Matrix.Identity(dimensions));
		}

		/// <summary>The inverse of this Matrix.</summary>
		public Matrix Invert()
		{
			return new Matrix(Library.Matrix.Invert(Elements));
		}

		/// <summary>If this Matrix and another Matrix have the same dimensions.</summary>
		public System.Boolean SameDimensions(Matrix other)
		{
			if (other == null) { throw new Eggceptions.ArgumentNullException(nameof(other)); }

			return Library.Matrix.SameDimensions(Elements, other.Elements);
		}

		/// <summary>The transpose of this Matrix.</summary>
		public Matrix Transpose()
		{
			return new Matrix(Library.Matrix.Transpose(Elements));
		}

		/// <summary>The zero Matrix with the specified rows and columns.</summary>
		public Matrix Zero(System.Int32 rows, System.Int32 columns)
		{
			return new Matrix(Library.Matrix.Zero(rows, columns));
		}
		#endregion



		#region Operator overloading
		// Matrix + Matrix
		static public Matrix operator +(Matrix left, Matrix right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException(nameof(left)); }
			if (right == null) { throw new Eggceptions.ArgumentNullException(nameof(right)); }

			return new Matrix(Library.Matrix.Add(left.Elements, right.Elements));
		}

		// Matrix + System.Single
		static public Matrix operator +(Matrix matrix, System.Single scalar)
		{
			if (matrix == null) { throw new Eggceptions.ArgumentNullException(nameof(matrix)); }
			// scalar

			return new Matrix(Library.Matrix.Add(matrix.Elements, scalar));
		}

		// System.Single + Matrix
		static public Matrix operator +(System.Single scalar, Matrix matrix)
		{
			// scalar
			if (matrix == null) { throw new Eggceptions.ArgumentNullException(nameof(matrix)); }

			return new Matrix(Library.Matrix.Add(matrix.Elements, scalar));
		}

		// Matrix + System.Single[,]
		static public Matrix operator +(Matrix left, System.Single[,] right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException(nameof(left)); }
			if (right == null) { throw new Eggceptions.ArgumentNullException(nameof(right)); }

			return new Matrix(Library.Matrix.Add(left.Elements, right));
		}

		// System.Single[,] + Matrix
		static public Matrix operator +(System.Single[,] left, Matrix right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException(nameof(left)); }
			if (right == null) { throw new Eggceptions.ArgumentNullException(nameof(right)); }

			return new Matrix(Library.Matrix.Add(left, right.Elements));
		}

		// -Matrix
		static public Matrix operator -(Matrix matrix)
		{
			if (matrix == null) { throw new Eggceptions.ArgumentNullException(nameof(matrix)); }

			return new Matrix(Library.Matrix.Negate(matrix.Elements));
		}

		// Matrix - Matrix
		static public Matrix operator -(Matrix left, Matrix right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException(nameof(left)); }
			if (right == null) { throw new Eggceptions.ArgumentNullException(nameof(right)); }

			return new Matrix(Library.Matrix.Subtract(left.Elements, right.Elements));
		}

		// Matrix - System.Single
		static public Matrix operator -(Matrix matrix, System.Single scalar)
		{
			if (matrix == null) { throw new Eggceptions.ArgumentNullException(nameof(matrix)); }
			// scalar

			return new Matrix(Library.Matrix.Subtract(matrix.Elements, scalar));
		}

		// System.Single - Matrix
		static public Matrix operator -(System.Single scalar, Matrix matrix)
		{
			// scalar
			if (matrix == null) { throw new Eggceptions.ArgumentNullException(nameof(matrix)); }

			return new Matrix(Library.Matrix.Subtract(scalar, matrix.Elements));
		}

		// Matrix - System.Single[,]
		static public Matrix operator -(Matrix left, System.Single[,] right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException(nameof(left)); }
			if (right == null) { throw new Eggceptions.ArgumentNullException(nameof(right)); }

			return new Matrix(Library.Matrix.Subtract(left.Elements, right));
		}

		// System.Single[,] - Matrix
		static public Matrix operator -(System.Single[,] left, Matrix right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException(nameof(left)); }
			if (right == null) { throw new Eggceptions.ArgumentNullException(nameof(right)); }

			return new Matrix(Library.Matrix.Subtract(left, right.Elements));
		}

		// Matrix * Matrix
		static public Matrix operator *(Matrix left, Matrix right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException(nameof(left)); }
			if (right == null) { throw new Eggceptions.ArgumentNullException(nameof(right)); }

			return new Matrix(Library.Matrix.Multiply(left.Elements, right.Elements));
		}

		// Matrix * System.Single
		static public Matrix operator *(Matrix matrix, System.Single scalar)
		{
			if (matrix == null) { throw new Eggceptions.ArgumentNullException(nameof(matrix)); }
			// scalar

			return new Matrix(Library.Matrix.Multiply(matrix.Elements, scalar));
		}

		// System.Single * Matrix
		static public Matrix operator *(System.Single scalar, Matrix matrix)
		{
			// scalar
			if (matrix == null) { throw new Eggceptions.ArgumentNullException(nameof(matrix)); }

			return new Matrix(Library.Matrix.Multiply(matrix.Elements, scalar));
		}

		// Matrix * System.Single[,]
		static public Matrix operator *(Matrix left, System.Single[,] right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException(nameof(left)); }
			if (right == null) { throw new Eggceptions.ArgumentNullException(nameof(right)); }

			return new Matrix(Library.Matrix.Multiply(left.Elements, right));
		}

		// System.Single[,] * Matrix
		static public Matrix operator *(System.Single[,] left, Matrix right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException(nameof(left)); }
			if (right == null) { throw new Eggceptions.ArgumentNullException(nameof(right)); }

			return new Matrix(Library.Matrix.Multiply(left, right.Elements));
		}
		#endregion
	}
}
