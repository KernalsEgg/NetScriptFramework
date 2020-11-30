namespace Eggceptions.Math.Matrix
{
	public class ArgumentUndefinedMatrixException : MatrixException
	{
		public ArgumentUndefinedMatrixException() { }

		public ArgumentUndefinedMatrixException(System.String message)
			: base(message) { }

		public ArgumentUndefinedMatrixException(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}
