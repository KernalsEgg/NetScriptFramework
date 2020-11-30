namespace Eggceptions.Bethesda
{
	public class ArgumentRunTimeTypeInformationException : BethesdaException
	{
		public ArgumentRunTimeTypeInformationException() { }

		public ArgumentRunTimeTypeInformationException(System.String message)
			: base(message) { }

		public ArgumentRunTimeTypeInformationException(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}
