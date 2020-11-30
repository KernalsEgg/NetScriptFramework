namespace Eggceptions
{
	public class ArgumentNullOrWhiteSpaceException : Eggception
	{
		public ArgumentNullOrWhiteSpaceException() { }

		public ArgumentNullOrWhiteSpaceException(System.String message)
			: base(message) { }

		public ArgumentNullOrWhiteSpaceException(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}
