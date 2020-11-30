using Eggstensions.ExtensionMethods;



namespace Eggstensions.Math.Unmanaged
{
	public class Matrix : TemporaryObject
	{
		virtual public System.Int32 Size { get; } = 0x4; // > 0

		virtual public System.Int32? Padding { get; } = null; // >= Size * (Rows * Columns)



		virtual public System.Single Read(System.Int32 row, System.Int32 column)
		{
			return NetScriptFramework.Memory.ReadFloat(Address + Index(row, column) * Size);
		}

		virtual public void Write(System.Single value, System.Int32 row, System.Int32 column)
		{
			NetScriptFramework.Memory.WriteFloat(Address + Index(row, column) * Size, value);
		}

		virtual public System.Int32 Index(System.Int32 row, System.Int32 column)
		{
			return Columns * row + column;
		}



		public Matrix(System.Int32 rows, System.Int32 columns)
		{
			if (rows < 0) { throw new Eggceptions.ArgumentOutOfRangeException("rows"); }
			if (columns < 0) { throw new Eggceptions.ArgumentOutOfRangeException("columns"); }

			Rows = rows;
			Columns = columns;

			_allocation = NetScriptFramework.Memory.Allocate(Padding.HasValue ? Padding.Value : Size * Rows * Columns);
			_allocation.Pin();
			_allocation.Zero();
		}

		public Matrix(System.Single[,] elements, System.Int32? rows = null, System.Int32? columns = null)
			: this(rows.HasValue ? rows.Value : elements.Rows(), columns.HasValue ? columns.Value : elements.Columns())
		{
			// elements
			// rows
			// columns

			Elements = elements;
		}

		public Matrix(Managed.Matrix matrix, System.Int32? rows = null, System.Int32? columns = null)
			: this(matrix.Elements, rows, columns)
		{
			// matrix
			// rows
			// columns
		}

		public Matrix(System.IntPtr address, System.Int32 rows, System.Int32 columns)
		{
			if (address == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("address"); }
			if (rows < 0) { throw new Eggceptions.ArgumentOutOfRangeException("rows"); }
			if (columns < 0) { throw new Eggceptions.ArgumentOutOfRangeException("columns"); }

			Rows = rows;
			Columns = columns;

			_instance = address;
		}

		override protected void Free()
		{
			if (_allocation != null)
			{
				_allocation.Unpin();
				_allocation.Dispose();
			}
		}



		readonly private NetScriptFramework.MemoryAllocation _allocation;

		readonly private System.IntPtr _instance;



		public System.IntPtr Address
		{
			get
			{
				var address = _allocation?.Address ?? _instance;
				if (address == System.IntPtr.Zero) { throw new Eggceptions.NullException("address"); }

				return address;
			}
		}

		/// <summary>The number of rows in this Matrix.</summary>
		public System.Int32 Rows { get; }

		/// <summary>The number of columns in this Matrix.</summary>
		public System.Int32 Columns { get; }

		/// <summary>The elements of this Matrix.</summary>
		public System.Single[,] Elements
		{
			get
			{
				var elements = new System.Single[Rows, Columns];

				for (var row = 0; row < Rows; row++)
				{
					for (var column = 0; column < Columns; column++)
					{
						elements[row, column] = this[row, column];
					}
				}

				return elements;
			}
			set
			{
				if (value == null) { throw new Eggceptions.NullException("value"); }
				if (!Library.Matrix.Dimensions(value, Rows, Columns)) { throw new Eggceptions.Math.Matrix.MatrixDimensionsException("this, value"); }

				for (var row = 0; row < Rows; row++)
				{
					for (var column = 0; column < Columns; column++)
					{
						this[row, column] = value[row, column];
					}
				}
			}
		}

		/// <summary>A wrapper for elements of this Matrix to facilitate operator overloading.</summary>
		public Managed.Matrix Wrapper
		{
			get
			{
				return new Managed.Matrix(Elements);
			}
			set
			{
				Elements = value.Elements;
			}
		}



