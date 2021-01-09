namespace Eggceptions.Bethesda
{
	public class DetachedCellException : BethesdaException
	{
		public DetachedCellException() { }

		public DetachedCellException(System.String message)
			: base(message) { }

		public DetachedCellException(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}
