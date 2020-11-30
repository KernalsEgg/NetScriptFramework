using Eggstensions.ExtensionMethods;



namespace Eggstensions.Math.Managed
{
	readonly public struct Matrix
	{
		public Matrix(System.Single[,] elements)
		{
			if (elements == null) { throw new Eggceptions.ArgumentNullException("elements"); }

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



		#region Operator overloading
		// Matrix + Matrix
		static public Matrix operator +(Matrix left, Matrix right)
		{
			// left
			// right

			return new Matrix(Library.Matrix.Add(left.Elements, right.Elements));
		}

		// Matrix + System.Single
		static public Matrix operator +(Matrix matrix, System.Single scalar)
		{
			// matrix
			// scalar

			return new Matrix(Library.Matrix.Add(matrix.Elements, scalar));
		}

		// System.Single + Matrix
		static public Matrix operator +(System.Single scalar, Matrix matrix)
		{
			// scalar
			// matrix

			return new Matrix(Library.Matrix.Add(matrix.Elements, scalar));
		}

		// Matrix + System.Single[,]
		static public Matrix operator +(Matrix left, System.Single[,] right)
		{
			// left
			// right

			return new Matrix(Library.Matrix.Add(left.Elements, right));
		}

		// System.Single[,] + Matrix
		static public Matrix operator +(System.Single[,] left, Matrix right)
		{
			// left
			// right

			return new Matrix(Library.Matrix.Add(left, right.Elements));
		}

		// -Matrix
		static public Matrix operator -(Matrix matrix)
		{
			// matrix

			return new Matrix(Library.Matrix.Negate(matrix.Elements));
		}

		// Matrix - Matrix
		static public Matrix operator -(Matrix left, Matrix right)
		{
			// left
			// right

			return new Matrix(Library.Matrix.Subtract(left.Elements, right.Elements));
		}

		// Matrix - System.Single
		static public Matrix operator -(Matrix matrix, System.Single scalar)
		{
			// matrix
			// scalar

			return new Matrix(Library.Matrix.Subtract(matrix.Elements, scalar));
		}

		// System.Single - Matrix
		static public Matrix operator -(System.Single scalar, Matrix matrix)
		{
			// scalar
			// matrix

			return new Matrix(Library.Matrix.Subtract(scalar, matrix.Elements));
		}

		// Matrix - System.Single[,]
		static public Matrix operator -(Matrix left, System.Single[,] right)
		{
			// left
			// right

			return new Matrix(Library.Matrix.Subtract(left.Elements, right));
		}

		// System.Single[,] - Matrix
		static public Matrix operator -(System.Single[,] left, Matrix right)
		{
			// left
			// right

			return new Matrix(Library.Matrix.Subtract(left, right.Elements));
		}

		// Matrix * Matrix
		static public Matrix operator *(Matrix left, Matrix right)
		{
			// left
			// right

			return new Matrix(Library.Matrix.Multiply(left.Elements, right.Elements));
		}

		// Matrix * System.Single
		static public Matrix operator *(Matrix matrix, System.Single scalar)
		{
			// matrix
			// scalar

			return new Matrix(Library.Matrix.Multiply(matrix.Elements, scalar));
		}

		// System.Single * Matrix
		static public Matrix operator *(System.Single scalar, Matrix matrix)
		{
			// scalar
			// matrix

			return new Matrix(Library.Matrix.Multiply(matrix.Elements, scalar));
		}

		// Matrix * System.Single[,]
		static public Matrix operator *(Matrix left, System.Single[,] right)
		{
			// left
			// right

			return new Matrix(Library.Matrix.Multiply(left.Elements, right));
		}

		// System.Single[,] * Matrix
		static public Matrix operator *(System.Single[,] left, Matrix right)
		{
			// left
			// right

			return new Matrix(Library.Matrix.Multiply(left, right.Elements));
		}
		#endregion
	}
}
