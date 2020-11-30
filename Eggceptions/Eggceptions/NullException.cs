namespace Eggceptions
{
	public class NullException : Eggception
	{
		public NullException() { }

		public NullException(System.String message)
			: base(message) { }

		public NullException(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}
