namespace Eggceptions
{
	public class ArgumentNullException : Eggception
	{
		public ArgumentNullException() { }

		public ArgumentNullException(System.String message)
			: base(message) { }

		public ArgumentNullException(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}
