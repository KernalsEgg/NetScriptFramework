namespace Eggceptions.Math.Matrix
{
	public class MatrixException : MathException
	{
		public MatrixException() { }

		public MatrixException(System.String message)
			: base(message) { }

		public MatrixException(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}
