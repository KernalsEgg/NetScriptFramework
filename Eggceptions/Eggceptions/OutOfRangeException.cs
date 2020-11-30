namespace Eggceptions
{
	public class OutOfRangeException : Eggception
	{
		public OutOfRangeException() { }

		public OutOfRangeException(System.String message)
			: base(message) { }

		public OutOfRangeException(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}
