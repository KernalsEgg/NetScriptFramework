namespace Eggceptions.Bethesda
{
	public class ArgumentFormNotFoundException : BethesdaException
	{
		public ArgumentFormNotFoundException() { }

		public ArgumentFormNotFoundException(System.String message)
			: base(message) { }

		public ArgumentFormNotFoundException(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}
