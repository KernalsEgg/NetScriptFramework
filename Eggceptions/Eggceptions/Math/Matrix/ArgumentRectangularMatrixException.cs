namespace Eggceptions.Math.Matrix
{
	public class ArgumentRectangularMatrixException : MatrixException
	{
		public ArgumentRectangularMatrixException() { }

		public ArgumentRectangularMatrixException(System.String message)
			: base(message) { }

		public ArgumentRectangularMatrixException(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}
