namespace Eggceptions.SkyrimSE
{
	public class ArgumentDetachedCellException : SkyrimSEException
	{
		public ArgumentDetachedCellException() { }

		public ArgumentDetachedCellException(System.String message)
			: base(message) { }

		public ArgumentDetachedCellException(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}
