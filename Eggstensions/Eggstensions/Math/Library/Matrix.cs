using Eggstensions.ExtensionMethods;



namespace Eggstensions.Math.Library
{
	static public class Matrix
	{
		static public System.Single[,] Add(System.Single[,] matrix, System.Single scalar)
		{
			if (matrix == null) { throw new Eggceptions.ArgumentNullException(nameof(matrix)); }
			// scalar

			var rows = matrix.Rows();
			var columns = matrix.Columns();

			var result = new System.Single[rows, columns];

			for (var row = 0; row < rows; row++)
			{
				for (var column = 0; column < columns; column++)
				{
					result[row, column] = matrix[row, column] + scalar;
				}
			}

			return result;
		}

		static public System.Single[,] Add(System.Single[,] left, System.Single[,] right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException(nameof(left)); }
			if (right == null) { throw new Eggceptions.ArgumentNullException(nameof(right)); }
			if (!Matrix.SameDimensions(left, right)) { throw new Eggceptions.Math.Matrix.ArgumentMatrixDimensionsException(System.String.Join(", ", nameof(left), nameof(right))); }

			var rows = left.Rows(); // left.Rows == right.Rows
			var columns = left.Columns(); // left.Columns == right.Columns

			var result = new System.Single[rows, columns];

			for (var row = 0; row < rows; row++)
			{
				for (var column = 0; column < columns; column++)
				{
					result[row, column] = left[row, column] + right[row, column];
				}
			}

			return result;
		}

		static public System.Single[,] Adjugate(System.Single[,] matrix)
		{
			if (matrix == null) { throw new Eggceptions.ArgumentNullException(nameof(matrix)); }
			if (!Matrix.IsSquare(matrix)) { throw new Eggceptions.Math.Matrix.ArgumentRectangularMatrixException(nameof(matrix)); }

			var rows = matrix.Rows();
			var columns = matrix.Columns();

			var result = new System.Single[rows, columns];

			for (var rowOffset = 0; rowOffset < rows; rowOffset++)
			{
				for (var columnOffset = 0; columnOffset < columns; columnOffset++)
				{
					var submatrix = new System.Single[rows - 1, columns - 1];

					for (var row = 0; row < rows; row++)
					{
						for (var column = 0; column < columns; column++)
						{
							if ((row != rowOffset) && (column != columnOffset))
							{
								submatrix[row < rowOffset ? row : row - 1, column < columnOffset ? column : column - 1] = matrix[row, column];
							}
						}
					}

					// Checkerboard
					if ((rowOffset + columnOffset) % 2 == 0) // Even
					{
						result[rowOffset, columnOffset] = Matrix.Determinant(submatrix);
					}
					else // Odd
					{
						result[rowOffset, columnOffset] = -Matrix.Determinant(submatrix);
					}
				}
			}

			return Matrix.Transpose(result);
		}

		static public (System.Boolean condition, (System.Int32 rows, System.Int32 columns)? dimensions) CanMultiply(System.Single[,] left, System.Single[,] right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException(nameof(left)); }
			if (right == null) { throw new Eggceptions.ArgumentNullException(nameof(right)); }

			if (left.Columns() != right.Rows())
			{
				return (false, null); // Incompatible
			}

