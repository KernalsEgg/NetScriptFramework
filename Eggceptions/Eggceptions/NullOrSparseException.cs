namespace Eggceptions
{
	public class NullOrSparseException : Eggception
	{
		public NullOrSparseException() { }

		public NullOrSparseException(System.String message)
			: base(message) { }

		public NullOrSparseException(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}
