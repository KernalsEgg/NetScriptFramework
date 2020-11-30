namespace Eggceptions
{
	public class ArgumentFormatException : Eggception
	{
		public ArgumentFormatException() { }

		public ArgumentFormatException(System.String message)
			: base(message) { }

		public ArgumentFormatException(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}
