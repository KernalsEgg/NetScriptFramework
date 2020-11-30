namespace Eggceptions.Math.Matrix
{
	public class SingularMatrixException : MatrixException
	{
		public SingularMatrixException() { }

		public SingularMatrixException(System.String message)
			: base(message) { }

		public SingularMatrixException(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}
