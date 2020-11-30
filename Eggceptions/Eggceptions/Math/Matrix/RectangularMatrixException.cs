namespace Eggceptions.Math.Matrix
{
	public class RectangularMatrixException : MatrixException
	{
		public RectangularMatrixException() { }

		public RectangularMatrixException(System.String message)
			: base(message) { }

		public RectangularMatrixException(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}
