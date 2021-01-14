﻿namespace Eggceptions.SkyrimSE
{
	public class ArgumentFormTypeException : SkyrimSEException
	{
		public ArgumentFormTypeException() { }

		public ArgumentFormTypeException(System.String message)
			: base(message) { }

		public ArgumentFormTypeException(System.String message, System.Exception innerException)
			: base(message, innerException) { }
	}
}