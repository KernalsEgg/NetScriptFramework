namespace ShelterFramework
{
	public class Settings
	{
		[NetScriptFramework.Tools.ConfigValue("LogHandledExceptions", "Log Handled Exceptions", "Log handled exceptions to Data\\NetScriptFramework\\NetScriptFramework.log.txt.", NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment)]
		public System.Boolean LogHandledExceptions { get; private set; } = false;

		[NetScriptFramework.Tools.ConfigValue("ShowHandledExceptions", "Show Handled Exceptions", "Show an in-game message box each time an exception is handled.", NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment)]
		public System.Boolean ShowHandledExceptions { get; private set; } = false;

		[NetScriptFramework.Tools.ConfigValue("RaycastDistance", "Raycast Distance", "The distance over which each raycast detects shelter.", NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment)]
		public System.Single RaycastDistance { get; private set; } = 4096.0f;



		internal void Load()
		{
			NetScriptFramework.Tools.ConfigFile.LoadFrom<Settings>(this, "ShelterFramework", true);
		}
	}
}
