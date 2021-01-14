namespace Eggceptions.SkyrimSE
{
	public class SkyrimSEException : Eggception
	{
		public SkyrimSEException() { }

		public SkyrimSEException(System.String message)
			: base(message) { }

		public SkyrimSEException(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}
