namespace Eggceptions.Bethesda
{
	public class BethesdaException : Eggception
	{
		public BethesdaException() { }

		public BethesdaException(System.String message)
			: base(message) { }

		public BethesdaException(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}
