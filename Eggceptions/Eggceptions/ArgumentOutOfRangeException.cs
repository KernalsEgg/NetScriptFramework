namespace Eggceptions
{
	public class ArgumentOutOfRangeException : Eggception
	{
		public ArgumentOutOfRangeException() { }

		public ArgumentOutOfRangeException(System.String message)
			: base(message) { }

		public ArgumentOutOfRangeException(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}
