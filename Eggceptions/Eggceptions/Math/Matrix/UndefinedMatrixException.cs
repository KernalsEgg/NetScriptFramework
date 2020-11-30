namespace Eggceptions.Math.Matrix
{
	public class UndefinedMatrixException : MatrixException
	{
		public UndefinedMatrixException() { }

		public UndefinedMatrixException(System.String message)
			: base(message) { }

		public UndefinedMatrixException(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}
