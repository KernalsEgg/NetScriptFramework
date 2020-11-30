namespace Eggceptions.Math.Matrix
{
	public class ArgumentSingularMatrixException : MatrixException
	{
		public ArgumentSingularMatrixException() { }

		public ArgumentSingularMatrixException(System.String message)
			: base(message) { }

		public ArgumentSingularMatrixException(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}