		/// <summary>The specified element of this Matrix.</summary>
		public System.Single this[System.Int32 row, System.Int32 column]
		{
			get
			{
				if (row < 0 || row >= Rows) { throw new Eggceptions.ArgumentOutOfRangeException("row"); }
				if (column < 0 || column >= Columns) { throw new Eggceptions.ArgumentOutOfRangeException("column"); }

				return Read(row, column);
			}
			set
			{
				if (row < 0 || row >= Rows) { throw new Eggceptions.ArgumentOutOfRangeException("row"); }
				if (column < 0 || column >= Columns) { throw new Eggceptions.ArgumentOutOfRangeException("column"); }

				Write(value, row, column);
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
		/// <summary>The addition of this Matrix and another Matrix.</summary>
		/// <returns>Matrix</returns>
		public Managed.Matrix Add(Matrix other)
		{
			if (other == null) { throw new Eggceptions.ArgumentNullException("other"); }

			return new Managed.Matrix(Library.Matrix.Add(Elements, other.Elements));
		}

		/// <summary>The addition of this Matrix and a scalar.</summary>
		/// <returns>Matrix</returns>
		public Managed.Matrix Add(System.Single scalar)
		{
			// scalar

			return new Managed.Matrix(Library.Matrix.Add(Elements, scalar));
		}

		/// <summary>The adjugate of this Matrix.</summary>
		/// <returns>Matrix</returns>
		public Managed.Matrix Adjugate()
		{
			return new Managed.Matrix(Library.Matrix.Adjugate(Elements));
		}

		/// <summary>If this Matrix and another Matrix can be multiplied.</summary>
		public (System.Boolean condition, System.Int32? rows, System.Int32? columns) CanMultiply(Matrix other)
		{
			if (other == null) { throw new Eggceptions.ArgumentNullException("other"); }

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
			if (other == null) { throw new Eggceptions.ArgumentNullException("other"); }

			return Library.Matrix.Equals(Elements, other.Elements);
		}

		/// <summary>If this Matrix has the specified dimensions. To exclude a dimension set it to null.</summary>
		public System.Boolean Dimensions(System.Int32? rows, System.Int32? columns)
		{
			// rows
			// columns

			return Library.Matrix.Dimensions(Elements, rows, columns);
		}

		/// <summary>If this Matrix and another Matrix have the same dimensions.</summary>
		public System.Boolean Dimensions(Matrix other)
		{
			if (other == null) { throw new Eggceptions.ArgumentNullException("other"); }

			return Library.Matrix.Dimensions(Elements, other.Elements);
		}

		/// <summary>The identity matrix with the specified Dimensions.</summary>
		/// <returns>Matrix</returns>
		public Managed.Matrix Identity(System.Int32 dimensions)
		{
			return new Managed.Matrix(Library.Matrix.Identity(dimensions));
		}

		/// <summary>The inverse of this Matrix.</summary>
		/// <returns>Matrix</returns>
		public Managed.Matrix Invert()
		{
			return new Managed.Matrix(Library.Matrix.Invert(Elements));
		}

		/// <summary>The multiplication of this Matrix and another Matrix.</summary>
		/// <returns>Matrix</returns>
		public Managed.Matrix Multiply(Matrix other)
		{
			if (other == null) { throw new Eggceptions.ArgumentNullException("other"); }

			return new Managed.Matrix(Library.Matrix.Multiply(Elements, other.Elements));
		}

		/// <summary>The multiplication of this Matrix and a scalar.</summary>
		/// <returns>Matrix</returns>
		public Managed.Matrix Multiply(System.Single scalar)
		{
			// scalar

			return new Managed.Matrix(Library.Matrix.Multiply(Elements, scalar));
		}

		/// <summary>The negation of this Matrix.</summary>
		/// <returns>Matrix</returns>
		public Managed.Matrix Negate()
		{
			return new Managed.Matrix(Library.Matrix.Negate(Elements));
		}

		/// <summary>The subtraction of another Matrix from this Matrix.</summary>
		/// <returns>Matrix</returns>
		public Managed.Matrix Subtract(Matrix other)
		{
			if (other == null) { throw new Eggceptions.ArgumentNullException("other"); }

			return new Managed.Matrix(Library.Matrix.Subtract(Elements, other.Elements));
		}

		/// <summary>The subtraction of a scalar from this Matrix.</summary>
		/// <returns>Matrix</returns>
		public Managed.Matrix Subtract(System.Single scalar)
		{
			// scalar

			return new Managed.Matrix(Library.Matrix.Subtract(Elements, scalar));
		}

		/// <summary>The transpose of this Matrix.</summary>
		/// <returns>Matrix</returns>
		public Managed.Matrix Transpose()
		{
			return new Managed.Matrix(Library.Matrix.Transpose(Elements));
		}
		#endregion



		#region Operator overloading
		// Matrix + Matrix
		static public Managed.Matrix operator +(Matrix left, Matrix right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException("left"); }
			if (right == null) { throw new Eggceptions.ArgumentNullException("right"); }

			return new Managed.Matrix(Library.Matrix.Add(left.Elements, right.Elements));
		}

		// Matrix + Managed.Matrix
		static public Managed.Matrix operator +(Matrix left, Managed.Matrix right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException("left"); }
			// right

			return new Managed.Matrix(Library.Matrix.Add(left.Elements, right.Elements));
		}

		// Managed.Matrix + Matrix
		static public Managed.Matrix operator +(Managed.Matrix left, Matrix right)
		{
			// left
			if (right == null) { throw new Eggceptions.ArgumentNullException("right"); }

			return new Managed.Matrix(Library.Matrix.Add(left.Elements, right.Elements));
		}

		// Matrix + System.Single
		static public Managed.Matrix operator +(Matrix matrix, System.Single scalar)
		{
			if (matrix == null) { throw new Eggceptions.ArgumentNullException("matrix"); }
			// scalar

			return new Managed.Matrix(Library.Matrix.Add(matrix.Elements, scalar));
		}

		// System.Single + Matrix
		static public Managed.Matrix operator +(System.Single scalar, Matrix matrix)
		{
			// scalar
			if (matrix == null) { throw new Eggceptions.ArgumentNullException("matrix"); }

			return new Managed.Matrix(Library.Matrix.Add(matrix.Elements, scalar));
		}