			return (true, (left.Rows(), right.Columns())); // Compatible
		}

		static public System.Single Determinant(System.Single[,] matrix)
		{
			if (matrix == null) { throw new Eggceptions.ArgumentNullException(nameof(matrix)); }
			if (!Matrix.IsSquare(matrix)) { throw new Eggceptions.Math.Matrix.ArgumentRectangularMatrixException(nameof(matrix)); }

			if (Matrix.HasDimensions(matrix, 2, 2))
			{
				return (matrix[0, 0] * matrix[1, 1]) - (matrix[0, 1] * matrix[1, 0]);
			}
			else
			{
				var rows = matrix.Rows();
				var columns = matrix.Columns();

				var result = 0.0f;

				for (var columnOffset = 0; columnOffset < columns; columnOffset++)
				{
					var submatrix = new System.Single[rows - 1, columns - 1];

					for (var row = 1; row < rows; row++) // Remove row 0
					{
						for (var column = 0; column < columns; column++)
						{
							if (column != columnOffset)
							{
								submatrix[row - 1, column < columnOffset ? column : column - 1] = matrix[row, column];
							}
						}
					}

					if (columnOffset % 2 == 0) // Even
					{
						result += matrix[0, columnOffset] * Matrix.Determinant(submatrix);
					}
					else // Odd
					{
						result -= matrix[0, columnOffset] * Matrix.Determinant(submatrix);
					}
				}

				return result;
			}
		}

		static public System.Boolean Equals(System.Single[,] left, System.Single[,] right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException(nameof(left)); }
			if (right == null) { throw new Eggceptions.ArgumentNullException(nameof(right)); }

			return (new System.Single[][,] { left, right }).EqualsJagged();
		}

		static public System.Boolean HasDimensions(System.Single[,] matrix, System.Int32? rows, System.Int32? columns)
		{
			if (matrix == null) { throw new Eggceptions.ArgumentNullException(nameof(matrix)); }
			// rows
			// columns

			return matrix.AllDimensions((input, output) => output == input, rows, columns);
		}

		static public System.Single[,] Identity(System.Int32 dimensions)
		{
			// dimensions
			
			var result = new System.Single[dimensions, dimensions];

			for (var row = 0; row < dimensions; row++)
			{
				for (var column = 0; column < dimensions; column++)
				{
					result[row, column] = (row == column) ? 1 : 0;
				}
			}

			return result;
		}

		static public System.Single[,] Invert(System.Single[,] matrix)
		{
			if (matrix == null) { throw new Eggceptions.ArgumentNullException(nameof(matrix)); }
			if (!Matrix.IsInvertible(matrix)) { throw new Eggceptions.Math.Matrix.ArgumentSingularMatrixException(nameof(matrix)); }

			return Matrix.Multiply(Matrix.Adjugate(matrix), 1 / Matrix.Determinant(matrix));
		}

		static public System.Boolean IsIdentity(System.Single[,] matrix)
		{
			if (matrix == null) { throw new Eggceptions.ArgumentNullException(nameof(matrix)); }

			return
				Matrix.IsSquare(matrix)
				&&
				IsIdentity();



			System.Boolean IsIdentity()
			{
				var rows = matrix.Rows();
				var columns = matrix.Columns();

				for (var row = 0; row < rows; row++)
				{
					for (var column = 0; column < columns; column++)
					{
						if (matrix[row, column] != ((row == column) ? 1.0f : 0.0f))
						{
							return false;
						}
					}
				}

				return true;
			}
		}

		static public System.Boolean IsInvertible(System.Single[,] matrix)
		{
			if (matrix == null) { throw new Eggceptions.ArgumentNullException(nameof(matrix)); }

			return
				Matrix.IsSquare(matrix)
				&&
				(Matrix.Determinant(matrix) != 0);
		}

		static public System.Boolean IsMatrix33(System.Single[,] matrix)
		{
			if (matrix == null) { throw new Eggceptions.ArgumentNullException(nameof(matrix)); }

			return Matrix.HasDimensions(matrix, 3, 3);
		}

		static public System.Boolean IsRotationMatrix(System.Single[,] matrix)
		{
			if (matrix == null) { throw new Eggceptions.ArgumentNullException(nameof(matrix)); }

			return
				Matrix.IsSquare(matrix)
				&&
				(Matrix.Determinant(matrix) == 1)
				&&
				Matrix.Equals(Matrix.Transpose(matrix), Matrix.Invert(matrix));
		}

		// A scalar is a 1x1 square matrix
		static public System.Boolean IsSquare(System.Single[,] matrix)
		{
			if (matrix == null) { throw new Eggceptions.ArgumentNullException(nameof(matrix)); }

			return matrix.Rows() == matrix.Columns();
		}

		static public System.Boolean IsSymmetric(System.Single[,] matrix, System.Boolean skewSymmetric = false)
		{
			if (matrix == null) { throw new Eggceptions.ArgumentNullException(nameof(matrix)); }
			// skewSymmetric

			return
				Matrix.IsSquare(matrix)
				&&
				IsSymmetric();



			System.Boolean IsSymmetric()
			{
				var rows = matrix.Rows();
				var columns = matrix.Columns();

				for (var row = 0; row < rows; row++)
				{
					for (var column = (row + 1); column < columns; column++) // Compare elements above the leading diagonal with elements below the leading diagonal
					{
						if (matrix[row, column] != (skewSymmetric ? -matrix[column, row] : matrix[column, row]))
						{
							return false;
						}
					}
				}

				return true;
			}
		}

		static public System.Boolean IsVector(System.Single[,] matrix)
		{
			if (matrix == null) { throw new Eggceptions.ArgumentNullException(nameof(matrix)); }

			return Matrix.HasDimensions(matrix, 1, null);
		}

		static public System.Boolean IsVector3(System.Single[,] matrix)
		{
			if (matrix == null) { throw new Eggceptions.ArgumentNullException(nameof(matrix)); }

			return Matrix.HasDimensions(matrix, 1, 3);
		}

		static public System.Boolean IsVector7(System.Single[,] matrix)
		{
			if (matrix == null) { throw new Eggceptions.ArgumentNullException(nameof(matrix)); }

			return Matrix.HasDimensions(matrix, 1, 7);
		}

		static public System.Boolean IsZero(System.Single[,] matrix)
		{
			if (matrix == null) { throw new Eggceptions.ArgumentNullException(nameof(matrix)); }
			
			var rows = matrix.Rows();
			var columns = matrix.Columns();

			for (var row = 0; row < rows; row++)
			{
				for (var column = 0; column < columns; column++)
				{
					if (matrix[row, column] != 0)
					{
						return false;
					}
				}
			}

			return true;
		}

		static public System.Single[,] Multiply(System.Single[,] matrix, System.Single scalar)
		{
			if (matrix == null) { throw new Eggceptions.ArgumentNullException(nameof(matrix)); }
			// scalar

			var rows = matrix.Rows();
			var columns = matrix.Columns();

			var result = new System.Single[rows, columns];

			for (var row = 0; row < rows; row++)
			{
				for (var column = 0; column < columns; column++)
				{
					result[row, column] = matrix[row, column] * scalar;
				}
			}

			return result;
		}

		static public System.Single[,] Multiply(System.Single[,] left, System.Single[,] right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException(nameof(left)); }
			if (right == null) { throw new Eggceptions.ArgumentNullException(nameof(right)); }
			if (!Matrix.CanMultiply(left, right).condition) { throw new Eggceptions.Math.Matrix.ArgumentUndefinedMatrixException(System.String.Join(", ", nameof(left), nameof(right))); }

			var rows = left.Rows();
			var columns = right.Columns();
			var offsets = left.Columns(); // left.Columns == right.Rows

			var result = new System.Single[rows, columns];

			for (var row = 0; row < rows; row++)
			{
				for (var column = 0; column < columns; column++)
				{
					for (var offset = 0; offset < offsets; offset++)
					{
						result[row, column] += left[row, offset] * right[offset, column];
					}
				}
			}

			return result;
		}

		static public System.Single[,] Negate(System.Single[,] matrix)
		{
			if (matrix == null) { throw new Eggceptions.ArgumentNullException(nameof(matrix)); }

			var rows = matrix.Rows();
			var columns = matrix.Columns();

			var result = new System.Single[rows, columns];

			for (var row = 0; row < rows; row++)
			{
				for (var column = 0; column < columns; column++)
				{
					result[row, column] = -matrix[row, column];
				}
			}

			return result;
		}

		static public System.Boolean SameDimensions(System.Single[,] left, System.Single[,] right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException(nameof(left)); }
			if (right == null) { throw new Eggceptions.ArgumentNullException(nameof(right)); }

			return left.SameDimensions(right);
		}

		static public System.Single[,] Subtract(System.Single scalar, System.Single[,] matrix)
		{
			// scalar
			if (matrix == null) { throw new Eggceptions.ArgumentNullException(nameof(matrix)); }

			var rows = matrix.Rows();
			var columns = matrix.Columns();

			var result = new System.Single[rows, columns];

			for (var row = 0; row < rows; row++)
			{
				for (var column = 0; column < columns; column++)
				{
					result[row, column] = scalar - matrix[row, column];
				}
			}

			return result;
		}

		static public System.Single[,] Subtract(System.Single[,] matrix, System.Single scalar)
		{
			if (matrix == null) { throw new Eggceptions.ArgumentNullException(nameof(matrix)); }
			// scalar

			var rows = matrix.Rows();
			var columns = matrix.Columns();

			var result = new System.Single[rows, columns];

			for (var row = 0; row < rows; row++)
			{
				for (var column = 0; column < columns; column++)
				{
					result[row, column] = matrix[row, column] - scalar;
				}
			}

			return result;
		}

		static public System.Single[,] Subtract(System.Single[,] left, System.Single[,] right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException(nameof(left)); }
			if (right == null) { throw new Eggceptions.ArgumentNullException(nameof(right)); }
			if (!Matrix.SameDimensions(left, right)) { throw new Eggceptions.Math.Matrix.ArgumentMatrixDimensionsException(System.String.Join(", ", nameof(left), nameof(right))); }

			var rows = left.Rows(); // left.Rows == right.Rows
			var columns = left.Columns(); // left.Columns == right.Columns

			var result = new System.Single[rows, columns];

			for (var row = 0; row < rows; row++)
			{
				for (var column = 0; column < columns; column++)
				{
					result[row, column] = left[row, column] - right[row, column];
				}
			}

			return result;
		}

		static public System.Single[,] Transpose(System.Single[,] matrix)
		{
			if (matrix == null) { throw new Eggceptions.ArgumentNullException(nameof(matrix)); }

			var rows = matrix.Rows();
			var columns = matrix.Columns();

			var result = new System.Single[columns, rows];

			for (var row = 0; row < rows; row++)
			{
				for (var column = 0; column < columns; column++)
				{
					result[column, row] = matrix[row, column];
				}
			}

			return result;
		}

		static public System.Single[,] Zero(System.Int32 rows, System.Int32 columns)
		{
			// rows
			// columns

			var result = new System.Single[rows, columns];

			for (var row = 0; row < rows; row++)
			{
				for (var column = 0; column < columns; column++)
				{
					result[row, column] = (row == column) ? 1 : 0;
				}
			}

			return result;
		}
	}
}
