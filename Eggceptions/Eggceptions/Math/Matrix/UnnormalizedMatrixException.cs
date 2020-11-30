namespace Eggceptions.Math.Matrix
{
	public class UnnormalizedMatrixException : MatrixException
	{
		public UnnormalizedMatrixException() { }

		public UnnormalizedMatrixException(System.String message)
			: base(message) { }

		public UnnormalizedMatrixException(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}
