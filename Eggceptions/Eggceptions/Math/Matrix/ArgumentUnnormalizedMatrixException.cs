namespace Eggceptions.Math.Matrix
{
	public class ArgumentUnnormalizedMatrixException : MatrixException
	{
		public ArgumentUnnormalizedMatrixException() { }

		public ArgumentUnnormalizedMatrixException(System.String message)
			: base(message) { }

		public ArgumentUnnormalizedMatrixException(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}
