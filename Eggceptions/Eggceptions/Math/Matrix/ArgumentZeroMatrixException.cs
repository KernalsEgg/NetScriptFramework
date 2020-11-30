namespace Eggceptions.Math.Matrix
{
	public class ArgumentZeroMatrixException : MatrixException
	{
		public ArgumentZeroMatrixException() { }

		public ArgumentZeroMatrixException(System.String message)
			: base(message) { }

		public ArgumentZeroMatrixException(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}
