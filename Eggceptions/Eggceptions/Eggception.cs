namespace Eggceptions
{
	public class Eggception : System.Exception
	{
		public Eggception() { }

		public Eggception(System.String message)
			: base(message) { }

		public Eggception(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}
