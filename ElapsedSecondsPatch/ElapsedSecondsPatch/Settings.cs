namespace ElapsedSecondsPatch
{
	public class Settings
	{
		[NetScriptFramework.Tools.ConfigValue("AlwaysIncreaseAccuracy", "Always Increase Accuracy", "Always use increased accuracy when getting the elapsed duration of active effects at the (likely unnoticeable) expense of performance.", NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment)]
		public System.Boolean AlwaysIncreaseAccuracy { get; private set; } = false;



		internal void Load()
		{
			NetScriptFramework.Tools.ConfigFile.LoadFrom<Settings>(this, "ElapsedSecondsPatch", true);
		}
	}
}
