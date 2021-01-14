namespace Eggceptions.SkyrimSE
{
	public class ArgumentFormNotFoundException : SkyrimSEException
	{
		public ArgumentFormNotFoundException() { }

		public ArgumentFormNotFoundException(System.String message)
			: base(message) { }

		public ArgumentFormNotFoundException(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}
