namespace ShelterFramework
{
	class Settings
	{
		[NetScriptFramework.Tools.ConfigValue("LogHandledExceptions", "Log Handled Exceptions", "Log handled exceptions to Data\\NetScriptFramework\\NetScriptFramework.log.txt.", NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment)]
		public System.Boolean LogHandledExceptions { get; set; } = false;

		[NetScriptFramework.Tools.ConfigValue("ShowHandledExceptions", "Show Handled Exceptions", "Show an in-game message box each time an exception is handled.", NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment)]
		public System.Boolean ShowHandledExceptions { get; set; } = false;



		internal void Load()
		{
			NetScriptFramework.Tools.ConfigFile.LoadFrom<Settings>(this, "ShelterFramework", true);
		}
	}
}
