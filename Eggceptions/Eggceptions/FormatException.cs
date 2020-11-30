namespace Eggceptions
{
	public class FormatException : Eggception
	{
		public FormatException() { }

		public FormatException(System.String message)
			: base(message) { }

		public FormatException(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}
