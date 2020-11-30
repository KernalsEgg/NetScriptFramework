namespace Eggceptions
{
	public class ArgumentNullOrEmptyException : Eggception
	{
		public ArgumentNullOrEmptyException() { }

		public ArgumentNullOrEmptyException(System.String message)
			: base(message) { }

		public ArgumentNullOrEmptyException(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}
