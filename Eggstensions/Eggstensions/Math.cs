namespace Eggstensions
{
	static public class Math
	{
		static public System.IntPtr Ceiling(System.IntPtr value, System.UInt32 multiple)
		{
			if (multiple == 0)
			{
				return value;
			}

			var remainder = value.ToInt64() % multiple;

			if (remainder == 0)
			{
				return value;
			}
			else
			{
				return new System.IntPtr(value.ToInt64() + multiple - remainder);
			}
		}

		static public System.IntPtr Floor(System.IntPtr value, System.UInt32 multiple)
		{
			if (multiple == 0)
			{
				return value;
			}

			var remainder = value.ToInt64() % multiple;

			if (remainder == 0)
			{
				return value;
			}
			else
			{
				return new System.IntPtr(value.ToInt64() - remainder);
			}
		}
	}
}
