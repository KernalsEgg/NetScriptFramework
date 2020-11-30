namespace Eggceptions.Bethesda
{
	public class FormNotFoundException : BethesdaException
	{
		public FormNotFoundException() { }

		public FormNotFoundException(System.String message)
			: base(message) { }

		public FormNotFoundException(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}
