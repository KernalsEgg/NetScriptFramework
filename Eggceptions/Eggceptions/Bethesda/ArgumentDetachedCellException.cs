namespace Eggceptions.Bethesda
{
	public class ArgumentDetachedCellException : BethesdaException
	{
		public ArgumentDetachedCellException() { }

		public ArgumentDetachedCellException(System.String message)
			: base(message) { }

		public ArgumentDetachedCellException(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}
