namespace Eggceptions.SkyrimSE
{
	public class FormTypeException : SkyrimSEException
	{
		public FormTypeException() { }

		public FormTypeException(System.String message)
			: base(message) { }

		public FormTypeException(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}
