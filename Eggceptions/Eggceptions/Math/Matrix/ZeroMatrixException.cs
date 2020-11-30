namespace Eggceptions.Math.Matrix
{
	public class ZeroMatrixException : MatrixException
	{
		public ZeroMatrixException() { }

		public ZeroMatrixException(System.String message)
			: base(message) { }

		public ZeroMatrixException(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}
