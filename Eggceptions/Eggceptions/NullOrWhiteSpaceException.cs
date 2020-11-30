namespace Eggceptions
{
	public class NullOrWhiteSpaceException : Eggception
	{
		public NullOrWhiteSpaceException() { }

		public NullOrWhiteSpaceException(System.String message)
			: base(message) { }

		public NullOrWhiteSpaceException(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}
