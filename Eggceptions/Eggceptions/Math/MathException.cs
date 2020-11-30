namespace Eggceptions.Math
{
	public class MathException : Eggception
	{
		public MathException() { }

		public MathException(System.String message)
			: base(message) { }

		public MathException(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}
