namespace Eggceptions
{
	public class ArgumentNullOrSparseException : Eggception
	{
		public ArgumentNullOrSparseException() { }

		public ArgumentNullOrSparseException(System.String message)
			: base(message) { }

		public ArgumentNullOrSparseException(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}
