namespace Eggceptions.Bethesda
{
	public class FormTypeException : BethesdaException
	{
		public FormTypeException() { }

		public FormTypeException(System.String message)
			: base(message) { }

		public FormTypeException(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}