		// Matrix + System.Single[,]
		static public Managed.Matrix operator +(Matrix left, System.Single[,] right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException("left"); }
			// right

			return new Managed.Matrix(Library.Matrix.Add(left.Elements, right));
		}

		// System.Single[,] + Matrix
		static public Managed.Matrix operator +(System.Single[,] left, Matrix right)
		{
			// left
			if (right == null) { throw new Eggceptions.ArgumentNullException("right"); }

			return new Managed.Matrix(Library.Matrix.Add(left, right.Elements));
		}

		// -Matrix
		static public Managed.Matrix operator -(Matrix matrix)
		{
			if (matrix == null) { throw new Eggceptions.ArgumentNullException("matrix"); }

			return new Managed.Matrix(Library.Matrix.Negate(matrix.Elements));
		}

		// Matrix - Matrix
		static public Managed.Matrix operator -(Matrix left, Matrix right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException("left"); }
			if (right == null) { throw new Eggceptions.ArgumentNullException("right"); }

			return new Managed.Matrix(Library.Matrix.Subtract(left.Elements, right.Elements));
		}

		// Matrix - Managed.Matrix
		static public Managed.Matrix operator -(Matrix left, Managed.Matrix right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException("left"); }
			// right

			return new Managed.Matrix(Library.Matrix.Subtract(left.Elements, right.Elements));
		}

		// Managed.Matrix - Matrix
		static public Managed.Matrix operator -(Managed.Matrix left, Matrix right)
		{
			// left
			if (right == null) { throw new Eggceptions.ArgumentNullException("right"); }

			return new Managed.Matrix(Library.Matrix.Subtract(left.Elements, right.Elements));
		}

		// Matrix - System.Single
		static public Managed.Matrix operator -(Matrix matrix, System.Single scalar)
		{
			if (matrix == null) { throw new Eggceptions.ArgumentNullException("matrix"); }
			// scalar

			return new Managed.Matrix(Library.Matrix.Subtract(matrix.Elements, scalar));
		}

		// System.Single - Matrix
		static public Managed.Matrix operator -(System.Single scalar, Matrix matrix)
		{
			// scalar
			if (matrix == null) { throw new Eggceptions.ArgumentNullException("matrix"); }

			return new Managed.Matrix(Library.Matrix.Subtract(scalar, matrix.Elements));
		}

		// Matrix - System.Single[,]
		static public Managed.Matrix operator -(Matrix left, System.Single[,] right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException("left"); }
			// right

			return new Managed.Matrix(Library.Matrix.Subtract(left.Elements, right));
		}

		// System.Single[,] - Matrix
		static public Managed.Matrix operator -(System.Single[,] left, Matrix right)
		{
			// left
			if (right == null) { throw new Eggceptions.ArgumentNullException("right"); }

			return new Managed.Matrix(Library.Matrix.Subtract(left, right.Elements));
		}

		// Matrix * Matrix
		static public Managed.Matrix operator *(Matrix left, Matrix right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException("left"); }
			if (right == null) { throw new Eggceptions.ArgumentNullException("right"); }

			return new Managed.Matrix(Library.Matrix.Multiply(left.Elements, right.Elements));
		}

		// Matrix * Managed.Matrix
		static public Managed.Matrix operator *(Matrix left, Managed.Matrix right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException("left"); }
			// right

			return new Managed.Matrix(Library.Matrix.Multiply(left.Elements, right.Elements));
		}

		// Managed.Matrix * Matrix
		static public Managed.Matrix operator *(Managed.Matrix left, Matrix right)
		{
			// left
			if (right == null) { throw new Eggceptions.ArgumentNullException("right"); }

			return new Managed.Matrix(Library.Matrix.Multiply(left.Elements, right.Elements));
		}

		// Matrix * System.Single
		static public Managed.Matrix operator *(Matrix matrix, System.Single scalar)
		{
			if (matrix == null) { throw new Eggceptions.ArgumentNullException("matrix"); }
			// scalar

			return new Managed.Matrix(Library.Matrix.Multiply(matrix.Elements, scalar));
		}

		// System.Single * Matrix
		static public Managed.Matrix operator *(System.Single scalar, Matrix matrix)
		{
			// scalar
			if (matrix == null) { throw new Eggceptions.ArgumentNullException("matrix"); }

			return new Managed.Matrix(Library.Matrix.Multiply(matrix.Elements, scalar));
		}

		// Matrix * System.Single[,]
		static public Managed.Matrix operator *(Matrix left, System.Single[,] right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException("left"); }
			// right

			return new Managed.Matrix(Library.Matrix.Multiply(left.Elements, right));
		}

		// System.Single[,] * Matrix
		static public Managed.Matrix operator *(System.Single[,] left, Matrix right)
		{
			// left
			if (right == null) { throw new Eggceptions.ArgumentNullException("right"); }

			return new Managed.Matrix(Library.Matrix.Multiply(left, right.Elements));
		}
		#endregion
	}
}
