using System.Linq;

using Eggstensions.ExtensionMethods;



namespace Eggstensions.Math.Library
{
	static public class Vector
	{
		static public System.Single AngleBetween(System.Single[,] left, System.Single[,] right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException("left"); }
			if (right == null) { throw new Eggceptions.ArgumentNullException("right"); }
			if (!Matrix.IsVector(left)) { throw new Eggceptions.Math.Matrix.ArgumentMatrixDimensionsException("left"); }
			if (!Matrix.IsVector(right)) { throw new Eggceptions.Math.Matrix.ArgumentMatrixDimensionsException("right"); }
			if (!Matrix.SameDimensions(left, right)) { throw new Eggceptions.Math.Matrix.ArgumentMatrixDimensionsException("left, right"); }
			if (Matrix.IsZero(left)) { throw new Eggceptions.Math.Matrix.ZeroMatrixException("left"); }
			if (Matrix.IsZero(right)) { throw new Eggceptions.Math.Matrix.ZeroMatrixException("right"); }

			return (System.Single)System.Math.Acos(Vector.DotProduct(left, right) / (Vector.Magnitude(left) * Vector.Magnitude(right)));
		}

		static public System.Boolean CanCrossProduct(params System.Single[][,] vectors)
		{
			if (vectors.IsNullOrSparse(2)) { throw new Eggceptions.ArgumentNullOrSparseException("vectors"); }

			return
				(
					vectors.All(vector => Matrix.IsVector3(vector)) // Valid in 3D
					||
					vectors.All(vector => Matrix.IsVector7(vector)) // Valid in 7D
				)
				&&
				vectors.All(vector => Matrix.HasDimensions(vector, 1, vectors.Length + 1));
		}

		static public System.Boolean CanDotProduct(System.Single[,] left, System.Single[,] right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException("left"); }
			if (right == null) { throw new Eggceptions.ArgumentNullException("right"); }

			return
				Matrix.IsVector(left)
				&&
				Matrix.IsVector(right)
				&&
				Matrix.SameDimensions(left, right);
		}

		static public System.Single[,] CrossProduct(params System.Single[][,] vectors)
		{
			if (vectors.IsNullOrSparse(2)) { throw new Eggceptions.ArgumentNullOrSparseException("vectors"); }
			if (!Vector.CanCrossProduct(vectors)) { throw new Eggceptions.Math.Matrix.ArgumentMatrixDimensionsException("vectors"); }

			var rows = vectors.Length + 1; // +1: Cross product
			var columns = vectors.Length + 1;

			var result = new System.Single[1, columns];

			for (var columnOffset = 0; columnOffset < columns; columnOffset++)
			{
				var submatrix = new System.Single[rows - 1, columns - 1];

				for (var row = 1; row < rows; row++) // Remove row 0
				{
					for (var column = 0; column < columns; column++)
					{
						if (column != columnOffset)
						{
							submatrix[row - 1, column < columnOffset ? column : column - 1] = vectors[row - 1][0, column];
						}
					}
				}

				if (columnOffset % 2 == 0) // Even
				{
					result[0, columnOffset] = Matrix.Determinant(submatrix);
				}
				else // Odd
				{
					result[0, columnOffset] = -Matrix.Determinant(submatrix);
				}
			}

			return result;
		}

		static public System.Single DistanceBetween(System.Single[,] left, System.Single[,] right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException("left"); }
			if (right == null) { throw new Eggceptions.ArgumentNullException("right"); }
			if (!Matrix.IsVector(left)) { throw new Eggceptions.Math.Matrix.ArgumentMatrixDimensionsException("left"); }
			if (!Matrix.IsVector(right)) { throw new Eggceptions.Math.Matrix.ArgumentMatrixDimensionsException("right"); }
			if (!Matrix.SameDimensions(left, right)) { throw new Eggceptions.Math.Matrix.ArgumentMatrixDimensionsException("left, right"); }

			var rows = left.Rows(); // left.Rows == right.Rows
			var columns = left.Columns(); // left.Columns == right.Columns

			var result = 0.0f;

			for (var row = 0; row < rows; row++)
			{
				for (var column = 0; column < columns; column++)
				{
					result += (right[row, column] - left[row, column]) * (right[row, column] - left[row, column]);
				}
			}

			return (System.Single)System.Math.Sqrt(result);
		}

		static public System.Single DotProduct(System.Single[,] left, System.Single[,] right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException("left"); }
			if (right == null) { throw new Eggceptions.ArgumentNullException("right"); }
			if (!Vector.CanDotProduct(left, right)) { throw new Eggceptions.Math.Matrix.ArgumentMatrixDimensionsException("left, right"); }

			var rows = left.Rows(); // left.Rows == right.Rows
			var columns = left.Columns(); // left.Columns == right.Columns

			var result = 0.0f;

			for (var row = 0; row < rows; row++)
			{
				for (var column = 0; column < columns; column++)
				{
					result += left[row, column] * right[row, column];
				}
			}

			return result;
		}

		static public System.Boolean IsNormalized(System.Single[,] vector)
		{
			if (vector == null) { throw new Eggceptions.ArgumentNullException("vector"); }

			return Vector.Magnitude(vector) == 1;
		}

		static public System.Single Magnitude(System.Single[,] vector)
		{
			if (vector == null) { throw new Eggceptions.ArgumentNullException("vector"); }
			if (!Matrix.IsVector(vector)) { throw new Eggceptions.Math.Matrix.ArgumentMatrixDimensionsException("vector"); }

			var rows = vector.Rows();
			var columns = vector.Columns();

			var result = 0.0f;

			for (var row = 0; row < rows; row++)
			{
				for (var column = 0; column < columns; column++)
				{
					result += vector[row, column] * vector[row, column];
				}
			}

			return (System.Single)System.Math.Sqrt(result);
		}

		static public System.Single[,] Normalize(System.Single[,] vector)
		{
			if (vector == null) { throw new Eggceptions.ArgumentNullException("vector"); }
			if (!Matrix.IsVector(vector)) { throw new Eggceptions.Math.Matrix.ArgumentMatrixDimensionsException("vector"); }
			if (Matrix.IsZero(vector)) { throw new Eggceptions.Math.Matrix.ZeroMatrixException("vector"); }

			return Matrix.Multiply(vector, 1 / Vector.Magnitude(vector));
		}
	}
}
