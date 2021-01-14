namespace Eggceptions.SkyrimSE
{
	public class RunTimeTypeInformationException : SkyrimSEException
	{
		public RunTimeTypeInformationException() { }

		public RunTimeTypeInformationException(System.String message)
			: base(message) { }

		public RunTimeTypeInformationException(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}
