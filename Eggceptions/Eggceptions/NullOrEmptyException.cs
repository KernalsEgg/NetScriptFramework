namespace Eggceptions
{
	public class NullOrEmptyException : Eggception
	{
		public NullOrEmptyException() { }

		public NullOrEmptyException(System.String message)
			: base(message) { }

		public NullOrEmptyException(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}
