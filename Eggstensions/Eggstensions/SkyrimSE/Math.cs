namespace Eggstensions.SkyrimSE
{
	static public class Math
	{
		static Math()
		{
			Delta =									NetScriptFramework.Memory.ReadFloat(VIDS.Math.Delta);
			Half =									NetScriptFramework.Memory.ReadFloat(VIDS.Math.Half);
			HalfPercent =							NetScriptFramework.Memory.ReadFloat(VIDS.Math.HalfPercent);
			HalfPercentNegative =					NetScriptFramework.Memory.ReadFloat(VIDS.Math.HalfPercentNegative);
			NinetyDegreesToRadians =				NetScriptFramework.Memory.ReadFloat(VIDS.Math.NinetyDegreesToRadians);
			NinetyDegreesToRadiansNegative =		NetScriptFramework.Memory.ReadFloat(VIDS.Math.NinetyDegreesToRadiansNegative);
			NinetyDegreesToRadiansInverseNegative =	NetScriptFramework.Memory.ReadFloat(VIDS.Math.NinetyDegreesToRadiansInverseNegative);
			One =									NetScriptFramework.Memory.ReadFloat(VIDS.Math.One);
			OneNegative =							NetScriptFramework.Memory.ReadFloat(VIDS.Math.OneNegative);
			OneQuarter =							NetScriptFramework.Memory.ReadFloat(VIDS.Math.OneQuarter);
			ThreeQuarters =							NetScriptFramework.Memory.ReadFloat(VIDS.Math.ThreeQuarters);
		}



		static public System.Single Delta { get; }

		static public System.Single Half { get; }

		static public System.Single HalfPercent { get; }

		static public System.Single HalfPercentNegative { get; }

		static public System.Single NinetyDegreesToRadians { get; }

		static public System.Single NinetyDegreesToRadiansNegative { get; }

		static public System.Single NinetyDegreesToRadiansInverseNegative { get; }

		static public System.Single One { get; }

		static public System.Single OneNegative { get; }

		static public System.Single OneQuarter { get; }

		static public System.Single ThreeQuarters { get; }
	}
}
