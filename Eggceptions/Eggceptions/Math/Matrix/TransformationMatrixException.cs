namespace Eggceptions.Math.Matrix
{
	public class TransformationMatrixException : MatrixException
	{
		public TransformationMatrixException() { }

		public TransformationMatrixException(System.String message)
			: base(message) { }

		public TransformationMatrixException(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}
