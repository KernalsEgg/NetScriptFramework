namespace Eggceptions.Math.Matrix
{
	public class ArgumentTransformationMatrixException : MatrixException
	{
		public ArgumentTransformationMatrixException() { }

		public ArgumentTransformationMatrixException(System.String message)
			: base(message) { }

		public ArgumentTransformationMatrixException(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}
