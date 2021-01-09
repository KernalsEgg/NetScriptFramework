namespace Eggstensions.Bethesda
{
	static public class Math
	{
		static public System.Single Delta
		{
			get
			{
				return NetScriptFramework.Memory.ReadFloat(VIDS.Math.Delta);
			}
		}

		static public System.Single Half
		{
			get
			{
				return NetScriptFramework.Memory.ReadFloat(VIDS.Math.Half);
			}
		}

		static public System.Single HalfPercent
		{
			get
			{
				return NetScriptFramework.Memory.ReadFloat(VIDS.Math.HalfPercent);
			}
		}

		static public System.Single HalfPercentNegative
		{
			get
			{
				return NetScriptFramework.Memory.ReadFloat(VIDS.Math.HalfPercentNegative);
			}
		}

		static public System.Single One
		{
			get
			{
				return NetScriptFramework.Memory.ReadFloat(VIDS.Math.One);
			}
		}

		static public System.Single OneNegative
		{
			get
			{
				return NetScriptFramework.Memory.ReadFloat(VIDS.Math.OneNegative);
			}
		}

		static public System.Single OneQuarter
		{
			get
			{
				return NetScriptFramework.Memory.ReadFloat(VIDS.Math.OneQuarter);
			}
		}

		static public System.Single ThreeQuarters
		{
			get
			{
				return NetScriptFramework.Memory.ReadFloat(VIDS.Math.ThreeQuarters);
			}
		}
	}
}
