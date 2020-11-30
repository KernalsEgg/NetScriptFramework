namespace Eggceptions.Bethesda
{
	public class RunTimeTypeInformationException : BethesdaException
	{
		public RunTimeTypeInformationException() { }

		public RunTimeTypeInformationException(System.String message)
			: base(message) { }

		public RunTimeTypeInformationException(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}
