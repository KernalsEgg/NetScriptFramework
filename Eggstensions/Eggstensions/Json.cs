namespace Eggstensions
{
	static public class Json
	{
		static public T DeserializeAnonymousType<T>(System.String json, T returnType, System.Text.Json.JsonSerializerOptions options = default)
		{
			return System.Text.Json.JsonSerializer.Deserialize<T>(json, options);
		}
	}
}
