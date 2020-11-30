namespace Eggceptions.Math.Matrix
{
	public class MatrixDimensionsException : MatrixException
	{
		public MatrixDimensionsException() { }

		public MatrixDimensionsException(System.String message)
			: base(message) { }

		public MatrixDimensionsException(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}
