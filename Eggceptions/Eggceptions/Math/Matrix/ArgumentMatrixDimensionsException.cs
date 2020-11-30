namespace Eggceptions.Math.Matrix
{
	public class ArgumentMatrixDimensionsException : MatrixException
	{
		public ArgumentMatrixDimensionsException() { }

		public ArgumentMatrixDimensionsException(System.String message)
			: base(message) { }

		public ArgumentMatrixDimensionsException(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}
